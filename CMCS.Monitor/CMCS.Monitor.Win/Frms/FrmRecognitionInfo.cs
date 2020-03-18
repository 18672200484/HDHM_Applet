using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CMCS.Common;
//
using CMCS.Common.Entities;
using CMCS.Common.Entities.BaseInfo;
using CMCS.Common.Entities.Inf;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.SuperGrid;
using System.Data;
using CMCS.Common.Utilities;
using CMCS.Common.Entities.Fuel;
using CMCS.Common.Entities.CarTransport;
using Xilium.CefGlue;
using CMCS.Monitor.Win.UserControls;
using CMCS.Monitor.Win.Core;

namespace CMCS.Monitor.Win.Frms
{
    public partial class FrmRecognitionInfo : MetroForm
    {
        /// <summary>
        /// 窗体唯一标识符
        /// </summary>
        public static string UniqueKey = "FrmRecognitionInfo";

        public FrmRecognitionInfo()
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

        public string SqlWhere1 = string.Empty;
        public string SqlWhere2 = string.Empty;
        public static string Device = string.Empty;
    

        private void FrmPoundInfo_Load(object sender, EventArgs e)
        {
            InitForm();

            BindData();
        }

        /// <summary>
        /// 窗体初始化
        /// </summary>
        private void InitForm()
        {
            dateTimeInput1.Value = DateTime.Now.Date;
            dateTimeInput2.Value = DateTime.Now.Date.AddDays(1).AddMilliseconds(-1);

            List<CmcsCMEquipment> list = new List<CmcsCMEquipment>();
            CmcsCMEquipment item1 = new CmcsCMEquipment();
            item1.EquipmentName = "#1翻车机";
            item1.EquipmentCode = "1";
            list.Add(item1);

            CmcsCMEquipment item2 = new CmcsCMEquipment();
            item2.EquipmentName = "#2翻车机";
            item2.EquipmentCode = "2";
            list.Add(item2);

            //加载识别设备
            cmbPoundName.DisplayMember = "EquipmentName";
            cmbPoundName.ValueMember = "EquipmentCode";
            cmbPoundName.DataSource = list;
            cmbPoundName.SelectedIndex = 0;

            if (!string.IsNullOrEmpty(Device))
            {
                cmbPoundName.SelectedValue = Device;
            }
        }

        public void BindData()
        {
            TotalCount = 0;
            PageCount = 0;

            string tempSqlWhere = "";
            List<CmcsTrainRecognition> list = new List<CmcsTrainRecognition>();

            tempSqlWhere = " WHERE MACHINECODE = '" + cmbPoundName.SelectedValue + "'";
            if (!String.IsNullOrEmpty((String)dateTimeInput1.Text))
            {
                tempSqlWhere += " and CROSSTIME >= to_date('" + dateTimeInput1.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss') ";
            }
            if (!String.IsNullOrEmpty((String)dateTimeInput2.Text))
            {
                tempSqlWhere += " and CROSSTIME <= to_date('" + dateTimeInput2.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss') ";
            }
            List<CmcsTrainRecognition> list2 = new List<CmcsTrainRecognition>();
            List<CmcsTrainRecognition> list3 = new List<CmcsTrainRecognition>();

            List<CmcsTrainRecognition> list4 = Dbers.GetInstance().SelfDber.ExecutePager<CmcsTrainRecognition>(99999, 0, tempSqlWhere + " order by CROSSTIME desc");

            List<string> CARNUMBERS = list4.Select(t => t.CARNUMBER).Distinct().ToList();

            foreach (string item in CARNUMBERS)
            {
                var collection = list4.Where(t => t.CARNUMBER == item).OrderByDescending(t => t.CROSSTIME).ToList();
                list3.Add(collection[0]);
                
                for (int i = 0; i < collection.Count; i++)
                {
                    if (i + 1 < collection.Count)
                    {
                        if (Math.Abs((collection[i].CROSSTIME - collection[i + 1].CROSSTIME).Hours) >= 1)
                        {
                            list3.Add(collection[i + 1]);
                        }
                    }
                }
            }

            TotalCount = list3.Count;

            list2 = list3.Skip(CurrentIndex * PageSize).Take(PageSize).OrderByDescending(t=>t.CROSSTIME).ToList();

            if (TotalCount % PageSize != 0)
                PageCount += TotalCount / PageSize + 1;
            else
                PageCount += TotalCount / PageSize;

            superGridControl1.PrimaryGrid.DataSource = list2;

            PagerControlStatue();

            lblPagerInfo.Text = string.Format("共 {0} 条记录，每页 {1} 条，共 {2} 页，当前第 {3} 页", TotalCount, PageSize, PageCount, CurrentIndex + 1);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
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

        private void GetTotalCount1(string sqlWhere, ref int TotalCount, ref int PageCount)
        {
            TotalCount += Dbers.GetInstance().SelfDber.Count<CmcsTrainRecognition>(sqlWhere);
           
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

        private void superGridControl1_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            foreach (GridRow item in e.GridPanel.Rows)
            {
                try
                {
                    CmcsTrainRecognition CmcsTrainRecognition = item.DataItem as CmcsTrainRecognition;

                    item.Cells["cellMACHINECODE"].Value = "#" + CmcsTrainRecognition.MACHINECODE + "翻车机";
                    
                }
                catch (Exception)
                {
                }
            }
        }

    }

    public class RecognitionInfo
    {
        public string CarNumber { get; set; }
        public string SupplierName { get; set; }
        public string tType { get; set; }
        public string GrossTime { get; set; }
        public string GrossWeight { get; set; }
    }
}
