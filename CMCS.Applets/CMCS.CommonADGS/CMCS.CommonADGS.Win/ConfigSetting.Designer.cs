﻿namespace CMCS.CommonADGS.Win
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
            this.txtSelfConnStr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sendData = new System.Windows.Forms.RadioButton();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.txtServerIp = new System.Windows.Forms.TextBox();
            this.txtOracleKeywords = new System.Windows.Forms.TextBox();
            this.extractData = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.btnBase = new System.Windows.Forms.Button();
            this.txtGrabInterval = new System.Windows.Forms.NumericUpDown();
            this.ckVerifyBeforeClose = new System.Windows.Forms.CheckBox();
            this.ckIsSecretRunning = new System.Windows.Forms.CheckBox();
            this.ckStartup = new System.Windows.Forms.CheckBox();
            this.txtAppIdentifier = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtProcessName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDataPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSaveAssay = new System.Windows.Forms.Button();
            this.selfDefineGraber = new System.Windows.Forms.RadioButton();
            this.sysGraber = new System.Windows.Forms.RadioButton();
            this.txtDayRange = new System.Windows.Forms.NumericUpDown();
            this.ckEnabled = new System.Windows.Forms.CheckBox();
            this.ddlDbType = new System.Windows.Forms.ComboBox();
            this.txtGaberType = new System.Windows.Forms.TextBox();
            this.txtSQL = new System.Windows.Forms.TextBox();
            this.txtPrimaryKeys = new System.Windows.Forms.TextBox();
            this.txtConnStr = new System.Windows.Forms.TextBox();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.txtMachineCode = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Instruments = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrabInterval)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDayRange)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSelfConnStr);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.sendData);
            this.groupBox1.Controls.Add(this.txtServerIp);
            this.groupBox1.Controls.Add(this.txtOracleKeywords);
            this.groupBox1.Controls.Add(this.extractData);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.btnBase);
            this.groupBox1.Controls.Add(this.txtGrabInterval);
            this.groupBox1.Controls.Add(this.ckVerifyBeforeClose);
            this.groupBox1.Controls.Add(this.ckIsSecretRunning);
            this.groupBox1.Controls.Add(this.ckStartup);
            this.groupBox1.Controls.Add(this.txtAppIdentifier);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(915, 217);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "保存基础配置";
            // 
            // txtSelfConnStr
            // 
            this.txtSelfConnStr.Location = new System.Drawing.Point(218, 80);
            this.txtSelfConnStr.Multiline = true;
            this.txtSelfConnStr.Name = "txtSelfConnStr";
            this.txtSelfConnStr.Size = new System.Drawing.Size(292, 43);
            this.txtSelfConnStr.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Oracle数据库连接字符串";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(303, 358);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 12);
            this.label18.TabIndex = 3;
            this.label18.Text = "服务器端口";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(563, 87);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 3;
            this.label17.Text = "服务器IP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Oracle关键字,多个使用“|”分割";
            // 
            // sendData
            // 
            this.sendData.AutoSize = true;
            this.sendData.Location = new System.Drawing.Point(333, 58);
            this.sendData.Name = "sendData";
            this.sendData.Size = new System.Drawing.Size(71, 16);
            this.sendData.TabIndex = 35;
            this.sendData.Text = "上传文件";
            this.sendData.UseVisualStyleBackColor = true;
            this.sendData.CheckedChanged += new System.EventHandler(this.extractType_CheckedChanged);
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(383, 354);
            this.txtServerPort.Multiline = true;
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(244, 21);
            this.txtServerPort.TabIndex = 8;
            // 
            // txtServerIp
            // 
            this.txtServerIp.Location = new System.Drawing.Point(622, 84);
            this.txtServerIp.Multiline = true;
            this.txtServerIp.Name = "txtServerIp";
            this.txtServerIp.Size = new System.Drawing.Size(244, 21);
            this.txtServerIp.TabIndex = 8;
            // 
            // txtOracleKeywords
            // 
            this.txtOracleKeywords.Location = new System.Drawing.Point(218, 129);
            this.txtOracleKeywords.Multiline = true;
            this.txtOracleKeywords.Name = "txtOracleKeywords";
            this.txtOracleKeywords.Size = new System.Drawing.Size(292, 21);
            this.txtOracleKeywords.TabIndex = 8;
            // 
            // extractData
            // 
            this.extractData.AutoSize = true;
            this.extractData.Checked = true;
            this.extractData.Location = new System.Drawing.Point(218, 58);
            this.extractData.Name = "extractData";
            this.extractData.Size = new System.Drawing.Size(71, 16);
            this.extractData.TabIndex = 34;
            this.extractData.TabStop = true;
            this.extractData.Text = "读取数据";
            this.extractData.UseVisualStyleBackColor = true;
            this.extractData.CheckedChanged += new System.EventHandler(this.extractType_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(150, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 33;
            this.label16.Text = "提取类型";
            // 
            // btnBase
            // 
            this.btnBase.Location = new System.Drawing.Point(800, 185);
            this.btnBase.Name = "btnBase";
            this.btnBase.Size = new System.Drawing.Size(109, 23);
            this.btnBase.TabIndex = 30;
            this.btnBase.Text = "保存基础配置";
            this.btnBase.UseVisualStyleBackColor = true;
            this.btnBase.Click += new System.EventHandler(this.btnBase_Click);
            // 
            // txtGrabInterval
            // 
            this.txtGrabInterval.Location = new System.Drawing.Point(218, 156);
            this.txtGrabInterval.Name = "txtGrabInterval";
            this.txtGrabInterval.Size = new System.Drawing.Size(120, 21);
            this.txtGrabInterval.TabIndex = 29;
            this.txtGrabInterval.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // ckVerifyBeforeClose
            // 
            this.ckVerifyBeforeClose.AutoSize = true;
            this.ckVerifyBeforeClose.Checked = true;
            this.ckVerifyBeforeClose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckVerifyBeforeClose.Location = new System.Drawing.Point(390, 192);
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
            this.ckIsSecretRunning.Location = new System.Drawing.Point(300, 192);
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
            this.ckStartup.Location = new System.Drawing.Point(218, 192);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "提取间隔 单位：分钟";
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
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(12, 233);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(915, 503);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "化验设备数据抓取配置";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtProcessName);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.txtDataPath);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnSaveAssay);
            this.groupBox3.Controls.Add(this.selfDefineGraber);
            this.groupBox3.Controls.Add(this.txtServerPort);
            this.groupBox3.Controls.Add(this.sysGraber);
            this.groupBox3.Controls.Add(this.txtDayRange);
            this.groupBox3.Controls.Add(this.ckEnabled);
            this.groupBox3.Controls.Add(this.ddlDbType);
            this.groupBox3.Controls.Add(this.txtGaberType);
            this.groupBox3.Controls.Add(this.txtSQL);
            this.groupBox3.Controls.Add(this.txtPrimaryKeys);
            this.groupBox3.Controls.Add(this.txtConnStr);
            this.groupBox3.Controls.Add(this.txtTableName);
            this.groupBox3.Controls.Add(this.txtMachineCode);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.Instruments);
            this.groupBox3.Location = new System.Drawing.Point(7, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(902, 476);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "化验设备";
            // 
            // txtProcessName
            // 
            this.txtProcessName.Enabled = false;
            this.txtProcessName.Location = new System.Drawing.Point(383, 413);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.Size = new System.Drawing.Size(513, 21);
            this.txtProcessName.TabIndex = 35;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(315, 416);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 34;
            this.label14.Text = "进程名称";
            // 
            // txtDataPath
            // 
            this.txtDataPath.Enabled = false;
            this.txtDataPath.Location = new System.Drawing.Point(383, 382);
            this.txtDataPath.Name = "txtDataPath";
            this.txtDataPath.Size = new System.Drawing.Size(513, 21);
            this.txtDataPath.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(291, 385);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 34;
            this.label5.Text = "数据文件路径";
            // 
            // btnSaveAssay
            // 
            this.btnSaveAssay.Location = new System.Drawing.Point(777, 438);
            this.btnSaveAssay.Name = "btnSaveAssay";
            this.btnSaveAssay.Size = new System.Drawing.Size(119, 32);
            this.btnSaveAssay.TabIndex = 33;
            this.btnSaveAssay.Text = "保    存";
            this.btnSaveAssay.UseVisualStyleBackColor = true;
            this.btnSaveAssay.Click += new System.EventHandler(this.btnSaveAssay_Click);
            // 
            // selfDefineGraber
            // 
            this.selfDefineGraber.AutoSize = true;
            this.selfDefineGraber.Location = new System.Drawing.Point(498, 18);
            this.selfDefineGraber.Name = "selfDefineGraber";
            this.selfDefineGraber.Size = new System.Drawing.Size(83, 16);
            this.selfDefineGraber.TabIndex = 32;
            this.selfDefineGraber.Text = "自定义抓取";
            this.selfDefineGraber.UseVisualStyleBackColor = true;
            this.selfDefineGraber.CheckedChanged += new System.EventHandler(this.sysGraber_CheckedChanged);
            // 
            // sysGraber
            // 
            this.sysGraber.AutoSize = true;
            this.sysGraber.Checked = true;
            this.sysGraber.Location = new System.Drawing.Point(383, 18);
            this.sysGraber.Name = "sysGraber";
            this.sysGraber.Size = new System.Drawing.Size(95, 16);
            this.sysGraber.TabIndex = 31;
            this.sysGraber.TabStop = true;
            this.sysGraber.Text = "系统内置抓取";
            this.sysGraber.UseVisualStyleBackColor = true;
            this.sysGraber.CheckedChanged += new System.EventHandler(this.sysGraber_CheckedChanged);
            // 
            // txtDayRange
            // 
            this.txtDayRange.Enabled = false;
            this.txtDayRange.Location = new System.Drawing.Point(383, 327);
            this.txtDayRange.Name = "txtDayRange";
            this.txtDayRange.Size = new System.Drawing.Size(120, 21);
            this.txtDayRange.TabIndex = 30;
            this.txtDayRange.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // ckEnabled
            // 
            this.ckEnabled.AutoSize = true;
            this.ckEnabled.Checked = true;
            this.ckEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckEnabled.Location = new System.Drawing.Point(383, 445);
            this.ckEnabled.Name = "ckEnabled";
            this.ckEnabled.Size = new System.Drawing.Size(72, 16);
            this.ckEnabled.TabIndex = 9;
            this.ckEnabled.Text = "是否启用";
            this.ckEnabled.UseVisualStyleBackColor = true;
            // 
            // ddlDbType
            // 
            this.ddlDbType.Enabled = false;
            this.ddlDbType.FormattingEnabled = true;
            this.ddlDbType.Items.AddRange(new object[] {
            "Access",
            "SqlServer",
            "SQLite"});
            this.ddlDbType.Location = new System.Drawing.Point(383, 199);
            this.ddlDbType.Name = "ddlDbType";
            this.ddlDbType.Size = new System.Drawing.Size(225, 20);
            this.ddlDbType.TabIndex = 28;
            // 
            // txtGaberType
            // 
            this.txtGaberType.Enabled = false;
            this.txtGaberType.Location = new System.Drawing.Point(383, 293);
            this.txtGaberType.Name = "txtGaberType";
            this.txtGaberType.Size = new System.Drawing.Size(513, 21);
            this.txtGaberType.TabIndex = 25;
            // 
            // txtSQL
            // 
            this.txtSQL.Enabled = false;
            this.txtSQL.Location = new System.Drawing.Point(383, 231);
            this.txtSQL.Multiline = true;
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.Size = new System.Drawing.Size(513, 53);
            this.txtSQL.TabIndex = 24;
            // 
            // txtPrimaryKeys
            // 
            this.txtPrimaryKeys.Location = new System.Drawing.Point(383, 114);
            this.txtPrimaryKeys.Name = "txtPrimaryKeys";
            this.txtPrimaryKeys.Size = new System.Drawing.Size(513, 21);
            this.txtPrimaryKeys.TabIndex = 23;
            // 
            // txtConnStr
            // 
            this.txtConnStr.Location = new System.Drawing.Point(383, 147);
            this.txtConnStr.Multiline = true;
            this.txtConnStr.Name = "txtConnStr";
            this.txtConnStr.Size = new System.Drawing.Size(513, 41);
            this.txtConnStr.TabIndex = 22;
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(383, 81);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(513, 21);
            this.txtTableName.TabIndex = 20;
            // 
            // txtMachineCode
            // 
            this.txtMachineCode.Location = new System.Drawing.Point(383, 48);
            this.txtMachineCode.Name = "txtMachineCode";
            this.txtMachineCode.Size = new System.Drawing.Size(513, 21);
            this.txtMachineCode.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(237, 331);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(131, 12);
            this.label15.TabIndex = 19;
            this.label15.Text = "数据提取范围 单位：天";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(267, 298);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 12);
            this.label13.TabIndex = 17;
            this.label13.Text = "自定义数据提取类";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(291, 236);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 16;
            this.label12.Text = "数据查询语句";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(255, 203);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 12);
            this.label11.TabIndex = 15;
            this.label11.Text = "化验设备数据库类型";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(243, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "设备数据库连接字符串";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(219, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "主键名,多个使用“|”分割";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(279, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "Oracle存储表名";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(315, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "设备编号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(315, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "抓取类型";
            // 
            // Instruments
            // 
            this.Instruments.FormattingEnabled = true;
            this.Instruments.ItemHeight = 12;
            this.Instruments.Location = new System.Drawing.Point(6, 20);
            this.Instruments.Name = "Instruments";
            this.Instruments.Size = new System.Drawing.Size(203, 412);
            this.Instruments.TabIndex = 0;
            this.Instruments.SelectedIndexChanged += new System.EventHandler(this.Instruments_SelectedIndexChanged);
            // 
            // ConfigSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 738);
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
            ((System.ComponentModel.ISupportInitialize)(this.txtGrabInterval)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDayRange)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ckStartup;
        private System.Windows.Forms.TextBox txtOracleKeywords;
        private System.Windows.Forms.TextBox txtSelfConnStr;
        private System.Windows.Forms.TextBox txtAppIdentifier;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox Instruments;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox ckEnabled;
        private System.Windows.Forms.ComboBox ddlDbType;
        private System.Windows.Forms.TextBox txtGaberType;
        private System.Windows.Forms.TextBox txtSQL;
        private System.Windows.Forms.TextBox txtPrimaryKeys;
        private System.Windows.Forms.TextBox txtConnStr;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.TextBox txtMachineCode;
        private System.Windows.Forms.NumericUpDown txtGrabInterval;
        private System.Windows.Forms.NumericUpDown txtDayRange;
        private System.Windows.Forms.RadioButton selfDefineGraber;
        private System.Windows.Forms.RadioButton sysGraber;
        private System.Windows.Forms.Button btnSaveAssay;
        private System.Windows.Forms.Button btnBase;
        private System.Windows.Forms.CheckBox ckVerifyBeforeClose;
        private System.Windows.Forms.CheckBox ckIsSecretRunning;
        private System.Windows.Forms.TextBox txtDataPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProcessName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton sendData;
        private System.Windows.Forms.RadioButton extractData;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtServerIp;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtServerPort;
    }
}