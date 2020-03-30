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
using CMCS.Common.Entities;
using CMCS.Common.Entities.BaseInfo;
using CMCS.Common.Entities.CarTransport;
using DevComponents.DotNetBar;

namespace CMCS.CarTransport.Queue.Frms.BaseInfo.Supplier
{
	public partial class FrmSupplier_Oper : DevComponents.DotNetBar.Metro.MetroForm
	{
		#region Var

		//业务id
		string PId = String.Empty;

		//编辑模式
		eEditMode EditMode = eEditMode.默认;

		CmcsSupplier CmcsSupplier;

		#endregion

		public FrmSupplier_Oper(string pId, eEditMode editMode)
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
		private void FrmSupplier_Oper_Load(object sender, EventArgs e)
		{
			this.CmcsSupplier = Dbers.GetInstance().SelfDber.Get<CmcsSupplier>(this.PId);
			if (this.CmcsSupplier != null)
			{
				txt_Code.Text = CmcsSupplier.Code;
				txt_Name.Text = CmcsSupplier.Name;
				chb_IsUse.Checked = (CmcsSupplier.IsStop == 0);
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
			if (txt_Name.Text.Length == 0)
			{
				MessageBoxEx.Show("该供应商名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if ((CmcsSupplier == null || CmcsSupplier.Name != txt_Name.Text) && Dbers.GetInstance().SelfDber.Entities<CmcsSupplier>(" where Name=:Name", new { Name = txt_Name.Text }).Count > 0)
			{
				MessageBoxEx.Show("该供应商名称不可重复！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (txt_Code.Text.Length == 0)
			{
				MessageBoxEx.Show("该供应商编号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if ((CmcsSupplier == null || CmcsSupplier.Code != txt_Code.Text) && Dbers.GetInstance().SelfDber.Entities<CmcsSupplier>(" where Code=:Code", new { Code = txt_Code.Text }).Count > 0)
			{
				MessageBoxEx.Show("该供应商编号不可重复！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (this.EditMode == eEditMode.修改)
			{
				CmcsSupplier.Name = txt_Name.Text;
				CmcsSupplier.Code = txt_Code.Text;
				CmcsSupplier.IsStop = (chb_IsUse.Checked ? 0 : 1);
				Dbers.GetInstance().SelfDber.Update(CmcsSupplier);
			}
			else if (this.EditMode == eEditMode.新增)
			{
				CmcsSupplier = new CmcsSupplier();
				CmcsSupplier.Name = txt_Name.Text;
				CmcsSupplier.Code = txt_Code.Text;
				CmcsSupplier.IsStop = (chb_IsUse.Checked ? 0 : 1);
				Dbers.GetInstance().SelfDber.Insert(CmcsSupplier);
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