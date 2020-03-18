using System;
using System.Linq;
using System.Windows.Forms;
//
using CMCS.CarTransport.Queue.Enums;
using CMCS.Common;
using CMCS.Common.Entities.CarTransport;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;


namespace CMCS.CarTransport.Queue.Frms.BaseInfo.Province
{
	public partial class FrmProvince_Oper : MetroForm
	{
		string Id = string.Empty;
		eEditMode EditMode = eEditMode.默认;
		CmcsProvinceAbbreviation cmcsProvince;

		public FrmProvince_Oper(string pId, eEditMode editMode)
		{
			InitializeComponent();
			this.Id = pId;
			this.EditMode = editMode;
		}

		private void FrmProvince_Oper_Load(object sender, EventArgs e)
		{
			if (this.EditMode == eEditMode.新增)
			{
				this.Text = "新增";
				btnSubmit.Text = "新增";

				txtCreateDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
			}
			else if (!string.IsNullOrEmpty(this.Id))
			{
				this.cmcsProvince = Dbers.GetInstance().SelfDber.Get<CmcsProvinceAbbreviation>(this.Id);

				txtPaName.Text = this.cmcsProvince.PaName;
				txtCreateDate.Text = this.cmcsProvince.CreationTime.ToString("yyyy-MM-dd HH:mm");

				if (this.EditMode == eEditMode.查看)
				{
					txtPaName.ReadOnly = true;
					btnSubmit.Enabled = false;
				}
				else if (this.EditMode == eEditMode.修改)
				{
					this.Text = "详情";
					btnSubmit.Text = "修改";
				}
			}
		}

		private void btnSubmit_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtPaName.Text))
			{
				MessageBoxEx.Show("请输入名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			CmcsProvinceAbbreviation entityCheck = Dbers.GetInstance().SelfDber.Entity<CmcsProvinceAbbreviation>("where PaName='" + txtPaName.Text.Trim() + "'");
			if ((this.cmcsProvince != null && entityCheck != null && this.cmcsProvince.Id != entityCheck.Id) || (this.cmcsProvince == null && entityCheck != null))
			{
				MessageBoxEx.Show("已经存在该名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (this.cmcsProvince == null)
			{
				// 新增
				CmcsProvinceAbbreviation entity = new CmcsProvinceAbbreviation();
				entity.PaName = txtPaName.Text.Trim();
				Dbers.GetInstance().SelfDber.Insert<CmcsProvinceAbbreviation>(entity);
				MessageBoxEx.Show("新增成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				// 修改
				this.cmcsProvince.PaName = txtPaName.Text.Trim();

				Dbers.GetInstance().SelfDber.Update(this.cmcsProvince);

				MessageBoxEx.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			btnCancel_Click(null, null);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

	}
}
