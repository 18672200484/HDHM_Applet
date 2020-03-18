using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CMCS.CarTransport.Queue.Core;
using CMCS.CarTransport.Queue.Enums;
using CMCS.Common;
using CMCS.Common.Entities.CarTransport;
using DevComponents.DotNetBar;

namespace CMCS.CarTransport.Queue.Frms.BaseInfo.EPCCard
{
    public partial class FrmEPCCard_Oper : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region Var

        //业务id
        string PId = String.Empty;

        //编辑模式
        eEditMode EditMode = eEditMode.默认;

        CmcsEPCCard CmcsepcCard;

        #endregion

        public FrmEPCCard_Oper(string pId, eEditMode editMode)
        {
            InitializeComponent();

            this.PId = pId;
            this.EditMode = editMode;
        }

        /// <summary>
        /// 窗体加载绑定数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmEPCCard_Oper_Load(object sender, EventArgs e)
        {
            this.CmcsepcCard = Dbers.GetInstance().SelfDber.Get<CmcsEPCCard>(this.PId);
            if (this.CmcsepcCard != null)
            {
                txt_CardNumber.Text = CmcsepcCard.CardNumber;
                txt_TagId.Text = CmcsepcCard.TagId;
            }

            if (this.EditMode == eEditMode.查看)
            {
                btnSubmit.Enabled = false;
                HelperUtil.ControlReadOnly(panelEx2, true);
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txt_CardNumber.Text.Length == 0)
            {
                MessageBoxEx.Show("该标卡号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (txt_TagId.Text.Length == 0)
            {
                MessageBoxEx.Show("该标签号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if ((CmcsepcCard == null || CmcsepcCard.CardNumber != txt_CardNumber.Text) && Dbers.GetInstance().SelfDber.Entities<CmcsEPCCard>(" where CardNumber=:CardNumber", new { CardNumber = txt_CardNumber.Text }).Count > 0)
            {
                MessageBoxEx.Show("该标卡号不可重复！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((CmcsepcCard == null || CmcsepcCard.TagId != txt_TagId.Text) && Dbers.GetInstance().SelfDber.Entities<CmcsEPCCard>(" where TagId=:TagId", new { TagId = txt_TagId.Text }).Count > 0)
            {
                MessageBoxEx.Show("该标签号不可重复！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.EditMode == eEditMode.修改)
            {
                CmcsepcCard.CardNumber = txt_CardNumber.Text;
                CmcsepcCard.TagId = txt_TagId.Text;
                Dbers.GetInstance().SelfDber.Update(CmcsepcCard);
            }
            else if (this.EditMode == eEditMode.新增)
            {
                CmcsepcCard = new CmcsEPCCard();
                CmcsepcCard.CardNumber = txt_CardNumber.Text;
                CmcsepcCard.TagId = txt_TagId.Text;
                Dbers.GetInstance().SelfDber.Insert(CmcsepcCard);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}