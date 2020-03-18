using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using BasisPlatform;
using CMCS.CarTransport.Weighter.Frms.Sys;
using CMCS.Common;
using CMCS.Common.Enums;
using CMCS.Common.Utilities;
using CMCS.DotNetBar.Utilities;

namespace CMCS.CarTransport.Weighter
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
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
            //basiser.Init(CommonAppConfig.GetInstance().AppIdentifier, PlatformType.Winform, IPAddress.Parse("127.0.0.1"), 0);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

            DotNetBarUtil.InitLocalization();

            try
            {
                CMCS.Common.DAO.CommonDAO.GetInstance().SetSignalDataValue(CommonAppConfig.GetInstance().AppIdentifier, eSignalDataName.系统.ToString(), "1");

                bool notRun;
                using (Mutex mutex = new Mutex(true, Application.ProductName, out notRun))
                {
                    if (notRun)
                        Application.Run(new FrmMainFrame());
                    else
                        MessageBox.Show("程序正在运行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("服务器连接异常，请联系管理员!" + ex.Message);
                return;
            }
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Log4Neter.Error("未捕获异常", e.Exception);
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            try
            {
                CMCS.Common.DAO.CommonDAO.GetInstance().SetSignalDataValue(CommonAppConfig.GetInstance().AppIdentifier, eSignalDataName.系统.ToString(), "0");
            }
            catch { }
        }
    }
}
