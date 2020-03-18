using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Common.Entities.Inf;
using CMCS.Monitor.Win.Core;
using CMCS.Monitor.Win.Frms;
using CMCS.Monitor.Win.Frms.Sys;
using CMCS.Monitor.Win.Html;
//
using Xilium.CefGlue;

namespace CMCS.Monitor.Win.CefGlue
{
    /// <summary>
    /// 汽车采样监控 CefV8Handler
    /// </summary>
    public class CarSamplerCefV8Handler : CefV8Handler
    {
        List<InfEquInfHitch> equInfHitchs = new List<InfEquInfHitch>();

        protected override bool Execute(string name, CefV8Value obj, CefV8Value[] arguments, out CefV8Value returnValue, out string exception)
        {
            exception = null;
            returnValue = null;
            string paramSampler = arguments[0].GetStringValue();

            switch (name)
            {
                // 急停
                case "Stop":
                    if (paramSampler == "#1")
                        MessageBox.Show("#1 Stop");
                    else if (paramSampler == "#2")
                        MessageBox.Show("#2 Stop");
                    break;
                // 车辆信息
                case "CarInfo":
                    if (paramSampler == "#1")
                        MessageBox.Show("#1 CarInfo");
                    else if (paramSampler == "#2")
                        MessageBox.Show("#2 CarInfo");
                    break;
                // 故障复位
                case "ErrorReset":
                    if (paramSampler == "#1")
                        MessageBox.Show("#1 ErrorReset");
                    else if (paramSampler == "#2")
                        MessageBox.Show("#2 ErrorReset");
                    break;
                // 采样历史记录
                case "SampleHistory":
                    if (paramSampler == "#1")
                        MessageBox.Show("#1 SampleHistory");
                    else if (paramSampler == "#2")
                        MessageBox.Show("#2 SampleHistory");
                    break;
                //获取异常信息
                case "GetHitchs":
                    //异常信息
                    string machineCode = string.Empty;
                    if (paramSampler == "#1")
                        machineCode = GlobalVars.MachineCode_QCJXCYJ_1;
                    else if (paramSampler == "#2")
                        machineCode = GlobalVars.MachineCode_QCJXCYJ_2;
                    equInfHitchs = CommonDAO.GetInstance().GetEquInfHitchsByTime(machineCode, DateTime.Now);
                    returnValue = CefV8Value.CreateString(Newtonsoft.Json.JsonConvert.SerializeObject(equInfHitchs.Select(a => new { MachineCode = a.MachineCode, HitchTime = a.HitchTime.ToString("yyyy-MM-dd HH:mm"), HitchDescribe = a.HitchDescribe })));
                    break;
                case "ChangeSelected":
                    CefProcessMessage cefMsg = CefProcessMessage.Create("CarSamplerChangeSelected");
                    cefMsg.Arguments.SetSize(0);
                    cefMsg.Arguments.SetString(0, paramSampler);
                    CefV8Context.GetCurrentContext().GetBrowser().SendProcessMessage(CefProcessId.Browser, cefMsg);
                    break;
                default:
                    returnValue = null;
                    break;
            }

            return true;
        }
    }
}
