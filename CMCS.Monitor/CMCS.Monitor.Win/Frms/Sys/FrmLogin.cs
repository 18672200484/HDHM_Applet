using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro.ColorTables;
using DevComponents.DotNetBar.Controls;
using CMCS.Common.DAO;
using CMCS.Common.Entities;
using CMCS.Monitor.Win.Utilities;
using CMCS.Common;
using CMCS.Common.Utilities;
using CMCS.Monitor.Win.Core;
using CMCS.Common.Entities.iEAA;
using CMCS.Common.Enums;
using CMCS.Common.Entities.Sys;
using CMCS.Common.Enums.Sys;

namespace CMCS.Monitor.Win.Frms.Sys
{
	public partial class FrmLogin : DevComponents.DotNetBar.Metro.MetroForm
	{
		public FrmLogin()
		{
			InitializeComponent();

			//StyleManager.MetroColorGeneratorParameters = MetroColorGeneratorParameters.BlackSky;
		}

		CommonDAO commonDao = CommonDAO.GetInstance();

		private void FrmLogin_Load(object sender, EventArgs e)
		{
			FormInit();
		}

		/// <summary>
		/// 窗体初始化
		/// </summary>
		private void FormInit()
		{
			//// 加载用户
			//cmbUserAccount.DataSource = commonDao.GetAllSystemUser(eUserRoleCodes.集控室.ToString());
			//cmbUserAccount.DisplayMember = "Name";
			//cmbUserAccount.ValueMember = "UserName";

			// 加载CS用户
			cmbUserAccount.DataSource = commonDao.GetAllSystemUser_Cmcs();
			cmbUserAccount.DisplayMember = "Name";
			cmbUserAccount.ValueMember = "UserName";
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			#region 验证

			if (cmbUserAccount.SelectedItem == null) return;
			if (string.IsNullOrEmpty(txtUserPassword.Text)) return;

			#endregion

			//SysUsers user = commonDao.Login(eUserRoleCodes.集控室.ToString(), cmbUserAccount.SelectedValue.ToString(), MD5Util.Encrypt(txtUserPassword.Text));
			CmcsUser user = commonDao.Login_Cmcs(cmbUserAccount.SelectedValue.ToString(), txtUserPassword.Text);
			//SysUsers user = ApiLogin.Login(cmbUserAccount.SelectedValue.ToString(), txtUserPassword.Text);
			if (user != null)
			{
				GlobalVars.LoginUser = user;

				this.Hide();
				//commonDao.SaveLoginLog(GlobalVars.LoginUser.UserName, eUserLogInattempts.Success);
				SelfVars.MainFrameForm = new FrmMainFrame();
				SelfVars.MainFrameForm.Show();
			}
			else
			{
				MessageBoxEx.Show("帐号或密码错误，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				//commonDao.SaveLoginLog(cmbUserAccount.SelectedValue.ToString(), eUserLogInattempts.InvalidPassword);
				txtUserPassword.ResetText();
				txtUserPassword.Focus();
			}
		}
	}
}