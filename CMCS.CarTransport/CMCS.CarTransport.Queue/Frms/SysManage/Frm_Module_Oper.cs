using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMCS.CarTransport.DAO;
using CMCS.CarTransport.Queue.Core;
using CMCS.Common;
using CMCS.Common.Entities.BaseInfo;
using CMCS.Common.Entities.CarTransport;
using CMCS.Common.Entities.iEAA;
using CMCS.Common.Entities.Sys;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;

namespace CMCS.CarTransport.Queue.Frms.SysManage
{
	public partial class Frm_Module_Oper : MetroForm
	{
		SysModule CurrSysModule = null;
		QueuerDAO queuerDAO = QueuerDAO.GetInstance();

		public Frm_Module_Oper(SysModule sysmodule)
		{
			InitializeComponent();

			this.CurrSysModule = sysmodule;
		}

		private void Frm_Module_Oper_Load(object sender, EventArgs e)
		{
			if (this.CurrSysModule != null)
			{
				this.Text = "模块管理 - 详情";
				btnSubmit.Text = "修改";

				txtModuleName.Text = this.CurrSysModule.ModuleName;
				txtModuleNo.Text = this.CurrSysModule.Moduleno;
				txtModuleDll.Text = this.CurrSysModule.ModuleDll;
				chbStopUse.Checked = Convert.ToBoolean(this.CurrSysModule.StopUse);
				txtCreateDate.Text = this.CurrSysModule.CreationTime.ToString("yyyy-MM-dd HH:mm");
			}
			else
			{
				this.Text = "模块管理 - 新增";
				btnSubmit.Text = "新增";

				txtCreateDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
				txtModuleNo.Text = queuerDAO.CreateModuleno();
			}
		}

		private void btnSubmit_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtModuleDll.Text))
			{
				MessageBoxEx.Show("请输入模块完整名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (string.IsNullOrEmpty(txtModuleName.Text))
			{
				MessageBoxEx.Show("请输入模块名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			else
			{
				SysModule entityCheck = Dbers.GetInstance().SelfDber.Entity<SysModule>("where ModuleDll='" + txtModuleDll.Text.Trim() + "'");
				if ((this.CurrSysModule != null && entityCheck != null && this.CurrSysModule.Id != entityCheck.Id) || (this.CurrSysModule == null && entityCheck != null))
				{
					MessageBoxEx.Show("已经存在该模块完整名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
			}

			if (this.CurrSysModule == null)
			{
				// 新增
				this.CurrSysModule = new SysModule();
				this.CurrSysModule.ModuleName = txtModuleName.Text.Trim();
				this.CurrSysModule.Moduleno = txtModuleNo.Text.Trim();
				this.CurrSysModule.ModuleDll = txtModuleDll.Text.Trim();
				this.CurrSysModule.StopUse = Convert.ToInt16(chbStopUse.Checked);

				Dbers.GetInstance().SelfDber.Insert<SysModule>(this.CurrSysModule);

				MessageBoxEx.Show("新增成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

				txtModuleName.Text = string.Empty;
				txtModuleDll.Text = string.Empty;
				txtModuleNo.Text = queuerDAO.CreateModuleno();
			}
			else
			{
				// 修改
				this.CurrSysModule.ModuleName = txtModuleName.Text.Trim();
				this.CurrSysModule.ModuleDll = txtModuleDll.Text.Trim();
				this.CurrSysModule.StopUse = Convert.ToInt16(chbStopUse.Checked);

				Dbers.GetInstance().SelfDber.Update<SysModule>(this.CurrSysModule);

				MessageBoxEx.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			//增加增删改查功能
			if (chkInsert.Checked)
			{
				//是否存在
				List<SysResource> listResource = queuerDAO.GetResources(this.CurrSysModule, false);
				if (listResource.Count == 0)
				{
					//不存在需要初始化
					listResource = queuerDAO.GetResources(this.CurrSysModule, true);
					foreach (SysResource item in listResource)
					{
						Dbers.GetInstance().SelfDber.Insert<SysResource>(item);
					}
				}
			}

			btnCancel_Click(null, null);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
