using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro.ColorTables;
using DevComponents.DotNetBar.Controls;
using CMCS.Common.DAO;
using CMCS.Common.Entities;
using CMCS.Common;
using CMCS.Common.Utilities;
using CMCS.CarTransport.Queue.Core;
using CMCS.Common.Entities.iEAA;
using CMCS.Common.Entities.Sys;

namespace CMCS.CarTransport.Queue.Frms.Sys
{
    public partial class FrmPassword : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FrmPassword()
        {
            InitializeComponent();
        }

        CommonDAO commonDao = CommonDAO.GetInstance();

        private void FrmPassword_Load(object sender, EventArgs e)
        {
            FormInit();
        }

        /// <summary>
        /// 窗体初始化
        /// </summary>
        private void FormInit()
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            #region 验证

            if (string.IsNullOrWhiteSpace(txtUserPassword.Text.Trim()))
            {
                MessageBoxEx.Show("请输入旧密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUserNewPassword.Text.Trim()))
            {
                MessageBoxEx.Show("请输入新密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUserNewPasswordSecond.Text.Trim()))
            {
                MessageBoxEx.Show("请输入确认密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtUserNewPassword.Text.Trim() != txtUserNewPasswordSecond.Text.Trim())
            {
                MessageBoxEx.Show("两次新密码不一致", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            #endregion

            SysUsers user = Dbers.GetInstance().SelfDber.Entities<SysUsers>(" where UserAccount=:UserAccount and MDPassword=:MDPassword", new { UserAccount = GlobalVars.LoginUser.UserName, MDPassword = MD5Util.Encrypt(txtUserPassword.Text.Trim()) }).FirstOrDefault();
            if (user != null)
            {
                Dbers.GetInstance().SelfDber.Execute("update " + DapperDber.Util.EntityReflectionUtil.GetTableName<SysUsers>() + " set MDPassword=:MDPassword where PartyId=:PartyId", new { MDPassword = MD5Util.Encrypt(txtUserNewPassword.Text.Trim()), PartyId = user.Id });

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBoxEx.Show("帐号或密码错误，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtUserPassword.ResetText();
                txtUserPassword.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}