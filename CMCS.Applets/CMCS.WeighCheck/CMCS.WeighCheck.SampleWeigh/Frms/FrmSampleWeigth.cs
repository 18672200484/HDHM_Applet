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
using CMCS.Common.Entities.Fuel;
using CMCS.Common.Enums;
using CMCS.Common.Utilities;
using CMCS.Forms.UserControls;
using CMCS.WeighCheck.DAO;
using CMCS.WeighCheck.SampleWeigh.Enums;
using CMCS.WeighCheck.SampleWeigh.Frms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.SuperGrid;

namespace CMCS.WeighCheck.SampleWeigh.Frms.SampleWeigth
{
    public partial class FrmSampleWeigth : MetroForm
    {
        public FrmSampleWeigth()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体唯一标识符
        /// </summary>
        public static string UniqueKey = "FrmSampleWeigth";

        #region Vars

        CommonDAO commonDAO = CommonDAO.GetInstance();
        CZYHandlerDAO cZYHandlerDAO = CZYHandlerDAO.GetInstance();

        eFlowFlag currentFlowFlag = eFlowFlag.选择采样单;
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

        string currentBarrelCode;
        /// <summary>
        /// 当前样桶编码
        /// </summary>
        public string CurrentBarrelCode
        {
            get { return currentBarrelCode; }
            set { currentBarrelCode = value; }
        }

        private SampleInfo currentSampleInfo = null;
        /// <summary>
        /// 当前选择的采样单信息
        /// </summary>
        public SampleInfo CurrentSampleInfo
        {
            get { return currentSampleInfo; }
            set
            {
                currentSampleInfo = value;
                this.MachineRCSampleBarrelId.Clear();

                if (value != null)
                {
                    txtBatch.Text = value.Batch;
                    txtSupplierName.Text = value.SupplierName;
                    txtSampleCode.Text = value.SampleCode;
                    txtSampleType.Text = value.SamplingType;
                    txtMineName.Text = value.MineName;
                }
                else
                {
                    txtBatch.ResetText();
                    txtSupplierName.ResetText();
                    txtSampleCode.ResetText();
                    txtSampleType.ResetText();
                    txtMineName.ResetText();
                }
            }
        }
        //当前采样桶记录信息
        CmcsRCSampleBarrel CurrenSampleBarrel = null;

        List<CmcsRCSampleBarrel> currentRCSampleBarrels = new List<CmcsRCSampleBarrel>();
        /// <summary>
        /// 当前登记的样桶记录
        /// </summary>
        public List<CmcsRCSampleBarrel> CurrentRCSampleBarrels
        {
            get { return currentRCSampleBarrels; }
            set
            {
                currentRCSampleBarrels = value;
                superGridControl1.PrimaryGrid.DataSource = value;
            }
        }

        List<string> machineRCSampleBarrelId = new List<string>();
        /// <summary>
        /// 在数据库中已存在的机器采样桶Id
        /// </summary>
        public List<string> MachineRCSampleBarrelId
        {
            get { return machineRCSampleBarrelId; }
            set { machineRCSampleBarrelId = value; }
        }

        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        public void InitFrom()
        {
            this.IsUseWeight = Convert.ToBoolean(commonDAO.GetAppletConfigInt32("启用称重"));
        }

        private void FrmSampleWeigth_Load(object sender, EventArgs e)
        {
            InitFrom();
            // 初始化设备
            InitHardware();
        }

        private void FrmSampleWeigth_FormClosing(object sender, FormClosingEventArgs e)
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

        bool wbRunStatus = false;
        /// <summary>
        /// 电子秤连接状态
        /// </summary>
        public bool WbRunStatus
        {
            get { return wbRunStatus; }
            set { wbRunStatus = value; }
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
        /// 电子秤状态变化
        /// </summary>
        /// <param name="status"></param>
        void wber_OnStatusChange(bool status)
        {
            // 接收设备状态 
            InvokeEx(() =>
            {
                this.WbRunStatus = status;

                slightWber.LightColor = (status ? Color.Green : Color.Red);
            });
        }

        /// <summary>
        /// 电子秤文档状态变化
        /// </summary>
        /// <param name="status"></param>
        void wber_OnSteadyChange(bool steady)
        {
            // 接收设备状态 
            InvokeEx(() =>
            {
                this.WbSteady = steady;
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

                    wber.OnStatusChange += new WB.TOLEDO.IND231.TOLEDO_IND231Wber.StatusChangeHandler(wber_OnStatusChange);
                    wber.OnSteadyChange += new WB.TOLEDO.IND231.TOLEDO_IND231Wber.SteadyChangeEventHandler(wber_OnSteadyChange);
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
                    case eFlowFlag.选择采样单:
                        #region

                        if (this.CurrentSampleInfo == null)
                            break;
                        else
                        {
                            this.CurrentFlowFlag = eFlowFlag.等待扫码;
                            txtInputSampleCode.Focus();
                        }

                        #endregion
                        break;
                    case eFlowFlag.样桶称重:
                        #region

                        if (wber.Status && wber.Weight > this.WbMinWeight && WbSteady)
                        {
                            this.CurrentWeight = this.wber.Weight;
                            this.CurrentFlowFlag = eFlowFlag.等待登记;
                        }

                        #endregion
                        break;
                    case eFlowFlag.等待登记:
                        #region

                        WaitRegister();

                        #endregion
                        break;
                    case eFlowFlag.完成登记:

                        this.CurrentRCSampleBarrels = currentRCSampleBarrels;
                        txtInputSampleCode.ResetText();
                        this.CurrentFlowFlag = eFlowFlag.等待扫码;

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
            txtInputSampleCode.ResetText();
            this.CurrentBarrelCode = string.Empty;
            this.CurrentSampleInfo = null;
            this.CurrenSampleBarrel = null;
            this.CurrentRCSampleBarrels = new List<CmcsRCSampleBarrel>();
            this.CurrentFlowFlag = eFlowFlag.选择采样单;
        }

        /// <summary>
        /// 等待登记
        /// </summary>
        private void WaitRegister()
        {
            currentRCSampleBarrels.Add(new CmcsRCSampleBarrel()
            {
                InFactoryBatchId = this.CurrentSampleInfo.BatchId,
                SamplingId = this.CurrentSampleInfo.Id,
                SampleType = this.CurrentSampleInfo.SamplingType,
                SamplerName = "",
                BarrelNumber = this.CurrentBarrelCode,
                BarrelCode = this.CurrentBarrelCode,
                BarrellingTime = DateTime.Now,
                SampleWeight = this.CurrentWeight
            });

            ShowMessage("添加到列表，样桶编码：" + this.CurrentBarrelCode + (this.IsUseWeight ? ("，重量：" + this.CurrentWeight.ToString() + "KG") : ""), eOutputType.Normal);
            this.CurrentFlowFlag = eFlowFlag.完成登记;
        }

        #endregion

        #region 操作

        private void txtInputSampleCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barrelCode = txtInputSampleCode.Text.Trim();
                if (String.IsNullOrWhiteSpace(barrelCode)) return;

                if (this.CurrentFlowFlag == eFlowFlag.等待扫码)
                {
                    if (!this.CurrentRCSampleBarrels.Any(a => a.BarrelCode == barrelCode))
                    {
                        // 查找3天内未绑定采样单的样桶记录
                        CmcsRCSampleBarrel rCSampleBarrel = commonDAO.SelfDber.Entity<CmcsRCSampleBarrel>("where BarrelCode=:BarrelCode and CreationTime>=:CreationTime and IsDeleted=0 order by CreationTime desc", new { BarrelCode = barrelCode, CreationTime = DateTime.Now.Date.AddDays(-3) });
                        if (rCSampleBarrel != null)
                        {
                            if (!string.IsNullOrWhiteSpace(rCSampleBarrel.SamplingId))
                            {
                                ShowMessage("此样桶已登记", eOutputType.Error);
                                txtInputSampleCode.ResetText();

                                return;
                            }
                            else
                            {
                                this.MachineRCSampleBarrelId.Add(rCSampleBarrel.Id);
                                this.CurrenSampleBarrel = rCSampleBarrel;
                            }
                        }

                        this.CurrentBarrelCode = barrelCode;

                        if (IsUseWeight)
                        {
                            this.CurrentFlowFlag = eFlowFlag.样桶称重;
                            ShowMessage("扫码成功，开始称重", eOutputType.Normal);
                        }
                        else
                        {
                            this.CurrentFlowFlag = eFlowFlag.等待登记;
                            ShowMessage("扫码成功，开始登记", eOutputType.Normal);

                            WaitRegister();
                        }
                    }
                    else
                    {
                        ShowMessage("列表中已存在该采样桶", eOutputType.Error);
                        txtInputSampleCode.ResetText();
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(this.CurrentBarrelCode))
                    {
                        ShowMessage("请先选择采样单", eOutputType.Error);
                        txtInputSampleCode.ResetText();
                    }
                }
            }
        }

        /// <summary>
        /// 保存样桶登记信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveSampleBarrel_Click(object sender, EventArgs e)
        {
            if (this.CurrentRCSampleBarrels.Count == 0)
            {
                MessageBoxEx.Show("采样桶列表为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (CmcsRCSampleBarrel item in this.CurrentRCSampleBarrels)
            {
                if (this.MachineRCSampleBarrelId.Contains(item.Id))
                    // 在数据库已存在的样桶，只是没有关联采样单
                    cZYHandlerDAO.UpdateRCSampleBarrelSampleWeight(item.Id, item.SampleWeight);
                else
                    // 人工登记桶
                    cZYHandlerDAO.SaveRCSampleBarrel(item);
            }

            MessageBoxEx.Show("样桶登记成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Restet();
        }

        /// <summary>
        /// 选择采样单信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelSampleInfo_Click(object sender, EventArgs e)
        {
            FrmSampleSelect frm = new FrmSampleSelect();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.CurrentSampleInfo = frm.Output;
            }
        }

        /// <summary>
        /// 重置信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            Restet();
        }

        #endregion

        #region 其他

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
        /// Invoke封装
        /// </summary>
        /// <param name="action"></param>
        public void InvokeEx(Action action)
        {
            if (this.IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(action);
        }

        private void superGridControl1_GetRowHeaderText(object sender, DevComponents.DotNetBar.SuperGrid.GridGetRowHeaderTextEventArgs e)
        {
            e.Text = (e.GridRow.RowIndex + 1).ToString();
        }

        private void superGridControl1_BeginEdit(object sender, GridEditEventArgs e)
        {
            // 取消编辑
            e.Cancel = true;
        }

        #endregion
    }
}
