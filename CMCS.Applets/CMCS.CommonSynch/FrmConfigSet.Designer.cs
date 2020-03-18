namespace CMCS.CommonSynch
{
    partial class FrmConfigSet
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
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfigSet));
            this.txtCommonAppConfig = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtServerConnStr = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtClientConnStr = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.intIptSynchInterval = new DevComponents.Editors.IntegerInput();
            this.chkStartup = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.superGridControl1 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.btnSubmit = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.btnDel = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.intIptSynchInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCommonAppConfig
            // 
            this.txtCommonAppConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.txtCommonAppConfig.Border.Class = "TextBoxBorder";
            this.txtCommonAppConfig.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCommonAppConfig.ForeColor = System.Drawing.Color.White;
            this.txtCommonAppConfig.Location = new System.Drawing.Point(305, 16);
            this.txtCommonAppConfig.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCommonAppConfig.Name = "txtCommonAppConfig";
            this.txtCommonAppConfig.Size = new System.Drawing.Size(298, 27);
            this.txtCommonAppConfig.TabIndex = 197;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.labelX3.ForeColor = System.Drawing.Color.White;
            this.labelX3.Location = new System.Drawing.Point(200, 17);
            this.labelX3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(101, 24);
            this.labelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX3.TabIndex = 196;
            this.labelX3.Text = "程序唯一标识";
            // 
            // txtServerConnStr
            // 
            this.txtServerConnStr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.txtServerConnStr.Border.Class = "TextBoxBorder";
            this.txtServerConnStr.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtServerConnStr.ForeColor = System.Drawing.Color.White;
            this.txtServerConnStr.Location = new System.Drawing.Point(305, 58);
            this.txtServerConnStr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtServerConnStr.Name = "txtServerConnStr";
            this.txtServerConnStr.Size = new System.Drawing.Size(674, 27);
            this.txtServerConnStr.TabIndex = 199;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.labelX1.ForeColor = System.Drawing.Color.White;
            this.labelX1.Location = new System.Drawing.Point(22, 59);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(279, 24);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX1.TabIndex = 198;
            this.labelX1.Text = "服务器端(下达)Oracle数据库连接字符串";
            // 
            // txtClientConnStr
            // 
            this.txtClientConnStr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.txtClientConnStr.Border.Class = "TextBoxBorder";
            this.txtClientConnStr.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtClientConnStr.ForeColor = System.Drawing.Color.White;
            this.txtClientConnStr.Location = new System.Drawing.Point(305, 100);
            this.txtClientConnStr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtClientConnStr.Name = "txtClientConnStr";
            this.txtClientConnStr.Size = new System.Drawing.Size(674, 27);
            this.txtClientConnStr.TabIndex = 201;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.labelX2.ForeColor = System.Drawing.Color.White;
            this.labelX2.Location = new System.Drawing.Point(38, 101);
            this.labelX2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(263, 24);
            this.labelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX2.TabIndex = 200;
            this.labelX2.Text = "就地端(上传)Oracle数据库连接字符串";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.labelX4.ForeColor = System.Drawing.Color.White;
            this.labelX4.Location = new System.Drawing.Point(614, 17);
            this.labelX4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(141, 24);
            this.labelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX4.TabIndex = 202;
            this.labelX4.Text = "同步间隔(单位：秒)";
            // 
            // intIptSynchInterval
            // 
            this.intIptSynchInterval.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.intIptSynchInterval.BackgroundStyle.Class = "DateTimeInputBackground";
            this.intIptSynchInterval.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.intIptSynchInterval.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.intIptSynchInterval.ForeColor = System.Drawing.Color.White;
            this.intIptSynchInterval.Location = new System.Drawing.Point(759, 16);
            this.intIptSynchInterval.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.intIptSynchInterval.MinValue = 1;
            this.intIptSynchInterval.Name = "intIptSynchInterval";
            this.intIptSynchInterval.ShowUpDown = true;
            this.intIptSynchInterval.Size = new System.Drawing.Size(102, 27);
            this.intIptSynchInterval.TabIndex = 203;
            this.intIptSynchInterval.Value = 1;
            // 
            // chkStartup
            // 
            this.chkStartup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.chkStartup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkStartup.ForeColor = System.Drawing.Color.White;
            this.chkStartup.Location = new System.Drawing.Point(874, 12);
            this.chkStartup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkStartup.Name = "chkStartup";
            this.chkStartup.Size = new System.Drawing.Size(101, 35);
            this.chkStartup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkStartup.TabIndex = 204;
            this.chkStartup.Text = "开机启动";
            // 
            // superGridControl1
            // 
            this.superGridControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.superGridControl1.DefaultVisualStyles.CellStyles.Default.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.superGridControl1.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.superGridControl1.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.superGridControl1.ForeColor = System.Drawing.Color.White;
            this.superGridControl1.Location = new System.Drawing.Point(22, 150);
            this.superGridControl1.Name = "superGridControl1";
            gridColumn1.DataPropertyName = "SynchTitle";
            gridColumn1.HeaderText = "标题";
            gridColumn1.Name = "SynchTitle";
            gridColumn1.Width = 170;
            gridColumn2.DataPropertyName = "TableName";
            gridColumn2.HeaderText = "表名";
            gridColumn2.Name = "TableName";
            gridColumn2.Width = 150;
            gridColumn3.DataPropertyName = "TableZNName";
            gridColumn3.HeaderText = "表名(中文名)";
            gridColumn3.Name = "TableZNName";
            gridColumn3.Width = 150;
            gridColumn4.DataPropertyName = "PrimaryKey";
            gridColumn4.HeaderText = "主键";
            gridColumn4.Name = "PrimaryKey";
            gridColumn4.Width = 60;
            gridColumn5.DataPropertyName = "SynchField";
            gridColumn5.HeaderText = "同步标识字段";
            gridColumn5.Name = "SynchField";
            gridColumn6.DataPropertyName = "SynchType";
            gridColumn6.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridComboBoxExEditControl);
            gridColumn6.HeaderText = "同步类型";
            gridColumn6.Name = "SynchType";
            gridColumn7.DataPropertyName = "Sequence";
            gridColumn7.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            gridColumn7.HeaderText = "同步顺序";
            gridColumn7.Name = "Sequence";
            gridColumn7.Width = 80;
            gridColumn8.DataPropertyName = "Enabled";
            gridColumn8.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridSwitchButtonEditControl);
            gridColumn8.HeaderText = "是否启用";
            gridColumn8.Name = "Enabled";
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn1);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn2);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn3);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn4);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn5);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn6);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn7);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn8);
            this.superGridControl1.PrimaryGrid.DefaultRowHeight = 30;
            this.superGridControl1.Size = new System.Drawing.Size(957, 400);
            this.superGridControl1.TabIndex = 205;
            this.superGridControl1.Text = "superGridControl1";
            this.superGridControl1.CellActivated += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellActivatedEventArgs>(this.superGridControl1_CellActivated);
            this.superGridControl1.GetRowHeaderText += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridGetRowHeaderTextEventArgs>(this.superGridControl1_GetRowHeaderText);
            // 
            // btnSubmit
            // 
            this.btnSubmit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnSubmit.Location = new System.Drawing.Point(823, 565);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSubmit.TabIndex = 207;
            this.btnSubmit.Text = "保  存";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnCancel.Location = new System.Drawing.Point(904, 565);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 206;
            this.btnCancel.Text = "取  消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnAdd.Location = new System.Drawing.Point(585, 565);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2000;
            this.btnAdd.TabIndex = 208;
            this.btnAdd.Text = "新 增";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDel.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnDel.Location = new System.Drawing.Point(666, 565);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2000;
            this.btnDel.TabIndex = 209;
            this.btnDel.Text = "删 除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // FrmConfigSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.superGridControl1);
            this.Controls.Add(this.chkStartup);
            this.Controls.Add(this.intIptSynchInterval);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.txtClientConnStr);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.txtServerConnStr);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtCommonAppConfig);
            this.Controls.Add(this.labelX3);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfigSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "同步通用程序配置界面";
            this.Load += new System.EventHandler(this.FrmConfigSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.intIptSynchInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtCommonAppConfig;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtServerConnStr;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtClientConnStr;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.Editors.IntegerInput intIptSynchInterval;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkStartup;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl1;
        private DevComponents.DotNetBar.ButtonX btnSubmit;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.ButtonX btnDel;
    }
}