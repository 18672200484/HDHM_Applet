using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMCS.DataTester.Frms;

namespace CMCS.DataTester
{
    public partial class MDIParent1 : Form
    {
        public MDIParent1()
        {
            InitializeComponent();
        }

        #region 窗口

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        #endregion

        private void MDIParent1_Load(object sender, EventArgs e)
        {

        }

        private void MDIParent1_Shown(object sender, EventArgs e)
        {

        }

        private void MDIParent1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        /// <summary>
        /// Invoke封装
        /// </summary>
        /// <param name="action"></param>
        public void InvokeEx(Action action)
        {
            if (this.IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(action);
        }

        /// <summary>
        /// 精敏IO控制器模拟
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFrmIOSimulator_Click(object sender, EventArgs e)
        {
            new FrmIOSimulator
           {
               MdiParent = this
           }.Show();
        }

        /// <summary>
        /// 托利多地磅IND245模拟工具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFrmWBSimulator_Click(object sender, EventArgs e)
        {
            new FrmWB245Simulator
           {
               MdiParent = this
           }.Show();
        }

        /// <summary>
        /// 托利多电子秤IND231模拟工具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFrmWB231Simulator_Click(object sender, EventArgs e)
        {
            new FrmWB231Simulator
            {
                MdiParent = this
            }.Show();
        }

        /// <summary>
        /// 火车入厂数据生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFrmBuildTrainWeightRecord_Click(object sender, EventArgs e)
        {
            new FrmBuildTrainWeightRecord
            {
                MdiParent = this
            }.Show();
        }

        /// <summary>
        /// 车号识别数据生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFrmBuildTrainCarriagePass_Click(object sender, EventArgs e)
        {
            new FrmBuildTrainCarriagePass
            {
                MdiParent = this
            }.Show();
        }
    }
}
