using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//
using Xilium.CefGlue.WindowsForms;
using Xilium.CefGlue;
using CMCS.Monitor.DAO;
using CMCS.Common.Entities;
using DevComponents.DotNetBar.SuperGrid;
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Monitor.Win.CefGlue;
using CMCS.Monitor.Win.Html;
using DevComponents.DotNetBar.Metro;
using CMCS.Monitor.Win.Core;
using CMCS.Common.Entities.Inf;
using CMCS.Common.Enums;
using CMCS.Monitor.Win.UserControls;
using DevComponents.DotNetBar;

namespace CMCS.Monitor.Win.Frms
{
    public partial class FrmCefTester : MetroForm
    {
        /// <summary>
        /// 窗体唯一标识符
        /// </summary>
        public static string UniqueKey = "FrmCefTester";

        CefWebBrowserEx cefWebBrowser = new CefWebBrowserEx();

        public FrmCefTester()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体初始化
        /// </summary>
        private void FormInit()
        {
#if DEBUG
            gboxTest.Visible = true;
#else
            gboxTest.Visible = false;
#endif

            cefWebBrowser.StartUrl = SelfVars.Url_CefTester;
            cefWebBrowser.Dock = DockStyle.Fill;
            cefWebBrowser.WebClient = new CefTesteClient(cefWebBrowser);
            cefWebBrowser.LoadEnd += new EventHandler<LoadEndEventArgs>(cefWebBrowser_LoadEnd);

            panWebBrower.Controls.Add(cefWebBrowser);
        }

        void cefWebBrowser_LoadEnd(object sender, LoadEndEventArgs e)
        {

        }

        private void FrmTrainBeltSampler_Load(object sender, EventArgs e)
        {
            FormInit();
        }

        /// <summary>
        /// 测试 - 刷新页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 测试 - 数据刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRequestData_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Invoke封装
        /// </summary>
        /// <param name="action"></param>
        public void InvokeEx(Action action)
        {
            if (this.IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(action);
        }
    }

    public class CefTesteClient : CefWebClient
    {
        CefWebBrowser cefWebBrowser;

        public CefTesteClient(CefWebBrowser cefWebBrowser)
            : base(cefWebBrowser)
        {
            this.cefWebBrowser = cefWebBrowser;
        }

        protected override bool OnProcessMessageReceived(CefBrowser browser, CefProcessId sourceProcess, CefProcessMessage message)
        {
            if (message.Name == "Send Message To Browser")
            {
                this.cefWebBrowser.Invoke((Action)(() =>
                {
                    MessageBoxEx.Show("这是从HTML页面传递回来的消息!");
                }));
            }

            //return base.OnProcessMessageReceived(browser, sourceProcess, message);
            return true;
        }
    }
}
