namespace CMCS.EPCEmpower
{
    partial class Form1
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvwReadResult = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbtnClientMode = new System.Windows.Forms.RadioButton();
            this.rbtnNetMode = new System.Windows.Forms.RadioButton();
            this.cmbCom = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStartScan = new System.Windows.Forms.Button();
            this.btnStartEmpower = new System.Windows.Forms.Button();
            this.chbAutoIncrease = new System.Windows.Forms.CheckBox();
            this.txtStartNumber = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrefixCode = new System.Windows.Forms.TextBox();
            this.btnOCRwer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvwEmpowered = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartNumber)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblVersion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 564);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(830, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel1.Text = "版本：";
            // 
            // lblVersion
            // 
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(45, 17);
            this.lblVersion.Text = "1.0.0.0";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(830, 564);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvwReadResult);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(409, 498);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " 扫描结果 ";
            // 
            // lvwReadResult
            // 
            this.lvwReadResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader1});
            this.lvwReadResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwReadResult.FullRowSelect = true;
            this.lvwReadResult.GridLines = true;
            this.lvwReadResult.Location = new System.Drawing.Point(3, 17);
            this.lvwReadResult.Name = "lvwReadResult";
            this.lvwReadResult.Size = new System.Drawing.Size(403, 478);
            this.lvwReadResult.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lvwReadResult.TabIndex = 5;
            this.lvwReadResult.UseCompatibleStateImageBehavior = false;
            this.lvwReadResult.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "序号";
            this.columnHeader3.Width = 40;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "标签号";
            this.columnHeader4.Width = 180;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "次数";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.cmbCom);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnStartScan);
            this.panel1.Controls.Add(this.btnStartEmpower);
            this.panel1.Controls.Add(this.chbAutoIncrease);
            this.panel1.Controls.Add(this.txtStartNumber);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPrefixCode);
            this.panel1.Controls.Add(this.btnOCRwer);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(824, 54);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbtnClientMode);
            this.panel2.Controls.Add(this.rbtnNetMode);
            this.panel2.Location = new System.Drawing.Point(552, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(80, 44);
            this.panel2.TabIndex = 14;
            // 
            // rbtnClientMode
            // 
            this.rbtnClientMode.AutoSize = true;
            this.rbtnClientMode.Checked = true;
            this.rbtnClientMode.Location = new System.Drawing.Point(5, 4);
            this.rbtnClientMode.Name = "rbtnClientMode";
            this.rbtnClientMode.Size = new System.Drawing.Size(71, 16);
            this.rbtnClientMode.TabIndex = 12;
            this.rbtnClientMode.TabStop = true;
            this.rbtnClientMode.Text = "单机模式";
            this.toolTip1.SetToolTip(this.rbtnClientMode, "只对标签卡进行授权");
            this.rbtnClientMode.UseVisualStyleBackColor = true;
            // 
            // rbtnNetMode
            // 
            this.rbtnNetMode.AutoSize = true;
            this.rbtnNetMode.Location = new System.Drawing.Point(5, 24);
            this.rbtnNetMode.Name = "rbtnNetMode";
            this.rbtnNetMode.Size = new System.Drawing.Size(71, 16);
            this.rbtnNetMode.TabIndex = 13;
            this.rbtnNetMode.Text = "联网模式";
            this.toolTip1.SetToolTip(this.rbtnNetMode, "对标签卡授权后，自动执行入库操作");
            this.rbtnNetMode.UseVisualStyleBackColor = true;
            this.rbtnNetMode.CheckedChanged += new System.EventHandler(this.rbtnNetMode_CheckedChanged);
            // 
            // cmbCom
            // 
            this.cmbCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCom.FormattingEnabled = true;
            this.cmbCom.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10"});
            this.cmbCom.Location = new System.Drawing.Point(43, 16);
            this.cmbCom.Name = "cmbCom";
            this.cmbCom.Size = new System.Drawing.Size(60, 20);
            this.cmbCom.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "串口";
            // 
            // btnStartScan
            // 
            this.btnStartScan.Enabled = false;
            this.btnStartScan.Location = new System.Drawing.Point(730, 15);
            this.btnStartScan.Name = "btnStartScan";
            this.btnStartScan.Size = new System.Drawing.Size(75, 23);
            this.btnStartScan.TabIndex = 9;
            this.btnStartScan.Text = "开始读卡";
            this.btnStartScan.UseVisualStyleBackColor = true;
            this.btnStartScan.Click += new System.EventHandler(this.btnStartScan_Click);
            // 
            // btnStartEmpower
            // 
            this.btnStartEmpower.Enabled = false;
            this.btnStartEmpower.Location = new System.Drawing.Point(649, 15);
            this.btnStartEmpower.Name = "btnStartEmpower";
            this.btnStartEmpower.Size = new System.Drawing.Size(75, 23);
            this.btnStartEmpower.TabIndex = 8;
            this.btnStartEmpower.Text = "开始授权";
            this.btnStartEmpower.UseVisualStyleBackColor = true;
            this.btnStartEmpower.Click += new System.EventHandler(this.btnStartEmpower_Click);
            // 
            // chbAutoIncrease
            // 
            this.chbAutoIncrease.AutoSize = true;
            this.chbAutoIncrease.Location = new System.Drawing.Point(498, 18);
            this.chbAutoIncrease.Name = "chbAutoIncrease";
            this.chbAutoIncrease.Size = new System.Drawing.Size(48, 16);
            this.chbAutoIncrease.TabIndex = 5;
            this.chbAutoIncrease.Text = "递增";
            this.chbAutoIncrease.UseVisualStyleBackColor = true;
            // 
            // txtStartNumber
            // 
            this.txtStartNumber.Location = new System.Drawing.Point(419, 16);
            this.txtStartNumber.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtStartNumber.Name = "txtStartNumber";
            this.txtStartNumber.Size = new System.Drawing.Size(73, 21);
            this.txtStartNumber.TabIndex = 4;
            this.txtStartNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(360, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "起始编号";
            // 
            // txtPrefixCode
            // 
            this.txtPrefixCode.Enabled = false;
            this.txtPrefixCode.Location = new System.Drawing.Point(249, 16);
            this.txtPrefixCode.Name = "txtPrefixCode";
            this.txtPrefixCode.Size = new System.Drawing.Size(100, 21);
            this.txtPrefixCode.TabIndex = 2;
            // 
            // btnOCRwer
            // 
            this.btnOCRwer.Location = new System.Drawing.Point(111, 15);
            this.btnOCRwer.Name = "btnOCRwer";
            this.btnOCRwer.Size = new System.Drawing.Size(75, 23);
            this.btnOCRwer.TabIndex = 1;
            this.btnOCRwer.Text = "连接发卡器";
            this.btnOCRwer.UseVisualStyleBackColor = true;
            this.btnOCRwer.Click += new System.EventHandler(this.btnOCRwer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "授权码";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvwEmpowered);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(418, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 498);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " 已授权列表 ";
            // 
            // lvwEmpowered
            // 
            this.lvwEmpowered.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader6,
            this.columnHeader7});
            this.lvwEmpowered.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwEmpowered.FullRowSelect = true;
            this.lvwEmpowered.GridLines = true;
            this.lvwEmpowered.Location = new System.Drawing.Point(3, 17);
            this.lvwEmpowered.Name = "lvwEmpowered";
            this.lvwEmpowered.Size = new System.Drawing.Size(403, 478);
            this.lvwEmpowered.TabIndex = 2;
            this.lvwEmpowered.UseCompatibleStateImageBehavior = false;
            this.lvwEmpowered.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "序号";
            this.columnHeader2.Width = 40;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "标签号";
            this.columnHeader6.Width = 180;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "授权时间";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 140;
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 586);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "标签卡授权工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartNumber)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblVersion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvwReadResult;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbtnClientMode;
        private System.Windows.Forms.RadioButton rbtnNetMode;
        private System.Windows.Forms.ComboBox cmbCom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStartScan;
        private System.Windows.Forms.Button btnStartEmpower;
        private System.Windows.Forms.CheckBox chbAutoIncrease;
        private System.Windows.Forms.NumericUpDown txtStartNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrefixCode;
        private System.Windows.Forms.Button btnOCRwer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvwEmpowered;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}

