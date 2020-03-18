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
using CMCS.WeighCheck.MakeCheck.Enums;
using CMCS.WeighCheck.MakeCheck.Frms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Metro;

namespace CMCS.WeighCheck.MakeCheck.Frms.SampleWeigth
{
    public partial class FrmMakeCheck : MetroForm
    {
        public FrmMakeCheck()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体唯一标识符
        /// </summary>
        public static string UniqueKey = "FrmMakeCheck";

        #region Vars

        CommonDAO commonDAO = CommonDAO.GetInstance();
        CZYHandlerDAO czyHandlerDAO = CZYHandlerDAO.GetInstance();
        CodePrinter _CodePrinter = null;

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

        // 当前制样明细记录
        CmcsRCMakeDetail currentMakeDetail = null;

        /// <summary>
        /// 化验记录
        /// </summary>
        CmcsRCAssay RCAssay;

        string resMessage = string.Empty;

        #endregion

        public void InitFrom()
        {
            this.IsUseWeight = Convert.ToBoolean(commonDAO.GetAppletConfigInt32("启用称重"));
            this._CodePrinter = new CodePrinter(printDocument1);
        }

        private void FrmMakeCheck_Load(object sender, EventArgs e)
        {
            //初始化
            InitFrom();
            //初始化设备
            InitHardware();
        }

        private void FrmMakeCheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnloadHardware();
        }

        #region 电子秤

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
            set { wbSteady = value; }
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
        /// 电子秤仪表状态变化
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

                    // 电子秤仪表1
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

        #region 称重校验业务
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            try
            {
                #region 制样称重校验
                switch (this.CurrentFlowFlag)
                {
                    case eFlowFlag.等待校验:
                        #region
                        // 重量大于最小称重且稳定
                        if (wber.Status && wber.Weight > WbMinWeight && WbSteady)
                        {
                            czyHandlerDAO.UpdateMakeDetailCheckWeight(this.currentMakeDetail.Id, wber.Weight);
                            ShowMessage("校验完成，重量为：" + wber.Weight.ToString(), eOutputType.Normal);

                            this.CurrentFlowFlag = eFlowFlag.校验成功;
                        }
                        #endregion
                        break;
                    case eFlowFlag.校验成功:
                        PrintAssayCode();
                        break;
                }
                #endregion
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

            this.currentMakeDetail = null;
            this.RCAssay = null;

            txtInputMakeCode.ButtonCustom.Enabled = false;
            txtInputMakeCode.ResetText();
            rtxtMakeCheckInfo.ResetText();

            // 方便客户快速使用，获取焦点
            txtInputMakeCode.Focus();
        }

        /// <summary>
        /// 打印化验码
        /// </summary>
        private void PrintAssayCode()
        {
            this.CurrentFlowFlag = eFlowFlag.打印化验码;

            if (this.RCAssay == null) return;

            if (MessageBoxEx.Show("样品类型：" + this.currentMakeDetail.SampleType + "，立刻打印化验码？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this._CodePrinter.Print(this.RCAssay.AssayCode);

                Restet();
            }
            else
                Restet();
        }

        #endregion

        #region 操作

        /// <summary>
        /// 获取焦点时清空制样码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInputMakeCode_Enter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtInputMakeCode.Text))
            {
                Restet();
            }
        }

        /// <summary>
        /// 键入Enter检测有效性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMakeCheckCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //  根据输入制样码查找制样明细记录
                if (!String.IsNullOrEmpty(txtInputMakeCode.Text.Trim()))
                {
                    this.currentMakeDetail = czyHandlerDAO.GetRCMakeDetail(txtInputMakeCode.Text.Trim(), out resMessage);
                    if (this.currentMakeDetail != null)
                    {
                        ShowMessage("扫码成功，样品类型：" + this.currentMakeDetail.SampleType + "  样罐编码：" + this.currentMakeDetail.SampleCode, eOutputType.Normal);

                        this.RCAssay = czyHandlerDAO.GetRCAssayByMakeCode(this.currentMakeDetail.Id);
                        if (this.RCAssay != null)
                        {
                            txtInputMakeCode.ButtonCustom.Enabled = true;

                            // 需要称重校验
                            if (IsUseWeight)
                            {
                                this.CurrentFlowFlag = eFlowFlag.等待校验;
                                ShowMessage("将样品放入台秤完成校验", eOutputType.Normal);
                            }
                            // 不需要称重校验，直接打印化验码
                            else
                            {
                                PrintAssayCode();
                            }
                        }
                        else
                        {
                            ShowMessage("未找到化验记录，无法打印化验码", eOutputType.Error);
                            txtInputMakeCode.ResetText();
                        }
                    }
                    else
                    {
                        ShowMessage(resMessage, eOutputType.Error);
                        txtInputMakeCode.ResetText();
                    }
                }
            }
        }

        /// <summary>
        /// 打印化验码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMakeCheckCode_ButtonCustomClick(object sender, EventArgs e)
        {
            PrintAssayCode();
        }

        #endregion

        #region 其他

        private void ShowMessage(string info, eOutputType outputType)
        {
            OutputRunInfo(rtxtMakeCheckInfo, info, outputType);
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
        #endregion

    }
}
