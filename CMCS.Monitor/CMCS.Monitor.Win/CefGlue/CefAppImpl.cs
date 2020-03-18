using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Windows.Forms;
using Xilium.CefGlue;
using System.Threading;
using CMCS.Monitor.Win.Frms.Sys;

namespace CMCS.Monitor.Win.CefGlue
{
    public class CefAppImpl : IDisposable
    {
        #region IDisposable

        ~CefAppImpl()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        #endregion

        protected bool MultiThreadedMessageLoop { get; private set; }

        public int Run()
        {
            try
            {
                return RunInternal(new string[] { });
            }
            catch (Exception ex)
            {
                PlatformMessageBox(ex.ToString());
                return 1;
            }
        }

        /// <summary>
        /// 加载 Cef
        /// </summary>
        /// <returns></returns>
        public int RunInternal(string[] args)
        {
            try
            {
                CefRuntime.Load();
            }
            catch (DllNotFoundException ex)
            {
                PlatformMessageBox(ex.Message);
                return 1;
            }
            catch (CefRuntimeException ex)
            {
                PlatformMessageBox(ex.Message);
                return 2;
            }
            catch (Exception ex)
            {
                PlatformMessageBox(ex.ToString());
                return 3;
            }

            CefSettings settings = new CefSettings();
            settings.MultiThreadedMessageLoop = MultiThreadedMessageLoop = CefRuntime.Platform == CefRuntimePlatform.Windows;
            //settings.MultiThreadedMessageLoop = false;
            settings.LogSeverity = CefLogSeverity.Error | CefLogSeverity.ErrorReport;
            settings.LogFile = "cef.log";
            settings.ResourcesDirPath = System.IO.Path.GetDirectoryName(new Uri(System.Reflection.Assembly.GetEntryAssembly().CodeBase).LocalPath);
            settings.RemoteDebuggingPort = 20480;
            settings.NoSandbox = true;
            settings.Locale = "zh-CN";
            settings.CommandLineArgsDisabled = false;

            CefMainArgs mainArgs = new CefMainArgs(args);
            MonitorCefApp app = new MonitorCefApp();
            CefMenuHandler cefMenuHandler = new CefMenuHandler();

            int exitCode = CefRuntime.ExecuteProcess(mainArgs, app, IntPtr.Zero);
            if (exitCode != -1) return exitCode;

            CefRuntime.Initialize(mainArgs, settings, app, IntPtr.Zero);

            PlatformInitialize();

            PlatformRunMessageLoop();

            CefRuntime.Shutdown();

            return 0;
        }

        /// <summary>
        /// 程序初始化
        /// </summary>
        protected void PlatformInitialize()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }

        protected void PlatformRunMessageLoop()
        {
            if (!MultiThreadedMessageLoop) Application.Idle += (s, e) => CefRuntime.DoMessageLoopWork();

            Program.frmLogin = new FrmLogin();

            Application.Run(Program.frmLogin);
        }

        /// <summary>
        /// 程序关闭
        /// </summary>
        protected void PlatformQuitMessageLoop()
        {
            Application.Exit();
        }

        /// <summary>
        /// 消息弹出提示
        /// </summary>
        /// <param name="message"></param>
        protected void PlatformMessageBox(string message)
        {
            MessageBox.Show(message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
