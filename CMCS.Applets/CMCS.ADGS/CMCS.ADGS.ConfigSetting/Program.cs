using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace CMCS.ADGS.ConfigSetting
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool notRun;
            using (Mutex mutex = new Mutex(true, Application.ProductName, out notRun))
            {
                if (notRun)
                    Application.Run(new ConfigSetting());
                else
                    MessageBox.Show("程序正在运行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
