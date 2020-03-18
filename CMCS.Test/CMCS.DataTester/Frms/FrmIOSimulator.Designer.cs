namespace CMCS.DataTester.Frms
{
    partial class FrmIOSimulator
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flpanInput = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.flpanOutput = new System.Windows.Forms.FlowLayoutPanel();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.button28 = new System.Windows.Forms.Button();
            this.button29 = new System.Windows.Forms.Button();
            this.button30 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.button32 = new System.Windows.Forms.Button();
            this.button33 = new System.Windows.Forms.Button();
            this.button34 = new System.Windows.Forms.Button();
            this.button35 = new System.Windows.Forms.Button();
            this.button36 = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.button38 = new System.Windows.Forms.Button();
            this.button39 = new System.Windows.Forms.Button();
            this.button40 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnOpenCom = new System.Windows.Forms.Button();
            this.btnCloseCom = new System.Windows.Forms.Button();
            this.cmbCom = new System.Windows.Forms.ComboBox();
            this.flpanInput.SuspendLayout();
            this.flpanOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "输入信号";
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
            // flpanInput
            // 
            this.flpanInput.BackColor = System.Drawing.SystemColors.Control;
            this.flpanInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpanInput.Controls.Add(this.button1);
            this.flpanInput.Controls.Add(this.button2);
            this.flpanInput.Controls.Add(this.button3);
            this.flpanInput.Controls.Add(this.button4);
            this.flpanInput.Controls.Add(this.button5);
            this.flpanInput.Controls.Add(this.button6);
            this.flpanInput.Controls.Add(this.button7);
            this.flpanInput.Controls.Add(this.button8);
            this.flpanInput.Controls.Add(this.button9);
            this.flpanInput.Controls.Add(this.button10);
            this.flpanInput.Controls.Add(this.button11);
            this.flpanInput.Controls.Add(this.button12);
            this.flpanInput.Location = new System.Drawing.Point(75, 46);
            this.flpanInput.Name = "flpanInput";
            this.flpanInput.Size = new System.Drawing.Size(363, 74);
            this.flpanInput.TabIndex = 33;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 0;
            this.button1.Tag = "0";
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(39, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 30);
            this.button2.TabIndex = 1;
            this.button2.Tag = "0";
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Red;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(75, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(30, 30);
            this.button3.TabIndex = 2;
            this.button3.Tag = "0";
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Red;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(111, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(30, 30);
            this.button4.TabIndex = 3;
            this.button4.Tag = "0";
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Red;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(147, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(30, 30);
            this.button5.TabIndex = 4;
            this.button5.Tag = "0";
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Red;
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(183, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(30, 30);
            this.button6.TabIndex = 5;
            this.button6.Tag = "0";
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Red;
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(219, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(30, 30);
            this.button7.TabIndex = 6;
            this.button7.Tag = "0";
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Red;
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(255, 3);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(30, 30);
            this.button8.TabIndex = 7;
            this.button8.Tag = "0";
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Red;
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(291, 3);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(30, 30);
            this.button9.TabIndex = 8;
            this.button9.Tag = "0";
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Red;
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(327, 3);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(30, 30);
            this.button10.TabIndex = 9;
            this.button10.Tag = "0";
            this.button10.Text = "10";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Red;
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(3, 39);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(30, 30);
            this.button11.TabIndex = 10;
            this.button11.Tag = "0";
            this.button11.Text = "11";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Red;
            this.button12.ForeColor = System.Drawing.Color.White;
            this.button12.Location = new System.Drawing.Point(39, 39);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(30, 30);
            this.button12.TabIndex = 11;
            this.button12.Tag = "0";
            this.button12.Text = "12";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // flpanOutput
            // 
            this.flpanOutput.BackColor = System.Drawing.SystemColors.Control;
            this.flpanOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpanOutput.Controls.Add(this.button21);
            this.flpanOutput.Controls.Add(this.button22);
            this.flpanOutput.Controls.Add(this.button23);
            this.flpanOutput.Controls.Add(this.button24);
            this.flpanOutput.Controls.Add(this.button25);
            this.flpanOutput.Controls.Add(this.button26);
            this.flpanOutput.Controls.Add(this.button27);
            this.flpanOutput.Controls.Add(this.button28);
            this.flpanOutput.Controls.Add(this.button29);
            this.flpanOutput.Controls.Add(this.button30);
            this.flpanOutput.Controls.Add(this.button31);
            this.flpanOutput.Controls.Add(this.button32);
            this.flpanOutput.Controls.Add(this.button33);
            this.flpanOutput.Controls.Add(this.button34);
            this.flpanOutput.Controls.Add(this.button35);
            this.flpanOutput.Controls.Add(this.button36);
            this.flpanOutput.Controls.Add(this.button37);
            this.flpanOutput.Controls.Add(this.button38);
            this.flpanOutput.Controls.Add(this.button39);
            this.flpanOutput.Controls.Add(this.button40);
            this.flpanOutput.Location = new System.Drawing.Point(75, 131);
            this.flpanOutput.Name = "flpanOutput";
            this.flpanOutput.Size = new System.Drawing.Size(363, 74);
            this.flpanOutput.TabIndex = 35;
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.Color.Red;
            this.button21.ForeColor = System.Drawing.Color.White;
            this.button21.Location = new System.Drawing.Point(3, 3);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(30, 30);
            this.button21.TabIndex = 0;
            this.button21.Tag = "1";
            this.button21.Text = "1";
            this.button21.UseVisualStyleBackColor = false;
            // 
            // button22
            // 
            this.button22.BackColor = System.Drawing.Color.Red;
            this.button22.ForeColor = System.Drawing.Color.White;
            this.button22.Location = new System.Drawing.Point(39, 3);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(30, 30);
            this.button22.TabIndex = 1;
            this.button22.Tag = "2";
            this.button22.Text = "2";
            this.button22.UseVisualStyleBackColor = false;
            // 
            // button23
            // 
            this.button23.BackColor = System.Drawing.Color.Red;
            this.button23.ForeColor = System.Drawing.Color.White;
            this.button23.Location = new System.Drawing.Point(75, 3);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(30, 30);
            this.button23.TabIndex = 2;
            this.button23.Tag = "3";
            this.button23.Text = "3";
            this.button23.UseVisualStyleBackColor = false;
            // 
            // button24
            // 
            this.button24.BackColor = System.Drawing.Color.Red;
            this.button24.ForeColor = System.Drawing.Color.White;
            this.button24.Location = new System.Drawing.Point(111, 3);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(30, 30);
            this.button24.TabIndex = 3;
            this.button24.Tag = "4";
            this.button24.Text = "4";
            this.button24.UseVisualStyleBackColor = false;
            // 
            // button25
            // 
            this.button25.BackColor = System.Drawing.Color.Red;
            this.button25.ForeColor = System.Drawing.Color.White;
            this.button25.Location = new System.Drawing.Point(147, 3);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(30, 30);
            this.button25.TabIndex = 4;
            this.button25.Tag = "5";
            this.button25.Text = "5";
            this.button25.UseVisualStyleBackColor = false;
            // 
            // button26
            // 
            this.button26.BackColor = System.Drawing.Color.Red;
            this.button26.ForeColor = System.Drawing.Color.White;
            this.button26.Location = new System.Drawing.Point(183, 3);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(30, 30);
            this.button26.TabIndex = 5;
            this.button26.Tag = "6";
            this.button26.Text = "6";
            this.button26.UseVisualStyleBackColor = false;
            // 
            // button27
            // 
            this.button27.BackColor = System.Drawing.Color.Red;
            this.button27.ForeColor = System.Drawing.Color.White;
            this.button27.Location = new System.Drawing.Point(219, 3);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(30, 30);
            this.button27.TabIndex = 6;
            this.button27.Tag = "7";
            this.button27.Text = "7";
            this.button27.UseVisualStyleBackColor = false;
            // 
            // button28
            // 
            this.button28.BackColor = System.Drawing.Color.Red;
            this.button28.ForeColor = System.Drawing.Color.White;
            this.button28.Location = new System.Drawing.Point(255, 3);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(30, 30);
            this.button28.TabIndex = 7;
            this.button28.Tag = "8";
            this.button28.Text = "8";
            this.button28.UseVisualStyleBackColor = false;
            // 
            // button29
            // 
            this.button29.BackColor = System.Drawing.Color.Red;
            this.button29.ForeColor = System.Drawing.Color.White;
            this.button29.Location = new System.Drawing.Point(291, 3);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(30, 30);
            this.button29.TabIndex = 8;
            this.button29.Tag = "9";
            this.button29.Text = "9";
            this.button29.UseVisualStyleBackColor = false;
            // 
            // button30
            // 
            this.button30.BackColor = System.Drawing.Color.Red;
            this.button30.ForeColor = System.Drawing.Color.White;
            this.button30.Location = new System.Drawing.Point(327, 3);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(30, 30);
            this.button30.TabIndex = 9;
            this.button30.Tag = "10";
            this.button30.Text = "10";
            this.button30.UseVisualStyleBackColor = false;
            // 
            // button31
            // 
            this.button31.BackColor = System.Drawing.Color.Red;
            this.button31.ForeColor = System.Drawing.Color.White;
            this.button31.Location = new System.Drawing.Point(3, 39);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(30, 30);
            this.button31.TabIndex = 10;
            this.button31.Tag = "11";
            this.button31.Text = "11";
            this.button31.UseVisualStyleBackColor = false;
            // 
            // button32
            // 
            this.button32.BackColor = System.Drawing.Color.Red;
            this.button32.ForeColor = System.Drawing.Color.White;
            this.button32.Location = new System.Drawing.Point(39, 39);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(30, 30);
            this.button32.TabIndex = 11;
            this.button32.Tag = "12";
            this.button32.Text = "12";
            this.button32.UseVisualStyleBackColor = false;
            // 
            // button33
            // 
            this.button33.BackColor = System.Drawing.Color.Red;
            this.button33.ForeColor = System.Drawing.Color.White;
            this.button33.Location = new System.Drawing.Point(75, 39);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(30, 30);
            this.button33.TabIndex = 12;
            this.button33.Tag = "13";
            this.button33.Text = "13";
            this.button33.UseVisualStyleBackColor = false;
            // 
            // button34
            // 
            this.button34.BackColor = System.Drawing.Color.Red;
            this.button34.ForeColor = System.Drawing.Color.White;
            this.button34.Location = new System.Drawing.Point(111, 39);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(30, 30);
            this.button34.TabIndex = 13;
            this.button34.Tag = "14";
            this.button34.Text = "14";
            this.button34.UseVisualStyleBackColor = false;
            // 
            // button35
            // 
            this.button35.BackColor = System.Drawing.Color.Red;
            this.button35.ForeColor = System.Drawing.Color.White;
            this.button35.Location = new System.Drawing.Point(147, 39);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(30, 30);
            this.button35.TabIndex = 14;
            this.button35.Tag = "15";
            this.button35.Text = "15";
            this.button35.UseVisualStyleBackColor = false;
            // 
            // button36
            // 
            this.button36.BackColor = System.Drawing.Color.Red;
            this.button36.ForeColor = System.Drawing.Color.White;
            this.button36.Location = new System.Drawing.Point(183, 39);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(30, 30);
            this.button36.TabIndex = 15;
            this.button36.Tag = "16";
            this.button36.Text = "16";
            this.button36.UseVisualStyleBackColor = false;
            // 
            // button37
            // 
            this.button37.BackColor = System.Drawing.Color.Red;
            this.button37.ForeColor = System.Drawing.Color.White;
            this.button37.Location = new System.Drawing.Point(219, 39);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(30, 30);
            this.button37.TabIndex = 16;
            this.button37.Tag = "17";
            this.button37.Text = "17";
            this.button37.UseVisualStyleBackColor = false;
            // 
            // button38
            // 
            this.button38.BackColor = System.Drawing.Color.Red;
            this.button38.ForeColor = System.Drawing.Color.White;
            this.button38.Location = new System.Drawing.Point(255, 39);
            this.button38.Name = "button38";
            this.button38.Size = new System.Drawing.Size(30, 30);
            this.button38.TabIndex = 17;
            this.button38.Tag = "18";
            this.button38.Text = "18";
            this.button38.UseVisualStyleBackColor = false;
            // 
            // button39
            // 
            this.button39.BackColor = System.Drawing.Color.Red;
            this.button39.ForeColor = System.Drawing.Color.White;
            this.button39.Location = new System.Drawing.Point(291, 39);
            this.button39.Name = "button39";
            this.button39.Size = new System.Drawing.Size(30, 30);
            this.button39.TabIndex = 18;
            this.button39.Tag = "19";
            this.button39.Text = "19";
            this.button39.UseVisualStyleBackColor = false;
            // 
            // button40
            // 
            this.button40.BackColor = System.Drawing.Color.Red;
            this.button40.ForeColor = System.Drawing.Color.White;
            this.button40.Location = new System.Drawing.Point(327, 39);
            this.button40.Name = "button40";
            this.button40.Size = new System.Drawing.Size(30, 30);
            this.button40.TabIndex = 19;
            this.button40.Tag = "20";
            this.button40.Text = "20";
            this.button40.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "输出信号";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnOpenCom
            // 
            this.btnOpenCom.Location = new System.Drawing.Point(181, 14);
            this.btnOpenCom.Name = "btnOpenCom";
            this.btnOpenCom.Size = new System.Drawing.Size(75, 23);
            this.btnOpenCom.TabIndex = 38;
            this.btnOpenCom.Text = "打开";
            this.btnOpenCom.UseVisualStyleBackColor = true;
            this.btnOpenCom.Click += new System.EventHandler(this.btnOpenCom_Click);
            // 
            // btnCloseCom
            // 
            this.btnCloseCom.Location = new System.Drawing.Point(262, 14);
            this.btnCloseCom.Name = "btnCloseCom";
            this.btnCloseCom.Size = new System.Drawing.Size(75, 23);
            this.btnCloseCom.TabIndex = 39;
            this.btnCloseCom.Text = "关闭";
            this.btnCloseCom.UseVisualStyleBackColor = true;
            this.btnCloseCom.Click += new System.EventHandler(this.btnColseCom_Click);
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
            this.cmbCom.TabIndex = 40;
            // 
            // FrmIOSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 224);
            this.Controls.Add(this.cmbCom);
            this.Controls.Add(this.btnCloseCom);
            this.Controls.Add(this.btnOpenCom);
            this.Controls.Add(this.flpanOutput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flpanInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "FrmIOSimulator";
            this.Text = "精敏IO控制器模拟工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmIOSimulator_FormClosing);
            this.Load += new System.EventHandler(this.FrmIOSimulator_Load);
            this.flpanInput.ResumeLayout(false);
            this.flpanOutput.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flpanInput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.FlowLayoutPanel flpanOutput;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.Button button27;
        private System.Windows.Forms.Button button28;
        private System.Windows.Forms.Button button29;
        private System.Windows.Forms.Button button30;
        private System.Windows.Forms.Button button31;
        private System.Windows.Forms.Button button32;
        private System.Windows.Forms.Button button33;
        private System.Windows.Forms.Button button34;
        private System.Windows.Forms.Button button35;
        private System.Windows.Forms.Button button36;
        private System.Windows.Forms.Button button37;
        private System.Windows.Forms.Button button38;
        private System.Windows.Forms.Button button39;
        private System.Windows.Forms.Button button40;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnOpenCom;
        private System.Windows.Forms.Button btnCloseCom;
        private System.Windows.Forms.ComboBox cmbCom;

    }
}