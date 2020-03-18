using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CMCS.CarTransport.DAO;
using CMCS.CarTransport.Queue.Enums;
using CMCS.Common;
using CMCS.Common.Entities.CarTransport;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.SuperGrid;

namespace CMCS.CarTransport.Queue.Frms.BaseInfo.Autotruck
{
	public partial class FrmAutotruck_List : MetroAppForm
	{
		/// <summary>
		/// 窗体唯一标识符
		/// </summary>
		public static string UniqueKey = "FrmAutotruck_List";

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

		public FrmAutotruck_List()
		{
			InitializeComponent();
		}

		private void FrmAutotruck_List_Load(object sender, EventArgs e)
		{
			superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
			//权限控制
			btnAdd.Enabled = QueuerDAO.GetInstance().InitMenuPower(this.GetType().ToString(), superGridControl1);
			btnSearch_Click(null, null);
		}

		public void BindData()
		{
			string tempSqlWhere = this.SqlWhere;
			List<CmcsAutotruck> list = Dbers.GetInstance().SelfDber.ExecutePager<CmcsAutotruck>(PageSize, CurrentIndex, tempSqlWhere + " order by CreationTime desc");
			superGridControl1.PrimaryGrid.DataSource = list;

			GetTotalCount(tempSqlWhere);
			PagerControlStatue();

			lblPagerInfo.Text = string.Format("共 {0} 条记录，每页 {1} 条，共 {2} 页，当前第 {3} 页", TotalCount, PageSize, PageCount, CurrentIndex + 1);
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			FrmAutotruck_Oper frmEdit = new FrmAutotruck_Oper(Guid.NewGuid().ToString(), eEditMode.新增);
			if (frmEdit.ShowDialog() == DialogResult.OK)
			{
				BindData();
			}
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			this.SqlWhere = " where 1=1";

			if (!string.IsNullOrEmpty(txtCarNumber_Ser.Text)) this.SqlWhere += " and CarNumber like '%" + txtCarNumber_Ser.Text + "%'";

			CurrentIndex = 0;
			BindData();
		}

		private void btnAll_Click(object sender, EventArgs e)
		{
			this.SqlWhere = string.Empty;
			txtCarNumber_Ser.Text = string.Empty;

			CurrentIndex = 0;
			BindData();
		}

		#region Pager

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

		private void GetTotalCount(string sqlWhere)
		{
			TotalCount = Dbers.GetInstance().SelfDber.Count<CmcsAutotruck>(sqlWhere);
			if (TotalCount % PageSize != 0)
				PageCount = TotalCount / PageSize + 1;
			else
				PageCount = TotalCount / PageSize;
		}
		#endregion

		#region DataGridView

		private void superGridControl1_BeginEdit(object sender, DevComponents.DotNetBar.SuperGrid.GridEditEventArgs e)
		{
			// 取消编辑
			e.Cancel = true;
		}

		private void superGridControl1_CellMouseDown(object sender, DevComponents.DotNetBar.SuperGrid.GridCellMouseEventArgs e)
		{
			CmcsAutotruck entity = Dbers.GetInstance().SelfDber.Get<CmcsAutotruck>(superGridControl1.PrimaryGrid.GetCell(e.GridCell.GridRow.Index, superGridControl1.PrimaryGrid.Columns["clmId"].ColumnIndex).Value.ToString());
			switch (superGridControl1.PrimaryGrid.Columns[e.GridCell.ColumnIndex].Name)
			{

				case "clmShow":
					FrmAutotruck_Oper frmShow = new FrmAutotruck_Oper(entity.Id, eEditMode.查看);
					if (frmShow.ShowDialog() == DialogResult.OK)
					{
						BindData();
					}
					break;
				case "clmEdit":
					FrmAutotruck_Oper frmEdit = new FrmAutotruck_Oper(entity.Id, eEditMode.修改);
					if (frmEdit.ShowDialog() == DialogResult.OK)
					{
						BindData();
					}
					break;
				case "clmDelete":
					// 查询正在使用该车牌号的车数 
					if (MessageBoxEx.Show("确定要删除该车牌号？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						try
						{
							Dbers.GetInstance().SelfDber.Delete<CmcsAutotruck>(entity.Id);
						}
						catch (Exception)
						{
							MessageBoxEx.Show("该车牌号正在使用中，禁止删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}

						BindData();
					}
					break;
			}
		}

		private void superGridControl1_DataBindingComplete(object sender, DevComponents.DotNetBar.SuperGrid.GridDataBindingCompleteEventArgs e)
		{
			foreach (GridRow gridRow in e.GridPanel.Rows)
			{
				CmcsAutotruck entity = gridRow.DataItem as CmcsAutotruck;
				if (entity == null) return;

				// 填充有效状态
				gridRow.Cells["clmIsUse"].Value = (entity.IsUse == 1 ? "是" : "否");

				CmcsEPCCard cmcsEPCCard = Dbers.GetInstance().SelfDber.Get<CmcsEPCCard>(entity.EPCCardId);
				gridRow.Cells["clmCardNumber"].Value = cmcsEPCCard == null ? "" : cmcsEPCCard.CardNumber;
			}
		}

		/// <summary>
		/// 设置行号
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void superGridControl_GetRowHeaderText(object sender, DevComponents.DotNetBar.SuperGrid.GridGetRowHeaderTextEventArgs e)
		{
			e.Text = (e.GridRow.RowIndex + 1).ToString();
		}

		#endregion
	}
}
