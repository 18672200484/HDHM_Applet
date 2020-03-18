namespace CMCS.DataTester.Frms
{
    partial class FrmWB245Simulator
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
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmbCom = new System.Windows.Forms.ComboBox();
            this.btnCloseCom = new System.Windows.Forms.Button();
            this.btnOpenCom = new System.Windows.Forms.Button();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "串口";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15"});
            this.cmbCom.Location = new System.Drawing.Point(75, 15);
            this.cmbCom.Name = "cmbCom";
            this.cmbCom.Size = new System.Drawing.Size(100, 20);
            this.cmbCom.TabIndex = 43;
            // 
            // btnCloseCom
            // 
            this.btnCloseCom.Location = new System.Drawing.Point(262, 14);
            this.btnCloseCom.Name = "btnCloseCom";
            this.btnCloseCom.Size = new System.Drawing.Size(75, 23);
            this.btnCloseCom.TabIndex = 42;
            this.btnCloseCom.Text = "关闭";
            this.btnCloseCom.UseVisualStyleBackColor = true;
            this.btnCloseCom.Click += new System.EventHandler(this.btnColseCom_Click);
            // 
            // btnOpenCom
            // 
            this.btnOpenCom.Location = new System.Drawing.Point(181, 14);
            this.btnOpenCom.Name = "btnOpenCom";
            this.btnOpenCom.Size = new System.Drawing.Size(75, 23);
            this.btnOpenCom.TabIndex = 41;
            this.btnOpenCom.Text = "打开";
            this.btnOpenCom.UseVisualStyleBackColor = true;
            this.btnOpenCom.Click += new System.EventHandler(this.btnOpenCom_Click);
            // 
            // txtWeight
            // 
            this.txtWeight.Font = new System.Drawing.Font("宋体", 48F, System.Drawing.FontStyle.Bold);
            this.txtWeight.Location = new System.Drawing.Point(75, 50);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(262, 80);
            this.txtWeight.TabIndex = 44;
            this.txtWeight.Text = "0.35";
            this.txtWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmWB245Simulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 143);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.cmbCom);
            this.Controls.Add(this.btnCloseCom);
            this.Controls.Add(this.btnOpenCom);
            this.Controls.Add(this.label2);
            this.Name = "FrmWB245Simulator";
            this.Text = "托利多地磅IND245模拟工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmWBSimulator_FormClosing);
            this.Load += new System.EventHandler(this.FrmWBSimulator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cmbCom;
        private System.Windows.Forms.Button btnCloseCom;
        private System.Windows.Forms.Button btnOpenCom;
        private System.Windows.Forms.TextBox txtWeight;

    }
}