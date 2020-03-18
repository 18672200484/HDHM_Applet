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
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using CMCS.Common.Entities.TrainInFactory;
using CMCS.Common.Utilities;
using CMCS.Common.Entities.CarTransport;
using CMCS.Common.Entities.BaseInfo;

namespace CMCS.Monitor.Win.Frms
{
    public partial class FrmSaleFuelLoadToday : MetroForm
    {
        /// <summary>
        /// 窗体唯一标识符
        /// </summary>
        public static string UniqueKey = "FrmSaleFuelLoadToday";

        public FrmSaleFuelLoadToday()
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
        string Id;


        private void FrmBuyFuel_Load(object sender, EventArgs e)
        {
            InitForm();
            BindData();
        }

        /// <summary>
        /// 窗体初始化
        /// </summary>
        private void InitForm()
        {
        }

        public class CmcsTrainWeightRecordTemp : CmcsTrainWeightRecord
        {
            public int TrueNumber { get; set; }
        }

        public void BindData()
        {
            string tempSqlWhere = this.SqlWhere;

            List<CmcsSaleFuelTransport> list = Dbers.GetInstance().SelfDber.Entities<CmcsSaleFuelTransport>(" where GrossTime>=to_date('" + DateTime.Now.ToString("yyyy-MM-dd") + "','yyyy-mm-dd') order by SerialNumber desc");

            CmcsSaleFuelTransport model = new CmcsSaleFuelTransport();

            model.GrossWeight = list.Sum(t => t.GrossWeight);
            model.TareWeight = list.Sum(t => t.TareWeight);
            model.SuttleWeight = list.Sum(t => t.SuttleWeight);
            model.CarNumber = "总计";
            list.Add(model);

            superGridControl1.PrimaryGrid.DataSource = list;
            if (list.Count > 0)
            {
                Id = list[0].Id;
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FrmSaleFuelLoad frm = new FrmSaleFuelLoad();
            FrmMainFrame.superTabControlManager.CreateTab(frm.Text, frm.Text, frm, true);
        }

        #region Pager

        private void btnPagerCommand_Click(object sender, EventArgs e)
        {
            BindData();
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
            if (e.GridCell.GridRow.Index == -1)
                return;
            e.GridCell.GridRow.IsSelected = true;
            SuperGridControl supergridcontrol = (SuperGridControl)sender;
            Id = supergridcontrol.GetCell(e.GridCell.GridRow.RowIndex, 11).Value.ToString();
        }

        List<CmcsTrainWatch> newcmcstrainwatchs;
        int SelectedIndex = 0;
        private void superGridControl1_RowHeaderClick(object sender, GridRowHeaderClickEventArgs e)
        {
            if (e.GridRow.Index == -1)
                return;
            e.GridRow.IsSelected = true;
            SuperGridControl supergridcontrol = (SuperGridControl)sender;
            Id = supergridcontrol.GetCell(e.GridRow.RowIndex, 11).Value.ToString();
        }

        private void BtnClick(object sender, EventArgs e)
        {
            if (newcmcstrainwatchs != null)
            {
                if (((ButtonX)sender).Text == "下一张")
                {
                    if (SelectedIndex == newcmcstrainwatchs.Count - 1)
                    {
                        SelectedIndex = 0;
                    }
                    else
                    {
                        SelectedIndex++;
                    }
                }
                else if ((((ButtonX)sender).Text == "上一张"))
                {
                    if (SelectedIndex == 0)
                    {
                        SelectedIndex = newcmcstrainwatchs.Count - 1;
                    }
                    else
                    {
                        SelectedIndex--;
                    }
                }
            }
        }


        private void FrmBuyFuelLoadToday_Shown(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindData();
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
