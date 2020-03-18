namespace CMCS.Monitor.Win.Frm.Sys
{
    partial class FrmSysMsg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSysMsg));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tlPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.flPanelButton = new System.Windows.Forms.FlowLayoutPanel();
            this.plnMain = new System.Windows.Forms.Panel();
            this.wbMessage = new System.Windows.Forms.WebBrowser();
            this.metroShell1 = new DevComponents.DotNetBar.Metro.MetroShell();
            this.tlPanelMain.SuspendLayout();
            this.plnMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tlPanelMain
            // 
            this.tlPanelMain.BackColor = System.Drawing.Color.Transparent;
            this.tlPanelMain.ColumnCount = 1;
            this.tlPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlPanelMain.Controls.Add(this.flPanelButton, 0, 2);
            this.tlPanelMain.Controls.Add(this.plnMain, 0, 1);
            this.tlPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlPanelMain.ForeColor = System.Drawing.Color.Black;
            this.tlPanelMain.Location = new System.Drawing.Point(0, 1);
            this.tlPanelMain.Name = "tlPanelMain";
            this.tlPanelMain.RowCount = 3;
            this.tlPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlPanelMain.Size = new System.Drawing.Size(316, 178);
            this.tlPanelMain.TabIndex = 0;
            // 
            // flPanelButton
            // 
            this.flPanelButton.ForeColor = System.Drawing.Color.Black;
            this.flPanelButton.Location = new System.Drawing.Point(3, 141);
            this.flPanelButton.Name = "flPanelButton";
            this.flPanelButton.Size = new System.Drawing.Size(309, 34);
            this.flPanelButton.TabIndex = 0;
            // 
            // plnMain
            // 
            this.plnMain.Controls.Add(this.wbMessage);
            this.plnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plnMain.ForeColor = System.Drawing.Color.Black;
            this.plnMain.Location = new System.Drawing.Point(3, 30);
            this.plnMain.Name = "plnMain";
            this.plnMain.Size = new System.Drawing.Size(310, 105);
            this.plnMain.TabIndex = 1;
            // 
            // wbMessage
            // 
            this.wbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbMessage.IsWebBrowserContextMenuEnabled = false;
            this.wbMessage.Location = new System.Drawing.Point(0, 0);
            this.wbMessage.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbMessage.Name = "wbMessage";
            this.wbMessage.ScrollBarsEnabled = false;
            this.wbMessage.Size = new System.Drawing.Size(310, 105);
            this.wbMessage.TabIndex = 0;
            // 
            // metroShell1
            // 
            this.metroShell1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.metroShell1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroShell1.CaptionVisible = true;
            this.metroShell1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroShell1.ForeColor = System.Drawing.Color.White;
            this.metroShell1.HelpButtonText = null;
            this.metroShell1.HelpButtonVisible = false;
            this.metroShell1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.metroShell1.Location = new System.Drawing.Point(0, 1);
            this.metroShell1.Name = "metroShell1";
            this.metroShell1.SettingsButtonVisible = false;
            this.metroShell1.Size = new System.Drawing.Size(316, 27);
            this.metroShell1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.metroShell1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.metroShell1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.metroShell1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.metroShell1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.metroShell1.SystemText.QatDialogAddButton = "&Add >>";
            this.metroShell1.SystemText.QatDialogCancelButton = "Cancel";
            this.metroShell1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.metroShell1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.metroShell1.SystemText.QatDialogOkButton = "OK";
            this.metroShell1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.metroShell1.SystemText.QatDialogRemoveButton = "&Remove";
            this.metroShell1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.metroShell1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.metroShell1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.metroShell1.TabIndex = 2;
            this.metroShell1.TabStripFont = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // Frm_SysMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 180);
            this.Controls.Add(this.metroShell1);
            this.Controls.Add(this.tlPanelMain);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(317, 180);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(317, 180);
            this.Name = "Frm_SysMsg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提示信息";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Frm_SysMsg_Load);
            this.tlPanelMain.ResumeLayout(false);
            this.plnMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tlPanelMain;
        private System.Windows.Forms.FlowLayoutPanel flPanelButton;
        private System.Windows.Forms.Panel plnMain;
        private DevComponents.DotNetBar.Metro.MetroShell metroShell1;
        private System.Windows.Forms.WebBrowser wbMessage;

    }
}