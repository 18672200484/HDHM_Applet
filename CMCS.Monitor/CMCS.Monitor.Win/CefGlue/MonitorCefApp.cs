using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using Xilium.CefGlue;
using Xilium.CefGlue.Demo;

namespace CMCS.Monitor.Win.CefGlue
{
    internal sealed class MonitorCefApp : CefApp
    {
        private CefRenderProcessHandler _renderProcessHandler = new MonitorRenderProcessHandler();

        protected override void OnBeforeCommandLineProcessing(string processType, CefCommandLine commandLine)
        {
            //CMCS.Common.Utilities.Log4Neter.Info(processType + "     " + commandLine.ToString()); 
        }

        protected override CefRenderProcessHandler GetRenderProcessHandler()
        {
            return _renderProcessHandler;
        }
    }
}
