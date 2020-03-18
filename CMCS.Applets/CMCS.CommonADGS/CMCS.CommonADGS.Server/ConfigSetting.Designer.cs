namespace CMCS.CommonADGS.Server
{
    partial class ConfigSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigSetting));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBase = new System.Windows.Forms.Button();
            this.ckVerifyBeforeClose = new System.Windows.Forms.CheckBox();
            this.ckIsSecretRunning = new System.Windows.Forms.CheckBox();
            this.ckStartup = new System.Windows.Forms.CheckBox();
            this.txtAppIdentifier = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Instruments = new System.Windows.Forms.ListBox();
            this.btnSaveAssay = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.ckEnabled = new System.Windows.Forms.CheckBox();
            this.txtMachineCode = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBase);
            this.groupBox1.Controls.Add(this.ckVerifyBeforeClose);
            this.groupBox1.Controls.Add(this.ckIsSecretRunning);
            this.groupBox1.Controls.Add(this.ckStartup);
            this.groupBox1.Controls.Add(this.txtAppIdentifier);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(699, 102);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "保存基础配置";
            // 
            // btnBase
            // 
            this.btnBase.Location = new System.Drawing.Point(534, 64);
            this.btnBase.Name = "btnBase";
            this.btnBase.Size = new System.Drawing.Size(109, 23);
            this.btnBase.TabIndex = 30;
            this.btnBase.Text = "保存基础配置";
            this.btnBase.UseVisualStyleBackColor = true;
            this.btnBase.Click += new System.EventHandler(this.btnBase_Click);
            // 
            // ckVerifyBeforeClose
            // 
            this.ckVerifyBeforeClose.AutoSize = true;
            this.ckVerifyBeforeClose.Checked = true;
            this.ckVerifyBeforeClose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckVerifyBeforeClose.Location = new System.Drawing.Point(390, 64);
            this.ckVerifyBeforeClose.Name = "ckVerifyBeforeClose";
            this.ckVerifyBeforeClose.Size = new System.Drawing.Size(72, 16);
            this.ckVerifyBeforeClose.TabIndex = 1;
            this.ckVerifyBeforeClose.Text = "关闭验证";
            this.ckVerifyBeforeClose.UseVisualStyleBackColor = true;
            // 
            // ckIsSecretRunning
            // 
            this.ckIsSecretRunning.AutoSize = true;
            this.ckIsSecretRunning.Checked = true;
            this.ckIsSecretRunning.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckIsSecretRunning.Location = new System.Drawing.Point(300, 64);
            this.ckIsSecretRunning.Name = "ckIsSecretRunning";
            this.ckIsSecretRunning.Size = new System.Drawing.Size(84, 16);
            this.ckIsSecretRunning.TabIndex = 1;
            this.ckIsSecretRunning.Text = "最小化运行";
            this.ckIsSecretRunning.UseVisualStyleBackColor = true;
            // 
            // ckStartup
            // 
            this.ckStartup.AutoSize = true;
            this.ckStartup.Checked = true;
            this.ckStartup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckStartup.Location = new System.Drawing.Point(218, 64);
            this.ckStartup.Name = "ckStartup";
            this.ckStartup.Size = new System.Drawing.Size(72, 16);
            this.ckStartup.TabIndex = 1;
            this.ckStartup.Text = "开机启动";
            this.ckStartup.UseVisualStyleBackColor = true;
            // 
            // txtAppIdentifier
            // 
            this.txtAppIdentifier.Location = new System.Drawing.Point(218, 27);
            this.txtAppIdentifier.Name = "txtAppIdentifier";
            this.txtAppIdentifier.Size = new System.Drawing.Size(425, 21);
            this.txtAppIdentifier.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "程序唯一标识";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSavePath);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.Instruments);
            this.groupBox2.Controls.Add(this.btnSaveAssay);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtPort);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.ckEnabled);
            this.groupBox2.Controls.Add(this.txtMachineCode);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(699, 325);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接收端口";
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(312, 86);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(331, 21);
            this.txtSavePath.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 34;
            this.label5.Text = "存放路径";
            // 
            // Instruments
            // 
            this.Instruments.FormattingEnabled = true;
            this.Instruments.ItemHeight = 12;
            this.Instruments.Location = new System.Drawing.Point(15, 32);
            this.Instruments.Name = "Instruments";
            this.Instruments.Size = new System.Drawing.Size(203, 268);
            this.Instruments.TabIndex = 0;
            this.Instruments.SelectedIndexChanged += new System.EventHandler(this.Instruments_SelectedIndexChanged);
            // 
            // btnSaveAssay
            // 
            this.btnSaveAssay.Location = new System.Drawing.Point(524, 113);
            this.btnSaveAssay.Name = "btnSaveAssay";
            this.btnSaveAssay.Size = new System.Drawing.Size(119, 32);
            this.btnSaveAssay.TabIndex = 33;
            this.btnSaveAssay.Text = "保    存";
            this.btnSaveAssay.UseVisualStyleBackColor = true;
            this.btnSaveAssay.Click += new System.EventHandler(this.btnSaveAssay_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(244, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "设备编号";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(312, 59);
            this.txtPort.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(120, 21);
            this.txtPort.TabIndex = 30;
            this.txtPort.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(256, 63);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 19;
            this.label15.Text = "端口号";
            // 
            // ckEnabled
            // 
            this.ckEnabled.AutoSize = true;
            this.ckEnabled.Checked = true;
            this.ckEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckEnabled.Location = new System.Drawing.Point(312, 113);
            this.ckEnabled.Name = "ckEnabled";
            this.ckEnabled.Size = new System.Drawing.Size(72, 16);
            this.ckEnabled.TabIndex = 9;
            this.ckEnabled.Text = "是否启用";
            this.ckEnabled.UseVisualStyleBackColor = true;
            // 
            // txtMachineCode
            // 
            this.txtMachineCode.Location = new System.Drawing.Point(312, 32);
            this.txtMachineCode.Name = "txtMachineCode";
            this.txtMachineCode.Size = new System.Drawing.Size(331, 21);
            this.txtMachineCode.TabIndex = 9;
            // 
            // ConfigSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 457);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConfigSetting";
            this.Text = "煤质化验设备数据提取工具-配置程序";
            this.Load += new System.EventHandler(this.ConfigSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ckStartup;
        private System.Windows.Forms.TextBox txtAppIdentifier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox Instruments;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox ckEnabled;
        private System.Windows.Forms.TextBox txtMachineCode;
        private System.Windows.Forms.NumericUpDown txtPort;
        private System.Windows.Forms.Button btnSaveAssay;
        private System.Windows.Forms.Button btnBase;
        private System.Windows.Forms.CheckBox ckVerifyBeforeClose;
        private System.Windows.Forms.CheckBox ckIsSecretRunning;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Label label5;
    }
}