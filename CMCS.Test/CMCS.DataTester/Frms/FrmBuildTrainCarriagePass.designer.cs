namespace CMCS.DataTester.Frms
{
    partial class FrmBuildTrainCarriagePass
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
            this.txtMineName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMachineCode = new System.Windows.Forms.TextBox();
            this.txtCarNumber = new System.Windows.Forms.TextBox();
            this.btnBuild = new System.Windows.Forms.Button();
            this.cmbDirection = new System.Windows.Forms.ComboBox(); 
            this.SuspendLayout();
            // 
            // txtMineName
            // 
            this.txtMineName.AutoSize = true;
            this.txtMineName.Location = new System.Drawing.Point(57, 80);
            this.txtMineName.Name = "txtMineName";
            this.txtMineName.Size = new System.Drawing.Size(41, 12);
            this.txtMineName.TabIndex = 21;
            this.txtMineName.Text = "方向：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "车号：";
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
            // txtMachineCode
            // 
            this.txtMachineCode.Location = new System.Drawing.Point(104, 22);
            this.txtMachineCode.Name = "txtMachineCode";
            this.txtMachineCode.Size = new System.Drawing.Size(173, 21);
            this.txtMachineCode.TabIndex = 31;
            this.txtMachineCode.Text = "#1翻车机车号识别";
            // 
            // txtCarNumber
            // 
            this.txtCarNumber.Location = new System.Drawing.Point(104, 49);
            this.txtCarNumber.Name = "txtCarNumber";
            this.txtCarNumber.Size = new System.Drawing.Size(173, 21);
            this.txtCarNumber.TabIndex = 32;
            this.txtCarNumber.Text = "d22f9183";
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(104, 107);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(75, 23);
            this.btnBuild.TabIndex = 33;
            this.btnBuild.Text = "生成";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // cmbDirection
            // 
            this.cmbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDirection.FormattingEnabled = true;
            this.cmbDirection.Items.AddRange(new object[] {
            "进厂",
            "出厂"});
            this.cmbDirection.Location = new System.Drawing.Point(104, 76);
            this.cmbDirection.Name = "cmbDirection";
            this.cmbDirection.Size = new System.Drawing.Size(173, 20);
            this.cmbDirection.TabIndex = 34; 
            // 
            // FrmBuildTrainCarriagePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 142);
            this.Controls.Add(this.cmbDirection);
            this.Controls.Add(this.btnBuild);
            this.Controls.Add(this.txtCarNumber);
            this.Controls.Add(this.txtMachineCode);
            this.Controls.Add(this.txtMineName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "FrmBuildTrainCarriagePass";
            this.Text = "车号识别数据生成";
            this.Load += new System.EventHandler(this.FrmBuildTrainCarriagePass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtMineName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMachineCode;
        private System.Windows.Forms.TextBox txtCarNumber;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.ComboBox cmbDirection; 

    }
}