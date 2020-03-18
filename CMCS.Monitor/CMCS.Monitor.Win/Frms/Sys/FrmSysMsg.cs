using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
//
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.Metro.ColorTables;
using CMCS.Common.Enums;
using CMCS.Common.Entities.Sys;

namespace CMCS.Monitor.Win.Frm.Sys
{
    public partial class FrmSysMsg : MetroAppForm
    {
        #region 定义
        /// <summary>
        /// 消息Id
        /// </summary>
        public string MsgId { get; set; }

        /// <summary>
        /// 消息代码
        /// </summary>
        public string MsgCode { get; set; }

        /// <summary>
        /// 消息参数
        /// </summary>
        public string JsonStr { get; set; }

        /// <summary>
        /// 自动关闭
        /// </summary>
        public bool IsAutoClose { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string HtmlContent { get; set; }

        /// <summary>
        /// 消息窗口标题
        /// </summary>
        public string WindowTitle = "系统提示";

        /// <summary>
        /// 出现时间（ms）
        /// </summary>
        public int ShowTime = 2000;

        /// <summary>
        /// 停留时间（ms）
        /// </summary>
        public int StopTime = 2000;

        /// <summary>
        /// 显示模式(默认右下角)
        /// </summary>
        public eMsgWarnType ShowMode = eMsgWarnType.右下角;

        /// <summary>
        /// time计数值
        /// </summary>
        int TimeCount = 1;

        ButtonX btn1 = null;
        ButtonX btn2 = null;
        ButtonX btn3 = null;
        ButtonX btn4 = null;

        #endregion

        #region 初始化

        public event MsgHandler OnMsgHandler;
        /// <summary>
        /// 消息处理事件
        /// </summary>
        /// <param name="msgId">消息Id，如果不是从数据库中提取的则为空</param>
        /// <param name="msgCode">消息代码</param>
        /// <param name="jsonStr">JSON参数</param>
        /// <param name="buttonText">按钮</param>
        /// <param name="frmMsg">消息窗体引用</param>
        public delegate void MsgHandler(string msgId, string msgCode, string jsonStr, string buttonText, Form frmMsg);

        /// <summary>
        /// 显示消息提示框
        /// </summary>
        /// <param name="htmlContent"></param>
        /// <param name="isAutoClose"></param>
        public FrmSysMsg(string htmlContent, bool isAutoClose)
        {
            InitializeComponent();

            this.HtmlContent = htmlContent;
            this.IsAutoClose = isAutoClose;
        }

        /// <summary>
        /// 显示消息提示框
        /// </summary>
        /// <param name="msgCode">消息代码</param>
        /// <param name="jsonStr">消息参数</param>
        /// <param name="htmlContent">消息内容</param>
        /// <param name="isAutoClose">是否自动关闭</param>
        public FrmSysMsg(string msgCode, string jsonStr, string htmlContent, bool isAutoClose)
        {
            InitializeComponent();

            this.MsgCode = msgCode;
            this.JsonStr = jsonStr;
            this.HtmlContent = htmlContent;
            this.IsAutoClose = isAutoClose;
        }

        /// <summary>
        /// 显示消息提示框
        /// </summary>
        /// <param name="msgCode">消息代码</param>
        /// <param name="jsonStr">消息参数</param>
        /// <param name="htmlContent">消息内容</param>
        /// <param name="isAutoClose">是否自动关闭</param>
        /// <param name="button1">按钮一</param>
        public FrmSysMsg(string msgCode, string jsonStr, string htmlContent, bool isAutoClose, string button1)
        {
            InitializeComponent();

            this.MsgCode = msgCode;
            this.JsonStr = jsonStr;
            this.HtmlContent = htmlContent;
            this.IsAutoClose = isAutoClose;

            btn1 = InitButtonX(button1);
        }

        /// <summary>
        /// 显示消息提示框
        /// </summary>
        /// <param name="msgCode">消息代码</param>
        /// <param name="jsonStr">消息参数</param>
        /// <param name="htmlContent">消息内容</param>
        /// <param name="isAutoClose">是否自动关闭</param>
        /// <param name="button1">按钮一</param>
        /// <param name="button2">按钮二</param>
        public FrmSysMsg(string msgCode, string jsonStr, string htmlContent, bool isAutoClose, string button1, string button2)
        {
            InitializeComponent();

            this.MsgCode = msgCode;
            this.JsonStr = jsonStr;
            this.HtmlContent = htmlContent;
            this.IsAutoClose = isAutoClose;

            btn1 = InitButtonX(button1);
            btn2 = InitButtonX(button2);
        }

        /// <summary>
        /// 显示消息提示框
        /// </summary>
        /// <param name="msgCode">消息代码</param>
        /// <param name="jsonStr">消息参数</param>
        /// <param name="htmlContent">消息内容</param>
        /// <param name="isAutoClose">是否自动关闭</param>
        /// <param name="button1">按钮一</param>
        /// <param name="button2">按钮二</param>
        /// <param name="button3">按钮三</param>
        public FrmSysMsg(string msgCode, string jsonStr, string htmlContent, bool isAutoClose, string button1, string button2, string button3)
        {
            InitializeComponent();

            this.MsgCode = msgCode;
            this.JsonStr = jsonStr;
            this.HtmlContent = htmlContent;
            this.IsAutoClose = isAutoClose;

            btn1 = InitButtonX(button1);
            btn2 = InitButtonX(button2);
            btn3 = InitButtonX(button3);
        }

        /// <summary>
        /// 显示消息提示框
        /// </summary>
        /// <param name="msgCode">消息代码</param>
        /// <param name="jsonStr">消息参数</param>
        /// <param name="htmlContent">消息内容</param>
        /// <param name="isAutoClose">是否自动关闭</param>
        /// <param name="button1">按钮一</param>
        /// <param name="button2">按钮二</param>
        /// <param name="button3">按钮三</param>
        /// <param name="button4">按钮四</param>
        public FrmSysMsg(string msgCode, string jsonStr, string htmlContent, bool isAutoClose, string button1, string button2, string button3, string button4)
        {
            InitializeComponent();

            this.MsgCode = msgCode;
            this.JsonStr = jsonStr;
            this.HtmlContent = htmlContent;
            this.IsAutoClose = isAutoClose;

            btn1 = InitButtonX(button1);
            btn2 = InitButtonX(button2);
            btn3 = InitButtonX(button3);
            btn4 = InitButtonX(button4);
        }

        /// <summary>
        /// 显示消息提示框
        /// </summary> 
        public FrmSysMsg(CmcsSysMessage sysMessage)
        {
            InitializeComponent();

            this.MsgId = sysMessage.Id;
            this.MsgCode = sysMessage.MsgCode;
            this.JsonStr = sysMessage.MsgParam;
            this.HtmlContent = sysMessage.MsgContent;
            this.IsAutoClose = Convert.ToBoolean(sysMessage.IsAutoClose);

            string[] buttons = sysMessage.MsgButton.Split(new char[] { '|' });
            for (int i = 0; i < buttons.Length; i++)
            {
                if (i == 0) btn1 = InitButtonX(buttons[i]);
                if (i == 1) btn1 = InitButtonX(buttons[i]);
                if (i == 2) btn1 = InitButtonX(buttons[i]);
                if (i == 3) btn1 = InitButtonX(buttons[i]);
            }

            this.StopTime = 10 * 1000;
            this.WindowTitle = string.IsNullOrEmpty(sysMessage.WindowsTitle) ? "提示" : sysMessage.WindowsTitle;
            if (sysMessage.MsgWarnType == (int)eMsgWarnType.右下角)
            {
                this.ShowMode = eMsgWarnType.右下角;
                this.Show();
            }
            else
            {
                this.ShowMode = eMsgWarnType.对话框;
                this.ShowDialog();
            }
        }

        #endregion

        #region 添加按钮及委托事件
        ButtonX InitButtonX(string btnText)
        {
            ButtonX btn = new ButtonX();

            btn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            btn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            btn.AutoSize = true;
            btn.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            btn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            btn.Text = btnText;
            btn.Click += new EventHandler(btn_Click);

            return btn;
        }

        void btn_Click(object sender, EventArgs e)
        {
            ButtonX btnX = sender as ButtonX;
            OnMsgHandler(this.MsgId, this.MsgCode, this.JsonStr, btnX.Text, this);
        }
        #endregion

        #region 右下角弹出窗体

        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

        //下面是可用的常量，根据不同的动画效果声明自己需要的
        private const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志该标志
        private const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；否则向外扩展
        private const int AW_HIDE = 0x10000;//隐藏窗口
        private const int AW_ACTIVE = 0x20000;//激活窗口，在使用了AW_HIDE标志后不要使用这个标志
        private const int AW_SLIDE = 0x40000;//使用滑动类型动画效果，默认为滚动动画类型，当使用AW_CENTER标志时，这个标志就被忽略
        private const int AW_BLEND = 0x80000;//使用淡入淡出效果

        private void Frm_SysMsg_Load(object sender, EventArgs e)
        {
            //启用自动关闭
            if (this.IsAutoClose)
                timer1.Enabled = true;
            this.Text = WindowTitle;

            //显示消息内容
            StringBuilder sbhtmlDocument = new StringBuilder();
            sbhtmlDocument.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\"><body style=\"overflow:auto; background-color:#434751 \">");
            sbhtmlDocument.Append(HtmlContent);
            sbhtmlDocument.Append("</body></html>");
            wbMessage.DocumentText = sbhtmlDocument.ToString();

            //添加操作按钮
            if (btn1 != null)
                flPanelButton.Controls.Add(btn1);
            if (btn2 != null)
                flPanelButton.Controls.Add(btn2);
            if (btn3 != null)
                flPanelButton.Controls.Add(btn3);
            if (btn4 != null)
                flPanelButton.Controls.Add(btn4);
            if (btn1 == null && btn2 == null && btn3 == null && btn4 == null)
            {
                flPanelButton.Visible = false;
                this.tlPanelMain.SetRowSpan(this.plnMain, 2);
            }

            //启动窗体
            StartWindows();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //关闭窗体
            CloseWindows();
        }

        void StartWindows()
        {
            if (this.ShowMode == eMsgWarnType.右下角)
            {
                int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
                int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
                this.Location = new Point(x, y);//设置窗体在屏幕右下角显示
                AnimateWindow(this.Handle, 1000, AW_ACTIVE | AW_SLIDE | AW_VER_NEGATIVE);
            }
        }

        void CloseWindows()
        {
            if (this.ShowMode == eMsgWarnType.右下角)
                AnimateWindow(this.Handle, 1000, AW_BLEND | AW_HIDE);
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.ShowMode == eMsgWarnType.右下角)
            {
                if (IsAutoClose)
                {
                    if (StopTime - 1000 * TimeCount <= 0)
                        this.Close();
                    TimeCount++;
                }
            }
        }
    }
}
