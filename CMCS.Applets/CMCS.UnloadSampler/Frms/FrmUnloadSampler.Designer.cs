namespace CMCS.UnloadSampler.Frms
{
    partial class FrmUnloadSampler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn11 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn12 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn13 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn14 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUnloadSampler));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSendMakeCmd = new DevComponents.DotNetBar.ButtonX();
            this.pnlExMain = new DevComponents.DotNetBar.PanelEx();
            this.rTxTMessageInfo = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.superGridControl3 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.panelEx4 = new DevComponents.DotNetBar.PanelEx();
            this.flpanUnloadType = new System.Windows.Forms.FlowLayoutPanel();
            this.rbtnToSubway = new System.Windows.Forms.RadioButton();
            this.rbtnToMaker = new System.Windows.Forms.RadioButton();
            this.btnSendLoadCmd = new DevComponents.DotNetBar.ButtonX();
            this.flpanSamplerButton = new System.Windows.Forms.FlowLayoutPanel();
            this.superGridControl2 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.superGridControl1 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.flpanEquState = new System.Windows.Forms.FlowLayoutPanel();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.pnlExMain.SuspendLayout();
            this.panelEx4.SuspendLayout();
            this.flpanUnloadType.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            // 
            // btnSendMakeCmd
            // 
            this.btnSendMakeCmd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSendMakeCmd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSendMakeCmd.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.btnSendMakeCmd.Location = new System.Drawing.Point(370, 20);
            this.btnSendMakeCmd.Name = "btnSendMakeCmd";
            this.btnSendMakeCmd.Size = new System.Drawing.Size(138, 84);
            this.btnSendMakeCmd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSendMakeCmd.TabIndex = 26;
            this.btnSendMakeCmd.Text = "开 始 制 样";
            this.toolTip1.SetToolTip(this.btnSendMakeCmd, "自动发送制样计划失败时采用人工发送");
            this.btnSendMakeCmd.Click += new System.EventHandler(this.btnSendMakeCmd_Click);
            // 
            // pnlExMain
            // 
            this.pnlExMain.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlExMain.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlExMain.Controls.Add(this.rTxTMessageInfo);
            this.pnlExMain.Controls.Add(this.superGridControl3);
            this.pnlExMain.Controls.Add(this.panelEx4);
            this.pnlExMain.Controls.Add(this.flpanSamplerButton);
            this.pnlExMain.Controls.Add(this.superGridControl2);
            this.pnlExMain.Controls.Add(this.superGridControl1);
            this.pnlExMain.Controls.Add(this.flpanEquState);
            this.pnlExMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlExMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pnlExMain.Location = new System.Drawing.Point(0, 0);
            this.pnlExMain.Name = "pnlExMain";
            this.pnlExMain.Size = new System.Drawing.Size(1086, 575);
            this.pnlExMain.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlExMain.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlExMain.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlExMain.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlExMain.Style.GradientAngle = 90;
            this.pnlExMain.TabIndex = 0;
            // 
            // rTxTMessageInfo
            // 
            // 
            // 
            // 
            this.rTxTMessageInfo.BackgroundStyle.Class = "RichTextBoxBorder";
            this.rTxTMessageInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rTxTMessageInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTxTMessageInfo.ForeColor = System.Drawing.Color.White;
            this.rTxTMessageInfo.Location = new System.Drawing.Point(570, 399);
            this.rTxTMessageInfo.Name = "rTxTMessageInfo";
            this.rTxTMessageInfo.Size = new System.Drawing.Size(509, 125);
            this.rTxTMessageInfo.TabIndex = 0;
            // 
            // superGridControl3
            // 
            this.superGridControl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.superGridControl3.DefaultVisualStyles.CaptionStyles.Default.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.superGridControl3.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.superGridControl3.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.superGridControl3.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.superGridControl3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superGridControl3.ForeColor = System.Drawing.Color.White;
            this.superGridControl3.Location = new System.Drawing.Point(570, 207);
            this.superGridControl3.Name = "superGridControl3";
            this.superGridControl3.PrimaryGrid.AutoGenerateColumns = false;
            this.superGridControl3.PrimaryGrid.Caption.Text = "最 近 卸 样 记 录";
            this.superGridControl3.PrimaryGrid.CheckBoxes = true;
            gridColumn1.MinimumWidth = 20;
            gridColumn1.Name = "";
            gridColumn1.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            gridColumn1.Width = 20;
            gridColumn2.DataPropertyName = "CreationTime";
            gridColumn2.HeaderText = "卸样时间";
            gridColumn2.Name = "";
            gridColumn2.Width = 150;
            gridColumn3.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn3.DataPropertyName = "SampleCode";
            gridColumn3.FillWeight = 70;
            gridColumn3.HeaderText = "采样副码";
            gridColumn3.MinimumWidth = 70;
            gridColumn3.Name = "";
            gridColumn3.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            gridColumn3.Width = 110;
            gridColumn4.DataPropertyName = "ResultCode";
            gridColumn4.HeaderText = "结果";
            gridColumn4.Name = "";
            gridColumn4.Width = 70;
            this.superGridControl3.PrimaryGrid.Columns.Add(gridColumn1);
            this.superGridControl3.PrimaryGrid.Columns.Add(gridColumn2);
            this.superGridControl3.PrimaryGrid.Columns.Add(gridColumn3);
            this.superGridControl3.PrimaryGrid.Columns.Add(gridColumn4);
            background1.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.Radial;
            background1.Color1 = System.Drawing.Color.DarkTurquoise;
            background1.Color2 = System.Drawing.Color.White;
            this.superGridControl3.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.Background = background1;
            this.superGridControl3.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.superGridControl3.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.superGridControl3.PrimaryGrid.DefaultVisualStyles.CellStyles.ReadOnly.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.superGridControl3.PrimaryGrid.DefaultVisualStyles.CellStyles.ReadOnly.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.superGridControl3.PrimaryGrid.ShowRowGridIndex = true;
            this.superGridControl3.Size = new System.Drawing.Size(509, 186);
            this.superGridControl3.TabIndex = 37;
            this.superGridControl3.Text = "superGridControl3";
            this.superGridControl3.CellClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs>(this.superGridControl3_CellClick);
            this.superGridControl3.BeginEdit += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEditEventArgs>(this.superGridControl3_BeginEdit);
            this.superGridControl3.GetRowHeaderText += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridGetRowHeaderTextEventArgs>(this.superGridControl_GetRowHeaderText);
            // 
            // panelEx4
            // 
            this.panelEx4.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx4.Controls.Add(this.btnSendMakeCmd);
            this.panelEx4.Controls.Add(this.flpanUnloadType);
            this.panelEx4.Controls.Add(this.btnSendLoadCmd);
            this.panelEx4.Location = new System.Drawing.Point(8, 399);
            this.panelEx4.Name = "panelEx4";
            this.panelEx4.Size = new System.Drawing.Size(556, 125);
            this.panelEx4.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx4.Style.BackColor1.Color = System.Drawing.Color.Transparent;
            this.panelEx4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx4.Style.BorderColor.Color = System.Drawing.Color.Gray;
            this.panelEx4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx4.Style.GradientAngle = 90;
            this.panelEx4.TabIndex = 36;
            // 
            // flpanUnloadType
            // 
            this.flpanUnloadType.BackColor = System.Drawing.Color.Transparent;
            this.flpanUnloadType.Controls.Add(this.rbtnToSubway);
            this.flpanUnloadType.Controls.Add(this.rbtnToMaker);
            this.flpanUnloadType.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpanUnloadType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flpanUnloadType.ForeColor = System.Drawing.Color.White;
            this.flpanUnloadType.Location = new System.Drawing.Point(16, 20);
            this.flpanUnloadType.Name = "flpanUnloadType";
            this.flpanUnloadType.Size = new System.Drawing.Size(166, 84);
            this.flpanUnloadType.TabIndex = 8;
            // 
            // rbtnToSubway
            // 
            this.rbtnToSubway.AutoSize = true;
            this.rbtnToSubway.Checked = true;
            this.rbtnToSubway.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnToSubway.ForeColor = System.Drawing.Color.White;
            this.rbtnToSubway.Location = new System.Drawing.Point(3, 3);
            this.rbtnToSubway.Name = "rbtnToSubway";
            this.rbtnToSubway.Size = new System.Drawing.Size(115, 34);
            this.rbtnToSubway.TabIndex = 0;
            this.rbtnToSubway.TabStop = true;
            this.rbtnToSubway.Tag = "0";
            this.rbtnToSubway.Text = "旁路卸样";
            this.rbtnToSubway.UseVisualStyleBackColor = true;
            // 
            // rbtnToMaker
            // 
            this.rbtnToMaker.AutoSize = true;
            this.rbtnToMaker.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnToMaker.ForeColor = System.Drawing.Color.White;
            this.rbtnToMaker.Location = new System.Drawing.Point(3, 43);
            this.rbtnToMaker.Name = "rbtnToMaker";
            this.rbtnToMaker.Size = new System.Drawing.Size(157, 34);
            this.rbtnToMaker.TabIndex = 1;
            this.rbtnToMaker.Tag = "1";
            this.rbtnToMaker.Text = "卸样到制样机";
            this.rbtnToMaker.UseVisualStyleBackColor = true;
            // 
            // btnSendLoadCmd
            // 
            this.btnSendLoadCmd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSendLoadCmd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSendLoadCmd.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendLoadCmd.Location = new System.Drawing.Point(211, 20);
            this.btnSendLoadCmd.Name = "btnSendLoadCmd";
            this.btnSendLoadCmd.Size = new System.Drawing.Size(138, 84);
            this.btnSendLoadCmd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSendLoadCmd.TabIndex = 9;
            this.btnSendLoadCmd.Text = "开 始 卸 样";
            this.btnSendLoadCmd.Click += new System.EventHandler(this.btnSendLoadCmd_Click);
            // 
            // flpanSamplerButton
            // 
            this.flpanSamplerButton.BackColor = System.Drawing.Color.Transparent;
            this.flpanSamplerButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpanSamplerButton.ForeColor = System.Drawing.Color.White;
            this.flpanSamplerButton.Location = new System.Drawing.Point(8, 9);
            this.flpanSamplerButton.Name = "flpanSamplerButton";
            this.flpanSamplerButton.Size = new System.Drawing.Size(1071, 35);
            this.flpanSamplerButton.TabIndex = 30;
            // 
            // superGridControl2
            // 
            this.superGridControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.superGridControl2.DefaultVisualStyles.CaptionStyles.Default.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.superGridControl2.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.superGridControl2.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.superGridControl2.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.superGridControl2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superGridControl2.ForeColor = System.Drawing.Color.White;
            this.superGridControl2.Location = new System.Drawing.Point(570, 50);
            this.superGridControl2.Name = "superGridControl2";
            this.superGridControl2.PrimaryGrid.AutoGenerateColumns = false;
            this.superGridControl2.PrimaryGrid.Caption.Text = "采 样 单 信 息";
            this.superGridControl2.PrimaryGrid.CheckBoxes = true;
            gridColumn5.MinimumWidth = 20;
            gridColumn5.Name = "";
            gridColumn5.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            gridColumn5.Width = 20;
            gridColumn6.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn6.DataPropertyName = "SampleCode";
            gridColumn6.HeaderText = "采样主码";
            gridColumn6.MinimumWidth = 100;
            gridColumn6.Name = "";
            gridColumn6.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            gridColumn6.Width = 110;
            gridColumn7.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn7.DataPropertyName = "SamplingType";
            gridColumn7.FillWeight = 80;
            gridColumn7.HeaderText = "采样方式";
            gridColumn7.MinimumWidth = 80;
            gridColumn7.Name = "";
            gridColumn7.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            gridColumn7.Width = 80;
            gridColumn8.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn8.DataPropertyName = "SamplingDate";
            gridColumn8.HeaderText = "采样时间";
            gridColumn8.MinimumWidth = 130;
            gridColumn8.Name = "";
            gridColumn8.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            gridColumn8.Width = 150;
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn5);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn6);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn7);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn8);
            background2.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.Radial;
            background2.Color1 = System.Drawing.Color.DarkTurquoise;
            background2.Color2 = System.Drawing.Color.White;
            this.superGridControl2.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.Background = background2;
            this.superGridControl2.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.superGridControl2.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.superGridControl2.PrimaryGrid.DefaultVisualStyles.CellStyles.ReadOnly.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.superGridControl2.PrimaryGrid.DefaultVisualStyles.CellStyles.ReadOnly.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.superGridControl2.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.Row;
            this.superGridControl2.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl2.PrimaryGrid.ShowRowGridIndex = true;
            this.superGridControl2.Size = new System.Drawing.Size(509, 151);
            this.superGridControl2.TabIndex = 33;
            this.superGridControl2.Text = "superGridControl2";
            this.superGridControl2.BeforeCheck += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridBeforeCheckEventArgs>(this.superGridControl2_BeforeCheck);
            this.superGridControl2.BeginEdit += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEditEventArgs>(this.superGridControl2_BeginEdit);
            this.superGridControl2.GetRowHeaderText += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridGetRowHeaderTextEventArgs>(this.superGridControl_GetRowHeaderText);
            // 
            // superGridControl1
            // 
            this.superGridControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.superGridControl1.DefaultVisualStyles.CaptionStyles.Default.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.superGridControl1.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.superGridControl1.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.superGridControl1.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.superGridControl1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superGridControl1.ForeColor = System.Drawing.Color.White;
            this.superGridControl1.Location = new System.Drawing.Point(8, 50);
            this.superGridControl1.Name = "superGridControl1";
            this.superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            this.superGridControl1.PrimaryGrid.Caption.Text = "集 样 罐 信 息";
            this.superGridControl1.PrimaryGrid.CheckBoxes = true;
            gridColumn9.MinimumWidth = 20;
            gridColumn9.Name = "";
            gridColumn9.Width = 20;
            gridColumn10.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn10.DataPropertyName = "BarrelNumber";
            gridColumn10.HeaderText = "罐号";
            gridColumn10.MinimumWidth = 50;
            gridColumn10.Name = "";
            gridColumn10.Width = 50;
            gridColumn11.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn11.DataPropertyName = "SampleCode";
            gridColumn11.HeaderText = "采样副码";
            gridColumn11.MinimumWidth = 110;
            gridColumn11.Name = "";
            gridColumn11.Width = 110;
            gridColumn12.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn12.DataPropertyName = "SampleCount";
            gridColumn12.HeaderText = "子样数";
            gridColumn12.MinimumWidth = 80;
            gridColumn12.Name = "";
            gridColumn12.Width = 80;
            gridColumn13.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn13.DataPropertyName = "BarrelStatus";
            gridColumn13.HeaderText = "桶满";
            gridColumn13.MinimumWidth = 60;
            gridColumn13.Name = "";
            gridColumn13.Width = 60;
            gridColumn14.DataPropertyName = "BarrelType";
            gridColumn14.HeaderText = "样罐类型";
            gridColumn14.Name = "";
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn9);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn10);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn11);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn12);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn13);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn14);
            background3.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.Radial;
            background3.Color1 = System.Drawing.Color.DarkTurquoise;
            background3.Color2 = System.Drawing.Color.White;
            this.superGridControl1.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.Background = background3;
            this.superGridControl1.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.superGridControl1.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.superGridControl1.PrimaryGrid.DefaultVisualStyles.CellStyles.ReadOnly.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.superGridControl1.PrimaryGrid.DefaultVisualStyles.CellStyles.ReadOnly.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.superGridControl1.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.Row;
            this.superGridControl1.PrimaryGrid.MultiSelect = false;
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl1.PrimaryGrid.ShowRowGridIndex = true;
            this.superGridControl1.Size = new System.Drawing.Size(556, 343);
            this.superGridControl1.TabIndex = 29;
            this.superGridControl1.Text = "superGridControl1";
            this.superGridControl1.BeforeCheck += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridBeforeCheckEventArgs>(this.superGridControl1_BeforeCheck);
            this.superGridControl1.BeginEdit += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEditEventArgs>(this.superGridControl1_BeginEdit);
            this.superGridControl1.GetCellStyle += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridGetCellStyleEventArgs>(this.superGridControl1_GetCellStyle);
            this.superGridControl1.GetRowHeaderText += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridGetRowHeaderTextEventArgs>(this.superGridControl_GetRowHeaderText);
            // 
            // flpanEquState
            // 
            this.flpanEquState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpanEquState.ForeColor = System.Drawing.Color.White;
            this.flpanEquState.Location = new System.Drawing.Point(8, 530);
            this.flpanEquState.Name = "flpanEquState";
            this.flpanEquState.Size = new System.Drawing.Size(1071, 35);
            this.flpanEquState.TabIndex = 32;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51))))), System.Drawing.Color.DarkTurquoise);
            // 
            // FrmUnloadSampler
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1086, 575);
            this.Controls.Add(this.pnlExMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1100, 575);
            this.Name = "FrmUnloadSampler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "武汉博晟燃料集中管控-卸样控制程序";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.FrmUnloadSampler_Load);
            this.pnlExMain.ResumeLayout(false);
            this.panelEx4.ResumeLayout(false);
            this.flpanUnloadType.ResumeLayout(false);
            this.flpanUnloadType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolTip toolTip1;
        private DevComponents.DotNetBar.PanelEx pnlExMain;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl3;
        private DevComponents.DotNetBar.PanelEx panelEx4;
        private DevComponents.DotNetBar.ButtonX btnSendMakeCmd;
        private System.Windows.Forms.FlowLayoutPanel flpanUnloadType;
        private System.Windows.Forms.RadioButton rbtnToSubway;
        private System.Windows.Forms.RadioButton rbtnToMaker;
        private DevComponents.DotNetBar.ButtonX btnSendLoadCmd;
        private System.Windows.Forms.FlowLayoutPanel flpanSamplerButton;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl2;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx rTxTMessageInfo;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl1;
        private System.Windows.Forms.FlowLayoutPanel flpanEquState;
        private DevComponents.DotNetBar.StyleManager styleManager1;
    }
}