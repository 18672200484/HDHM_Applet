namespace CMCS.DataTester
{
    partial class MDIParent1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIParent1));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiSimulator = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenFrmIOSimulator = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenFrmWB231Simulator = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenFrmWB245Simulator = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsmiData = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenFrmBuildTrainWeightRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenFrmBuildTrainCarriagePass = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiData,
            this.tsmiSimulator,
            this.windowsMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.windowsMenu;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // tsmiSimulator
            // 
            this.tsmiSimulator.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenFrmIOSimulator,
            this.btnOpenFrmWB231Simulator,
            this.btnOpenFrmWB245Simulator});
            this.tsmiSimulator.Name = "tsmiSimulator";
            this.tsmiSimulator.Size = new System.Drawing.Size(59, 21);
            this.tsmiSimulator.Text = "模拟(&S)";
            // 
            // btnOpenFrmIOSimulator
            // 
            this.btnOpenFrmIOSimulator.Name = "btnOpenFrmIOSimulator";
            this.btnOpenFrmIOSimulator.Size = new System.Drawing.Size(240, 22);
            this.btnOpenFrmIOSimulator.Text = "精敏IO控制器模拟";
            this.btnOpenFrmIOSimulator.Click += new System.EventHandler(this.btnOpenFrmIOSimulator_Click);
            // 
            // btnOpenFrmWB231Simulator
            // 
            this.btnOpenFrmWB231Simulator.Name = "btnOpenFrmWB231Simulator";
            this.btnOpenFrmWB231Simulator.Size = new System.Drawing.Size(240, 22);
            this.btnOpenFrmWB231Simulator.Text = "托利多电子秤IND231模拟工具";
            this.btnOpenFrmWB231Simulator.Click += new System.EventHandler(this.btnOpenFrmWB231Simulator_Click);
            // 
            // btnOpenFrmWB245Simulator
            // 
            this.btnOpenFrmWB245Simulator.Name = "btnOpenFrmWB245Simulator";
            this.btnOpenFrmWB245Simulator.Size = new System.Drawing.Size(240, 22);
            this.btnOpenFrmWB245Simulator.Text = "托利多地磅IND245模拟工具";
            this.btnOpenFrmWB245Simulator.Click += new System.EventHandler(this.btnOpenFrmWBSimulator_Click);
            // 
            // windowsMenu
            // 
            this.windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem});
            this.windowsMenu.Name = "windowsMenu";
            this.windowsMenu.Size = new System.Drawing.Size(64, 21);
            this.windowsMenu.Text = "窗口(&W)";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.cascadeToolStripMenuItem.Text = "层叠(&C)";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.CascadeToolStripMenuItem_Click);
            // 
            // tileVerticalToolStripMenuItem
            // 
            this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.tileVerticalToolStripMenuItem.Text = "垂直平铺(&V)";
            this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.TileVerticalToolStripMenuItem_Click);
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.tileHorizontalToolStripMenuItem.Text = "水平平铺(&H)";
            this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.TileHorizontalToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.tsslblVersion});
            this.statusStrip.Location = new System.Drawing.Point(0, 396);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel.Text = "版本：";
            // 
            // tsslblVersion
            // 
            this.tsslblVersion.Name = "tsslblVersion";
            this.tsslblVersion.Size = new System.Drawing.Size(45, 17);
            this.tsslblVersion.Text = "1.0.0.0";
            // 
            // tsmiData
            // 
            this.tsmiData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenFrmBuildTrainWeightRecord,
            this.btnOpenFrmBuildTrainCarriagePass});
            this.tsmiData.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.tsmiData.Name = "tsmiData";
            this.tsmiData.Size = new System.Drawing.Size(59, 21);
            this.tsmiData.Text = "数据(&T)";
            // 
            // btnOpenFrmBuildTrainWeightRecord
            // 
            this.btnOpenFrmBuildTrainWeightRecord.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnOpenFrmBuildTrainWeightRecord.Name = "btnOpenFrmBuildTrainWeightRecord";
            this.btnOpenFrmBuildTrainWeightRecord.Size = new System.Drawing.Size(172, 22);
            this.btnOpenFrmBuildTrainWeightRecord.Text = "火车入厂数据生成";
            this.btnOpenFrmBuildTrainWeightRecord.Click += new System.EventHandler(this.btnOpenFrmBuildTrainWeightRecord_Click);
            // 
            // btnOpenFrmBuildTrainCarriagePass
            // 
            this.btnOpenFrmBuildTrainCarriagePass.Name = "btnOpenFrmBuildTrainCarriagePass";
            this.btnOpenFrmBuildTrainCarriagePass.Size = new System.Drawing.Size(172, 22);
            this.btnOpenFrmBuildTrainCarriagePass.Text = "车号识别数据生成";
            this.btnOpenFrmBuildTrainCarriagePass.Click += new System.EventHandler(this.btnOpenFrmBuildTrainCarriagePass_Click);
            // 
            // MDIParent1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 418);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MDIParent1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "燃料集中管控模拟测试工具";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MDIParent1_FormClosing);
            this.Load += new System.EventHandler(this.MDIParent1_Load);
            this.Shown += new System.EventHandler(this.MDIParent1_Shown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsMenu;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel tsslblVersion;
        private System.Windows.Forms.ToolStripMenuItem tsmiSimulator;
        private System.Windows.Forms.ToolStripMenuItem btnOpenFrmIOSimulator;
        private System.Windows.Forms.ToolStripMenuItem btnOpenFrmWB245Simulator;
        private System.Windows.Forms.ToolStripMenuItem btnOpenFrmWB231Simulator;
        private System.Windows.Forms.ToolStripMenuItem tsmiData;
        private System.Windows.Forms.ToolStripMenuItem btnOpenFrmBuildTrainWeightRecord;
        private System.Windows.Forms.ToolStripMenuItem btnOpenFrmBuildTrainCarriagePass;
    }
}



