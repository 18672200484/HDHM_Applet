using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Common.Entities.Sys;
using CMCS.UnloadSampler.Utilities;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;

namespace CMCS.UnloadSampler.Frms.Sys
{
    public partial class FrmConfirmOperationLog : DevComponents.DotNetBar.Metro.MetroForm
    {
        CommonDAO commonDAO = CommonDAO.GetInstance();
        string OperContent = string.Empty;

        public FrmConfirmOperationLog(string operContent)
        {
            InitializeComponent();
            this.OperContent = operContent;
        }

        private void FrmConfirmOperationLog_Load(object sender, EventArgs e)
        {
            txtCommonAppConfig.Text = CommonAppConfig.GetInstance().AppIdentifier;
            txtOperMan.Text = GlobalVars.LoginUser != null ? GlobalVars.LoginUser.UserName : "未知";
            txtOperTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txtOperContent.Text = this.OperContent;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOperCause.Text))
            {
                MessageBoxEx.Show("请填写操作原因!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            Dbers.GetInstance().SelfDber.Insert(new CmcsConfirmOperationLog()
            {
                AppIdentifier = txtCommonAppConfig.Text,
                OperMan = txtOperMan.Text,
                OperTime = DateTime.Parse(txtOperTime.Text),
                OperContent = txtOperContent.Text,
                OperCause = txtOperCause.Text,
            });

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}