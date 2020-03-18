using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using BasisPlatform;
using CMCS.Common;
using CMCS.DotNetBar.Utilities;

namespace CMCS.DataTester
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // BasisPlatform:应用程序初始化
            Basiser basiser = Basiser.GetInstance();
            basiser.Init(CommonAppConfig.GetInstance().AppIdentifier, PlatformType.Winform, IPAddress.Parse("127.0.0.1"), 0);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DotNetBarUtil.InitLocalization();

            Application.Run(new MDIParent1());
        }
    }
}
