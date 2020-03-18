namespace CMCS.CarTransport.Queue.Frms.BaseInfo.GoodsType
{
    partial class FrmGoodsType_List
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
			this.advTree1 = new DevComponents.AdvTree.AdvTree();
			this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
			this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
			this.btnAdd = new DevComponents.DotNetBar.ButtonX();
			this.btnUpdate = new DevComponents.DotNetBar.ButtonX();
			this.btnDelete = new DevComponents.DotNetBar.ButtonX();
			this.pnlMain = new DevComponents.DotNetBar.PanelEx();
			this.labelX1 = new DevComponents.DotNetBar.LabelX();
			this.txt_ReMark = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.btnCancel = new DevComponents.DotNetBar.ButtonX();
			this.txt_TreeCode = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.txt_GoodsName = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.btnSave = new DevComponents.DotNetBar.ButtonX();
			this.labelX3 = new DevComponents.DotNetBar.LabelX();
			this.dbi_OrderNumber = new DevComponents.Editors.IntegerInput();
			this.labelX6 = new DevComponents.DotNetBar.LabelX();
			this.chb_IsUse = new DevComponents.DotNetBar.Controls.CheckBoxX();
			this.labelX8 = new DevComponents.DotNetBar.LabelX();
			((System.ComponentModel.ISupportInitialize)(this.advTree1)).BeginInit();
			this.pnlMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dbi_OrderNumber)).BeginInit();
			this.SuspendLayout();
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
			this.advTree1.TabIndex = 5;
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
			// btnAdd
			// 
			this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.btnAdd.Location = new System.Drawing.Point(12, 11);
			this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(64, 23);
			this.btnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.btnAdd.TabIndex = 19;
			this.btnAdd.Text = "新 增";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
			this.btnUpdate.TabIndex = 20;
			this.btnUpdate.Text = "修 改";
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
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
			this.btnDelete.TabIndex = 21;
			this.btnDelete.Text = "删 除";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// pnlMain
			// 
			this.pnlMain.CanvasColor = System.Drawing.Color.Transparent;
			this.pnlMain.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.pnlMain.Controls.Add(this.labelX1);
			this.pnlMain.Controls.Add(this.txt_ReMark);
			this.pnlMain.Controls.Add(this.btnCancel);
			this.pnlMain.Controls.Add(this.txt_TreeCode);
			this.pnlMain.Controls.Add(this.txt_GoodsName);
			this.pnlMain.Controls.Add(this.btnSave);
			this.pnlMain.Controls.Add(this.labelX3);
			this.pnlMain.Controls.Add(this.dbi_OrderNumber);
			this.pnlMain.Controls.Add(this.labelX6);
			this.pnlMain.Controls.Add(this.chb_IsUse);
			this.pnlMain.Controls.Add(this.labelX8);
			this.pnlMain.Location = new System.Drawing.Point(473, 39);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(919, 606);
			this.pnlMain.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.pnlMain.Style.BackColor1.Color = System.Drawing.Color.Transparent;
			this.pnlMain.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.pnlMain.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.pnlMain.Style.GradientAngle = 90;
			this.pnlMain.TabIndex = 240;
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
			this.labelX1.Location = new System.Drawing.Point(19, 64);
			this.labelX1.Name = "labelX1";
			this.labelX1.Size = new System.Drawing.Size(72, 24);
			this.labelX1.TabIndex = 239;
			this.labelX1.Text = "物资编码";
			// 
			// txt_ReMark
			// 
			this.txt_ReMark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
			// 
			// 
			// 
			this.txt_ReMark.Border.Class = "TextBoxBorder";
			this.txt_ReMark.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.txt_ReMark.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.txt_ReMark.ForeColor = System.Drawing.Color.White;
			this.txt_ReMark.Location = new System.Drawing.Point(95, 103);
			this.txt_ReMark.Multiline = true;
			this.txt_ReMark.Name = "txt_ReMark";
			this.txt_ReMark.Size = new System.Drawing.Size(489, 106);
			this.txt_ReMark.TabIndex = 235;
			// 
			// btnCancel
			// 
			this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.btnCancel.Location = new System.Drawing.Point(520, 240);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(64, 23);
			this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.btnCancel.TabIndex = 238;
			this.btnCancel.Text = "取 消";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// txt_TreeCode
			// 
			this.txt_TreeCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
			// 
			// 
			// 
			this.txt_TreeCode.Border.Class = "TextBoxBorder";
			this.txt_TreeCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.txt_TreeCode.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.txt_TreeCode.ForeColor = System.Drawing.Color.White;
			this.txt_TreeCode.Location = new System.Drawing.Point(95, 61);
			this.txt_TreeCode.Name = "txt_TreeCode";
			this.txt_TreeCode.ReadOnly = true;
			this.txt_TreeCode.Size = new System.Drawing.Size(180, 27);
			this.txt_TreeCode.TabIndex = 226;
			this.txt_TreeCode.Text = "自动生成";
			// 
			// txt_GoodsName
			// 
			this.txt_GoodsName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
			// 
			// 
			// 
			this.txt_GoodsName.Border.Class = "TextBoxBorder";
			this.txt_GoodsName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.txt_GoodsName.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.txt_GoodsName.ForeColor = System.Drawing.Color.White;
			this.txt_GoodsName.Location = new System.Drawing.Point(95, 21);
			this.txt_GoodsName.Name = "txt_GoodsName";
			this.txt_GoodsName.Size = new System.Drawing.Size(180, 27);
			this.txt_GoodsName.TabIndex = 226;
			// 
			// btnSave
			// 
			this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.btnSave.Location = new System.Drawing.Point(450, 240);
			this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(64, 23);
			this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.btnSave.TabIndex = 237;
			this.btnSave.Text = "保 存";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
			this.labelX3.Location = new System.Drawing.Point(19, 24);
			this.labelX3.Name = "labelX3";
			this.labelX3.Size = new System.Drawing.Size(72, 24);
			this.labelX3.TabIndex = 227;
			this.labelX3.Text = "物资名称";
			// 
			// dbi_OrderNumber
			// 
			this.dbi_OrderNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
			// 
			// 
			// 
			this.dbi_OrderNumber.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
			this.dbi_OrderNumber.BackgroundStyle.Class = "DateTimeInputBackground";
			this.dbi_OrderNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dbi_OrderNumber.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
			this.dbi_OrderNumber.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.dbi_OrderNumber.ForeColor = System.Drawing.Color.White;
			this.dbi_OrderNumber.IsInputReadOnly = true;
			this.dbi_OrderNumber.Location = new System.Drawing.Point(404, 21);
			this.dbi_OrderNumber.MaxValue = 100000;
			this.dbi_OrderNumber.MinValue = 0;
			this.dbi_OrderNumber.Name = "dbi_OrderNumber";
			this.dbi_OrderNumber.Size = new System.Drawing.Size(180, 27);
			this.dbi_OrderNumber.TabIndex = 236;
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
			this.labelX6.Location = new System.Drawing.Point(344, 24);
			this.labelX6.Name = "labelX6";
			this.labelX6.Size = new System.Drawing.Size(56, 24);
			this.labelX6.TabIndex = 228;
			this.labelX6.Text = "顺序号";
			// 
			// chb_IsUse
			// 
			this.chb_IsUse.AutoSize = true;
			this.chb_IsUse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
			// 
			// 
			// 
			this.chb_IsUse.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.chb_IsUse.Checked = true;
			this.chb_IsUse.CheckSignSize = new System.Drawing.Size(15, 15);
			this.chb_IsUse.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chb_IsUse.CheckValue = "Y";
			this.chb_IsUse.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.chb_IsUse.ForeColor = System.Drawing.Color.White;
			this.chb_IsUse.Location = new System.Drawing.Point(404, 64);
			this.chb_IsUse.Name = "chb_IsUse";
			this.chb_IsUse.Size = new System.Drawing.Size(62, 24);
			this.chb_IsUse.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.chb_IsUse.TabIndex = 232;
			this.chb_IsUse.Text = "启用";
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
			this.labelX8.Location = new System.Drawing.Point(50, 105);
			this.labelX8.Name = "labelX8";
			this.labelX8.Size = new System.Drawing.Size(40, 24);
			this.labelX8.TabIndex = 234;
			this.labelX8.Text = "备注";
			// 
			// FrmGoodsType_List
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1370, 656);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.advTree1);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1420, 695);
			this.MinimumSize = new System.Drawing.Size(1364, 695);
			this.Name = "FrmGoodsType_List";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "物资";
			this.Shown += new System.EventHandler(this.FrmGoodsType_List_Shown);
			((System.ComponentModel.ISupportInitialize)(this.advTree1)).EndInit();
			this.pnlMain.ResumeLayout(false);
			this.pnlMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dbi_OrderNumber)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.AdvTree.AdvTree advTree1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.ButtonX btnUpdate;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private DevComponents.DotNetBar.PanelEx pnlMain;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_ReMark;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_TreeCode;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_GoodsName;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.IntegerInput dbi_OrderNumber;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.CheckBoxX chb_IsUse;
        private DevComponents.DotNetBar.LabelX labelX8;


    }
}