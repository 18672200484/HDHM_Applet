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
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;

namespace CMCS.CarTransport.Queue.Frms.BaseInfo.AppletConfig
{
	public partial class FrmAppletConfig_Oper : MetroForm
	{
		//业务id
		string PId = String.Empty;

		//编辑模式
		eEditMode EditMode = eEditMode.默认;

		CmcsAppletConfig CmcsAppModel;

		public FrmAppletConfig_Oper(string pId, eEditMode editMode)
		{
			InitializeComponent();

			this.PId = pId;
			this.EditMode = editMode;
		}

		private void FrmAppletConfig_Oper_Load(object sender, EventArgs e)
		{

			this.CmcsAppModel = Dbers.GetInstance().SelfDber.Get<CmcsAppletConfig>(this.PId);
			if (this.CmcsAppModel != null)
			{
				txt_AppIdentifier.Text = CmcsAppModel.AppIdentifier;
				txt_ConfigName.Text = CmcsAppModel.ConfigName;
				txt_ConfigValue.Text = CmcsAppModel.ConfigValue;
			}

			if (this.EditMode == eEditMode.查看)
			{
				btnSubmit.Enabled = false;
				HelperUtil.ControlReadOnly(panelEx2, true);
			}
		}

		private void btnSubmit_Click(object sender, EventArgs e)
		{
			if (txt_AppIdentifier.Text.Length == 0)
			{
				MessageBoxEx.Show("该程序唯一标识不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (txt_ConfigName.Text.Length == 0)
			{
				MessageBoxEx.Show("该配置名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if ((CmcsAppModel == null || (CmcsAppModel.AppIdentifier != txt_AppIdentifier.Text && CmcsAppModel.ConfigName != txt_ConfigName.Text)) && Dbers.GetInstance().SelfDber.Entities<CmcsAppletConfig>(" where appIdentifier=:appIdentifier and ConfigName=:ConfigName", new { appIdentifier = txt_AppIdentifier.Text, ConfigName = txt_ConfigName.Text }).Count > 0)
			{
				MessageBoxEx.Show("该程序唯一标识不可重复！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (this.EditMode == eEditMode.修改)
			{
				CmcsAppModel.AppIdentifier = txt_AppIdentifier.Text;
				CmcsAppModel.ConfigName = txt_ConfigName.Text;
				CmcsAppModel.ConfigValue = txt_ConfigValue.Text;
				Dbers.GetInstance().SelfDber.Update(CmcsAppModel);
			}
			else if (this.EditMode == eEditMode.新增)
			{
				CmcsAppModel = new CmcsAppletConfig();
				CmcsAppModel.AppIdentifier = txt_AppIdentifier.Text;
				CmcsAppModel.ConfigName = txt_ConfigName.Text;
				CmcsAppModel.ConfigValue = txt_ConfigValue.Text;
				Dbers.GetInstance().SelfDber.Insert(CmcsAppModel);
			}
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
