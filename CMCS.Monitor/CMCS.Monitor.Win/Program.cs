using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
// 
using BasisPlatform;
using CMCS.Common;
using CMCS.Monitor.Win.CefGlue;
using System.Diagnostics;
using CMCS.Monitor.Win.Frms.Sys;
using CMCS.DotNetBar.Utilities;
using System.Threading;

namespace CMCS.Monitor.Win
{
    static class Program
    {
        /// <summary>
        /// 登录窗体
        /// </summary>
        public static FrmLogin frmLogin;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // 检测更新
            AU.Updater updater = new AU.Updater();
            if (updater.NeedUpdate())
            {
                Process.Start("AutoUpdater.exe");
                Environment.Exit(0);
            }

            // BasisPlatform:应用程序初始化
            //Basiser basiser = Basiser.GetInstance();
            //basiser.EnabledEbiaSupport = true;
            //basiser.InitBasisPlatform(CommonAppConfig.GetInstance().AppIdentifier, PlatformType.Winform);

            DotNetBarUtil.InitLocalization();

            using (CefAppImpl application = new CefAppImpl())
            {
                application.Run();
            }
        }
    }
}
