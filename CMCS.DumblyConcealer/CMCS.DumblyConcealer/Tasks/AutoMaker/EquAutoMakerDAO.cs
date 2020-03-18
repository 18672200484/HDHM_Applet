using System;
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Common.Entities.Fuel;
using CMCS.Common.Entities.Inf;
using CMCS.Common.Enums;
using CMCS.DapperDber.Dbs.SqlServerDb;
using CMCS.DumblyConcealer.Enums;
using CMCS.DumblyConcealer.Tasks.AutoMaker.Entities;

namespace CMCS.DumblyConcealer.Tasks.AutoMaker
{
    /// <summary>
    /// 全自动制样机接口业务
    /// </summary>
    public class EquAutoMakerDAO
    {
        /// <summary>
        /// EquAutoMakerDAO
        /// </summary>
        /// <param name="machineCode">制样机编码</param>
        /// <param name="equDber">第三方数据库访问对象</param>
        public EquAutoMakerDAO(string machineCode, SqlServerDapperDber equDber)
        {
            this.MachineCode = machineCode;
            this.EquDber = equDber;
        }

        CommonDAO commonDAO = CommonDAO.GetInstance();

        /// <summary>
        /// 第三方数据库访问对象
        /// </summary>
        SqlServerDapperDber EquDber;
        /// <summary>
        /// 设备编码
        /// </summary>
        string MachineCode;
        /// <summary>
        /// 是否处于故障状态
        /// </summary>
        bool IsHitch = false;
        /// <summary>
        /// 上一次上位机心跳值
        /// </summary>
        string PrevHeartbeat = string.Empty;

        #region 数据转换方法（此处有点麻烦，后期调整接口方案）


        #endregion

        /// <summary>
        /// 同步实时信号到集中管控
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        public int SyncSignal(Action<string, eOutputType> output)
        {
            int res = 0;

            foreach (EquQZDZYJSignal entity in this.EquDber.Entities<EquQZDZYJSignal>())
            {
                if (entity.TagName == GlobalVars.EquHeartbeatName) continue;

                // 当心跳检测为故障时，则不更新系统状态，保持 eSampleSystemStatus.发生故障
                if (entity.TagName == eSignalDataName.系统.ToString() && IsHitch) continue;

                res += commonDAO.SetSignalDataValue(this.MachineCode, entity.TagName, entity.TagValue) ? 1 : 0;
            }
            output(string.Format("同步实时信号 {0} 条", res), eOutputType.Normal);

            return res;
        }

        /// <summary>
        /// 获取上位机运行状态表 - 心跳值
        /// 每隔30s读取该值，如果数值不变化则表示设备上位机出现故障
        /// </summary>
        /// <returns></returns>
        public void SyncHeartbeatSignal()
        {
            EquQZDZYJSignal pDCYSignal = this.EquDber.Entity<EquQZDZYJSignal>("where TagName=@TagName", new { TagName = GlobalVars.EquHeartbeatName });
            ChangeSystemHitchStatus((pDCYSignal != null && pDCYSignal.TagValue == this.PrevHeartbeat));
        }

        /// <summary>
        /// 改变系统状态值
        /// </summary>
        /// <param name="isHitch">是否故障</param>
        public void ChangeSystemHitchStatus(bool isHitch)
        {
            IsHitch = isHitch;

            if (IsHitch) CommonDAO.GetInstance().SetSignalDataValue(this.MachineCode, eSignalDataName.系统.ToString(), eEquInfSamplerSystemStatus.发生故障.ToString());
        }

        /// <summary>
        /// 同步制样计划
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        public void SyncPlan(Action<string, eOutputType> output)
        {
            int res = 0;

            // 集中管控 > 第三方 
            foreach (InfMakerPlan entity in AutoMakerDAO.GetInstance().GetWaitForSyncMakePlan(this.MachineCode))
            {
                bool isSuccess = false;
                // 需调整：计划中的煤种、水分、颗粒度等信息视接口而定
                EquQZDZYJPlan qZDZYJPlan = this.EquDber.Get<EquQZDZYJPlan>(entity.Id);
                if (qZDZYJPlan == null)
                {
                    isSuccess = this.EquDber.Insert(new EquQZDZYJPlan
                    {
                        // 保持相同的Id
                        Id = entity.Id,
                        InFactoryBatchId = entity.InFactoryBatchId,
                        MakeCode = entity.MakeCode,
                        FuelKindName = entity.FuelKindName,
                        //Mt = 0,
                        //CoalSize = 2, 
                        DataFlag = 0
                    }) > 0;
                }
                else
                {
                    qZDZYJPlan.Id = entity.Id;
                    qZDZYJPlan.MakeCode = entity.MakeCode;
                    qZDZYJPlan.FuelKindName = entity.FuelKindName;
                    //qZDZYJPlan.Mt = 0;
                    //qZDZYJPlan.CoalSize = 0; 
                    qZDZYJPlan.DataFlag = 0;
                    isSuccess = this.EquDber.Update(qZDZYJPlan) > 0;
                }

                if (isSuccess)
                {
                    entity.SyncFlag = 1;
                    commonDAO.SelfDber.Update(entity);

                    res++;
                }
            }
            output(string.Format("同步制样计划 {0} 条（集中管控 > 第三方）", res), eOutputType.Normal);
        }

        /// <summary>
        /// 皮带控制命令表
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        public void SyncCmd(Action<string, eOutputType> output)
        {
            int res = 0;

            // 集中管控 > 第三方 
            foreach (InfMakerControlCmd entity in AutoMakerDAO.GetInstance().GetWaitForSyncMakerControlCmd(this.MachineCode))
            {
                bool isSuccess = false;

                EquQZDZYJCmd qZDZYJCmd = this.EquDber.Get<EquQZDZYJCmd>(entity.Id);
                if (qZDZYJCmd == null)
                {
                    isSuccess = this.EquDber.Insert(new EquQZDZYJCmd
                    {
                        // 保持相同的Id
                        Id = entity.Id,
                        CmdCode = entity.CmdCode,
                        MakeCode = entity.MakeCode,
                        ResultCode = eEquInfCmdResultCode.默认.ToString(),
                        DataFlag = 0
                    }) > 0;
                }
                else isSuccess = true;

                if (isSuccess)
                {
                    entity.SyncFlag = 1;
                    commonDAO.SelfDber.Update(entity);

                    res++;
                }
            }
            output(string.Format("同步控制命令 {0} 条（集中管控 > 第三方）", res), eOutputType.Normal);

            res = 0;
            // 第三方 > 集中管控
            foreach (EquQZDZYJCmd entity in this.EquDber.Entities<EquQZDZYJCmd>("where DataFlag=2"))
            {
                InfMakerControlCmd makerControlCmd = commonDAO.SelfDber.Get<InfMakerControlCmd>(entity.Id);
                if (makerControlCmd == null) continue;

                // 更新执行结果等
                makerControlCmd.ResultCode = entity.ResultCode;
                makerControlCmd.DataFlag = 3;

                if (commonDAO.SelfDber.Update(makerControlCmd) > 0)
                {
                    // 我方已读
                    entity.DataFlag = 3;
                    this.EquDber.Update(entity);

                    res++;
                }
            }
            output(string.Format("同步控制命令 {0} 条（第三方 > 集中管控）", res), eOutputType.Normal);
        }

        /// <summary>
        /// 同步制样 出样明细信息到集中管控
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        public void SyncMakeDetail(Action<string, eOutputType> output)
        {
            int res = 0;

            foreach (EquQZDZYJDetail entity in this.EquDber.Entities<EquQZDZYJDetail>("where DataFlag=0 order by CreationTime asc"))
            {
                if (SyncToRCMakeDetail(entity))
                {
                    if (AutoMakerDAO.GetInstance().SaveMakerRecord(new InfMakerRecord
                    {
                        InterfaceType = CommonDAO.GetInstance().GetMachineInterfaceTypeByCode(this.MachineCode),
                        MachineCode = this.MachineCode,
                        MakeCode = entity.MakeCode,
                        BarrelCode = entity.BarrelCode,
                        YPType = entity.YPType,
                        YPWeight = entity.YPWeight,
                        StartTime = entity.StartTime,
                        EndTime = entity.EndTime,
                        MakeUser = entity.MakeUser,
                        DataFlag = 1
                    }))
                    {
                        entity.DataFlag = 1;
                        this.EquDber.Update(entity);
                        res++;

                        // 需调整：启动传输调度计划需根据现场情况而定
                        // 插入气动传输调度计划
                        //EquAutoCupboardDAO.GetInstance().AddNewSendSampleId(entity.BarrelCode, entity.YPType, eCmdCode.制样机1, eCmdCode.存样柜);
                    }
                }
            }

            output(string.Format("同步出样明细记录 {0} 条", res), eOutputType.Normal);
        }

        /// <summary>
        /// 同步制样 故障信息到集中管控
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        public void SyncError(Action<string, eOutputType> output)
        {
            int res = 0;

            foreach (EquQZDZYJError entity in this.EquDber.Entities<EquQZDZYJError>("where DataFlag=0"))
            {
                if (CommonDAO.GetInstance().SaveEquInfHitch(this.MachineCode, entity.ErrorTime, entity.ErrorDescribe))
                {
                    entity.DataFlag = 1;
                    this.EquDber.Update(entity);

                    res++;
                }
            }

            output(string.Format("同步故障信息记录 {0} 条", res), eOutputType.Normal);
        }

        /// <summary>
        /// 同步样品信息到集中管控入厂煤制样明细表
        /// </summary>
        /// <param name="makeDetail"></param>
        private bool SyncToRCMakeDetail(EquQZDZYJDetail makeDetail)
        {
            CmcsRCMake rCMake = commonDAO.SelfDber.Entity<CmcsRCMake>("where MakeCode=:MakeCode and IsDeleted=0", new { MakeCode = makeDetail.MakeCode });
            if (rCMake != null)
            {
                // 修改制样结束时间
                rCMake.MakeType = eMakeType.机械制样.ToString();

                rCMake.GetDate = DateTime.Now;
                rCMake.MakeDate = makeDetail.StartTime;

                commonDAO.SelfDber.Update(rCMake);

                CmcsRCMakeDetail rCMakeDetail = commonDAO.SelfDber.Entity<CmcsRCMakeDetail>("where MakeId=:MakeId and SampleType=:SampleType and IsDeleted=0", new { MakeId = rCMake.Id, SampleType = makeDetail.YPType });
                if (rCMakeDetail != null)
                {
                    rCMakeDetail.LastModificAtionTime = DateTime.Now;
                    rCMakeDetail.CreationTime = DateTime.Now;
                    rCMakeDetail.SampleWeight = makeDetail.YPWeight;
                    rCMakeDetail.SampleCode = makeDetail.BarrelCode;
                    return commonDAO.SelfDber.Update(rCMakeDetail) > 0;
                }
            }

            return false;
        }
    }
}
