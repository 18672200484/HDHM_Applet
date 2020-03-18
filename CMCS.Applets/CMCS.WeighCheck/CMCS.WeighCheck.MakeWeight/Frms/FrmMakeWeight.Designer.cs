namespace CMCS.WeighCheck.MakeWeight.Frms.SampleWeigth
{
    partial class FrmMakeWeight
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
            this.components = new System.ComponentModel.Container();
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMakeWeight));
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.slightWber = new CMCS.Forms.UserControls.UCtrlSignalLight();
            this.pnlExMain = new DevComponents.DotNetBar.PanelEx();
            this.superGridControl1 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.lblWber = new System.Windows.Forms.Label();
            this.rtxtMakeWeightInfo = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.lblCurrentFlowFlag = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtInputMakeCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pnlExMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // slightWber
            // 
            this.slightWber.BackColor = System.Drawing.Color.Transparent;
            this.slightWber.ForeColor = System.Drawing.Color.White;
            this.slightWber.LightColor = System.Drawing.Color.Gray;
            this.slightWber.Location = new System.Drawing.Point(660, 9);
            this.slightWber.Name = "slightWber";
            this.slightWber.Size = new System.Drawing.Size(20, 20);
            this.slightWber.TabIndex = 221;
            this.toolTip1.SetToolTip(this.slightWber, "<绿色> 已连接\r\n<红色> 未连接");
            // 
            // pnlExMain
            // 
            this.pnlExMain.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlExMain.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlExMain.Controls.Add(this.superGridControl1);
            this.pnlExMain.Controls.Add(this.lblWber);
            this.pnlExMain.Controls.Add(this.slightWber);
            this.pnlExMain.Controls.Add(this.rtxtMakeWeightInfo);
            this.pnlExMain.Controls.Add(this.lblCurrentFlowFlag);
            this.pnlExMain.Controls.Add(this.label10);
            this.pnlExMain.Controls.Add(this.txtInputMakeCode);
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
            // superGridControl1
            // 
            this.superGridControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.superGridControl1.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.superGridControl1.DefaultVisualStyles.CellStyles.Default.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.superGridControl1.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            background1.Color1 = System.Drawing.Color.DarkTurquoise;
            this.superGridControl1.DefaultVisualStyles.RowStyles.Selected.Background = background1;
            this.superGridControl1.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.superGridControl1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.superGridControl1.ForeColor = System.Drawing.Color.White;
            this.superGridControl1.Location = new System.Drawing.Point(12, 80);
            this.superGridControl1.Margin = new System.Windows.Forms.Padding(0);
            this.superGridControl1.Name = "superGridControl1";
            this.superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            gridColumn1.DataPropertyName = "SampleType";
            gridColumn1.HeaderText = "样品类型";
            gridColumn1.Name = "SampleType";
            gridColumn1.Width = 170;
            gridColumn2.DataPropertyName = "SampleCode";
            gridColumn2.HeaderText = "样品编码";
            gridColumn2.Name = "SampleCode";
            gridColumn2.Width = 240;
            gridColumn3.DataPropertyName = "SampleWeight";
            gridColumn3.HeaderText = "样重(g)";
            gridColumn3.Name = "SampleWeight";
            gridColumn3.Width = 80;
            gridColumn4.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridButtonXEditControl);
            gridColumn4.HeaderText = "";
            gridColumn4.Name = "gclmNewCode";
            gridColumn4.NullString = "生成编码";
            gridColumn4.RenderType = typeof(DevComponents.DotNetBar.SuperGrid.GridButtonXEditControl);
            gridColumn4.Width = 80;
            gridColumn5.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridButtonXEditControl);
            gridColumn5.HeaderText = "";
            gridColumn5.Name = "gclmPrintCode";
            gridColumn5.NullString = "打印编码";
            gridColumn5.RenderType = typeof(DevComponents.DotNetBar.SuperGrid.GridButtonXEditControl);
            gridColumn5.Width = 80;
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn1);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn2);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn3);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn4);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn5);
            this.superGridControl1.PrimaryGrid.EnterKeySelectsNextRow = false;
            this.superGridControl1.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.Row;
            this.superGridControl1.PrimaryGrid.MultiSelect = false;
            this.superGridControl1.PrimaryGrid.NoRowsText = "";
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl1.Size = new System.Drawing.Size(730, 244);
            this.superGridControl1.TabIndex = 223;
            this.superGridControl1.Text = "superGridControl1";
            this.superGridControl1.BeginEdit += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEditEventArgs>(this.superGridControl1_BeginEdit);
            // 
            // lblWber
            // 
            this.lblWber.AutoSize = true;
            this.lblWber.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWber.ForeColor = System.Drawing.Color.White;
            this.lblWber.Location = new System.Drawing.Point(685, 9);
            this.lblWber.Name = "lblWber";
            this.lblWber.Size = new System.Drawing.Size(54, 20);
            this.lblWber.TabIndex = 222;
            this.lblWber.Text = "电子秤";
            // 
            // rtxtMakeWeightInfo
            // 
            // 
            // 
            // 
            this.rtxtMakeWeightInfo.BackgroundStyle.Class = "RichTextBoxBorder";
            this.rtxtMakeWeightInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rtxtMakeWeightInfo.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.rtxtMakeWeightInfo.ForeColor = System.Drawing.Color.White;
            this.rtxtMakeWeightInfo.Location = new System.Drawing.Point(12, 330);
            this.rtxtMakeWeightInfo.Name = "rtxtMakeWeightInfo";
            this.rtxtMakeWeightInfo.ReadOnly = true;
            this.rtxtMakeWeightInfo.Size = new System.Drawing.Size(730, 81);
            this.rtxtMakeWeightInfo.TabIndex = 213;
            // 
            // lblCurrentFlowFlag
            // 
            this.lblCurrentFlowFlag.AutoSize = true;
            this.lblCurrentFlowFlag.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblCurrentFlowFlag.ForeColor = System.Drawing.Color.White;
            this.lblCurrentFlowFlag.Location = new System.Drawing.Point(88, 9);
            this.lblCurrentFlowFlag.Name = "lblCurrentFlowFlag";
            this.lblCurrentFlowFlag.Size = new System.Drawing.Size(69, 20);
            this.lblCurrentFlowFlag.TabIndex = 210;
            this.lblCurrentFlowFlag.Text = "等待扫码";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(12, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 20);
            this.label10.TabIndex = 209;
            this.label10.Text = "当前流程：";
            // 
            // txtInputMakeCode
            // 
            this.txtInputMakeCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.txtInputMakeCode.Border.Class = "TextBoxBorder";
            this.txtInputMakeCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtInputMakeCode.ButtonCustom.Text = "清空";
            this.txtInputMakeCode.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.txtInputMakeCode.ForeColor = System.Drawing.Color.White;
            this.txtInputMakeCode.Location = new System.Drawing.Point(12, 35);
            this.txtInputMakeCode.Name = "txtInputMakeCode";
            this.txtInputMakeCode.Size = new System.Drawing.Size(727, 39);
            this.txtInputMakeCode.TabIndex = 0;
            this.txtInputMakeCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInputMakeCode.WatermarkText = "扫描制样码. . .";
            this.txtInputMakeCode.ButtonCustomClick += new System.EventHandler(this.txtMakeWeightCode_ButtonCustomClick);
            this.txtInputMakeCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtInputMakeCode_KeyUp);
            // 
            // timer2
            // 
            this.timer2.Interval = 2000;
            // 
            // FrmMakeWeight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(752, 423);
            this.Controls.Add(this.pnlExMain);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmMakeWeight";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "样品称重校验程序";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMakeWeight_FormClosing);
            this.Load += new System.EventHandler(this.FrmMakeWeight_Load);
            this.pnlExMain.ResumeLayout(false);
            this.pnlExMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ToolTip toolTip1;
        private DevComponents.DotNetBar.PanelEx pnlExMain;
        private System.Windows.Forms.Timer timer2;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx rtxtMakeWeightInfo;
        private System.Windows.Forms.Label lblCurrentFlowFlag;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.Controls.TextBoxX txtInputMakeCode;
        private System.Windows.Forms.Label lblWber;
        private Forms.UserControls.UCtrlSignalLight slightWber;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl1;
    }
}

