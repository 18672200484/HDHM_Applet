using System;
using System.Collections.Generic;
using System.Windows.Forms;
//
using CMCS.Common.Entities;
using CMCS.Common;
using DevComponents.DotNetBar;
using System.Linq;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.Metro;
using CMCS.Monitor.Win.Frms.Sys;
using CMCS.Common.Entities.TrainInFactory;
using CMCS.Common.Entities.BaseInfo;
using CMCS.Common.Entities.CarTransport;

namespace CMCS.Monitor.Win.Frms
{
    public partial class FrmSaleFuelLoad : MetroForm
    {
        /// <summary>
        /// 窗体唯一标识符
        /// </summary>
        public static string UniqueKey = "FrmSaleFuelLoad";

        public FrmSaleFuelLoad()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 每页显示行数
        /// </summary>
        int PageSize = 28;

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


        private void FrmBuyFuel_Load(object sender, EventArgs e)
        {
            InitForm();

            btnSearch_Click(null, null);
        }

        /// <summary>
        /// 窗体初始化
        /// </summary>
        private void InitForm()
        {
            dateTimeInput1.Value = DateTime.Now.Date;
            dateTimeInput2.Value = DateTime.Now.Date.AddDays(1).AddMilliseconds(-1);

            // 加载识别设备
        }

        public class CmcsTrainWeightRecordTemp : CmcsTrainWeightRecord
        {
            public int TrueNumber { get; set; }
        }

        public void BindData()
        {
            string tempSqlWhere = this.SqlWhere;
            List<CmcsSaleFuelTransport> list = Dbers.GetInstance().SelfDber.ExecutePager<CmcsSaleFuelTransport>(PageSize, CurrentIndex, tempSqlWhere + " order by GrossTime desc");

            CmcsSaleFuelTransport model = new CmcsSaleFuelTransport();
            model.GrossWeight = list.Sum(t => t.GrossWeight);
            model.TareWeight = list.Sum(t => t.TareWeight);
            model.SuttleWeight = list.Sum(t => t.SuttleWeight);
            model.CarNumber = "总计";
            list.Add(model);
            
            GetTotalCount(tempSqlWhere);
            superGridControl1.PrimaryGrid.DataSource = list;
            PagerControlStatue();

            lblPagerInfo.Text = string.Format("共 {0} 条记录，每页 {1} 条，共 {2} 页，当前第 {3} 页", TotalCount, PageSize, PageCount, CurrentIndex + 1);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.SqlWhere = string.Empty;

            if (!String.IsNullOrEmpty((String)dateTimeInput1.Text))
            {
                SqlWhere += " and GrossTime>= to_date('" + dateTimeInput1.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss') ";
            }
            if (!String.IsNullOrEmpty((String)dateTimeInput2.Text))
            {
                SqlWhere += " and GrossTime<= to_date('" + dateTimeInput2.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss') ";
            }

            if (!String.IsNullOrEmpty(this.SqlWhere))
            {
                SqlWhere = " where 1=1 " + SqlWhere;
            }
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
            TotalCount = Dbers.GetInstance().SelfDber.Count<CmcsSaleFuelTransport>(sqlWhere);
            if (TotalCount % PageSize != 0)
                PageCount = TotalCount / PageSize + 1;
            else
                PageCount = TotalCount / PageSize;
        }
        #endregion

        #region SuperGridControl

        private void superGridControl1_GetRowHeaderText(object sender, DevComponents.DotNetBar.SuperGrid.GridGetRowHeaderTextEventArgs e)
        {
            e.Text = ((this.CurrentIndex * this.PageSize) + e.GridRow.RowIndex + 1).ToString();
        }

        private void superGridControl1_BeginEdit(object sender, GridEditEventArgs e)
        {
            // 取消编辑
            e.Cancel = true;
        }

        #endregion


        private void superGridControl1_CellMouseDown(object sender, GridCellMouseEventArgs e)
        {
            if (e.GridCell.ColumnIndex == -1 || e.GridCell.GridRow.Index == -1)
                return;

            SuperGridControl sgc = (SuperGridControl)sender;
            var Cell = sgc.PrimaryGrid.GetCell(e.GridCell.GridRow.Index, 12);
            string id = Cell != null ? Cell.Value.ToString() : "";

            CmcsSaleFuelTransport entity = Dbers.GetInstance().SelfDber.Get<CmcsSaleFuelTransport>(id);
            if (entity == null)
                return;
            String newid = id.ToString();
            switch (sgc.PrimaryGrid.GetCell(e.GridCell.GridRow.Index, e.GridCell.ColumnIndex).NullString)
            {
                case "抓拍":
                   
                    break;
                case "装车线":
                    
                    break;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            FrmSaleFuelLoadToday frm = new FrmSaleFuelLoadToday();
            FrmMainFrame.superTabControlManager.CreateTab(frm.Text, frm.Text, frm, true);
        }

        private void superGridControl1_CellValidated(object sender, GridCellValidatedEventArgs e)
        {

        }

        private void superGridControl1_GetCellFormattedValue(object sender, GridGetCellFormattedValueEventArgs e)
        {
            if (e.GridCell.ColumnIndex == -1 || e.GridCell.GridRow.Index == -1)
                return;

            SuperGridControl sgc = (SuperGridControl)sender;
            //String newid = sgc.PrimaryGrid.GetCell(e.GridCell.GridRow.Index, 12).Value.ToString();
            //switch (sgc.PrimaryGrid.GetCell(e.GridCell.GridRow.Index, e.GridCell.ColumnIndex).NullString)
            //{
            //    case "抓拍":
                  
            //        break;
            //    case "装车线":
                    
            //        break;
            //}

        }

        private void superGridControl1_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            foreach (GridRow item in e.GridPanel.Rows)
            {
                try
                {
                    CmcsSaleFuelTransport cmcsBuyFuelTransport = item.DataItem as CmcsSaleFuelTransport;

                    CmcsFuelKind fk = Dbers.GetInstance().SelfDber.Get<CmcsFuelKind>(cmcsBuyFuelTransport.FuelKindId);
                    item.Cells["FuelKindName"].Value = fk != null ? fk.FuelName : "";

                    CmcsSupplier sp = Dbers.GetInstance().SelfDber.Get<CmcsSupplier>(cmcsBuyFuelTransport.SupplierId);
                    item.Cells["SupplierName"].Value = sp != null ? sp.Name : "";

                    CmcsTransportCompany tc = Dbers.GetInstance().SelfDber.Get<CmcsTransportCompany>(cmcsBuyFuelTransport.TransportCompanyId);
                    item.Cells["TransportCompanyName"].Value = tc != null ? tc.Name : "";

                    item.Cells["cellGrossWeight"].Value = cmcsBuyFuelTransport.GrossWeight.ToString("f2");
                    item.Cells["cellTareWeight"].Value = cmcsBuyFuelTransport.TareWeight.ToString("f2");
                    item.Cells["cellSuttleWeight"].Value = cmcsBuyFuelTransport.SuttleWeight.ToString("f2");


                    if (cmcsBuyFuelTransport.CarNumber != "总计")
                    {
                        item.Cells["cellInFactoryTime"].Value = cmcsBuyFuelTransport.InFactoryTime.ToShortDateString();
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
