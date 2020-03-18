using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
//
using CMCS.CarTransport.Queue.Core;
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Common.Entities.iEAA;
using CMCS.Common.Enums.Sys;
using DevComponents.DotNetBar;
using System;

namespace CMCS.CarTransport.Queue.Frms.Sys
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
			//cmbUserAccount.DataSource = commonDao.GetAllSystemUser(eUserRoleCodes.汽车智能化.ToString());
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

			//SysUsers test = new SysUsers();
			//test.UserName = "test";
			//test.Name = "测试";
			//test.PassWord = "123456";
			//test.WorkNumber = "test";
			//test.CreationTime = DateTime.Now;
			//test.IsActive = 1;
			//test.SurName = "test";
			//test.EmailAddress = "test@qq.com";
			//test.AccessFailedCount = 1;
			//test.IsLockOutEnabled = 0;
			//test.LastPassWordUpdateTime = DateTime.Now;
			//test.Sort = 1;
			//test.NORMALIZEDEMAILADDRESS = "test@qq.com";
			//test.NORMALIZEDUSERNAME = "test";
			//test.IsEmailConfirmed = 1;
			//test.IsTwoFactorEnabled = 0;
			//test.IsPhoneNumberConfirmed = 1;
			//test.DEPARTMENTID = 1;
			//commonDao.SelfDber.Insert(test);
			//test = commonDao.SelfDber.Entity<SysUsers>("where UserName='test' order by CreationTime desc");
			//test.NORMALIZEDEMAILADDRESS = "test1@163.com";
			//int ss = commonDao.SelfDber.Update(test);

			#region BS登录
			//SysUsers user = ApiLogin.Login(cmbUserAccount.SelectedValue.ToString(), txtUserPassword.Text);

			//if (user != null)
			//{
			//    GlobalVars.LoginUser = user;

			//    this.Hide();
			//    commonDao.SaveLoginLog(GlobalVars.LoginUser.UserName, eUserLogInattempts.Success);
			//    SelfVars.MainFrameForm = new FrmMainFrame();
			//    SelfVars.MainFrameForm.Show();
			//}
			//else
			//{
			//    MessageBoxEx.Show("帐号或密码错误，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			//    commonDao.SaveLoginLog(cmbUserAccount.SelectedValue.ToString(), eUserLogInattempts.InvalidPassword);
			//    txtUserPassword.ResetText();
			//    txtUserPassword.Focus();
			//}
			#endregion

			#region CS登录
			CmcsUser user = commonDao.Login_Cmcs(cmbUserAccount.SelectedValue.ToString(), txtUserPassword.Text);
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
			#endregion
		}

		public string HttpApi(string url, string jsonstr, string type)
		{
			Encoding encoding = Encoding.UTF8;
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Accept = "text/html,applicaton/xhtml+xml,*/*";
			request.ContentType = "application/json";
			request.Method = type.ToUpper().ToString();
			byte[] buffer = encoding.GetBytes(jsonstr);
			request.ContentLength = buffer.Length;
			request.GetRequestStream().Write(buffer, 0, buffer.Length);
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
			{
				return reader.ReadToEnd();
			}
		}

	}
}