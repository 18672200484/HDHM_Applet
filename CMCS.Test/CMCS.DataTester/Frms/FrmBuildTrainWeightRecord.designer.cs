namespace CMCS.DataTester.Frms
{
    partial class FrmBuildTrainWeightRecord
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
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMineName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMachineCode = new System.Windows.Forms.TextBox();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.txtMineName = new System.Windows.Forms.TextBox();
            this.txtFuelKindName = new System.Windows.Forms.TextBox();
            this.txtStationName = new System.Windows.Forms.TextBox();
            this.txtRecordCount = new System.Windows.Forms.NumericUpDown();
            this.txtInFactoryTime = new System.Windows.Forms.DateTimePicker();
            this.btnBuild = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtRecordCount)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 27;
            this.label7.Text = "生成记录数：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "发站：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 23;
            this.label4.Text = "煤种：";
            // 
            // lblMineName
            // 
            this.lblMineName.AutoSize = true;
            this.lblMineName.Location = new System.Drawing.Point(57, 107);
            this.lblMineName.Name = "lblMineName";
            this.lblMineName.Size = new System.Drawing.Size(41, 12);
            this.lblMineName.TabIndex = 21;
            this.lblMineName.Text = "矿点：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "供煤单位：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "设备编号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "进厂时间：";
            // 
            // txtMachineCode
            // 
            this.txtMachineCode.Location = new System.Drawing.Point(104, 22);
            this.txtMachineCode.Name = "txtMachineCode";
            this.txtMachineCode.Size = new System.Drawing.Size(173, 21);
            this.txtMachineCode.TabIndex = 30;
            this.txtMachineCode.Text = "#1动态衡";
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Location = new System.Drawing.Point(104, 76);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(173, 21);
            this.txtSupplierName.TabIndex = 31;
            this.txtSupplierName.Text = "山西中亚发商贸有限公司";
            // 
            // txtMineName
            // 
            this.txtMineName.Location = new System.Drawing.Point(104, 103);
            this.txtMineName.Name = "txtMineName";
            this.txtMineName.Size = new System.Drawing.Size(173, 21);
            this.txtMineName.TabIndex = 32;
            this.txtMineName.Text = "桃园矿";
            // 
            // txtFuelKindName
            // 
            this.txtFuelKindName.Location = new System.Drawing.Point(104, 130);
            this.txtFuelKindName.Name = "txtFuelKindName";
            this.txtFuelKindName.Size = new System.Drawing.Size(173, 21);
            this.txtFuelKindName.TabIndex = 33;
            this.txtFuelKindName.Text = "褐煤";
            // 
            // txtStationName
            // 
            this.txtStationName.Location = new System.Drawing.Point(104, 158);
            this.txtStationName.Name = "txtStationName";
            this.txtStationName.Size = new System.Drawing.Size(173, 21);
            this.txtStationName.TabIndex = 34;
            this.txtStationName.Text = "庄儿上";
            // 
            // txtRecordCount
            // 
            this.txtRecordCount.Location = new System.Drawing.Point(104, 185);
            this.txtRecordCount.Name = "txtRecordCount";
            this.txtRecordCount.Size = new System.Drawing.Size(173, 21);
            this.txtRecordCount.TabIndex = 35;
            this.txtRecordCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // txtInFactoryTime
            // 
            this.txtInFactoryTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.txtInFactoryTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtInFactoryTime.Location = new System.Drawing.Point(104, 49);
            this.txtInFactoryTime.Name = "txtInFactoryTime";
            this.txtInFactoryTime.Size = new System.Drawing.Size(173, 21);
            this.txtInFactoryTime.TabIndex = 36;
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(104, 212);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(75, 23);
            this.btnBuild.TabIndex = 37;
            this.btnBuild.Text = "生成";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // FrmBuildTrainWeightRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 250);
            this.Controls.Add(this.btnBuild);
            this.Controls.Add(this.txtInFactoryTime);
            this.Controls.Add(this.txtRecordCount);
            this.Controls.Add(this.txtStationName);
            this.Controls.Add(this.txtFuelKindName);
            this.Controls.Add(this.txtMineName);
            this.Controls.Add(this.txtSupplierName);
            this.Controls.Add(this.txtMachineCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblMineName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmBuildTrainWeightRecord";
            this.Text = "火车入厂数据生成";
            this.Load += new System.EventHandler(this.FrmBuildTrainWeightRecord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtRecordCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMineName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMachineCode;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.TextBox txtMineName;
        private System.Windows.Forms.TextBox txtFuelKindName;
        private System.Windows.Forms.TextBox txtStationName;
        private System.Windows.Forms.NumericUpDown txtRecordCount;
        private System.Windows.Forms.DateTimePicker txtInFactoryTime;
        private System.Windows.Forms.Button btnBuild;

    }
}