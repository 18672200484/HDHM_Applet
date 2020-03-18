namespace CMCS.CarTransport.Queue.Frms.SysManage
{
    partial class Frm_ResourceUser_List
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
			DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
			DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
			DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn11 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
			DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn12 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnAll = new DevComponents.DotNetBar.ButtonX();
			this.txtUserAccount_Ser = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.btnSearch = new DevComponents.DotNetBar.ButtonX();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			this.superGridControl1 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
			this.superGridControl2 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
			this.superGridControl3 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
			this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
			this.btnInsertResUser = new DevComponents.DotNetBar.ButtonX();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
			this.splitContainer3.Panel1.SuspendLayout();
			this.splitContainer3.Panel2.SuspendLayout();
			this.splitContainer3.SuspendLayout();
			this.panelEx1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.ForeColor = System.Drawing.Color.White;
			this.splitContainer1.Location = new System.Drawing.Point(0, 1);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent;
			this.splitContainer1.Panel1.Controls.Add(this.panel1);
			this.splitContainer1.Panel1.ForeColor = System.Drawing.Color.White;
			this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(82)))), ((int)(((byte)(89)))));
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Panel2.ForeColor = System.Drawing.Color.White;
			this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.splitContainer1.Size = new System.Drawing.Size(1385, 655);
			this.splitContainer1.SplitterDistance = 40;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 148;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Transparent;
			this.panel1.Controls.Add(this.btnAll);
			this.panel1.Controls.Add(this.txtUserAccount_Ser);
			this.panel1.Controls.Add(this.btnSearch);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.ForeColor = System.Drawing.Color.White;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1385, 40);
			this.panel1.TabIndex = 12;
			// 
			// btnAll
			// 
			this.btnAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAll.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAll.Location = new System.Drawing.Point(1317, 9);
			this.btnAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnAll.Name = "btnAll";
			this.btnAll.Size = new System.Drawing.Size(64, 23);
			this.btnAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.btnAll.TabIndex = 20;
			this.btnAll.Text = "全 部";
			this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
			// 
			// txtUserAccount_Ser
			// 
			this.txtUserAccount_Ser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUserAccount_Ser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
			// 
			// 
			// 
			this.txtUserAccount_Ser.Border.Class = "TextBoxBorder";
			this.txtUserAccount_Ser.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.txtUserAccount_Ser.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUserAccount_Ser.ForeColor = System.Drawing.Color.White;
			this.txtUserAccount_Ser.Location = new System.Drawing.Point(1065, 7);
			this.txtUserAccount_Ser.Name = "txtUserAccount_Ser";
			this.txtUserAccount_Ser.Size = new System.Drawing.Size(169, 27);
			this.txtUserAccount_Ser.TabIndex = 19;
			this.txtUserAccount_Ser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtUserAccount_Ser.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
			this.txtUserAccount_Ser.WatermarkText = "用户账户...";
			// 
			// btnSearch
			// 
			this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSearch.Location = new System.Drawing.Point(1246, 9);
			this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(64, 23);
			this.btnSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.btnSearch.TabIndex = 13;
			this.btnSearch.Text = "搜 索";
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// splitContainer2
			// 
			this.splitContainer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
			this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer2.ForeColor = System.Drawing.Color.White;
			this.splitContainer2.IsSplitterFixed = true;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.BackColor = System.Drawing.Color.Transparent;
			this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
			this.splitContainer2.Panel1.ForeColor = System.Drawing.Color.White;
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.BackColor = System.Drawing.Color.Transparent;
			this.splitContainer2.Panel2.Controls.Add(this.superGridControl3);
			this.splitContainer2.Panel2.Controls.Add(this.panelEx1);
			this.splitContainer2.Panel2.ForeColor = System.Drawing.Color.White;
			this.splitContainer2.Panel2MinSize = 40;
			this.splitContainer2.Size = new System.Drawing.Size(1385, 614);
			this.splitContainer2.SplitterDistance = 919;
			this.splitContainer2.SplitterWidth = 1;
			this.splitContainer2.TabIndex = 0;
			// 
			// splitContainer3
			// 
			this.splitContainer3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
			this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer3.ForeColor = System.Drawing.Color.White;
			this.splitContainer3.IsSplitterFixed = true;
			this.splitContainer3.Location = new System.Drawing.Point(0, 0);
			this.splitContainer3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.splitContainer3.Name = "splitContainer3";
			// 
			// splitContainer3.Panel1
			// 
			this.splitContainer3.Panel1.BackColor = System.Drawing.Color.Transparent;
			this.splitContainer3.Panel1.Controls.Add(this.superGridControl1);
			this.splitContainer3.Panel1.ForeColor = System.Drawing.Color.White;
			// 
			// splitContainer3.Panel2
			// 
			this.splitContainer3.Panel2.BackColor = System.Drawing.Color.Transparent;
			this.splitContainer3.Panel2.Controls.Add(this.superGridControl2);
			this.splitContainer3.Panel2.ForeColor = System.Drawing.Color.White;
			this.splitContainer3.Panel2MinSize = 40;
			this.splitContainer3.Size = new System.Drawing.Size(919, 614);
			this.splitContainer3.SplitterDistance = 446;
			this.splitContainer3.SplitterWidth = 1;
			this.splitContainer3.TabIndex = 1;
			// 
			// superGridControl1
			// 
			this.superGridControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
			this.superGridControl1.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
			this.superGridControl1.DefaultVisualStyles.CellStyles.Default.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.superGridControl1.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.superGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.superGridControl1.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
			this.superGridControl1.ForeColor = System.Drawing.Color.White;
			this.superGridControl1.Location = new System.Drawing.Point(0, 0);
			this.superGridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.superGridControl1.Name = "superGridControl1";
			this.superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
			this.superGridControl1.PrimaryGrid.Caption.Text = "";
			gridColumn1.DataPropertyName = "Id";
			gridColumn1.Name = "clmId";
			gridColumn1.Visible = false;
			gridColumn2.DataPropertyName = "Name";
			gridColumn2.HeaderText = "昵称";
			gridColumn2.Name = "clmUserName";
			gridColumn2.Width = 150;
			gridColumn3.DataPropertyName = "UserName";
			gridColumn3.HeaderText = "账号";
			gridColumn3.Name = "clmUserAccount";
			gridColumn3.Width = 120;
			this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn1);
			this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn2);
			this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn3);
			this.superGridControl1.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.Row;
			this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
			this.superGridControl1.Size = new System.Drawing.Size(446, 614);
			this.superGridControl1.TabIndex = 5;
			this.superGridControl1.Text = "superGridControl1";
			this.superGridControl1.CellMouseDown += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellMouseEventArgs>(this.superGridControl1_CellMouseDown);
			this.superGridControl1.DataBindingComplete += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridDataBindingCompleteEventArgs>(this.superGridControl1_DataBindingComplete);
			this.superGridControl1.BeginEdit += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEditEventArgs>(this.superGridControl1_BeginEdit);
			// 
			// superGridControl2
			// 
			this.superGridControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
			this.superGridControl2.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
			this.superGridControl2.DefaultVisualStyles.CellStyles.Default.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.superGridControl2.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.superGridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.superGridControl2.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
			this.superGridControl2.ForeColor = System.Drawing.Color.White;
			this.superGridControl2.Location = new System.Drawing.Point(0, 0);
			this.superGridControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.superGridControl2.Name = "superGridControl2";
			this.superGridControl2.PrimaryGrid.AutoGenerateColumns = false;
			this.superGridControl2.PrimaryGrid.Caption.Text = "";
			gridColumn4.DataPropertyName = "Id";
			gridColumn4.Name = "clmId";
			gridColumn4.Visible = false;
			gridColumn5.DataPropertyName = "ModuleName";
			gridColumn5.HeaderText = "模块名称";
			gridColumn5.Name = "clmModeuleName";
			gridColumn5.Width = 150;
			gridColumn6.DataPropertyName = "Moduleno";
			gridColumn6.HeaderText = "模块编码";
			gridColumn6.Name = "clmModuleno";
			gridColumn6.Width = 80;
			gridColumn7.DataPropertyName = "CreationTime";
			gridColumn7.HeaderText = "创建时间";
			gridColumn7.Name = "clmCreateDate";
			gridColumn7.Width = 150;
			this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn4);
			this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn5);
			this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn6);
			this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn7);
			this.superGridControl2.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.Row;
			this.superGridControl2.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
			this.superGridControl2.Size = new System.Drawing.Size(472, 614);
			this.superGridControl2.TabIndex = 5;
			this.superGridControl2.Text = "superGridControl2";
			this.superGridControl2.CellMouseDown += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellMouseEventArgs>(this.superGridControl2_CellMouseDown);
			this.superGridControl2.BeginEdit += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEditEventArgs>(this.superGridControl2_BeginEdit);
			// 
			// superGridControl3
			// 
			this.superGridControl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
			this.superGridControl3.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
			this.superGridControl3.DefaultVisualStyles.CellStyles.Default.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.superGridControl3.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.superGridControl3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.superGridControl3.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
			this.superGridControl3.ForeColor = System.Drawing.Color.White;
			this.superGridControl3.Location = new System.Drawing.Point(0, 35);
			this.superGridControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.superGridControl3.Name = "superGridControl3";
			this.superGridControl3.PrimaryGrid.AutoGenerateColumns = false;
			this.superGridControl3.PrimaryGrid.Caption.Text = "";
			gridColumn8.DataPropertyName = "Id";
			gridColumn8.HeaderText = "";
			gridColumn8.Name = "clmResourceId";
			gridColumn8.Visible = false;
			gridColumn9.DataPropertyName = "CheckPower";
			gridColumn9.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
			gridColumn9.HeaderText = "";
			gridColumn9.Name = "clmCheckPower";
			gridColumn9.Width = 80;
			gridColumn10.DataPropertyName = "ResName";
			gridColumn10.HeaderText = "功能名称";
			gridColumn10.Name = "clnResName";
			gridColumn11.DataPropertyName = "Resno";
			gridColumn11.HeaderText = "功能编码";
			gridColumn11.Name = "clnResno";
			gridColumn11.Width = 80;
			gridColumn12.DataPropertyName = "CreationTime";
			gridColumn12.HeaderText = "创建时间";
			gridColumn12.Name = "clmCreateDate";
			gridColumn12.Width = 150;
			this.superGridControl3.PrimaryGrid.Columns.Add(gridColumn8);
			this.superGridControl3.PrimaryGrid.Columns.Add(gridColumn9);
			this.superGridControl3.PrimaryGrid.Columns.Add(gridColumn10);
			this.superGridControl3.PrimaryGrid.Columns.Add(gridColumn11);
			this.superGridControl3.PrimaryGrid.Columns.Add(gridColumn12);
			this.superGridControl3.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.Row;
			this.superGridControl3.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
			this.superGridControl3.Size = new System.Drawing.Size(465, 579);
			this.superGridControl3.TabIndex = 8;
			this.superGridControl3.Text = "superGridControl3";
			this.superGridControl3.BeginEdit += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEditEventArgs>(this.superGridControl3_BeginEdit);
			// 
			// panelEx1
			// 
			this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
			this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.panelEx1.Controls.Add(this.btnInsertResUser);
			this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelEx1.Location = new System.Drawing.Point(0, 0);
			this.panelEx1.Name = "panelEx1";
			this.panelEx1.Size = new System.Drawing.Size(465, 35);
			this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
			this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.panelEx1.Style.GradientAngle = 90;
			this.panelEx1.TabIndex = 7;
			// 
			// btnInsertResUser
			// 
			this.btnInsertResUser.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnInsertResUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnInsertResUser.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnInsertResUser.Location = new System.Drawing.Point(44, 6);
			this.btnInsertResUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnInsertResUser.Name = "btnInsertResUser";
			this.btnInsertResUser.Size = new System.Drawing.Size(64, 23);
			this.btnInsertResUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.btnInsertResUser.TabIndex = 14;
			this.btnInsertResUser.Text = "确 定";
			this.btnInsertResUser.Click += new System.EventHandler(this.btnInsertResUser_Click);
			// 
			// Frm_ResourceUser_List
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
			this.ClientSize = new System.Drawing.Size(1386, 657);
			this.Controls.Add(this.splitContainer1);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
			this.Name = "Frm_ResourceUser_List";
			this.Text = "权限管理列表";
			this.Load += new System.EventHandler(this.Frm_ResourceUser_List_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
			this.splitContainer3.ResumeLayout(false);
			this.panelEx1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnSearch;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUserAccount_Ser;
        private DevComponents.DotNetBar.ButtonX btnAll;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl1;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl2;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnInsertResUser;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl3;
    }
}