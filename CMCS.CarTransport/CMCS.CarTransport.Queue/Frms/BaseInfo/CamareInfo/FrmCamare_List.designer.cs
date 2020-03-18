namespace CMCS.CarTransport.Queue.Frms.BaseInfo.CamareInfo
{
    partial class FrmCamare_List
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
            this.txt_Remark = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.pnlMain = new DevComponents.DotNetBar.PanelEx();
            this.txt_IP = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_Channel = new DevComponents.Editors.IntegerInput();
            this.txt_Port = new DevComponents.Editors.IntegerInput();
            this.dbi_Sequence = new DevComponents.Editors.IntegerInput();
            this.cmbCameraType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.txt_UserName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_Password = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_Code = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_EquipmentCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_CameraName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.advTree1 = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.btnUpdate = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Channel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Port)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbi_Sequence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Remark
            // 
            this.txt_Remark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.txt_Remark.Border.Class = "TextBoxBorder";
            this.txt_Remark.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_Remark.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txt_Remark.ForeColor = System.Drawing.Color.White;
            this.txt_Remark.Location = new System.Drawing.Point(95, 240);
            this.txt_Remark.Multiline = true;
            this.txt_Remark.Name = "txt_Remark";
            this.txt_Remark.Size = new System.Drawing.Size(489, 106);
            this.txt_Remark.TabIndex = 235;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnCancel.Location = new System.Drawing.Point(520, 410);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 238;
            this.btnCancel.Text = "取 消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnSave.Location = new System.Drawing.Point(450, 410);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 237;
            this.btnSave.Text = "保 存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.CanvasColor = System.Drawing.Color.Transparent;
            this.pnlMain.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlMain.Controls.Add(this.txt_IP);
            this.pnlMain.Controls.Add(this.txt_Channel);
            this.pnlMain.Controls.Add(this.txt_Port);
            this.pnlMain.Controls.Add(this.dbi_Sequence);
            this.pnlMain.Controls.Add(this.cmbCameraType);
            this.pnlMain.Controls.Add(this.txt_Remark);
            this.pnlMain.Controls.Add(this.btnCancel);
            this.pnlMain.Controls.Add(this.txt_UserName);
            this.pnlMain.Controls.Add(this.txt_Password);
            this.pnlMain.Controls.Add(this.txt_Code);
            this.pnlMain.Controls.Add(this.txt_EquipmentCode);
            this.pnlMain.Controls.Add(this.txt_CameraName);
            this.pnlMain.Controls.Add(this.btnSave);
            this.pnlMain.Controls.Add(this.labelX10);
            this.pnlMain.Controls.Add(this.labelX1);
            this.pnlMain.Controls.Add(this.labelX7);
            this.pnlMain.Controls.Add(this.labelX4);
            this.pnlMain.Controls.Add(this.labelX9);
            this.pnlMain.Controls.Add(this.labelX5);
            this.pnlMain.Controls.Add(this.labelX3);
            this.pnlMain.Controls.Add(this.labelX11);
            this.pnlMain.Controls.Add(this.labelX2);
            this.pnlMain.Controls.Add(this.labelX6);
            this.pnlMain.Controls.Add(this.labelX8);
            this.pnlMain.Location = new System.Drawing.Point(472, 39);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(919, 606);
            this.pnlMain.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlMain.Style.BackColor1.Color = System.Drawing.Color.Transparent;
            this.pnlMain.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlMain.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlMain.Style.GradientAngle = 90;
            this.pnlMain.TabIndex = 244;
            // 
            // txt_IP
            // 
            this.txt_IP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.txt_IP.Border.Class = "TextBoxBorder";
            this.txt_IP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_IP.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txt_IP.ForeColor = System.Drawing.Color.White;
            this.txt_IP.Location = new System.Drawing.Point(95, 196);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(180, 27);
            this.txt_IP.TabIndex = 245;
            // 
            // txt_Channel
            // 
            this.txt_Channel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.txt_Channel.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.txt_Channel.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txt_Channel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_Channel.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txt_Channel.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txt_Channel.ForeColor = System.Drawing.Color.White;
            this.txt_Channel.IsInputReadOnly = true;
            this.txt_Channel.Location = new System.Drawing.Point(95, 153);
            this.txt_Channel.MaxValue = 100000;
            this.txt_Channel.MinValue = 0;
            this.txt_Channel.Name = "txt_Channel";
            this.txt_Channel.Size = new System.Drawing.Size(180, 27);
            this.txt_Channel.TabIndex = 243;
            // 
            // txt_Port
            // 
            this.txt_Port.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.txt_Port.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.txt_Port.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txt_Port.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_Port.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txt_Port.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txt_Port.ForeColor = System.Drawing.Color.White;
            this.txt_Port.IsInputReadOnly = true;
            this.txt_Port.Location = new System.Drawing.Point(95, 109);
            this.txt_Port.MaxValue = 100000;
            this.txt_Port.MinValue = 0;
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(180, 27);
            this.txt_Port.TabIndex = 242;
            // 
            // dbi_Sequence
            // 
            this.dbi_Sequence.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.dbi_Sequence.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.dbi_Sequence.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dbi_Sequence.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dbi_Sequence.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.dbi_Sequence.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.dbi_Sequence.ForeColor = System.Drawing.Color.White;
            this.dbi_Sequence.IsInputReadOnly = true;
            this.dbi_Sequence.Location = new System.Drawing.Point(400, 23);
            this.dbi_Sequence.MaxValue = 100000;
            this.dbi_Sequence.MinValue = 0;
            this.dbi_Sequence.Name = "dbi_Sequence";
            this.dbi_Sequence.Size = new System.Drawing.Size(180, 27);
            this.dbi_Sequence.TabIndex = 241;
            // 
            // cmbCameraType
            // 
            this.cmbCameraType.DisplayMember = "Text";
            this.cmbCameraType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCameraType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCameraType.FocusHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.cmbCameraType.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.cmbCameraType.ForeColor = System.Drawing.Color.White;
            this.cmbCameraType.FormattingEnabled = true;
            this.cmbCameraType.ItemHeight = 21;
            this.cmbCameraType.Items.AddRange(new object[] {
            this.comboItem2,
            this.comboItem1});
            this.cmbCameraType.Location = new System.Drawing.Point(402, 109);
            this.cmbCameraType.Name = "cmbCameraType";
            this.cmbCameraType.Size = new System.Drawing.Size(178, 27);
            this.cmbCameraType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbCameraType.TabIndex = 239;
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "请选择摄像头类型";
            this.comboItem2.TextAlignment = System.Drawing.StringAlignment.Center;
            this.comboItem2.TextLineAlignment = System.Drawing.StringAlignment.Center;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "海康威视";
            this.comboItem1.TextAlignment = System.Drawing.StringAlignment.Center;
            this.comboItem1.TextLineAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txt_UserName
            // 
            this.txt_UserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.txt_UserName.Border.Class = "TextBoxBorder";
            this.txt_UserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_UserName.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txt_UserName.ForeColor = System.Drawing.Color.White;
            this.txt_UserName.Location = new System.Drawing.Point(95, 65);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(180, 27);
            this.txt_UserName.TabIndex = 226;
            // 
            // txt_Password
            // 
            this.txt_Password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.txt_Password.Border.Class = "TextBoxBorder";
            this.txt_Password.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_Password.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txt_Password.ForeColor = System.Drawing.Color.White;
            this.txt_Password.Location = new System.Drawing.Point(400, 66);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(180, 27);
            this.txt_Password.TabIndex = 226;
            // 
            // txt_Code
            // 
            this.txt_Code.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.txt_Code.Border.Class = "TextBoxBorder";
            this.txt_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_Code.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txt_Code.ForeColor = System.Drawing.Color.White;
            this.txt_Code.Location = new System.Drawing.Point(400, 196);
            this.txt_Code.Name = "txt_Code";
            this.txt_Code.ReadOnly = true;
            this.txt_Code.Size = new System.Drawing.Size(180, 27);
            this.txt_Code.TabIndex = 226;
            // 
            // txt_EquipmentCode
            // 
            this.txt_EquipmentCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.txt_EquipmentCode.Border.Class = "TextBoxBorder";
            this.txt_EquipmentCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_EquipmentCode.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txt_EquipmentCode.ForeColor = System.Drawing.Color.White;
            this.txt_EquipmentCode.Location = new System.Drawing.Point(400, 151);
            this.txt_EquipmentCode.Name = "txt_EquipmentCode";
            this.txt_EquipmentCode.Size = new System.Drawing.Size(180, 27);
            this.txt_EquipmentCode.TabIndex = 226;
            // 
            // txt_CameraName
            // 
            this.txt_CameraName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.txt_CameraName.Border.Class = "TextBoxBorder";
            this.txt_CameraName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_CameraName.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txt_CameraName.ForeColor = System.Drawing.Color.White;
            this.txt_CameraName.Location = new System.Drawing.Point(95, 23);
            this.txt_CameraName.Name = "txt_CameraName";
            this.txt_CameraName.Size = new System.Drawing.Size(180, 27);
            this.txt_CameraName.TabIndex = 226;
            // 
            // labelX10
            // 
            this.labelX10.AutoSize = true;
            this.labelX10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.labelX10.ForeColor = System.Drawing.Color.White;
            this.labelX10.Location = new System.Drawing.Point(51, 156);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(39, 24);
            this.labelX10.TabIndex = 227;
            this.labelX10.Text = "频道";
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
            this.labelX1.Location = new System.Drawing.Point(342, 24);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(54, 24);
            this.labelX1.TabIndex = 227;
            this.labelX1.Text = "顺序号";
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            this.labelX7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.labelX7.ForeColor = System.Drawing.Color.White;
            this.labelX7.Location = new System.Drawing.Point(36, 112);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(54, 24);
            this.labelX7.TabIndex = 227;
            this.labelX7.Text = "端口号";
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
            this.labelX4.Location = new System.Drawing.Point(36, 68);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(54, 24);
            this.labelX4.TabIndex = 227;
            this.labelX4.Text = "用户名";
            // 
            // labelX9
            // 
            this.labelX9.AutoSize = true;
            this.labelX9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.labelX9.ForeColor = System.Drawing.Color.White;
            this.labelX9.Location = new System.Drawing.Point(326, 153);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(70, 24);
            this.labelX9.TabIndex = 228;
            this.labelX9.Text = "设备编码";
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.labelX5.ForeColor = System.Drawing.Color.White;
            this.labelX5.Location = new System.Drawing.Point(311, 110);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(85, 24);
            this.labelX5.TabIndex = 228;
            this.labelX5.Text = "摄像头类型";
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
            this.labelX3.Location = new System.Drawing.Point(5, 24);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(85, 24);
            this.labelX3.TabIndex = 227;
            this.labelX3.Text = "摄像头名称";
            // 
            // labelX11
            // 
            this.labelX11.AutoSize = true;
            this.labelX11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.labelX11.ForeColor = System.Drawing.Color.White;
            this.labelX11.Location = new System.Drawing.Point(357, 197);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(39, 24);
            this.labelX11.TabIndex = 228;
            this.labelX11.Text = "编号";
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
            this.labelX2.Location = new System.Drawing.Point(357, 67);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(39, 24);
            this.labelX2.TabIndex = 228;
            this.labelX2.Text = "密码";
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            this.labelX6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.labelX6.ForeColor = System.Drawing.Color.White;
            this.labelX6.Location = new System.Drawing.Point(70, 197);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(20, 24);
            this.labelX6.TabIndex = 228;
            this.labelX6.Text = "IP";
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            this.labelX8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.labelX8.ForeColor = System.Drawing.Color.White;
            this.labelX8.Location = new System.Drawing.Point(42, 248);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(39, 24);
            this.labelX8.TabIndex = 234;
            this.labelX8.Text = "备注";
            // 
            // advTree1
            // 
            this.advTree1.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree1.AllowDrop = true;
            this.advTree1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.advTree1.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.advTree1.ForeColor = System.Drawing.Color.White;
            this.advTree1.Location = new System.Drawing.Point(12, 39);
            this.advTree1.Name = "advTree1";
            this.advTree1.NodesConnector = this.nodeConnector1;
            this.advTree1.NodeStyle = this.elementStyle1;
            this.advTree1.PathSeparator = ";";
            this.advTree1.Size = new System.Drawing.Size(428, 606);
            this.advTree1.Styles.Add(this.elementStyle1);
            this.advTree1.TabIndex = 240;
            this.advTree1.Text = "advTree1";
            this.advTree1.NodeClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.advTree1_NodeClick);
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(188)))), ((int)(((byte)(204)))));
            // 
            // elementStyle1
            // 
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.Color.White;
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnDelete.Location = new System.Drawing.Point(152, 11);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(64, 23);
            this.btnDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDelete.TabIndex = 243;
            this.btnDelete.Text = "删 除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnUpdate.Location = new System.Drawing.Point(82, 11);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(64, 23);
            this.btnUpdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUpdate.TabIndex = 242;
            this.btnUpdate.Text = "修 改";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnAdd.Location = new System.Drawing.Point(12, 11);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(64, 23);
            this.btnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdd.TabIndex = 241;
            this.btnAdd.Text = "新 增";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FrmCamare_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 657);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.advTree1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "FrmCamare_List";
            this.ShowIcon = false;
            this.Text = "摄像头管理";
            this.Shown += new System.EventHandler(this.FrmCamare_List_Shown);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Channel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Port)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbi_Sequence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txt_Remark;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.PanelEx pnlMain;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_CameraName;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.AdvTree.AdvTree advTree1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private DevComponents.DotNetBar.ButtonX btnUpdate;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_UserName;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_Password;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbCameraType;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_EquipmentCode;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.IntegerInput dbi_Sequence;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_Code;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.Editors.IntegerInput txt_Port;
        private DevComponents.Editors.IntegerInput txt_Channel;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_IP;
    }
}