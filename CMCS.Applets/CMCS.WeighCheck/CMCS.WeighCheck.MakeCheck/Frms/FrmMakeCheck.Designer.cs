namespace CMCS.WeighCheck.MakeCheck.Frms.SampleWeigth
{
    partial class FrmMakeCheck
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMakeCheck));
            this.timer1 = new System.Windows.Forms.Timer();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.toolTip1 = new System.Windows.Forms.ToolTip();
            this.slightWber = new CMCS.Forms.UserControls.UCtrlSignalLight();
            this.pnlExMain = new DevComponents.DotNetBar.PanelEx();
            this.lblWber = new System.Windows.Forms.Label();
            this.txtInputMakeCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.rtxtMakeCheckInfo = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.lblCurrentFlowFlag = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.pnlExMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // slightWber
            // 
            this.slightWber.BackColor = System.Drawing.Color.Transparent;
            this.slightWber.ForeColor = System.Drawing.Color.White;
            this.slightWber.LightColor = System.Drawing.Color.Gray;
            this.slightWber.Location = new System.Drawing.Point(660, 10);
            this.slightWber.Name = "slightWber";
            this.slightWber.Size = new System.Drawing.Size(20, 20);
            this.slightWber.TabIndex = 223;
            this.toolTip1.SetToolTip(this.slightWber, "<绿色> 已连接\r\n<红色> 未连接");
            // 
            // pnlExMain
            // 
            this.pnlExMain.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlExMain.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlExMain.Controls.Add(this.lblWber);
            this.pnlExMain.Controls.Add(this.slightWber);
            this.pnlExMain.Controls.Add(this.txtInputMakeCode);
            this.pnlExMain.Controls.Add(this.rtxtMakeCheckInfo);
            this.pnlExMain.Controls.Add(this.lblCurrentFlowFlag);
            this.pnlExMain.Controls.Add(this.label14);
            this.pnlExMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlExMain.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.pnlExMain.Location = new System.Drawing.Point(0, 0);
            this.pnlExMain.Name = "pnlExMain";
            this.pnlExMain.Size = new System.Drawing.Size(752, 423);
            this.pnlExMain.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlExMain.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(63)))));
            this.pnlExMain.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlExMain.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlExMain.Style.GradientAngle = 90;
            this.pnlExMain.TabIndex = 0;
            // 
            // lblWber
            // 
            this.lblWber.AutoSize = true;
            this.lblWber.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWber.ForeColor = System.Drawing.Color.White;
            this.lblWber.Location = new System.Drawing.Point(685, 9);
            this.lblWber.Name = "lblWber";
            this.lblWber.Size = new System.Drawing.Size(54, 20);
            this.lblWber.TabIndex = 224;
            this.lblWber.Text = "电子秤";
            // 
            // txtInputMakeCode
            // 
            this.txtInputMakeCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.txtInputMakeCode.Border.Class = "TextBoxBorder";
            this.txtInputMakeCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtInputMakeCode.ButtonCustom.Enabled = false;
            this.txtInputMakeCode.ButtonCustom.Text = " 打印化验码";
            this.txtInputMakeCode.ButtonCustom.Visible = true;
            this.txtInputMakeCode.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.txtInputMakeCode.ForeColor = System.Drawing.Color.White;
            this.txtInputMakeCode.Location = new System.Drawing.Point(12, 35);
            this.txtInputMakeCode.Name = "txtInputMakeCode";
            this.txtInputMakeCode.PreventEnterBeep = true;
            this.txtInputMakeCode.Size = new System.Drawing.Size(727, 39);
            this.txtInputMakeCode.TabIndex = 213;
            this.txtInputMakeCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInputMakeCode.WatermarkText = "扫描样品编码. . .";
            this.txtInputMakeCode.ButtonCustomClick += new System.EventHandler(this.txtMakeCheckCode_ButtonCustomClick);
            this.txtInputMakeCode.Enter += new System.EventHandler(this.txtInputMakeCode_Enter);
            this.txtInputMakeCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMakeCheckCode_KeyUp);
            // 
            // rtxtMakeCheckInfo
            // 
            this.rtxtMakeCheckInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.rtxtMakeCheckInfo.BackgroundStyle.Class = "RichTextBoxBorder";
            this.rtxtMakeCheckInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rtxtMakeCheckInfo.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtxtMakeCheckInfo.ForeColor = System.Drawing.Color.White;
            this.rtxtMakeCheckInfo.Location = new System.Drawing.Point(12, 80);
            this.rtxtMakeCheckInfo.Name = "rtxtMakeCheckInfo";
            this.rtxtMakeCheckInfo.ReadOnly = true;
            this.rtxtMakeCheckInfo.Size = new System.Drawing.Size(727, 331);
            this.rtxtMakeCheckInfo.TabIndex = 212;
            // 
            // lblCurrentFlowFlag
            // 
            this.lblCurrentFlowFlag.AutoSize = true;
            this.lblCurrentFlowFlag.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentFlowFlag.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblCurrentFlowFlag.ForeColor = System.Drawing.Color.White;
            this.lblCurrentFlowFlag.Location = new System.Drawing.Point(88, 9);
            this.lblCurrentFlowFlag.Name = "lblCurrentFlowFlag";
            this.lblCurrentFlowFlag.Size = new System.Drawing.Size(69, 20);
            this.lblCurrentFlowFlag.TabIndex = 209;
            this.lblCurrentFlowFlag.Text = "等待扫码";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(12, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 20);
            this.label14.TabIndex = 208;
            this.label14.Text = "当前流程：";
            // 
            // FrmMakeCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(752, 423);
            this.Controls.Add(this.pnlExMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmMakeCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "样品称重校验程序";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMakeCheck_FormClosing);
            this.Load += new System.EventHandler(this.FrmMakeCheck_Load);
            this.pnlExMain.ResumeLayout(false);
            this.pnlExMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ToolTip toolTip1;
        private DevComponents.DotNetBar.PanelEx pnlExMain;
        private DevComponents.DotNetBar.Controls.TextBoxX txtInputMakeCode;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx rtxtMakeCheckInfo;
        private System.Windows.Forms.Label lblCurrentFlowFlag;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblWber;
        private Forms.UserControls.UCtrlSignalLight slightWber;
    }
}

