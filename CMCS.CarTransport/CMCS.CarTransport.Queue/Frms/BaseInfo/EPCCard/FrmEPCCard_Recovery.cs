using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CMCS.CarTransport.DAO;
using CMCS.CarTransport.Queue.Core;
using CMCS.CarTransport.Queue.Frms.BaseInfo.Autotruck;
using CMCS.Common;
using CMCS.Common.Entities.CarTransport;
using DevComponents.DotNetBar;

namespace CMCS.CarTransport.Queue.Frms.BaseInfo.EPCCard
{
    public partial class FrmEPCCard_Recovery : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FrmEPCCard_Recovery()
        {
            InitializeComponent();
        }

        CmcsEPCCard currCmcsEPCCard;
        /// <summary>
        /// 当前IC卡信息
        /// </summary>
        public CmcsEPCCard CurrCmcsEPCCard
        {
            get { return currCmcsEPCCard; }
            set
            {
                currCmcsEPCCard = value;
                if (value != null)
                {
                    txt_CardNumber.Text = value.CardNumber;
                    txt_TagId.Text = value.TagId;
                }
                else
                    txt_CardNumber.ResetText();
            }
        }

        CmcsAutotruck currCmcsAutotruck;
        /// <summary>
        /// 当前车辆信息
        /// </summary>
        public CmcsAutotruck CurrCmcsAutotruck
        {
            get { return currCmcsAutotruck; }
            set
            {
                currCmcsAutotruck = value;
                if (value != null)
                {
                    txt_CarNumber.Text = value.CarNumber;

                    this.CurrCmcsEPCCard = Dbers.GetInstance().SelfDber.Get<CmcsEPCCard>(value.EPCCardId);

                }
                else
                    txt_CarNumber.ResetText();
            }
        }

        private void FrmEPCCard_Recovery_Load(object sender, EventArgs e)
        {

        }

        private void FrmEPCCard_Recovery_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        /// <summary>
        /// 选择车辆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectAutotruck_Click(object sender, EventArgs e)
        {
            FrmAutotruck_Select frm = new FrmAutotruck_Select("and IsUse=1 order by CarNumber asc");
            if (frm.ShowDialog() == DialogResult.OK)
                this.CurrCmcsAutotruck = frm.Output;
        }

        /// <summary>
        /// 回收
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.CurrCmcsEPCCard != null && this.CurrCmcsAutotruck != null)
            {
                CmcsUnFinishTransport unFinishTransport = CarTransportDAO.GetInstance().GetUnFinishTransportByAutotruckId(this.CurrCmcsAutotruck.Id, this.CurrCmcsAutotruck.CarType);
                if (unFinishTransport != null)
                {
                    FrmTransport_Confirm frm = new FrmTransport_Confirm(unFinishTransport.TransportId, unFinishTransport.CarType);
                    if (frm.ShowDialog() == DialogResult.Yes)
                    {
                        this.CurrCmcsAutotruck.EPCCardId = string.Empty;
                        Dbers.GetInstance().SelfDber.Update(this.CurrCmcsAutotruck);
                        MessageBoxEx.Show("回收成功");
                        Reset();
                    }
                }
                else
                {
                    this.CurrCmcsAutotruck.EPCCardId = string.Empty;
                    Dbers.GetInstance().SelfDber.Update(this.CurrCmcsAutotruck);
                    MessageBoxEx.Show("回收成功");
                    Reset();
                }
            }
            else
                MessageBoxEx.Show("没有需要回收的卡");
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            try
            {
                List<string> tags = Hardwarer.Rwer2.ScanTags();
                if (tags.Count > 0)
                {
                    txt_TagId.Text = tags[0];
                    KeyEnterEven();
                }
            }
            catch { }
            timer1.Start();
        }

        private void txt_TagId_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                KeyEnterEven();
            }
        }

        private void KeyEnterEven()
        {
            if (!string.IsNullOrEmpty(txt_TagId.Text.Trim()))
            {
                this.CurrCmcsEPCCard = Dbers.GetInstance().SelfDber.Entity<CmcsEPCCard>("where TagId=:TagId", new { TagId = txt_TagId.Text.Trim() });
                if (this.CurrCmcsEPCCard != null)
                {
                    txt_CardNumber.Text = this.CurrCmcsEPCCard.CardNumber;
                    this.CurrCmcsAutotruck = Dbers.GetInstance().SelfDber.Entity<CmcsAutotruck>("where EPCCardId=:EPCCardId", new { EPCCardId = this.CurrCmcsEPCCard.Id });
                    if (this.CurrCmcsAutotruck != null)
                        txt_CarNumber.Text = this.CurrCmcsAutotruck.CarNumber;
                }
            }
        }

        private void Reset()
        {
            this.CurrCmcsEPCCard = null;
            this.CurrCmcsAutotruck = null;
            txt_TagId.ResetText();
        }

    }
}