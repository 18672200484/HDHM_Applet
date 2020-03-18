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
using CMCS.Common.Views;
using CMCS.DapperDber.Dbs.OracleDb;
using CMCS.DapperDber.Util;

namespace CMCS.Common.DAO
{
    /// <summary>
    /// 皮带采样机业务
    /// </summary>
    public class BeltSamplerDAO
    {
        private static BeltSamplerDAO instance;

        public static BeltSamplerDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new BeltSamplerDAO();
            }

            return instance;
        }

        private BeltSamplerDAO()
        { }

        public OracleDapperDber SelfDber
        {
            get { return Dbers.GetInstance().SelfDber; }
        }

        /// <summary>
        /// 获取皮带采样机系统状态
        /// </summary>
        /// <param name="machineCode">设备编码</param>
        /// <returns></returns>
        public string GetBeltSamplerSystemStatue(string machineCode)
        {
            return CommonDAO.GetInstance().GetSignalDataValue(machineCode, eSignalDataName.系统.ToString());
        }

        /// <summary>
        /// 发送控制命令
        /// </summary>
        /// <param name="machineCode">设备编码</param>
        /// <param name="sampleCmd">控制命令</param>
        /// <param name="sampleCode">采样码</param> 
        /// <param name="cmdId">记录Id</param> 
        /// <returns></returns>
        public bool SendSampleCmd(string machineCode, eEquInfSamplerCmd sampleCmd, string sampleCode, out string cmdId)
        {
            cmdId = Guid.NewGuid().ToString();

            return Dbers.GetInstance().SelfDber.Insert<InfBeltSampleCmd>(new InfBeltSampleCmd
            {
                Id = cmdId,
                DataFlag = 0,
                InterfaceType = CommonDAO.GetInstance().GetMachineInterfaceTypeByCode(machineCode),
                MachineCode = machineCode,
                ResultCode = eEquInfCmdResultCode.默认.ToString(),
                SampleCode = sampleCode,
                CmdCode = sampleCmd.ToString(),
                SyncFlag = 0
            }) > 0;
        }

        /// <summary>
        /// 获取控制命令的执行结果
        /// </summary>
        /// <param name="cmdId">控制命令记录Id</param>
        /// <returns></returns>
        public eEquInfCmdResultCode GetSampleCmdResult(string cmdId)
        {
            eEquInfCmdResultCode res;

            InfBeltSampleCmd beltSampleCmd = Dbers.GetInstance().SelfDber.Get<InfBeltSampleCmd>(cmdId);
            if (beltSampleCmd == null) throw new ArgumentException("未找到采样控制命令，cmdId:" + cmdId);

            Enum.TryParse<eEquInfCmdResultCode>(beltSampleCmd.ResultCode, out res);

            return res;
        }

        /// <summary>
        /// 判断是否可以发送卸样命令
        /// </summary>
        /// <param name="machineCode">设备编码</param>
        /// <returns></returns>
        public bool CanSendSampleUnloadCmd(string machineCode, out string message)
        {
            message = string.Empty;

            if (GetBeltSamplerSystemStatue(machineCode) != eEquInfSamplerSystemStatus.就绪待机.ToString())
            {
                message = "采样机系统未就绪";
                return false;
            }

            if (Dbers.GetInstance().SelfDber.Count<InfBeltSampleUnloadCmd>("where MachineCode=:MachineCode and DataFlag=0", new { MachineCode = machineCode }) > 0)
            {
                message = "存在未处理的卸样任务";
                return false;
            }

            if (Dbers.GetInstance().SelfDber.Count<InfBeltSampleUnloadCmd>("where MachineCode=:MachineCode and ResultCode='" + eEquInfCmdResultCode.默认 + "'", new { MachineCode = machineCode }) > 0)
            {
                message = "存在未执行的卸样任务";
                return false;
            }

            return string.IsNullOrEmpty(message);
        }

        /// <summary>
        /// 发送卸样命令
        /// </summary> 
        /// <param name="machineCode">设备编码</param>
        /// <param name="sampleCode">采样码</param>
        /// <param name="sampleUnloadType">卸样方式</param>
        /// <returns></returns>
        public bool SendSampleUnloadCmd(string machineCode, string sampleCode, eEquInfSamplerUnloadType sampleUnloadType)
        {
            InfBeltSampleUnloadCmd SampleUnloadCmd = new InfBeltSampleUnloadCmd
            {
                DataFlag = 0,
                InterfaceType = CommonDAO.GetInstance().GetMachineInterfaceTypeByCode(machineCode),
                MachineCode = machineCode,
                ResultCode = eEquInfCmdResultCode.默认.ToString(),
                SampleCode = sampleCode,
                UnloadType = sampleUnloadType.ToString(),
                SyncFlag = 0
            };
            return Dbers.GetInstance().SelfDber.Insert<InfBeltSampleUnloadCmd>(SampleUnloadCmd) > 0;
        }

        /// <summary>
        /// 发送卸样命令
        /// </summary> 
        /// <param name="machineCode">设备编码</param>
        /// <param name="samplingId">采样单Id</param>
        /// <param name="sampleCode">采样码</param>
        /// <param name="sampleUnloadType">卸样方式</param>
        /// <param name="sampleUnloadCmdId">返回命令Id</param>
        /// <returns></returns>
        public bool SendSampleUnloadCmd(string machineCode, string samplingId, string sampleCode, eEquInfSamplerUnloadType sampleUnloadType, out string sampleUnloadCmdId)
        {
            InfBeltSampleUnloadCmd sampleUnloadCmd = new InfBeltSampleUnloadCmd
            {
                Id = Guid.NewGuid().ToString(),
                DataFlag = 0,
                InterfaceType = CommonDAO.GetInstance().GetMachineInterfaceTypeByCode(machineCode),
                MachineCode = machineCode,
                ResultCode = eEquInfCmdResultCode.默认.ToString(),
                SampleCode = sampleCode,
                UnloadType = sampleUnloadType.ToString(),
                SyncFlag = 0,
                SamplingId = samplingId
            };

            sampleUnloadCmdId = sampleUnloadCmd.Id;

            return Dbers.GetInstance().SelfDber.Insert<InfBeltSampleUnloadCmd>(sampleUnloadCmd) > 0;
        }

        /// <summary>
        /// 获取最后一次卸样命令
        /// </summary>
        /// <param name="machineCode">设备编码</param>
        /// <returns></returns>
        public InfBeltSampleUnloadCmd GetLastSampleUnloadCmd(string machineCode)
        {
            return Dbers.GetInstance().SelfDber.Entity<InfBeltSampleUnloadCmd>("where MachineCode=:MachineCode order by CreationTime desc", new { MachineCode = machineCode });
        }

        /// <summary>
        /// 保存采样罐与车号的关联信息
        /// </summary>
        /// <param name="TransportIds"></param>
        /// <param name="SampleBarrelId"></param>
        public void SaveSampling_B_T(string TransportIds, string SampleBarrelId)
        {
            if (!string.IsNullOrEmpty(TransportIds))
            {
                foreach (string item in TransportIds.Split(new char[] { '|' }).Where(a => a != ""))
                {
                    CmcsRCSampling_B_T cmcsrcsampling_b_t = new CmcsRCSampling_B_T();
                    cmcsrcsampling_b_t.SampleBarrelId = SampleBarrelId;
                    cmcsrcsampling_b_t.TransportId = item;
                    Dbers.GetInstance().SelfDber.Insert<CmcsRCSampling_B_T>(cmcsrcsampling_b_t);
                }
            }
        }

        /// <summary>
        /// 获取待同步到第三方接口的采样计划
        /// </summary>
        /// <param name="interfaceType">接口类型</param>
        /// <returns></returns>
        public List<InfBeltSamplePlan> GetWaitForSyncBeltSamplePlan(string interfaceType)
        {
            return Dbers.GetInstance().SelfDber.Entities<InfBeltSamplePlan>("where InterfaceType=:InterfaceType and SyncFlag=0", new { InterfaceType = interfaceType });
        }

        /// <summary>
        /// 获取待同步到第三方接口的控制命令
        /// </summary>
        /// <param name="interfaceType">接口类型</param>
        /// <returns></returns>
        public List<InfBeltSampleCmd> GetWaitForSyncBeltSampleCmd(string interfaceType)
        {
            return Dbers.GetInstance().SelfDber.Entities<InfBeltSampleCmd>("where InterfaceType=:InterfaceType and SyncFlag=0", new { InterfaceType = interfaceType });
        }

        /// <summary>
        /// 获取待同步到第三方接口的卸样命令
        /// </summary>
        /// <param name="interfaceType">接口类型</param>
        /// <returns></returns>
        public List<InfBeltSampleUnloadCmd> GetWaitForSyncBeltSampleUnloadCmd(string interfaceType)
        {
            return Dbers.GetInstance().SelfDber.Entities<InfBeltSampleUnloadCmd>("where InterfaceType=:InterfaceType and SyncFlag=0", new { InterfaceType = interfaceType });
        }
    }
}
