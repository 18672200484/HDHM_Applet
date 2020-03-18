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

namespace CMCS.Monitor.Win.CefGlue
{
    /// <summary>
    /// CefTester CefV8Handler
    /// </summary>
    public class CefTesterCefV8Handler : CefV8Handler
    {
        protected override bool Execute(string name, CefV8Value obj, CefV8Value[] arguments, out CefV8Value returnValue, out string exception)
        {
            exception = null;
            returnValue = null;

            switch (name)
            {
                case "sendMessage":
                    string inputArg_Name = arguments[0].GetStringValue();
                    string inputArg_Value = arguments[1].GetStringValue();

                    if (inputArg_Name == "Send Message To Browser")
                    {
                        CefProcessMessage processMessage = CefProcessMessage.Create(inputArg_Name);
                        CefListValue listValue = processMessage.Arguments;
                        listValue.SetString(0, inputArg_Name);

                        CefV8Context.GetCurrentContext().GetBrowser().SendProcessMessage(CefProcessId.Browser, processMessage);
                    }

                    break;
                default:
                    returnValue = null;
                    break;
            }

            return true;
        }
    }
}
