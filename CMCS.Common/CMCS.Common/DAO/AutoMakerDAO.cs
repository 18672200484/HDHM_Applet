using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
//
using CMCS.Common.Entities;
using CMCS.Common.Entities.Fuel;
using CMCS.Common.Entities.Inf;
using CMCS.Common.Enums;
using CMCS.DapperDber.Util;

namespace CMCS.Common.DAO
{
    /// <summary>
    /// 全自动制样机业务
    /// </summary>
    public class AutoMakerDAO
    {
        private static AutoMakerDAO instance;

        public static AutoMakerDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new AutoMakerDAO();
            }

            return instance;
        }

        private AutoMakerDAO()
        { }

        /// <summary>
        /// 发送制样计划，并发送开始制样命令
        /// </summary>
        public bool SaveMakerPlanAndStartCmd(InfMakerPlan entity, out string message)
        {
            try
            {
                message = "制样计划发送成功";
                if (Dbers.GetInstance().SelfDber.Insert<InfMakerPlan>(entity) > 0)
                {
                    InfMakerControlCmd makerControlCmd = new InfMakerControlCmd();
                    makerControlCmd.InterfaceType = CommonDAO.GetInstance().GetMachineInterfaceTypeByCode(entity.MachineCode);
                    makerControlCmd.MachineCode = entity.MachineCode;
                    makerControlCmd.MakeCode = entity.MakeCode;
                    makerControlCmd.ResultCode = eEquInfCmdResultCode.默认.ToString();
                    makerControlCmd.CmdCode = eEquInfMakerCmd.开始制样.ToString();
                    makerControlCmd.SyncFlag = 0;
                    Dbers.GetInstance().SelfDber.Insert<InfMakerControlCmd>(makerControlCmd);

                    // 修改入厂煤制样记录的开始制样时间
                    //Dbers.GetInstance().SelfDber.Execute("update " + EntityReflectionUtil.GetTableName<CmcsRCMake>() + " set GetPle='自动接样',GetDate=:DtNow,MakeDate=:DtNow where MakeCode=:MakeCode", new { DtNow = DateTime.Now, MakeCode = entity.MakeCode });

                    return true;
                }
                message = "制样计划发送失败";
                return false;
            }
            catch (Exception ex)
            {
                message = "制样计划发送失败" + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 保存制样明细记录
        /// </summary>
        public bool SaveMakerRecord(InfMakerRecord entity)
        {
            return Dbers.GetInstance().SelfDber.Insert<InfMakerRecord>(entity) > 0 ? true : false;
        }

        /// <summary>
        /// 根据采样id获取制样记录
        /// </summary>
        /// <param name="sampleId"></param>
        /// <returns></returns>
        public CmcsRCMake GetRCMakeBySampleId(string sampleId)
        {
            CmcsRCMake rcmake = Dbers.GetInstance().SelfDber.Entity<CmcsRCMake>("where SamplingId=:SamplingId and IsDeleted=0", new { SamplingId = sampleId });
            return rcmake;
        }

        /// <summary>
        /// 历史制样记录分页查询
        /// </summary>
        /// <param name="PageSize">每页显示条数</param>
        /// <param name="CurrentIndex">当前页索引</param>
        /// <param name="sqlWhere">sql条件</param>
        /// <returns></returns>
        public List<InfMakerRecord> ExecutePager(int PageSize, int CurrentIndex, string sqlWhere)
        {
            return Dbers.GetInstance().SelfDber.ExecutePager<InfMakerRecord>(PageSize, CurrentIndex, sqlWhere + " order by CreationTime desc");
        }

        /// <summary>
        /// 历史制样记录总数
        /// </summary>
        /// <param name="sqlWhere">sql条件</param>
        /// <returns></returns>
        public int GetTotalCount(string sqlWhere)
        {
            return Dbers.GetInstance().SelfDber.Count<InfMakerRecord>(sqlWhere);
        }

        /// <summary>
        /// 获取待同步到第三方接口的制样计划
        /// </summary>
        /// <param name="machineCode">设备编码</param>
        /// <returns></returns>
        public List<InfMakerPlan> GetWaitForSyncMakePlan(string machineCode)
        {
            return Dbers.GetInstance().SelfDber.Entities<InfMakerPlan>("where MachineCode=:MachineCode and SyncFlag=0", new { MachineCode = machineCode });
        }

        /// <summary>
        /// 获取待同步到第三方接口的控制命令表
        /// </summary>
        /// <param name="machineCode">设备编码</param>
        /// <returns></returns>
        public List<InfMakerControlCmd> GetWaitForSyncMakerControlCmd(string machineCode)
        {
            return Dbers.GetInstance().SelfDber.Entities<InfMakerControlCmd>("where MachineCode=:MachineCode and SyncFlag=0", new { MachineCode = machineCode });
        }

        /// <summary>
        /// 获取制样出样明细
        /// </summary>
        /// <param name="makecode"></param>
        /// <returns></returns>
        public List<InfMakerRecord> GetMakerRecordByMakeCode(string makecode)
        {
            return Dbers.GetInstance().SelfDber.Entities<InfMakerRecord>("where makecode=:MakeCode order by EndTime desc", new { MakeCode = makecode });
        }

        /// <summary>
        /// 获取制样样品传输状态
        /// </summary>
        /// <param name="barrelcode">样瓶编码</param>
        /// <returns></returns>
        public string GetMakerRecordStatusByBarrelCode(string barrelcode)
        {
            InfCYGControlCMDDetail entity = Dbers.GetInstance().SelfDber.Entity<InfCYGControlCMDDetail>("where code=:BarrelCode order by CreationTime desc", new { BarrelCode = barrelcode });
            if (entity != null)
                if (entity.Status != null)
                    return entity.Status;
            return "";
        }

        /// <summary>
        /// 获取气动传输传输样品信息
        /// </summary>
        /// <param name="dTime"></param>
        /// <returns></returns>
        public List<InfCYGControlCMDDetail> GetCYGControlCMDDetailByTime(DateTime dTime)
        {
            return Dbers.GetInstance().SelfDber.Entities<InfCYGControlCMDDetail>("where CreationTime like '%" + dTime.ToString("yyyy-MM-dd") + "%' order by CreationTime desc");
        }

        #region 获取采样单
        /// <summary>
        /// 获取采样单信息
        /// </summary>
        /// <param name="dtStart">开始时间</param>
        /// <param name="dtEnd">结束时间</param>
        /// <returns></returns>
        public DataTable GetSampleInfo(DateTime dtStart, DateTime dtEnd)
        {
            string sql = @" select a.batch,a.id as batchid,
                                 b.name as suppliername,
                                 c.name as minename,
                                 d.fuelname as kindname,
                                 e.name as stationname,
                                 a.factarrivedate,
                                 t.id,
                                 t.samplecode,
                                 t.samplingdate,
                                 t.samplingtype
                            from cmcstbrcsampling t
                            left join cmcstbinfactorybatch a on t.infactorybatchid = a.id
                            left join fultbsupplier b on a.supplierid = b.id
                            left join fultbmine c on a.mineid = c.id
                            left join fultbfuelkind d on a.fuelkindid = d.id
                            left join fultbstationinfo e on a.stationid = e.id
                       where t.samplingdate >= '" + dtStart + "' and t.samplingdate < '" + dtEnd + "'";
            return Dbers.GetInstance().SelfDber.ExecuteDataTable(sql);
        }
        #endregion
    }
}
