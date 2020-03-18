using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Common.Entities;
using CMCS.Common.Entities.BaseInfo;
using CMCS.Common.Entities.Fuel;
using CMCS.Common.Entities.Inf;
using CMCS.Common.Enums;
using CMCS.Common.Utilities;
using CMCS.Forms.UserControls;
using CMCS.WeighCheck.DAO;
using CMCS.WeighCheck.SampleCheck.Enums;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Metro;

namespace CMCS.WeighCheck.SampleCheck.Frms
{
    public partial class FrmSampleCheck : MetroForm
    {
        public FrmSampleCheck()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体唯一标识符
        /// </summary>
        public static string UniqueKey = "FrmSampleCheck";

        #region Vars

        CodePrinter _CodePrinter = null;
        CommonDAO commonDAO = CommonDAO.GetInstance();
        CZYHandlerDAO czyHandlerDAO = CZYHandlerDAO.GetInstance();

        eFlowFlag currentFlowFlag = eFlowFlag.等待扫码;
        /// <summary>
        /// 当前流程标识
        /// </summary>
        public eFlowFlag CurrentFlowFlag
        {
            get { return currentFlowFlag; }
            set
            {
                currentFlowFlag = value;
                lblCurrentFlowFlag.Text = value.ToString();
            }
        }

        CmcsCMEquipment autoMaker;
        /// <summary>
        /// 全自动制样机
        /// </summary>
        public CmcsCMEquipment AutoMaker
        {
            get { return autoMaker; }
            set
            {
                autoMaker = value;

                lblAutoMakerName.Text = value != null ? value.EquipmentName : "未设置";
                btnSendMakePlan.Visible = (value != null);
                timer2.Enabled = (value != null);
            }
        }

        CmcsRCMake rCMake = null;
        /// <summary>
        /// 当前入厂煤制样记录
        /// </summary>
        public CmcsRCMake RCMake
        {
            get { return rCMake; }
            set
            {
                rCMake = value;

                btnSendMakePlan.Enabled = (value != null);
                btnPrintMakeCode.Enabled = (value != null);

                this.IsScanedRCSampleBarrelId.Clear();
            }
        }

        CmcsRCSampleBarrel rCSampleBarrel = null;
        /// <summary>
        /// 当前扫描的样桶信息
        /// </summary>
        public CmcsRCSampleBarrel RCSampleBarrel
        {
            get { return rCSampleBarrel; }
            set
            {
                rCSampleBarrel = value;
            }
        }
        /// <summary>
        /// 与当前扫描的样桶关联的其他样桶记录
        /// </summary>
        List<CmcsRCSampleBarrel> brotherRCSampleBarrels = new List<CmcsRCSampleBarrel>();

        List<string> isScanedRCSampleBarrelId = new List<string>();
        /// <summary>
        /// 已完成验证的采样桶Id
        /// </summary>
        public List<string> IsScanedRCSampleBarrelId
        {
            get { return isScanedRCSampleBarrelId; }
            set { isScanedRCSampleBarrelId = value; }
        }

        string resMessage = string.Empty;

        #endregion

        public void InitFrom()
        {
            this.IsUseWeight = Convert.ToBoolean(commonDAO.GetAppletConfigInt32("启用称重"));

            this._CodePrinter = new CodePrinter(printDocument1);

            // 获取全自动制样机
            this.AutoMaker = commonDAO.GetCMEquipmentByMachineCode(commonDAO.GetAppletConfigString("全自动制样机编码"));
        }

        private void FrmSampleCheck_Load(object sender, EventArgs e)
        {
            //初始化
            InitFrom();
            //初始化设备
            InitHardware();
        }

        private void FrmSampleCheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnloadHardware();
        }

        #region 电子秤

        double currentWeight = 0;
        /// <summary>
        /// 电子秤当前重量
        /// </summary>
        public double CurrentWeight
        {
            get { return currentWeight; }
            set { currentWeight = value; }
        }

        /// <summary>
        /// 电子秤
        /// </summary>
        WB.TOLEDO.IND231.TOLEDO_IND231Wber wber = new WB.TOLEDO.IND231.TOLEDO_IND231Wber(3);

        bool isUseWeight = true;
        /// <summary>
        /// 启用电子秤
        /// </summary>
        public bool IsUseWeight
        {
            get { return isUseWeight; }
            set
            {
                isUseWeight = value;

                lblWber.Visible = value;
                slightWber.Visible = value;
            }
        }

        bool wbSteady = false;
        /// <summary>
        /// 电子秤稳定状态
        /// </summary>
        public bool WbSteady
        {
            get { return wbSteady; }
            set
            {
                wbSteady = value;
            }
        }

        double wbMinWeight = 0;
        /// <summary>
        /// 电子秤最小称重 单位：吨
        /// </summary>
        public double WbMinWeight
        {
            get { return wbMinWeight; }
            set
            {
                wbMinWeight = value;
            }
        }

        /// <summary>
        /// 重量稳定事件
        /// </summary>
        /// <param name="steady"></param>
        void Wber_OnSteadyChange(bool steady)
        {
            // 仪表稳定状态 
            InvokeEx(() =>
            {
                this.WbSteady = steady;
            });
        }

        /// <summary>
        /// 电子秤状态变化
        /// </summary>
        /// <param name="status"></param>
        void Wber_OnStatusChange(bool status)
        {
            // 接收设备状态 
            InvokeEx(() =>
            {
                slightWber.LightColor = (status ? Color.Green : Color.Red);
            });
        }

        #endregion

        #region 设备初始化与卸载

        /// <summary>
        /// 初始化外接设备
        /// </summary>
        private void InitHardware()
        {
            try
            {
                bool success = false;

                // 初始化-电子秤
                if (IsUseWeight)
                {
                    this.WbMinWeight = commonDAO.GetAppletConfigDouble("电子秤最小重量");

                    // 电子秤
                    wber.OnStatusChange += new WB.TOLEDO.IND231.TOLEDO_IND231Wber.StatusChangeHandler(Wber_OnStatusChange);
                    wber.OnSteadyChange += new WB.TOLEDO.IND231.TOLEDO_IND231Wber.SteadyChangeEventHandler(Wber_OnSteadyChange);
                    success = wber.OpenCom(commonDAO.GetAppletConfigInt32("电子秤串口"), commonDAO.GetAppletConfigInt32("电子秤波特率"), commonDAO.GetAppletConfigInt32("电子秤数据位"), commonDAO.GetAppletConfigInt32("电子秤停止位"));
                }

                timer1.Enabled = true;
            }
            catch (Exception ex)
            {
                Log4Neter.Error("设备初始化", ex);
            }
        }

        /// <summary>
        /// 卸载设备
        /// </summary>
        private void UnloadHardware()
        {
            // 注意此段代码
            Application.DoEvents();

            try
            {
                wber.CloseCom();
            }
            catch { }
        }
        #endregion

        #region 业务

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            try
            {
                switch (this.CurrentFlowFlag)
                {
                    case eFlowFlag.等待扫码:

                        break;
                    case eFlowFlag.重量校验:
                        #region

                        if (wber.Status && wber.Weight > this.WbMinWeight && WbSteady)
                        {
                            this.CurrentWeight = this.wber.Weight;
                            this.CurrentFlowFlag = eFlowFlag.等待校验;
                        }

                        #endregion
                        break;
                    case eFlowFlag.等待校验:
                        #region

                        if (czyHandlerDAO.UpdateRCSampleBarrelCheckSampleWeight(this.rCSampleBarrel.Id, wber.Weight))
                        {
                            ShowMessage("校验成功，重量：" + wber.Weight.ToString() + "KG", eOutputType.Normal);

                            // 所有桶扫描完后进入下一流程 
                            if (this.IsScanedRCSampleBarrelId.Count == this.brotherRCSampleBarrels.Count)
                            {
                                ShowMessage("该环节样桶已全部校验完毕!", eOutputType.Normal);
                                txtInputSampleCode.ResetText();

                                this.RCMake = czyHandlerDAO.GetRCMakeBySampleId(this.brotherRCSampleBarrels[0].SamplingId);
                                if (this.RCMake != null)
                                {
                                    this.CurrentFlowFlag = eFlowFlag.发送制样命令;
                                    SendMakePlanAndStart();
                                }
                                else
                                {
                                    ShowMessage("未找到制样单", eOutputType.Error);
                                }
                            }
                            else
                            {
                                txtInputSampleCode.ResetText();
                                this.CurrentFlowFlag = eFlowFlag.等待扫码;
                            }
                        }
                        else
                        {
                            ShowMessage("校验失败或者已校验，请联系管理员", eOutputType.Error);
                            this.CurrentFlowFlag = eFlowFlag.等待校验;
                        }

                        #endregion
                        break;
                    case eFlowFlag.发送制样命令:

                        break;
                    case eFlowFlag.等待制样结果:

                        break;
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Timer1运行异常" + ex.Message, eOutputType.Error);
            }

            timer1.Start();
        }

        /// <summary>
        /// 重置
        /// </summary>
        private void Restet()
        {
            this.CurrentFlowFlag = eFlowFlag.等待扫码;
            this.RCMake = null;
            this.RCSampleBarrel = null;
            this.brotherRCSampleBarrels.Clear();
            this.CurrentWeight = 0;

            btnSendMakePlan.Enabled = false;
            btnPrintMakeCode.Enabled = false;
            txtInputSampleCode.ResetText();
            rtxtOutputInfo.ResetText();

            // 方便客户快速使用，获取焦点
            txtInputSampleCode.Focus();

            ShowButton(0, "Clear");
        }

        /// <summary>
        /// 发送制样计划和制样命令给制样机
        /// </summary>
        private void SendMakePlanAndStart()
        {
            if (this.brotherRCSampleBarrels.Count == 0)
            {
                ShowMessage("请先完成采样桶校验", eOutputType.Error);
                return;
            }

            if (this.RCMake == null)
            {
                ShowMessage("未找到制样单记录", eOutputType.Error);
                return;
            }
            if (this.AutoMaker == null)
            {
                ShowMessage("未找到制样机设备", eOutputType.Error);
                return;
            }

            if (commonDAO.GetSignalDataValue(this.AutoMaker.EquipmentCode, eSignalDataName.系统.ToString()) != eEquInfSamplerSystemStatus.就绪待机.ToString())
            {
                MessageBoxEx.Show("制样机未就绪，禁止发送制样命令!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBoxEx.Show("准备启动制样机，请确定煤样已全部倒入制样机料斗!", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                // 需调整：根据接口规定写入煤种、水分等参数
                InfMakerPlan makerPlan = new InfMakerPlan()
                {
                    InterfaceType = commonDAO.GetMachineInterfaceTypeByCode(this.AutoMaker.EquipmentCode),
                    MachineCode = this.AutoMaker.EquipmentCode,
                    InFactoryBatchId = this.brotherRCSampleBarrels[0].InFactoryBatchId,
                    MakeCode = this.RCMake.MakeCode,
                    FuelKindName = "褐煤",
                    Mt = "湿煤",
                    MakeType = "在线制样",
                    CoalSize = "小粒度"
                };

                if (AutoMakerDAO.GetInstance().SaveMakerPlanAndStartCmd(makerPlan, out resMessage))
                {
                    this.CurrentFlowFlag = eFlowFlag.等待制样结果;
                    ShowMessage(resMessage, eOutputType.Normal);
                }
                else
                    ShowMessage(resMessage, eOutputType.Error);
            }
        }

        #endregion

        #region 操作

        /// <summary>
        /// 键入Enter检测有效性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInputSampleCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.CurrentFlowFlag != eFlowFlag.等待扫码) return;

                string barrelCode = txtInputSampleCode.Text.Trim();
                if (String.IsNullOrWhiteSpace(barrelCode)) return;

                //  根据采样桶编码查找该采样单下所有采样桶记录
                if (this.brotherRCSampleBarrels.Count == 0)
                {
                    this.brotherRCSampleBarrels = czyHandlerDAO.GetRCSampleBarrels(barrelCode, out resMessage);
                    if (this.brotherRCSampleBarrels.Count == 0)
                    {
                        ShowMessage(resMessage, eOutputType.Error);
                        txtInputSampleCode.ResetText();
                        return;
                    }
                    ShowMessage(resMessage, eOutputType.Normal);
                    ShowButton(this.brotherRCSampleBarrels.Count, "Sum");
                }

                // 采样桶编码属于同一采样单下则验证通过，直到全部验证完毕
                this.rCSampleBarrel = this.brotherRCSampleBarrels.Where(a => a.BarrelCode == barrelCode).FirstOrDefault();
                if (this.rCSampleBarrel != null)
                {
                    if (!this.IsScanedRCSampleBarrelId.Contains(this.rCSampleBarrel.Id))
                    {
                        this.IsScanedRCSampleBarrelId.Add(this.rCSampleBarrel.Id);
                        ShowButton(this.IsScanedRCSampleBarrelId.Count, "Already");

                        if (this.IsScanedRCSampleBarrelId.Count < this.brotherRCSampleBarrels.Count)
                            ShowMessage("样桶编码：" + barrelCode + "，还剩" + (this.brotherRCSampleBarrels.Count - this.IsScanedRCSampleBarrelId.Count) + "桶未校验，请扫下个样桶", eOutputType.Normal);
                        else
                            ShowMessage("样桶编码：" + barrelCode + "，该批次样桶已全部校验成功", eOutputType.Normal);

                        this.CurrentFlowFlag = eFlowFlag.等待校验;
                    }
                    else
                    {
                        txtInputSampleCode.ResetText();
                        ShowMessage("样桶编码：" + barrelCode + " 已校验，请扫下个样桶", eOutputType.Error);
                    }
                }
                else
                {
                    txtInputSampleCode.ResetText();
                    ShowMessage("样桶编码：" + barrelCode + " 校验失败，请扫下个样桶", eOutputType.Error);
                }
            }
        }

        /// <summary>
        /// 制样前样桶称重校验-发送制样计划和命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendMakePlan_Click(object sender, EventArgs e)
        {
            SendMakePlanAndStart();
        }

        /// <summary>
        /// 打印制样码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintMakeCode_Click(object sender, EventArgs e)
        {
            if (this.RCMake != null) this._CodePrinter.Print(this.RCMake.MakeCode);
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            Restet();
        }

        #endregion

        #region 信号

        /// <summary>
        /// 更新设备状态
        /// </summary>
        private void RefreshSignalStatus()
        {
            string systemStatus = commonDAO.GetSignalDataValue(this.AutoMaker.EquipmentCode, eSignalDataName.系统.ToString());
            if (systemStatus == eEquInfAutoMakerSystemStatus.就绪待机.ToString())
                slightAutoMaker.LightColor = EquipmentStatusColors.BeReady;
            else if (systemStatus == eEquInfAutoMakerSystemStatus.正在运行.ToString())
                slightAutoMaker.LightColor = EquipmentStatusColors.Working;
            else if (systemStatus == eEquInfAutoMakerSystemStatus.发生故障.ToString())
                slightAutoMaker.LightColor = EquipmentStatusColors.Breakdown;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            RefreshSignalStatus();
        }

        #endregion

        #region 其他

        private void ClearBarrelCode()
        {
            txtInputSampleCode.ResetText();
            this.RCSampleBarrel = null;
            this.brotherRCSampleBarrels.Clear();
            this.RCMake = null;
            this.CurrentFlowFlag = eFlowFlag.等待扫码;
        }

        private void ShowMessage(string info, eOutputType outputType)
        {
            OutputRunInfo(rtxtOutputInfo, info, outputType);
        }

        /// <summary>
        /// 输出运行信息
        /// </summary>
        /// <param name="richTextBox"></param>
        /// <param name="text"></param>
        /// <param name="outputType"></param>
        private void OutputRunInfo(RichTextBoxEx richTextBox, string text, eOutputType outputType = eOutputType.Normal)
        {
            this.Invoke((EventHandler)(delegate
            {
                if (richTextBox.TextLength > 100000) richTextBox.Clear();

                text = string.Format("{0}  {1}", DateTime.Now.ToString("HH:mm:ss"), text);

                richTextBox.SelectionStart = richTextBox.TextLength;

                switch (outputType)
                {
                    case eOutputType.Normal:
                        richTextBox.SelectionColor = ColorTranslator.FromHtml("#BD86FA");
                        break;
                    case eOutputType.Important:
                        richTextBox.SelectionColor = ColorTranslator.FromHtml("#A50081");
                        break;
                    case eOutputType.Warn:
                        richTextBox.SelectionColor = ColorTranslator.FromHtml("#F9C916");
                        break;
                    case eOutputType.Error:
                        richTextBox.SelectionColor = ColorTranslator.FromHtml("#DB2606");
                        break;
                    default:
                        richTextBox.SelectionColor = Color.White;
                        break;
                }

                richTextBox.AppendText(string.Format("{0}\r", text));

                richTextBox.ScrollToCaret();

            }));
        }

        /// <summary>
        /// 输出信息类型
        /// </summary>
        public enum eOutputType
        {
            /// <summary>
            /// 普通
            /// </summary>
            [Description("#BD86FA")]
            Normal,
            /// <summary>
            /// 重要
            /// </summary>
            [Description("#A50081")]
            Important,
            /// <summary>
            /// 警告
            /// </summary>
            [Description("#F9C916")]
            Warn,
            /// <summary>
            /// 错误
            /// </summary>
            [Description("#DB2606")]
            Error
        }

        /// <summary>
        /// 设置按钮显示状态
        /// </summary>
        /// <param name="count"></param>
        /// <param name="type"></param> 
        private void ShowButton(int count, string type)
        {
            if (type == "Sum")
            {
                foreach (Control control in panSampleBarrels.Controls)
                {
                    if (control.Tag == null) continue;
                    if (control.Tag.ToString() == "Btn")
                    {
                        for (int i = 1; i <= count; i++)
                        {
                            if (control.Text == i.ToString())
                                control.BackColor = Color.FromArgb(0, 157, 218);
                        }
                    }
                }
            }
            else if (type == "Already")
            {
                foreach (Control control in panSampleBarrels.Controls)
                {
                    if (control.Tag == null) continue;
                    if (control.Tag.ToString() == "Btn")
                    {
                        for (int i = 1; i <= count; i++)
                        {
                            if (control.Text == i.ToString())
                                control.BackColor = Color.Red;
                        }
                    }
                }
            }
            else if (type == "Clear")
            {
                foreach (Control control in panSampleBarrels.Controls)
                {
                    if (control.Tag == null) continue;
                    if (control.Tag.ToString() == "Btn")
                        control.BackColor = System.Drawing.Color.DarkGray;
                }
            }
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

        #endregion
    }
}
