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
using CMCS.Common.Entities.iEAA;
using CMCS.Common.Entities.Sys;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.SuperGrid;

namespace CMCS.CarTransport.Queue.Frms.SysManage
{
	public partial class Frm_Module_List : MetroAppForm
	{
		/// <summary>
		/// 窗体唯一标识符
		/// </summary>
		public static string UniqueKey = "Frm_Module_List";

		QueuerDAO queuerDAO = QueuerDAO.GetInstance();

		string SqlWhere = string.Empty;

		SysModule CurrSysModule = null;

		public Frm_Module_List()
		{
			InitializeComponent();
		}

		private void Frm_Module_List_Load(object sender, EventArgs e)
		{
			superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
			superGridControl2.PrimaryGrid.AutoGenerateColumns = false;

			//01查看 02增加 03修改 04删除
			btnAdd.Visible = queuerDAO.CheckPower(this.GetType().ToString(), "02", GlobalVars.LoginUser);
			superGridControl1.PrimaryGrid.Columns["clmEdit"].Visible = queuerDAO.CheckPower(this.GetType().ToString(), "04", GlobalVars.LoginUser);

			btnInsertRes.Visible = queuerDAO.CheckPower(this.GetType().ToString(), "02", GlobalVars.LoginUser);
			superGridControl2.PrimaryGrid.Columns["clmEdit"].Visible = queuerDAO.CheckPower(this.GetType().ToString(), "04", GlobalVars.LoginUser);

			btnSearch_Click(null, null);
		}

		public void BindData()
		{
			string tempSqlWhere = this.SqlWhere;
			if (!string.IsNullOrEmpty(txtUserAccount_Ser.Text)) this.SqlWhere += " and UserAccount like '%" + txtUserAccount_Ser.Text + "%'";

			List<SysModule> list = Dbers.GetInstance().SelfDber.Entities<SysModule>(tempSqlWhere + "  order by CreationTime desc");
			superGridControl1.PrimaryGrid.DataSource = list;

			BindDataRes();
		}

		/// <summary>
		/// 绑定模块功能数据
		/// </summary>
		public void BindDataRes()
		{
			if (this.CurrSysModule != null)
			{
				List<SysResource> list = Dbers.GetInstance().SelfDber.Entities<SysResource>("where moduleId='" + this.CurrSysModule.Id + "' order by orderno");
				superGridControl2.PrimaryGrid.DataSource = list;
			}
		}

		/// <summary>
		/// 新增模块
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdd_Click(object sender, EventArgs e)
		{
			Frm_Module_Oper frmEdit = new Frm_Module_Oper(null);
			frmEdit.ShowDialog();
			BindData();

		}

		/// <summary>
		/// 新增模块功能
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnInsertRes_Click(object sender, EventArgs e)
		{
			if (this.CurrSysModule == null)
			{
				MessageBoxEx.Show("请先选择一个模块菜单", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			Frm_Resource_Oper frm = new Frm_Resource_Oper(this.CurrSysModule);
			frm.ShowDialog();

			BindData();
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			BindData();
		}

		private void btnAll_Click(object sender, EventArgs e)
		{
			this.SqlWhere = string.Empty;
			txtUserAccount_Ser.Text = string.Empty;

			BindData();
		}

		#region superGridControl1
		private void superGridControl1_DataBindingComplete(object sender, DevComponents.DotNetBar.SuperGrid.GridDataBindingCompleteEventArgs e)
		{
			foreach (GridRow gridRow in e.GridPanel.Rows)
			{
				SysModule entity = gridRow.DataItem as SysModule;
				if (entity == null) return;

				gridRow.Cells["clmStopUse"].Value = (entity.StopUse == 1 ? "启用" : "停用");
			}
		}

		private void superGridControl1_BeginEdit(object sender, GridEditEventArgs e)
		{
			// 取消编辑
			e.Cancel = true;
		}

		private void superGridControl1_CellMouseDown(object sender, GridCellMouseEventArgs e)
		{
			SysModule sysModule = Dbers.GetInstance().SelfDber.Get<SysModule>(superGridControl1.PrimaryGrid.GetCell(e.GridCell.GridRow.Index, superGridControl1.PrimaryGrid.Columns["clmId"].ColumnIndex).Value.ToString());

			if (sysModule != null)
			{
				this.CurrSysModule = sysModule;
				BindDataRes();
			}

			switch (superGridControl1.PrimaryGrid.Columns[e.GridCell.ColumnIndex].Name)
			{
				case "clmEdit":
					Frm_Module_Oper frmEdit = new Frm_Module_Oper(sysModule);
					frmEdit.ShowDialog();
					BindData();
					break;
			}
		}

		/// <summary>
		///设置行号  
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void superGridControl1_GetRowHeaderText(object sender, GridGetRowHeaderTextEventArgs e)
		{
			e.Text = (e.GridRow.RowIndex + 1).ToString();
		}
		#endregion

		#region superGridControl2
		private void superGridControl2_BeginEdit(object sender, GridEditEventArgs e)
		{
			// 取消编辑
			e.Cancel = true;
		}

		private void superGridControl2_CellMouseDown(object sender, GridCellMouseEventArgs e)
		{
			SysResource entity = Dbers.GetInstance().SelfDber.Get<SysResource>(superGridControl2.PrimaryGrid.GetCell(e.GridCell.GridRow.Index, superGridControl2.PrimaryGrid.Columns["clmId"].ColumnIndex).Value.ToString());
			switch (superGridControl2.PrimaryGrid.Columns[e.GridCell.ColumnIndex].Name)
			{
				case "clmEdit":
					Frm_Resource_Oper frmEdit = new Frm_Resource_Oper(entity);
					frmEdit.ShowDialog();
					BindData();
					break;
			}
		}

		private void superGridControl2_GetRowHeaderText(object sender, GridGetRowHeaderTextEventArgs e)
		{
			e.Text = (e.GridRow.RowIndex + 1).ToString();
		}
		#endregion

	}
}
