namespace CMCS.CarTransport.Queue.Frms.BaseInfo.UserInfo
{
    partial class FrmUserInfo_Oper
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserInfo_Oper));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
			this.btnSubmit = new DevComponents.DotNetBar.ButtonX();
			this.btnCancel = new DevComponents.DotNetBar.ButtonX();
			this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
			this.chbIsDeductUser = new DevComponents.DotNetBar.Controls.CheckBoxX();
			this.chbIsSupper = new DevComponents.DotNetBar.Controls.CheckBoxX();
			this.txtUserName = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.labelX4 = new DevComponents.DotNetBar.LabelX();
			this.txtCreateDate = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.labelX5 = new DevComponents.DotNetBar.LabelX();
			this.chbIsUse = new DevComponents.DotNetBar.Controls.CheckBoxX();
			this.txtUserPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.labelX6 = new DevComponents.DotNetBar.LabelX();
			this.txtUserAccount = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.labelX7 = new DevComponents.DotNetBar.LabelX();
			this.tableLayoutPanel1.SuspendLayout();
			this.panelEx1.SuspendLayout();
			this.panelEx2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.panelEx1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.panelEx2, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(610, 203);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// panelEx1
			// 
			this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
			this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.panelEx1.Controls.Add(this.btnSubmit);
			this.panelEx1.Controls.Add(this.btnCancel);
			this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelEx1.Location = new System.Drawing.Point(3, 166);
			this.panelEx1.Name = "panelEx1";
			this.panelEx1.Size = new System.Drawing.Size(604, 34);
			this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.panelEx1.Style.GradientAngle = 90;
			this.panelEx1.TabIndex = 0;
			// 
			// btnSubmit
			// 
			this.btnSubmit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.btnSubmit.Location = new System.Drawing.Point(439, 6);
			this.btnSubmit.Name = "btnSubmit";
			this.btnSubmit.Size = new System.Drawing.Size(75, 23);
			this.btnSubmit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.btnSubmit.TabIndex = 1;
			this.btnSubmit.Text = "保  存";
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.btnCancel.Location = new System.Drawing.Point(520, 6);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "取  消";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// panelEx2
			// 
			this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
			this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.panelEx2.Controls.Add(this.chbIsDeductUser);
			this.panelEx2.Controls.Add(this.chbIsSupper);
			this.panelEx2.Controls.Add(this.txtUserName);
			this.panelEx2.Controls.Add(this.labelX4);
			this.panelEx2.Controls.Add(this.txtCreateDate);
			this.panelEx2.Controls.Add(this.labelX5);
			this.panelEx2.Controls.Add(this.chbIsUse);
			this.panelEx2.Controls.Add(this.txtUserPassword);
			this.panelEx2.Controls.Add(this.labelX6);
			this.panelEx2.Controls.Add(this.txtUserAccount);
			this.panelEx2.Controls.Add(this.labelX7);
			this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelEx2.Location = new System.Drawing.Point(3, 3);
			this.panelEx2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.panelEx2.Name = "panelEx2";
			this.panelEx2.Size = new System.Drawing.Size(604, 160);
			this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.panelEx2.Style.GradientAngle = 90;
			this.panelEx2.TabIndex = 1;
			// 
			// chbIsDeductUser
			// 
			this.chbIsDeductUser.AutoSize = true;
			this.chbIsDeductUser.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.chbIsDeductUser.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.chbIsDeductUser.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.chbIsDeductUser.ForeColor = System.Drawing.Color.Black;
			this.chbIsDeductUser.Location = new System.Drawing.Point(187, 114);
			this.chbIsDeductUser.Name = "chbIsDeductUser";
			this.chbIsDeductUser.Size = new System.Drawing.Size(76, 24);
			this.chbIsDeductUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.chbIsDeductUser.TabIndex = 175;
			this.chbIsDeductUser.Text = "扣吨员";
			// 
			// chbIsSupper
			// 
			this.chbIsSupper.AutoSize = true;
			this.chbIsSupper.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.chbIsSupper.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.chbIsSupper.Enabled = false;
			this.chbIsSupper.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.chbIsSupper.ForeColor = System.Drawing.Color.Black;
			this.chbIsSupper.Location = new System.Drawing.Point(293, 114);
			this.chbIsSupper.Name = "chbIsSupper";
			this.chbIsSupper.Size = new System.Drawing.Size(108, 24);
			this.chbIsSupper.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.chbIsSupper.TabIndex = 170;
			this.chbIsSupper.Text = "超级管理员";
			// 
			// txtUserName
			// 
			this.txtUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
			// 
			// 
			// 
			this.txtUserName.Border.Class = "TextBoxBorder";
			this.txtUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.txtUserName.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.txtUserName.ForeColor = System.Drawing.Color.White;
			this.txtUserName.Location = new System.Drawing.Point(405, 23);
			this.txtUserName.MaxLength = 64;
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(176, 27);
			this.txtUserName.TabIndex = 166;
			// 
			// labelX4
			// 
			this.labelX4.AutoSize = true;
			this.labelX4.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX4.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.labelX4.ForeColor = System.Drawing.Color.White;
			this.labelX4.Location = new System.Drawing.Point(334, 26);
			this.labelX4.Name = "labelX4";
			this.labelX4.Size = new System.Drawing.Size(65, 24);
			this.labelX4.TabIndex = 174;
			this.labelX4.Text = "昵      称";
			// 
			// txtCreateDate
			// 
			this.txtCreateDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
			// 
			// 
			// 
			this.txtCreateDate.Border.Class = "TextBoxBorder";
			this.txtCreateDate.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.txtCreateDate.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.txtCreateDate.ForeColor = System.Drawing.Color.White;
			this.txtCreateDate.Location = new System.Drawing.Point(405, 62);
			this.txtCreateDate.MaxLength = 16;
			this.txtCreateDate.Name = "txtCreateDate";
			this.txtCreateDate.ReadOnly = true;
			this.txtCreateDate.Size = new System.Drawing.Size(176, 27);
			this.txtCreateDate.TabIndex = 168;
			// 
			// labelX5
			// 
			this.labelX5.AutoSize = true;
			this.labelX5.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX5.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.labelX5.ForeColor = System.Drawing.Color.White;
			this.labelX5.Location = new System.Drawing.Point(334, 65);
			this.labelX5.Name = "labelX5";
			this.labelX5.Size = new System.Drawing.Size(72, 24);
			this.labelX5.TabIndex = 173;
			this.labelX5.Text = "创建时间";
			// 
			// chbIsUse
			// 
			this.chbIsUse.AutoSize = true;
			this.chbIsUse.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.chbIsUse.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.chbIsUse.Checked = true;
			this.chbIsUse.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chbIsUse.CheckValue = "Y";
			this.chbIsUse.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.chbIsUse.ForeColor = System.Drawing.Color.Black;
			this.chbIsUse.Location = new System.Drawing.Point(86, 114);
			this.chbIsUse.Name = "chbIsUse";
			this.chbIsUse.Size = new System.Drawing.Size(77, 24);
			this.chbIsUse.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.chbIsUse.TabIndex = 169;
			this.chbIsUse.Text = "启    用";
			// 
			// txtUserPassword
			// 
			this.txtUserPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
			// 
			// 
			// 
			this.txtUserPassword.Border.Class = "TextBoxBorder";
			this.txtUserPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.txtUserPassword.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.txtUserPassword.ForeColor = System.Drawing.Color.White;
			this.txtUserPassword.Location = new System.Drawing.Point(85, 62);
			this.txtUserPassword.MaxLength = 16;
			this.txtUserPassword.Name = "txtUserPassword";
			this.txtUserPassword.Size = new System.Drawing.Size(176, 27);
			this.txtUserPassword.TabIndex = 167;
			// 
			// labelX6
			// 
			this.labelX6.AutoSize = true;
			this.labelX6.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX6.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.labelX6.ForeColor = System.Drawing.Color.White;
			this.labelX6.Location = new System.Drawing.Point(20, 65);
			this.labelX6.Name = "labelX6";
			this.labelX6.Size = new System.Drawing.Size(65, 24);
			this.labelX6.TabIndex = 172;
			this.labelX6.Text = "密      码";
			// 
			// txtUserAccount
			// 
			this.txtUserAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
			// 
			// 
			// 
			this.txtUserAccount.Border.Class = "TextBoxBorder";
			this.txtUserAccount.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.txtUserAccount.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.txtUserAccount.ForeColor = System.Drawing.Color.White;
			this.txtUserAccount.Location = new System.Drawing.Point(85, 23);
			this.txtUserAccount.MaxLength = 64;
			this.txtUserAccount.Name = "txtUserAccount";
			this.txtUserAccount.Size = new System.Drawing.Size(176, 27);
			this.txtUserAccount.TabIndex = 165;
			// 
			// labelX7
			// 
			this.labelX7.AutoSize = true;
			this.labelX7.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX7.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.labelX7.ForeColor = System.Drawing.Color.White;
			this.labelX7.Location = new System.Drawing.Point(20, 26);
			this.labelX7.Name = "labelX7";
			this.labelX7.Size = new System.Drawing.Size(65, 24);
			this.labelX7.TabIndex = 171;
			this.labelX7.Text = "账      号";
			// 
			// FrmUserInfo_Oper
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(610, 203);
			this.Controls.Add(this.tableLayoutPanel1);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "FrmUserInfo_Oper";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "用户管理详情";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmUserInfo_Oper_FormClosed);
			this.Load += new System.EventHandler(this.FrmUserInfo_Oper_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panelEx1.ResumeLayout(false);
			this.panelEx2.ResumeLayout(false);
			this.panelEx2.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnSubmit;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.Controls.CheckBoxX chbIsDeductUser;
        private DevComponents.DotNetBar.Controls.CheckBoxX chbIsSupper;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUserName;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCreateDate;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.CheckBoxX chbIsUse;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUserPassword;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUserAccount;
        private DevComponents.DotNetBar.LabelX labelX7;
    }
}