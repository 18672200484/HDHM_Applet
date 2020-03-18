using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMCS.CarTransport.Queue.Core;
using CMCS.CarTransport.Queue.Enums;
using CMCS.Common;
using CMCS.Common.Entities.BaseInfo;
using CMCS.Common.Entities.iEAA;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;

namespace CMCS.CarTransport.Queue.Frms.BaseInfo.UserInfo
{
	public partial class FrmUserInfo_Oper : MetroForm
	{
		string Id = string.Empty;
		eEditMode EditMode = eEditMode.默认;
		CmcsUser cmcsUser;

		/// <summary>
		/// 用户名不应该包含的非法字符
		/// </summary>
		char[] IllicitChar = new char[] { '|', '%', '.', ',' };

		public FrmUserInfo_Oper(string pId, eEditMode editMode)
		{
			InitializeComponent();
			this.Id = pId;
			this.EditMode = editMode;
		}

		private void FrmUserInfo_Oper_Load(object sender, EventArgs e)
		{
			//只有admin用户才能分配超级管理员
			if (GlobalVars.LoginUser.UserName == "admin")
				chbIsSupper.Enabled = true;

			if (this.EditMode == eEditMode.新增)
			{
				this.Text = "用户管理 - 新增";
				btnSubmit.Text = "新增";

				txtCreateDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
			}
			else if (!string.IsNullOrEmpty(this.Id))
			{
				this.cmcsUser = Dbers.GetInstance().SelfDber.Get<CmcsUser>(this.Id);

				txtUserAccount.Text = this.cmcsUser.UserName;
				txtUserName.Text = this.cmcsUser.Name;
				txtUserPassword.Text = this.cmcsUser.PassWord;
				chbIsUse.Checked = Convert.ToBoolean(this.cmcsUser.IsUse);
				chbIsSupper.Checked = Convert.ToBoolean(this.cmcsUser.IsSupper);
				chbIsDeductUser.Checked = Convert.ToBoolean(this.cmcsUser.IsDeductUser);
				txtCreateDate.Text = this.cmcsUser.CreationTime.ToString("yyyy-MM-dd HH:mm");

				if (this.EditMode == eEditMode.查看)
				{
					txtUserAccount.ReadOnly = true;
					txtUserName.ReadOnly = true;
					btnSubmit.Enabled = false;
				}
				else if (this.EditMode == eEditMode.修改)
				{
					this.Text = "用户管理 - 详情";
					btnSubmit.Text = "修改";

					txtUserAccount.ReadOnly = true;
					txtUserName.ReadOnly = Convert.ToBoolean(this.cmcsUser.IsSupper);
					chbIsUse.Enabled = !Convert.ToBoolean(this.cmcsUser.IsSupper);
				}
			}
		}

		private void btnSubmit_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtUserName.Text))
			{
				MessageBoxEx.Show("请输入用户昵称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (string.IsNullOrEmpty(txtUserPassword.Text))
			{
				MessageBoxEx.Show("请输入用户密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (string.IsNullOrEmpty(txtUserAccount.Text))
			{
				MessageBoxEx.Show("请输入用户账号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			else
			{
				char illicitChar = ' ';
				if (!CheckIllicitAccount(txtUserAccount.Text.Trim(), ref illicitChar))
				{
					MessageBoxEx.Show("帐号中存在非法字符" + illicitChar + "！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				CmcsUser entityCheck = Dbers.GetInstance().SelfDber.Entity<CmcsUser>("where UserName='" + txtUserAccount.Text.Trim() + "'");
				if ((this.cmcsUser != null && entityCheck != null && this.cmcsUser.Id != entityCheck.Id) || (this.cmcsUser == null && entityCheck != null))
				{
					MessageBoxEx.Show("已经存在该账号的用户！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
			}

			if (this.cmcsUser == null)
			{
				// 新增
				CmcsUser entity = new CmcsUser();
				entity.UserName = txtUserAccount.Text.Trim();
				entity.Name = txtUserName.Text.Trim();
				entity.PassWord = txtUserPassword.Text.Trim();
				entity.IsUse = Convert.ToInt16(chbIsUse.Checked);
				entity.IsDeductUser = Convert.ToInt16(chbIsDeductUser.Checked);
				entity.IsSupper = Convert.ToInt16(chbIsSupper.Checked);
				Dbers.GetInstance().SelfDber.Insert<CmcsUser>(entity);

				MessageBoxEx.Show("新增成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

				txtUserAccount.Text = string.Empty;
				txtUserName.Text = string.Empty;
				txtUserPassword.Text = string.Empty;
			}
			else
			{
				// 修改
				this.cmcsUser.Name = txtUserName.Text.Trim();
				this.cmcsUser.PassWord = txtUserPassword.Text.Trim();
				this.cmcsUser.IsUse = Convert.ToInt16(chbIsUse.Checked);
				this.cmcsUser.IsDeductUser = Convert.ToInt16(chbIsDeductUser.Checked);
				this.cmcsUser.IsSupper = Convert.ToInt16(chbIsSupper.Checked);

				Dbers.GetInstance().SelfDber.Update(this.cmcsUser);

				MessageBoxEx.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				btnCancel_Click(null, null);
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		/// <summary>
		/// 验证帐号中是否包含预定的非法字符
		/// </summary>
		/// <param name="userAccount"></param>
		/// <param name="illicitChar">非法字符</param>
		/// <returns></returns>
		private bool CheckIllicitAccount(string userAccount, ref char illicitChar)
		{
			foreach (char value in userAccount)
			{
				if (this.IllicitChar.Contains(value))
				{
					illicitChar = value;
					return false;
				}
			}

			return true;
		}

		private void FrmUserInfo_Oper_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}
	}
}
