using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CMCS.CarTransport.DAO;
//
using CMCS.CarTransport.Queue.Enums;
using CMCS.Common;
using CMCS.Common.Entities.CarTransport;
using CMCS.Common.Entities.Sys;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.SuperGrid;

namespace CMCS.CarTransport.Queue.Frms.BaseInfo.Province
{
	public partial class FrmProvince_List : MetroAppForm
	{
		/// <summary>
		/// 窗体唯一标识符
		/// </summary>
		public static string UniqueKey = "FrmProvince_List";

		/// <summary>
		/// 每页显示行数
		/// </summary>
		int PageSize = 18;

		/// <summary>
		/// 总页数
		/// </summary>
		int PageCount = 0;

		/// <summary>
		/// 总记录数
		/// </summary>
		int TotalCount = 0;

		/// <summary>
		/// 当前页索引
		/// </summary>
		int CurrentIndex = 0;

		string SqlWhere = string.Empty;

		public FrmProvince_List()
		{
			InitializeComponent();
		}

		private void FrmProvince_List_Load(object sender, EventArgs e)
		{
			superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
			//权限控制
			btnAdd.Enabled = QueuerDAO.GetInstance().InitMenuPower(this.GetType().ToString(), superGridControl1);
			btnSearch_Click(null, null);
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			this.SqlWhere = " where 1=1";

			if (!string.IsNullOrEmpty(txtPaName_Ser.Text)) this.SqlWhere += " and PaName like '%" + txtPaName_Ser.Text + "%'";

			CurrentIndex = 0;
			BindData();
		}

		public void BindData()
		{
			string tempSqlWhere = this.SqlWhere;
			List<CmcsProvinceAbbreviation> list = Dbers.GetInstance().SelfDber.ExecutePager<CmcsProvinceAbbreviation>(PageSize, CurrentIndex, tempSqlWhere + " order by CreationTime asc");
			superGridControl1.PrimaryGrid.DataSource = list;

			GetTotalCount(tempSqlWhere);
			PagerControlStatue();

			lblPagerInfo.Text = string.Format("共 {0} 条记录，每页 {1} 条，共 {2} 页，当前第 {3} 页", TotalCount, PageSize, PageCount, CurrentIndex + 1);
		}

		private void GetTotalCount(string sqlWhere)
		{
			TotalCount = Dbers.GetInstance().SelfDber.Count<CmcsProvinceAbbreviation>(sqlWhere);
			if (TotalCount % PageSize != 0)
				PageCount = TotalCount / PageSize + 1;
			else
				PageCount = TotalCount / PageSize;
		}

		public void PagerControlStatue()
		{
			if (PageCount <= 1)
			{
				btnFirst.Enabled = false;
				btnPrevious.Enabled = false;
				btnLast.Enabled = false;
				btnNext.Enabled = false;

				return;
			}

			if (CurrentIndex == 0)
			{
				// 首页
				btnFirst.Enabled = false;
				btnPrevious.Enabled = false;
				btnLast.Enabled = true;
				btnNext.Enabled = true;
			}

			if (CurrentIndex > 0 && CurrentIndex < PageCount - 1)
			{
				// 上一页/下一页
				btnFirst.Enabled = true;
				btnPrevious.Enabled = true;
				btnLast.Enabled = true;
				btnNext.Enabled = true;
			}

			if (CurrentIndex == PageCount - 1)
			{
				// 末页
				btnFirst.Enabled = true;
				btnPrevious.Enabled = true;
				btnLast.Enabled = false;
				btnNext.Enabled = false;
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			FrmProvince_Oper frmEdit = new FrmProvince_Oper(string.Empty, eEditMode.新增);
			if (frmEdit.ShowDialog() == DialogResult.OK)
			{
				BindData();
			}
		}

		private void btnAll_Click(object sender, EventArgs e)
		{
			this.SqlWhere = string.Empty;
			txtPaName_Ser.Text = string.Empty;
			CurrentIndex = 0;
			BindData();
		}

		private void superGridControl1_BeginEdit(object sender, GridEditEventArgs e)
		{
			// 取消编辑
			e.Cancel = true;
		}

		private void superGridControl1_CellMouseDown(object sender, GridCellMouseEventArgs e)
		{
			CmcsProvinceAbbreviation entity = Dbers.GetInstance().SelfDber.Get<CmcsProvinceAbbreviation>(superGridControl1.PrimaryGrid.GetCell(e.GridCell.GridRow.Index, superGridControl1.PrimaryGrid.Columns["clmId"].ColumnIndex).Value.ToString());
			switch (superGridControl1.PrimaryGrid.Columns[e.GridCell.ColumnIndex].Name)
			{

				case "clmShow":
					FrmProvince_Oper frmShow = new FrmProvince_Oper(entity.Id, eEditMode.查看);
					if (frmShow.ShowDialog() == DialogResult.OK)
					{
						BindData();
					}
					break;
				case "clmEdit":
					FrmProvince_Oper frmEdit = new FrmProvince_Oper(entity.Id, eEditMode.修改);
					if (frmEdit.ShowDialog() == DialogResult.OK)
					{
						BindData();
					}
					break;
				case "clmDelete":
					// 查询正在使用该供应商的车数 
					if (MessageBoxEx.Show("确定要删除该信息？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						try
						{
							Dbers.GetInstance().SelfDber.Delete<CmcsProvinceAbbreviation>(entity.Id);
						}
						catch (Exception)
						{
							MessageBoxEx.Show("该信息正在使用中，禁止删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}

						BindData();
					}
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

		private void btnPagerCommand_Click(object sender, EventArgs e)
		{
			ButtonX btn = sender as ButtonX;
			switch (btn.CommandParameter.ToString())
			{
				case "First":
					CurrentIndex = 0;
					break;
				case "Previous":
					CurrentIndex = CurrentIndex - 1;
					break;
				case "Next":
					CurrentIndex = CurrentIndex + 1;
					break;
				case "Last":
					CurrentIndex = PageCount - 1;
					break;
			}

			BindData();
		}
	}
}
