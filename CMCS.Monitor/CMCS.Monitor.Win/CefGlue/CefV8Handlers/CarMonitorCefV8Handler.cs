using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using Xilium.CefGlue;
using System.Windows.Forms;
using CMCS.Monitor.Win.Frms;
using CMCS.Monitor.Win.Frms.Sys;
using CMCS.Monitor.Win.Core;
using CMCS.Common.DAO;
using CMCS.Common;

namespace CMCS.Monitor.Win.CefGlue
{
    /// <summary>
    /// 汽车监控 CefV8Handler
    /// </summary>
    public class CarMonitorCefV8Handler : CefV8Handler
    {
        CommonDAO commonDao = CommonDAO.GetInstance();
        protected override bool Execute(string name, CefV8Value obj, CefV8Value[] arguments, out CefV8Value returnValue, out string exception)
        {
            exception = null;
            returnValue = null;
            string paramSampler = arguments[0].GetStringValue();

            switch (paramSampler)
            {
                #region 入厂
                case "Infactory_Up1":
                    SendControlCmd(GlobalVars.MachineCode_QC_Queue_1, "Gate1Up");
                    break;
                case "Infactory_Down1":
                    SendControlCmd(GlobalVars.MachineCode_QC_Queue_1, "Gate1Down");
                    break;
                case "Infactory_Up2":
                    SendControlCmd(GlobalVars.MachineCode_QC_Queue_1, "Gate2Up");
                    break;
                case "Infactory_Down2":
                    SendControlCmd(GlobalVars.MachineCode_QC_Queue_1, "Gate2Down");
                    break;
                #endregion

                #region 采样
                case "Sample1_Up1":
                    SendControlCmd(GlobalVars.MachineCode_QC_JxSampler_1, "Gate1Up");
                    break;
                case "Sample1_Down1":
                    SendControlCmd(GlobalVars.MachineCode_QC_JxSampler_1, "Gate1Down");
                    break;
                case "Sample1_Up2":
                    SendControlCmd(GlobalVars.MachineCode_QC_JxSampler_1, "Gate2Up");
                    break;
                case "Sample1_Down2":
                    SendControlCmd(GlobalVars.MachineCode_QC_JxSampler_1, "Gate2Down");
                    break;
                case "Sample2_Up1":
                    SendControlCmd(GlobalVars.MachineCode_QC_JxSampler_2, "Gate1Up");
                    break;
                case "Sample2_Down1":
                    SendControlCmd(GlobalVars.MachineCode_QC_JxSampler_2, "Gate1Down");
                    break;
                case "Sample2_Up2":
                    SendControlCmd(GlobalVars.MachineCode_QC_JxSampler_2, "Gate2Up");
                    break;
                case "Sample2_Down2":
                    SendControlCmd(GlobalVars.MachineCode_QC_JxSampler_2, "Gate2Down");
                    break;
                #endregion

                #region 汽车衡
                case "Weighter1_Up1":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_1, "Gate1Up");
                    break;
                case "Weighter1_Down1":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_1, "Gate1Down");
                    break;
                case "Weighter1_Up2":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_1, "Gate2Up");
                    break;
                case "Weighter1_Down2":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_1, "Gate2Down");
                    break;
                case "Weighter2_Up1":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_2, "Gate1Up");
                    break;
                case "Weighter2_Down1":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_2, "Gate1Down");
                    break;
                case "Weighter2_Up2":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_2, "Gate2Up");
                    break;
                case "Weighter2_Down2":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_2, "Gate2Down");
                    break;
                case "Weighter3_Up1":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_3, "Gate1Up");
                    break;
                case "Weighter3_Down1":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_3, "Gate1Down");
                    break;
                case "Weighter3_Up2":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_3, "Gate2Up");
                    break;
                case "Weighter3_Down2":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_3, "Gate2Down");
                    break;
                case "Weighter4_Up1":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_4, "Gate1Up");
                    break;
                case "Weighter4_Down1":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_4, "Gate1Down");
                    break;
                case "Weighter4_Up2":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_4, "Gate2Up");
                    break;
                case "Weighter4_Down2":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_4, "Gate2Down");
                    break;
                case "Weighter5_Up1":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_5, "Gate1Up");
                    break;
                case "Weighter5_Down1":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_5, "Gate1Down");
                    break;
                case "Weighter5_Up2":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_5, "Gate2Up");
                    break;
                case "Weighter5_Down2":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_5, "Gate2Down");
                    break;
                case "Weighter6_Up1":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_6, "Gate1Up");
                    break;
                case "Weighter6_Down1":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_6, "Gate1Down");
                    break;
                case "Weighter6_Up2":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_6, "Gate2Up");
                    break;
                case "Weighter6_Down2":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_6, "Gate2Down");
                    break;
                case "Weighter7_Up1":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_7, "Gate1Up");
                    break;
                case "Weighter7_Down1":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_7, "Gate1Down");
                    break;
                case "Weighter7_Up2":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_7, "Gate2Up");
                    break;
                case "Weighter7_Down2":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_7, "Gate2Down");
                    break;
                case "Weighter8_Up1":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_8, "Gate1Up");
                    break;
                case "Weighter8_Down1":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_8, "Gate1Down");
                    break;
                case "Weighter8_Up2":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_8, "Gate2Up");
                    break;
                case "Weighter8_Down2":
                    SendControlCmd(GlobalVars.MachineCode_QC_Weighter_8, "Gate2Down");
                    break;
                #endregion

                #region 出厂
                case "Outfactory_Up1":
                    SendControlCmd(GlobalVars.MachineCode_QC_Out_1, "Gate1Up");
                    break;
                case "Outfactory_Down1":
                    SendControlCmd(GlobalVars.MachineCode_QC_Out_1, "Gate1Down");
                    break;
                #endregion

                default:
                    returnValue = null;
                    break;
            }

            return true;
        }

        private void SendControlCmd(string appIdentifier, string param)
        {
            commonDao.SendAppRemoteControlCmd(appIdentifier, "控制道闸", param);
        }
    }
}
