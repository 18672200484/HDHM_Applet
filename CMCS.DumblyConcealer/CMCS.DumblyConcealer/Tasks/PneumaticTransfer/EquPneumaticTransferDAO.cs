using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.DumblyConcealer.Tasks.PneumaticTransfer.Entities;
using CMCS.DumblyConcealer.Tasks.PneumaticTransfer.Enums;
using CMCS.DumblyConcealer.Enums;
using CMCS.Common.DAO;
using CMCS.Common;

namespace CMCS.DumblyConcealer.Tasks.PneumaticTransfer
{
    public class EquPneumaticTransferDAO
    {
        private static EquPneumaticTransferDAO instance;
        private static String MachineCode = GlobalVars.MachineCode_QD;

        public static EquPneumaticTransferDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new EquPneumaticTransferDAO();
            }
            return instance;
        }

        private EquPneumaticTransferDAO()
        { }


        /// <summary>
        /// 是否处于空闲状态
        /// </summary>
        public bool CheckFree()
        {
            bool returnCheckFree = true;
            if (returnCheckFree)
            {
                if (DcDbers.GetInstance().PneumaticTransfer_Dber.Entities<EquQDBill>(" where DataStatus=0 or DataStatus=3").Count != 0)
                {
                    returnCheckFree = false;
                }
            }
            if (returnCheckFree)
            {
                List<EquQDStatus> infqdstatuses = DcDbers.GetInstance().PneumaticTransfer_Dber.Entities<EquQDStatus>("");
                if (infqdstatuses.Count != 0)
                {
                    if (infqdstatuses[0].SamReady != 3)
                    {
                        returnCheckFree = false;
                    }
                }
                else
                {
                    returnCheckFree = false;
                }
            }
            return returnCheckFree;
        }

        /// <summary>
        /// 默认为智能存样柜取到
        /// </summary>
        /// <param name="opstart"></param>
        /// <param name="opend"></param>
        /// <returns></returns>
        bool SendSample(eOp opstart = eOp.自动存查样管理系统, eOp opend = eOp.化验室)
        {
            EquQDBill infqdbill = new EquQDBill();
            infqdbill.OpStart = (int)opstart;
            infqdbill.OpEnd = (int)opend;
            infqdbill.Operator_Code = 501;
            infqdbill.Send_Time = DateTime.Now;
            infqdbill.DataStatus = 0;
            infqdbill.readState = 1;
            if (DcDbers.GetInstance().PneumaticTransfer_Dber.Insert(infqdbill) > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 判断气动传输无人操作并取样
        /// </summary>
        /// <param name="opstart"></param>
        /// <param name="opend"></param>
        /// <returns></returns>
        public bool CheckFreeSendSample(eOp opstart = eOp.自动存查样管理系统, eOp opend = eOp.化验室)
        {
            if (CheckFree())
            {
                return SendSample(opstart, opend);
            }
            return false;
        }


        /// <summary>
        /// 转换成第三方接口-操作票类型
        /// </summary>
        /// <param name="sampleType">操作票类型</param>
        /// <returns></returns>
        public eOp ConvertToInfeOp(string mType)
        {
            eOp enumResulr;
            if (Enum.TryParse(mType, out enumResulr))
                return enumResulr;
            else
                return eOp.自动存查样管理系统;
        }
        /// <summary>
        /// 同步制样 故障信息到集中管控
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        public void SyncCYGError(Action<string, eOutputType> output)
        {
            int res = 0;

            foreach (EquQDError entity in DcDbers.GetInstance().PneumaticTransfer_Dber.Entities<EquQDError>("where DataStatus=0"))
            {
                if (CommonDAO.GetInstance().SaveEquInfHitch(MachineCode, entity.ErrorTime, entity.ErrorDec))
                {
                    entity.DataStatus = 1;
                    DcDbers.GetInstance().PneumaticTransfer_Dber.Insert(entity);

                    res++;
                }
            }

            output(string.Format("气动传输-同步故障信息记录 {0} 条", res), eOutputType.Normal);
        }
    }
}
