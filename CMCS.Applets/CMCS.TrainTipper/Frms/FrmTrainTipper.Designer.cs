namespace CMCS.TrainTipper.Frms
{
    partial class FrmTrainTipper
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
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background4 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.lblCurrentTrainNumber = new DevComponents.DotNetBar.LabelX();
            this.superGridControl_DF = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.superGridControl_YF = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.btnAddTrainCarriagePass = new DevComponents.DotNetBar.ButtonX();
            this.dtiptStartArriveTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dtiptEndArriveTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.uCtrlSignalLight_TrainBeltSampler = new CMCS.Forms.UserControls.UCtrlSignalLight();
            this.lblTrainBeltSampler = new DevComponents.DotNetBar.LabelX();
            this.lblRunInfo = new DevComponents.DotNetBar.LabelX();
            this.btnStopTurnover = new DevComponents.DotNetBar.ButtonX();
            this.btnStartTurnover = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.lblBarrelStatus = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dtiptStartArriveTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtiptEndArriveTime)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.White;
            this.labelX1.Location = new System.Drawing.Point(8, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(107, 32);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "当前翻车：";
            // 
            // lblCurrentTrainNumber
            // 
            this.lblCurrentTrainNumber.AutoSize = true;
            this.lblCurrentTrainNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.lblCurrentTrainNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCurrentTrainNumber.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblCurrentTrainNumber.ForeColor = System.Drawing.Color.White;
            this.lblCurrentTrainNumber.Location = new System.Drawing.Point(109, 12);
            this.lblCurrentTrainNumber.Name = "lblCurrentTrainNumber";
            this.lblCurrentTrainNumber.Size = new System.Drawing.Size(29, 32);
            this.lblCurrentTrainNumber.TabIndex = 1;
            this.lblCurrentTrainNumber.Text = "无";
            // 
            // superGridControl_DF
            // 
            this.superGridControl_DF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.superGridControl_DF.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.superGridControl_DF.DefaultVisualStyles.CellStyles.Default.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.superGridControl_DF.DefaultVisualStyles.HeaderStyles.Default.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.superGridControl_DF.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.superGridControl_DF.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.superGridControl_DF.ForeColor = System.Drawing.Color.White;
            this.superGridControl_DF.Location = new System.Drawing.Point(12, 110);
            this.superGridControl_DF.Name = "superGridControl_DF";
            this.superGridControl_DF.PrimaryGrid.AutoGenerateColumns = false;
            this.superGridControl_DF.PrimaryGrid.Caption.Text = "待翻列表 ↑";
            gridColumn1.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn1.DataPropertyName = "TrainNumber";
            gridColumn1.HeaderText = "车厢号";
            gridColumn1.MinimumWidth = 90;
            gridColumn1.Name = "TrainNumber";
            gridColumn1.Width = 90;
            gridColumn2.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn2.DataPropertyName = "InfactoryTime";
            gridColumn2.HeaderText = "入厂时间";
            gridColumn2.MinimumWidth = 130;
            gridColumn2.Name = "InfactoryTime";
            gridColumn2.Width = 150;
            gridColumn3.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn3.DataPropertyName = "SampleType";
            gridColumn3.HeaderText = "采样方式";
            gridColumn3.Name = "SampleType";
            gridColumn3.Width = 90;
            this.superGridControl_DF.PrimaryGrid.Columns.Add(gridColumn1);
            this.superGridControl_DF.PrimaryGrid.Columns.Add(gridColumn2);
            this.superGridControl_DF.PrimaryGrid.Columns.Add(gridColumn3);
            background1.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.Radial;
            background1.Color1 = System.Drawing.Color.DarkTurquoise;
            background1.Color2 = System.Drawing.Color.White;
            this.superGridControl_DF.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.Background = background1;
            this.superGridControl_DF.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superGridControl_DF.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.superGridControl_DF.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.superGridControl_DF.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.superGridControl_DF.PrimaryGrid.DefaultVisualStyles.HeaderStyles.Default.Font = new System.Drawing.Font("Segoe UI", 10F);
            background2.Color1 = System.Drawing.Color.Red;
            this.superGridControl_DF.PrimaryGrid.DefaultVisualStyles.RowStyles.Selected.Background = background2;
            background3.Color1 = System.Drawing.Color.Red;
            this.superGridControl_DF.PrimaryGrid.DefaultVisualStyles.RowStyles.SelectedMouseOver.Background = background3;
            this.superGridControl_DF.PrimaryGrid.MultiSelect = false;
            this.superGridControl_DF.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl_DF.Size = new System.Drawing.Size(463, 422);
            this.superGridControl_DF.TabIndex = 2;
            this.superGridControl_DF.Text = "superGridControl1";
            this.superGridControl_DF.BeginEdit += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEditEventArgs>(this.superGridControl_BeginEdit);
            this.superGridControl_DF.GetCellStyle += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridGetCellStyleEventArgs>(this.superGridControl_FormatCellColor_GetCellStyle);
            this.superGridControl_DF.GetRowHeaderText += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridGetRowHeaderTextEventArgs>(this.superGridControl_GetRowHeaderText);
            // 
            // superGridControl_YF
            // 
            this.superGridControl_YF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.superGridControl_YF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.superGridControl_YF.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.superGridControl_YF.DefaultVisualStyles.CellStyles.Default.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.superGridControl_YF.DefaultVisualStyles.HeaderStyles.Default.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.superGridControl_YF.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.superGridControl_YF.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.superGridControl_YF.ForeColor = System.Drawing.Color.White;
            this.superGridControl_YF.Location = new System.Drawing.Point(643, 110);
            this.superGridControl_YF.Name = "superGridControl_YF";
            this.superGridControl_YF.PrimaryGrid.AutoGenerateColumns = false;
            this.superGridControl_YF.PrimaryGrid.Caption.Text = "已翻列表 ↓";
            gridColumn4.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn4.DataPropertyName = "TrainNumber";
            gridColumn4.HeaderText = "车厢号";
            gridColumn4.MinimumWidth = 90;
            gridColumn4.Name = "TrainNumber";
            gridColumn4.Width = 90;
            gridColumn5.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn5.DataPropertyName = "InfactoryTime";
            gridColumn5.HeaderText = "入厂时间";
            gridColumn5.MinimumWidth = 150;
            gridColumn5.Name = "InfactoryTime";
            gridColumn5.Width = 150;
            gridColumn6.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn6.DataPropertyName = "SampleType";
            gridColumn6.HeaderText = "采样方式";
            gridColumn6.Name = "SampleType";
            gridColumn6.Width = 90;
            this.superGridControl_YF.PrimaryGrid.Columns.Add(gridColumn4);
            this.superGridControl_YF.PrimaryGrid.Columns.Add(gridColumn5);
            this.superGridControl_YF.PrimaryGrid.Columns.Add(gridColumn6);
            background4.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.Radial;
            background4.Color1 = System.Drawing.Color.DarkTurquoise;
            background4.Color2 = System.Drawing.Color.White;
            background4.GradientAngle = 60;
            this.superGridControl_YF.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.Background = background4;
            this.superGridControl_YF.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superGridControl_YF.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.superGridControl_YF.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.superGridControl_YF.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.superGridControl_YF.PrimaryGrid.DefaultVisualStyles.HeaderStyles.Default.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.superGridControl_YF.PrimaryGrid.MultiSelect = false;
            this.superGridControl_YF.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl_YF.PrimaryGrid.ShowRowGridIndex = true;
            this.superGridControl_YF.Size = new System.Drawing.Size(467, 422);
            this.superGridControl_YF.TabIndex = 3;
            this.superGridControl_YF.Text = "superGridControl2";
            this.superGridControl_YF.BeginEdit += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEditEventArgs>(this.superGridControl_BeginEdit);
            this.superGridControl_YF.GetCellStyle += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridGetCellStyleEventArgs>(this.superGridControl_FormatCellColor_GetCellStyle);
            this.superGridControl_YF.GetRowHeaderText += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridGetRowHeaderTextEventArgs>(this.superGridControl_GetRowHeaderText);
            // 
            // btnAddTrainCarriagePass
            // 
            this.btnAddTrainCarriagePass.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddTrainCarriagePass.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAddTrainCarriagePass.Enabled = false;
            this.btnAddTrainCarriagePass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTrainCarriagePass.Location = new System.Drawing.Point(490, 244);
            this.btnAddTrainCarriagePass.Name = "btnAddTrainCarriagePass";
            this.btnAddTrainCarriagePass.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(5);
            this.btnAddTrainCarriagePass.Size = new System.Drawing.Size(138, 46);
            this.btnAddTrainCarriagePass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddTrainCarriagePass.TabIndex = 5;
            this.btnAddTrainCarriagePass.Text = "设置为当前翻车";
            this.btnAddTrainCarriagePass.Click += new System.EventHandler(this.btnAddTrainCarriagePass_Click);
            // 
            // dtiptStartArriveTime
            // 
            this.dtiptStartArriveTime.AllowEmptyState = false;
            this.dtiptStartArriveTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtiptStartArriveTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.dtiptStartArriveTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtiptStartArriveTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiptStartArriveTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtiptStartArriveTime.ButtonDropDown.Visible = true;
            this.dtiptStartArriveTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtiptStartArriveTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtiptStartArriveTime.ForeColor = System.Drawing.Color.White;
            this.dtiptStartArriveTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtiptStartArriveTime.IsPopupCalendarOpen = false;
            this.dtiptStartArriveTime.Location = new System.Drawing.Point(369, 10);
            // 
            // 
            // 
            this.dtiptStartArriveTime.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiptStartArriveTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiptStartArriveTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtiptStartArriveTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtiptStartArriveTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtiptStartArriveTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiptStartArriveTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtiptStartArriveTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtiptStartArriveTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtiptStartArriveTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtiptStartArriveTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiptStartArriveTime.MonthCalendar.DisplayMonth = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            this.dtiptStartArriveTime.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtiptStartArriveTime.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiptStartArriveTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtiptStartArriveTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiptStartArriveTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtiptStartArriveTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiptStartArriveTime.MonthCalendar.TodayButtonVisible = true;
            this.dtiptStartArriveTime.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtiptStartArriveTime.Name = "dtiptStartArriveTime";
            this.dtiptStartArriveTime.Size = new System.Drawing.Size(209, 29);
            this.dtiptStartArriveTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtiptStartArriveTime.TabIndex = 6;
            this.dtiptStartArriveTime.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H;
            this.dtiptStartArriveTime.ValueObjectChanged += new System.EventHandler(this.dtiptStartArriveTime_ValueObjectChanged);
            // 
            // labelX3
            // 
            this.labelX3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.ForeColor = System.Drawing.Color.White;
            this.labelX3.Location = new System.Drawing.Point(281, 10);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(90, 29);
            this.labelX3.TabIndex = 7;
            this.labelX3.Text = "入厂时间：";
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dtiptEndArriveTime
            // 
            this.dtiptEndArriveTime.AllowEmptyState = false;
            this.dtiptEndArriveTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtiptEndArriveTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.dtiptEndArriveTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtiptEndArriveTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiptEndArriveTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtiptEndArriveTime.ButtonDropDown.Visible = true;
            this.dtiptEndArriveTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtiptEndArriveTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtiptEndArriveTime.ForeColor = System.Drawing.Color.White;
            this.dtiptEndArriveTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtiptEndArriveTime.IsPopupCalendarOpen = false;
            this.dtiptEndArriveTime.Location = new System.Drawing.Point(609, 10);
            // 
            // 
            // 
            this.dtiptEndArriveTime.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiptEndArriveTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiptEndArriveTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtiptEndArriveTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtiptEndArriveTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtiptEndArriveTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiptEndArriveTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtiptEndArriveTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtiptEndArriveTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtiptEndArriveTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtiptEndArriveTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiptEndArriveTime.MonthCalendar.DisplayMonth = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            this.dtiptEndArriveTime.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtiptEndArriveTime.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiptEndArriveTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtiptEndArriveTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiptEndArriveTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtiptEndArriveTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiptEndArriveTime.MonthCalendar.TodayButtonVisible = true;
            this.dtiptEndArriveTime.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtiptEndArriveTime.Name = "dtiptEndArriveTime";
            this.dtiptEndArriveTime.Size = new System.Drawing.Size(209, 29);
            this.dtiptEndArriveTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtiptEndArriveTime.TabIndex = 8;
            this.dtiptEndArriveTime.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H;
            this.dtiptEndArriveTime.ValueObjectChanged += new System.EventHandler(this.dtiptEndArriveTime_ValueObjectChanged);
            // 
            // labelX2
            // 
            this.labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.ForeColor = System.Drawing.Color.White;
            this.labelX2.Location = new System.Drawing.Point(581, 11);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(24, 26);
            this.labelX2.TabIndex = 9;
            this.labelX2.Text = "到";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51))))), System.Drawing.Color.DarkTurquoise);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // uCtrlSignalLight_TrainBeltSampler
            // 
            this.uCtrlSignalLight_TrainBeltSampler.BackColor = System.Drawing.Color.Transparent;
            this.uCtrlSignalLight_TrainBeltSampler.LightColor = System.Drawing.Color.Gray;
            this.uCtrlSignalLight_TrainBeltSampler.Location = new System.Drawing.Point(277, 15);
            this.uCtrlSignalLight_TrainBeltSampler.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uCtrlSignalLight_TrainBeltSampler.Name = "uCtrlSignalLight_TrainBeltSampler";
            this.uCtrlSignalLight_TrainBeltSampler.Size = new System.Drawing.Size(26, 26);
            this.uCtrlSignalLight_TrainBeltSampler.TabIndex = 12;
            this.toolTip1.SetToolTip(this.uCtrlSignalLight_TrainBeltSampler, "<绿色> 就绪待机\r\n<红色> 正在运行\r\n<黄色> 发生故障");
            // 
            // lblTrainBeltSampler
            // 
            this.lblTrainBeltSampler.AutoSize = true;
            this.lblTrainBeltSampler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.lblTrainBeltSampler.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTrainBeltSampler.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTrainBeltSampler.ForeColor = System.Drawing.Color.White;
            this.lblTrainBeltSampler.Location = new System.Drawing.Point(313, 12);
            this.lblTrainBeltSampler.Name = "lblTrainBeltSampler";
            this.lblTrainBeltSampler.Size = new System.Drawing.Size(29, 32);
            this.lblTrainBeltSampler.TabIndex = 13;
            this.lblTrainBeltSampler.Text = "无";
            // 
            // lblRunInfo
            // 
            this.lblRunInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRunInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.lblRunInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblRunInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRunInfo.ForeColor = System.Drawing.Color.White;
            this.lblRunInfo.Location = new System.Drawing.Point(12, 538);
            this.lblRunInfo.Name = "lblRunInfo";
            this.lblRunInfo.Size = new System.Drawing.Size(1098, 29);
            this.lblRunInfo.TabIndex = 15;
            this.lblRunInfo.Text = "输出信息";
            // 
            // btnStopTurnover
            // 
            this.btnStopTurnover.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStopTurnover.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStopTurnover.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopTurnover.Location = new System.Drawing.Point(490, 182);
            this.btnStopTurnover.Name = "btnStopTurnover";
            this.btnStopTurnover.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(5);
            this.btnStopTurnover.Size = new System.Drawing.Size(138, 46);
            this.btnStopTurnover.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnStopTurnover.TabIndex = 16;
            this.btnStopTurnover.Text = "停 止 翻 车";
            this.btnStopTurnover.Click += new System.EventHandler(this.btnStopTurnover_Click);
            // 
            // btnStartTurnover
            // 
            this.btnStartTurnover.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStartTurnover.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStartTurnover.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartTurnover.Location = new System.Drawing.Point(490, 120);
            this.btnStartTurnover.Name = "btnStartTurnover";
            this.btnStartTurnover.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(5);
            this.btnStartTurnover.Size = new System.Drawing.Size(138, 46);
            this.btnStartTurnover.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnStartTurnover.TabIndex = 17;
            this.btnStartTurnover.Text = "开 始 翻 车";
            this.btnStartTurnover.Click += new System.EventHandler(this.btnStartTurnover_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.dtiptStartArriveTime);
            this.panelEx1.Controls.Add(this.dtiptEndArriveTime);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Location = new System.Drawing.Point(12, 55);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1098, 49);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.Color = System.Drawing.Color.Gray;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 18;
            // 
            // lblBarrelStatus
            // 
            this.lblBarrelStatus.AutoSize = true;
            this.lblBarrelStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.lblBarrelStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblBarrelStatus.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarrelStatus.ForeColor = System.Drawing.Color.White;
            this.lblBarrelStatus.Location = new System.Drawing.Point(460, 19);
            this.lblBarrelStatus.Name = "lblBarrelStatus";
            this.lblBarrelStatus.Size = new System.Drawing.Size(76, 23);
            this.lblBarrelStatus.TabIndex = 19;
            this.lblBarrelStatus.Text = "(样桶充足)";
            // 
            // FrmTrainTipper
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1122, 574);
            this.Controls.Add(this.lblBarrelStatus);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.btnStartTurnover);
            this.Controls.Add(this.btnStopTurnover);
            this.Controls.Add(this.lblRunInfo);
            this.Controls.Add(this.lblTrainBeltSampler);
            this.Controls.Add(this.uCtrlSignalLight_TrainBeltSampler);
            this.Controls.Add(this.superGridControl_DF);
            this.Controls.Add(this.btnAddTrainCarriagePass);
            this.Controls.Add(this.superGridControl_YF);
            this.Controls.Add(this.lblCurrentTrainNumber);
            this.Controls.Add(this.labelX1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTrainTipper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "翻车机功能";
            this.Load += new System.EventHandler(this.FrmTrainTipper_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtiptStartArriveTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtiptEndArriveTime)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX lblCurrentTrainNumber;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl_DF;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl_YF;
        private DevComponents.DotNetBar.ButtonX btnAddTrainCarriagePass;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtiptStartArriveTime;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.Timer timer1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtiptEndArriveTime;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolTip toolTip1;
        private Forms.UserControls.UCtrlSignalLight uCtrlSignalLight_TrainBeltSampler;
        private DevComponents.DotNetBar.LabelX lblTrainBeltSampler;
        private DevComponents.DotNetBar.LabelX lblRunInfo;
        private DevComponents.DotNetBar.ButtonX btnStopTurnover;
        private DevComponents.DotNetBar.ButtonX btnStartTurnover;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX lblBarrelStatus;
    }
}