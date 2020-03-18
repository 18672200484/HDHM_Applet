using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
//
using CMCS.CarTransport.DAO;
using CMCS.CarTransport.Queue.Enums;
using CMCS.CarTransport.Queue.Frms.BaseInfo.Supplier;
using CMCS.CarTransport.Queue.Frms.Transport.TransportPicture;
using CMCS.Common;
using CMCS.Common.Entities.BaseInfo;
using CMCS.Common.Entities.CarTransport;
using CMCS.Common.Entities.Fuel;
using CMCS.Common.Enums;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.SuperGrid;
using NPOI.HSSF.UserModel;

namespace CMCS.CarTransport.Queue.Frms.Transport.BuyFuelTransport
{
	public partial class FrmBuyFuelTransport_List : MetroAppForm
	{
		/// <summary>
		/// 窗体唯一标识符
		/// </summary>
		public static string UniqueKey = "FrmBuyFuelTransport_List";

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

		List<CmcsBuyFuelTransport> CurrExportData = new List<CmcsBuyFuelTransport>();

		CarTransportDAO carTransportDAO = CarTransportDAO.GetInstance();

		private CmcsSupplier selectedSupplier_BuyFuel;
		/// <summary>
		/// 选择的供煤单位
		/// </summary>
		public CmcsSupplier SelectedSupplier_BuyFuel
		{
			get { return selectedSupplier_BuyFuel; }
			set
			{
				selectedSupplier_BuyFuel = value;

				if (value != null)
					txtSupplierName_BuyFuel.Text = value.Name;
				else
					txtSupplierName_BuyFuel.ResetText();
			}
		}

		public FrmBuyFuelTransport_List()
		{
			InitializeComponent();
		}

		private void FrmBuyFuelTransport_List_Load(object sender, EventArgs e)
		{
			superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
			//权限控制
			QueuerDAO.GetInstance().InitMenuPower(this.GetType().ToString(), superGridControl1);
			//初始化查询条件
			dtInputStart.Value = DateTime.Now.Date;
			dtInputEnd.Value = dtInputStart.Value.AddDays(1);
			cmbTimeType.SelectedIndex = 0;
			BindStepName();

			btnSearch_Click(null, null);
		}

		public void BindData()
		{
			object param = new { InFactoryStartTime = this.dtInputStart.Value, InFactoryEndTime = this.dtInputEnd.Value, TareStartTime = this.dtInputStart.Value, TareEndTime = this.dtInputEnd.Value };

			string tempSqlWhere = this.SqlWhere;
			List<CmcsBuyFuelTransport> list = Dbers.GetInstance().SelfDber.ExecutePager<CmcsBuyFuelTransport>(PageSize, CurrentIndex, tempSqlWhere + " order by SerialNumber desc", param);
			superGridControl1.PrimaryGrid.DataSource = list;

			CurrExportData = Dbers.GetInstance().SelfDber.Entities<CmcsBuyFuelTransport>(tempSqlWhere + " order by CreationTime desc", param);

			GetTotalCount(tempSqlWhere, param);
			PagerControlStatue();

			lblPagerInfo.Text = string.Format("共 {0} 条记录，每页 {1} 条，共 {2} 页，当前第 {3} 页", TotalCount, PageSize, PageCount, CurrentIndex + 1);
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			this.SqlWhere = " where 1=1";

			if (!string.IsNullOrEmpty(txtCarNumber_Ser.Text)) this.SqlWhere += " and CarNumber like '%" + txtCarNumber_Ser.Text + "%'";

			if (cmbTimeType.SelectedItem.ToString() == "入厂时间")
			{
				if (!string.IsNullOrEmpty(dtInputStart.Text)) this.SqlWhere += " and InFactoryTime >=:InFactoryStartTime";

				if (!string.IsNullOrEmpty(dtInputEnd.Text)) this.SqlWhere += " and InFactoryTime <:InFactoryEndTime";
			}
			else if (cmbTimeType.SelectedItem.ToString() == "回皮时间")
			{
				if (!string.IsNullOrEmpty(dtInputStart.Text)) this.SqlWhere += " and TareTime >=:TareStartTime";

				if (!string.IsNullOrEmpty(dtInputEnd.Text)) this.SqlWhere += " and TareTime <:TareEndTime";
			}

			if (this.SelectedSupplier_BuyFuel != null) this.SqlWhere += " and SupplierId = '" + this.SelectedSupplier_BuyFuel.Id + "'";

			if (this.cmbStepName.Text != "全部") this.SqlWhere += " and StepName = '" + this.cmbStepName.Text + "'";

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

		private void btnReportExport_Click(object sender, EventArgs e)
		{
			try
			{
				FileStream file = new FileStream("计量明细模板.xls", FileMode.Open, FileAccess.Read);
				HSSFWorkbook hssfworkbook = new HSSFWorkbook(file);
				HSSFSheet sheetl = (HSSFSheet)hssfworkbook.GetSheet("计量明细");

				if (CurrExportData.Count == 0)
				{
					MessageBox.Show("请先查询数据");
					return;
				}

				if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
					return;

				for (int i = 0; i < CurrExportData.Count; i++)
				{
					CmcsBuyFuelTransport entity = CurrExportData[i];
					Mysheet1(sheetl, i + 1, 0, entity.SerialNumber.ToString());
					Mysheet1(sheetl, i + 1, 1, entity.CarNumber);
					Mysheet1(sheetl, i + 1, 2, entity.SupplierName);
					Mysheet1(sheetl, i + 1, 3, entity.FuelKindName);
					Mysheet1(sheetl, i + 1, 4, entity.GrossWeight.ToString());
					Mysheet1(sheetl, i + 1, 5, entity.TareWeight.ToString());
					Mysheet1(sheetl, i + 1, 6, entity.DeductWeight.ToString());
					Mysheet1(sheetl, i + 1, 7, entity.SuttleWeight.ToString());
					Mysheet1(sheetl, i + 1, 8, entity.TareTime.Year < 2000 ? "" : entity.TareTime.ToString("yyyy-MM-dd HH:mm:ss"));
				}

				#region 合计
				Mysheet1(sheetl, CurrExportData.Count + 1, 0, "合计");
				Mysheet1(sheetl, CurrExportData.Count + 1, 1, CurrExportData.Count + "车");
				Mysheet1(sheetl, CurrExportData.Count + 1, 4, Math.Round(CurrExportData.Sum(a => a.GrossWeight), 2).ToString());
				Mysheet1(sheetl, CurrExportData.Count + 1, 5, Math.Round(CurrExportData.Sum(a => a.TareWeight), 2).ToString());
				Mysheet1(sheetl, CurrExportData.Count + 1, 6, Math.Round(CurrExportData.Sum(a => a.DeductWeight), 2).ToString());
				Mysheet1(sheetl, CurrExportData.Count + 1, 7, Math.Round(CurrExportData.Sum(a => a.SuttleWeight), 2).ToString());
				#endregion

				sheetl.ForceFormulaRecalculation = true;
				string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "计量明细.xls";
				GC.Collect();

				FileStream fs = File.OpenWrite(folderBrowserDialog.SelectedPath + "\\" + fileName);
				hssfworkbook.Write(fs);   //向打开的这个xls文件中写入表并保存。  
				fs.Close();
				MessageBox.Show("导出成功");

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public void Mysheet1(HSSFSheet sheet1, int x, int y, String Value)
		{
			if (sheet1.GetRow(x) == null)
			{
				sheet1.CreateRow(x);
			}
			if (sheet1.GetRow(x).GetCell(y) == null)
			{
				sheet1.GetRow(x).CreateCell(y);
			}
			sheet1.GetRow(x).GetCell(y).SetCellValue(Value);
		}

		/// <summary>
		/// 绑定流程节点
		/// </summary>
		private void BindStepName()
		{
			cmbStepName.Items.Add("全部");
			cmbStepName.Items.Add(eTruckInFactoryStep.入厂.ToString());
			cmbStepName.Items.Add(eTruckInFactoryStep.采样.ToString());
			cmbStepName.Items.Add(eTruckInFactoryStep.重车.ToString());
			cmbStepName.Items.Add(eTruckInFactoryStep.轻车.ToString());
			cmbStepName.Items.Add(eTruckInFactoryStep.出厂.ToString());
			cmbStepName.SelectedIndex = 0;
		}

		#region 供应商
		private void btnSelectSupplier_BuyFuel_Click(object sender, EventArgs e)
		{
			FrmSupplier_Select frm = new FrmSupplier_Select("where IsStop=0 order by Name asc");
			if (frm.ShowDialog() == DialogResult.OK)
			{
				this.SelectedSupplier_BuyFuel = frm.Output;
			}
		}

		private void btnDelSupplier_BuyFuel_Click(object sender, EventArgs e)
		{
			this.SelectedSupplier_BuyFuel = null;
		}
		#endregion

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

		private void GetTotalCount(string sqlWhere, object param)
		{
			TotalCount = Dbers.GetInstance().SelfDber.Count<CmcsBuyFuelTransport>(sqlWhere, param);
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
			CmcsBuyFuelTransport entity = Dbers.GetInstance().SelfDber.Get<CmcsBuyFuelTransport>(superGridControl1.PrimaryGrid.GetCell(e.GridCell.GridRow.Index, superGridControl1.PrimaryGrid.Columns["clmId"].ColumnIndex).Value.ToString());
			switch (superGridControl1.PrimaryGrid.Columns[e.GridCell.ColumnIndex].Name)
			{

				case "clmShow":
					FrmBuyFuelTransport_Oper frmShow = new FrmBuyFuelTransport_Oper(entity.Id, eEditMode.查看);
					if (frmShow.ShowDialog() == DialogResult.OK)
					{
						BindData();
					}
					break;
				case "clmEdit":
					FrmBuyFuelTransport_Oper frmEdit = new FrmBuyFuelTransport_Oper(entity.Id, eEditMode.修改);
					if (frmEdit.ShowDialog() == DialogResult.OK)
					{
						BindData();
					}
					break;
				case "clmDelete":
					// 查询正在使用该记录的车数 
					if (MessageBoxEx.Show("确定要删除该记录？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						try
						{
							Dbers.GetInstance().SelfDber.Delete<CmcsBuyFuelTransport>(entity.Id);

							//删除临时运输记录
							Dbers.GetInstance().SelfDber.DeleteBySQL<CmcsUnFinishTransport>("where TransportId=:TransportId", new { TransportId = entity.Id });
						}
						catch (Exception)
						{
							MessageBoxEx.Show("该记录正在使用中，禁止删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}

						BindData();
					}
					break;
				case "clmPic":

					if (Dbers.GetInstance().SelfDber.Entities<CmcsTransportPicture>(String.Format(" where TransportId='{0}'", entity.Id)).Count > 0)
					{
						FrmTransportPicture frmPic = new FrmTransportPicture(entity.Id, entity.CarNumber);
						if (frmPic.ShowDialog() == DialogResult.OK)
						{
							BindData();
						}
					}
					else
					{
						MessageBoxEx.Show("暂无抓拍图片！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
					break;
			}
		}

		private void superGridControl1_DataBindingComplete(object sender, DevComponents.DotNetBar.SuperGrid.GridDataBindingCompleteEventArgs e)
		{

			foreach (GridRow gridRow in e.GridPanel.Rows)
			{
				CmcsBuyFuelTransport entity = gridRow.DataItem as CmcsBuyFuelTransport;
				if (entity == null) return;

				// 填充有效状态
				gridRow.Cells["clmIsUse"].Value = (entity.IsUse == 1 ? "是" : "否");
				CmcsInFactoryBatch cmcsinfactorybatch = Dbers.GetInstance().SelfDber.Get<CmcsInFactoryBatch>(entity.InFactoryBatchId);
				if (cmcsinfactorybatch != null)
				{
					gridRow.Cells["clmInFactoryBatchNumber"].Value = cmcsinfactorybatch.Batch;
				}

				//List<CmcsTransportPicture> cmcstrainwatchs = Dbers.GetInstance().SelfDber.Entities<CmcsTransportPicture>(String.Format(" where TransportId='{0}'", gridRow.Cells["clmId"].Value));
				//if (cmcstrainwatchs.Count == 0)
				//{
				//    //gridRow.Cells["clmPic"].Value = "";
				//}

			}
		}

		#endregion

	}
}
