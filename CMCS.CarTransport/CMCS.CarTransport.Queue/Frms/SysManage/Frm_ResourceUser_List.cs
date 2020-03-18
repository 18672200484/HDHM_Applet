using System;
using System.Collections.Generic;
using System.Windows.Forms;
//
using CMCS.CarTransport.DAO;
using CMCS.Common;
using CMCS.Common.Entities.iEAA;
using CMCS.Common.Entities.Sys;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.SuperGrid;

namespace CMCS.CarTransport.Queue.Frms.SysManage
{
	public partial class Frm_ResourceUser_List : MetroAppForm
	{
		/// <summary>
		/// 窗体唯一标识符
		/// </summary>
		public static string UniqueKey = "Frm_ResourceUser_List";

		QueuerDAO queuerDAO = QueuerDAO.GetInstance();

		string SqlWhere = string.Empty;

		CmcsUser CurrUser = null;
		SysModule CurrSysModule = null;

		public Frm_ResourceUser_List()
		{
			InitializeComponent();
		}

		private void Frm_ResourceUser_List_Load(object sender, EventArgs e)
		{
			superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
			superGridControl2.PrimaryGrid.AutoGenerateColumns = false;
			superGridControl3.PrimaryGrid.AutoGenerateColumns = false;

			//01查看 02增加 03修改 04删除
			btnInsertResUser.Visible = queuerDAO.CheckPower(this.GetType().ToString(), "03", GlobalVars.LoginUser);

			btnSearch_Click(null, null);
		}

		public void BindData()
		{
			this.SqlWhere = " where 1=1 ";

			if (!string.IsNullOrEmpty(txtUserAccount_Ser.Text)) this.SqlWhere += " and UserName like '%" + txtUserAccount_Ser.Text + "%'";

			List<CmcsUser> listUser = Dbers.GetInstance().SelfDber.Entities<CmcsUser>(this.SqlWhere + " order by CreationTime ");
			superGridControl1.PrimaryGrid.DataSource = listUser;

			List<SysModule> list = Dbers.GetInstance().SelfDber.Entities<SysModule>(" order by Moduleno ");
			superGridControl2.PrimaryGrid.DataSource = list;
		}

		/// <summary>
		/// 绑定模块功能数据
		/// </summary>
		public void BindDataRes()
		{
			if (CurrSysModule != null && CurrUser != null)
			{
				List<SysResource> resList = Dbers.GetInstance().SelfDber.Entities<SysResource>("where moduleId='" + CurrSysModule.Id + "' order by orderno");
				List<SysResourceTemp> resTempList = new List<SysResourceTemp>();
				foreach (SysResource item in resList)
				{
					SysResourceTemp temp = new SysResourceTemp();
					temp.Id = item.Id;
					temp.ResName = item.ResName;
					temp.Resno = item.Resno;
					List<SysResourceUser> resUser = Dbers.GetInstance().SelfDber.Entities<SysResourceUser>(" where ResourceId='" + item.Id + "' and UserId='" + CurrUser.Id + "'");
					temp.CheckPower = resUser.Count > 0 ? true : false;
					resTempList.Add(temp);
				}
				superGridControl3.PrimaryGrid.DataSource = resTempList;
			}
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			BindData();
		}

		private void btnAll_Click(object sender, EventArgs e)
		{
			txtUserAccount_Ser.Text = string.Empty;
			BindData();
		}

		/// <summary>
		/// 新增模块功能
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnInsertResUser_Click(object sender, EventArgs e)
		{
			if (CurrSysModule != null && CurrUser != null)
			{
				foreach (GridRow row in superGridControl3.PrimaryGrid.Rows)
				{
					string resourceId = row.Cells["clmResourceId"].Value.ToString();
					SysResourceUser resUser = Dbers.GetInstance().SelfDber.Entity<SysResourceUser>(" where ResourceId='" + resourceId + "' and UserId='" + CurrUser.Id + "'");

					if (bool.Parse(row.Cells["clmCheckPower"].Value.ToString()))
					{
						if (resUser == null)
						{
							SysResourceUser entity = new SysResourceUser();
							entity.ResourceId = resourceId;
							entity.UserId = CurrUser.Id;
							Dbers.GetInstance().SelfDber.Insert<SysResourceUser>(entity);
						}
					}
					else
					{
						if (resUser != null)
							Dbers.GetInstance().SelfDber.Delete<SysResourceUser>(resUser.Id);
					}
				}
				BindData();
				MessageBoxEx.Show("用户：" + CurrUser.UserName + " 对模块【" + CurrSysModule.ModuleName + "】功能调整成功", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
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
			CmcsUser cmcsUser = Dbers.GetInstance().SelfDber.Get<CmcsUser>(superGridControl1.PrimaryGrid.GetCell(e.GridCell.GridRow.Index, superGridControl1.PrimaryGrid.Columns["clmId"].ColumnIndex).Value.ToString());

			if (cmcsUser != null)
			{
				this.CurrUser = cmcsUser;
				BindDataRes();
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
			SysModule sysModule = Dbers.GetInstance().SelfDber.Get<SysModule>(superGridControl2.PrimaryGrid.GetCell(e.GridCell.GridRow.Index, superGridControl2.PrimaryGrid.Columns["clmId"].ColumnIndex).Value.ToString());

			if (sysModule != null)
			{
				this.CurrSysModule = sysModule;
				BindDataRes();
			}
		}

		private void superGridControl2_GetRowHeaderText(object sender, GridGetRowHeaderTextEventArgs e)
		{
			e.Text = (e.GridRow.RowIndex + 1).ToString();
		}
		#endregion

		#region superGridControl3
		private void superGridControl3_BeginEdit(object sender, GridEditEventArgs e)
		{
			// 取消编辑
			e.Cancel = true;
		}

		private void superGridControl3_GetRowHeaderText(object sender, GridGetRowHeaderTextEventArgs e)
		{
			e.Text = (e.GridRow.RowIndex + 1).ToString();
		}
		#endregion

		public class SysResourceTemp : SysResource
		{
			public bool CheckPower { get; set; }
		}
	}
}
