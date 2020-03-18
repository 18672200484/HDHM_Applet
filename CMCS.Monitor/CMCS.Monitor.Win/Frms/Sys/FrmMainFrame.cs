using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Common.Entities.BaseInfo;
using CMCS.Common.Entities.Inf;
using CMCS.Common.Entities.Sys;
using CMCS.Common.Enums;
using CMCS.Forms.UserControls;
using CMCS.Monitor.Win.Core;
using CMCS.Monitor.Win.Frm.Sys;
using CMCS.Monitor.Win.Utilities;
//
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xilium.CefGlue;

namespace CMCS.Monitor.Win.Frms.Sys
{
    public partial class FrmMainFrame : MetroForm
    {
        CommonDAO commonDAO = CommonDAO.GetInstance();

        public static SuperTabControlManager superTabControlManager;

        public FrmMainFrame()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblVersion.Text = new AU.Updater().Version;

            FrmMainFrame.superTabControlManager = new SuperTabControlManager(this.superTabControl1);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (GlobalVars.LoginUser != null) lblLoginUserName.Text = GlobalVars.LoginUser.UserName;

            CommonDAO.GetInstance().ResetAllSysMessageStatus();

            // 打开集中管控首页
            btnOpenHomePage_Click(null, null);

            InitEquipmentStatus();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBoxEx.Show("确认退出系统？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Common.DAO.CommonDAO.GetInstance().SaveLoginLog(GlobalVars.LoginUser.UserName, Common.Enums.Sys.eUserLogInattempts.LockedOut);
                    CefRuntime.Shutdown();
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApplicationExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 显示当前时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_CurrentTime_Tick(object sender, EventArgs e)
        {
            lblCurrentTime.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
        }

        #region 打开/切换可视主界面

        #region 弹出窗体

        /// <summary>
        /// 打开集中管控首页
        /// </summary>
        public void OpenHomePage()
        {
            this.InvokeEx(() =>
            {
                string uniqueKey = FrmHomePage.UniqueKey;

                if (FrmMainFrame.superTabControlManager.GetTab(uniqueKey) == null)
                {
                    FrmHomePage Frm = new FrmHomePage();
                    FrmMainFrame.superTabControlManager.CreateTab(Frm.Text, uniqueKey, Frm, false);
                }
                else
                    FrmMainFrame.superTabControlManager.ChangeToTab(uniqueKey);
            });
        }

        /// <summary>
        /// 打开汽车过衡监控
        /// </summary>
        public void OpenTruckWeighter()
        {
            this.InvokeEx(() =>
            {
                string uniqueKey = FrmTruckWeighter.UniqueKey;

                if (FrmMainFrame.superTabControlManager.GetTab(uniqueKey) == null)
                {
                    SelfVars.TruckWeighterForm = new FrmTruckWeighter();
                    FrmMainFrame.superTabControlManager.CreateTab(SelfVars.TruckWeighterForm.Text, uniqueKey, SelfVars.TruckWeighterForm, false);
                }
                else
                    FrmMainFrame.superTabControlManager.ChangeToTab(uniqueKey);
            });
        }

        #endregion

        /// <summary>
        /// FrmCefTester
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCefTester_Click(object sender, EventArgs e)
        {
            //this.InvokeEx(() =>
            //{
            string uniqueKey = FrmCefTester.UniqueKey;

            if (FrmMainFrame.superTabControlManager.GetTab(uniqueKey) == null)
            {
                FrmCefTester Frm = new FrmCefTester();
                FrmMainFrame.superTabControlManager.CreateTab(Frm.Text, uniqueKey, Frm, false);
            }
            else
                FrmMainFrame.superTabControlManager.ChangeToTab(uniqueKey);
            //});
        }

        public void SetColorTable(string controlName)
        {
            if (string.IsNullOrEmpty(controlName)) return;
            foreach (Control item in panel_Buttons.Controls)
            {
                if (item.GetType().Name != "ButtonX" && item.GetType().Name != "ButtonItem")
                    continue;
                ButtonX button = (ButtonX)item;
                if (item.Name == controlName || (button.SubItems.Count > 0 && button.SubItems.Contains(controlName)))
                    button.ColorTable = eButtonColor.Magenta;
                else
                    button.ColorTable = eButtonColor.BlueWithBackground;
            }
        }

        /// <summary>
        /// 打开集中管控首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenHomePage_Click(object sender, EventArgs e)
        {
            ButtonX button = (ButtonX)sender;
            SetColorTable(button != null ? button.Name : "");

            OpenHomePage();
        }

        /// <summary>
        /// 打开汽车过衡监控
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenTruckWeighter_Click(object sender, EventArgs e)
        {
            ButtonItem button = (ButtonItem)sender;
            SetColorTable(button != null ? button.Name : "");

            OpenTruckWeighter();
        }

        #endregion

        #region 设备状态监控

        /// <summary>
        /// 初始化设备状态任务
        /// </summary>
        private void InitEquipmentStatus()
        {
            timer_EquipmentStatus.Enabled = true;

            List<CmcsCMEquipment> list = commonDAO.GetChildrenMachinesByCode("机械采样机");
            CreateEquipmentStatus(list);

            // 更新设备状态
            RefreshEquipmentStatus();
        }

        /// <summary>
        /// 创建设备状态控件
        /// </summary>
        /// <param name="list"></param>
        private void CreateEquipmentStatus(List<CmcsCMEquipment> list)
        {
            flpanEquipments.SuspendLayout();

            foreach (CmcsCMEquipment cMEquipment in list)
            {
                UCtrlSignalLight uCtrlSignalLight = new UCtrlSignalLight()
                {
                    Anchor = AnchorStyles.Left,
                    Width = 16,
                    Height = 16,
                    Tag = cMEquipment.EquipmentCode,
                    Padding = new System.Windows.Forms.Padding(10, 0, 0, 0)
                };
                SetSystemStatusToolTip(uCtrlSignalLight);

                flpanEquipments.Controls.Add(uCtrlSignalLight);

                LabelX lblMachineName = new LabelX()
                {
                    Text = cMEquipment.EquipmentName,
                    Tag = cMEquipment.EquipmentCode,
                    AutoSize = true,
                    Anchor = AnchorStyles.Left,
                    Font = new Font("Segoe UI", 10f, FontStyle.Regular)
                };

                flpanEquipments.Controls.Add(lblMachineName);
            }

            flpanEquipments.ResumeLayout();
        }

        /// <summary>
        /// 更新设备状态
        /// </summary>
        private void RefreshEquipmentStatus()
        {
            foreach (UCtrlSignalLight uCtrlSignalLight in flpanEquipments.Controls.OfType<UCtrlSignalLight>())
            {
                if (uCtrlSignalLight.Tag == null) continue;

                string machineCode = uCtrlSignalLight.Tag.ToString();
                if (string.IsNullOrEmpty(machineCode)) continue;

                string systemStatus = CommonDAO.GetInstance().GetSignalDataValue(machineCode, eSignalDataName.系统.ToString());
                if ("|就绪待机|".Contains("|" + systemStatus + "|"))
                    uCtrlSignalLight.LightColor = EquipmentStatusColors.BeReady;
                else if ("|正在运行|正在卸样|".Contains("|" + systemStatus + "|"))
                    uCtrlSignalLight.LightColor = EquipmentStatusColors.Working;
                else if ("|发生故障|".Contains("|" + systemStatus + "|"))
                    uCtrlSignalLight.LightColor = EquipmentStatusColors.Breakdown;
                else
                    uCtrlSignalLight.LightColor = EquipmentStatusColors.Forbidden;
            }
        }

        /// <summary>
        /// 设置ToolTip提示
        /// </summary>
        private void SetSystemStatusToolTip(Control control)
        {
            this.toolTip1.SetToolTip(control, "<绿色> 就绪待机\r\n<红色> 正在运行\r\n<黄色> 发生故障");
        }

        private void timer_EquipmentStatus_Tick(object sender, EventArgs e)
        {
            // 更新设备状态
            RefreshEquipmentStatus();
        }

        #endregion

        #region 显示消息框

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_MsgTime_Tick(object sender, EventArgs e)
        {
            timer_MsgTime.Stop();

            if (DateTime.Now.Second % 30 == 0)
                //30秒获取一次异常信息表
                ShowEquInfHitch();
            if (DateTime.Now.Second % 5 == 0)
                ShowSysMessage();

            timer_MsgTime.Start();
        }

        /// <summary>
        /// 显示设备异常消息框
        /// </summary>
        public void ShowEquInfHitch()
        {
            List<InfEquInfHitch> listResult = CommonDAO.GetInstance().GetWarnEquInfHitch();
            StringBuilder sbHitchDescribe = new StringBuilder();
            if (listResult.Count > 0)
            {
                foreach (InfEquInfHitch item in listResult)
                {
                    sbHitchDescribe.Append("<font color='red' size='2'>");
                    sbHitchDescribe.Append(item.HitchTime.ToString("HH:mm") + "   " + item.HitchDescribe + "<br>");
                    sbHitchDescribe.Append("</font>");
                    CommonDAO.GetInstance().UpdateReadEquInfHitch(item.Id);
                }
                //右下角显示
                FrmSysMsg frm_sysMsg = new FrmSysMsg(sbHitchDescribe.ToString(), false);
                frm_sysMsg.Show();
            }
        }

        /// <summary>
        /// 显示系统消息
        /// </summary>
        public void ShowSysMessage()
        {
            CmcsSysMessage entity = CommonDAO.GetInstance().GetTodayTopSysMessage();
            if (entity != null)
            {
                CommonDAO.GetInstance().ChangeSysMessageStatus(entity.Id, eSysMessageStatus.处理中);

                FrmSysMsg frmSysMsg = new FrmSysMsg(entity);
                frmSysMsg.OnMsgHandler += new FrmSysMsg.MsgHandler(frmSysMsg_OnMsgHandler);

            }
        }

        void frmSysMsg_OnMsgHandler(string msgId, string msgCode, string jsonStr, string buttonText, Form frmMsg)
        {
            switch (buttonText)
            {
                case "查看":

                    CommonDAO.GetInstance().ChangeSysMessageStatus(msgId, eSysMessageStatus.已处理);

                    switch (msgCode)
                    {
                        case "汽车桥式采样机":
                            break;
                    }

                    frmMsg.Close();
                    break;
                case "我知道了":
                    frmMsg.Close();
                    break;
                default:
                    frmMsg.Close();
                    break;
            }
        }
        #endregion

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
}
