using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CMCS.Common;
using CMCS.Common.Entities.CarTransport;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;

namespace CMCS.CarTransport.Queue.Frms.BaseInfo.CarModel
{
    public partial class FrmCarModel_Select : DevComponents.DotNetBar.Metro.MetroForm
    {
        /// <summary>
        /// 选中的实体
        /// </summary>
        public CmcsCarModel Output;

        /// <summary>
        /// 条件语句
        /// </summary>
        string sqlWhere;

        public FrmCarModel_Select(string sqlWhere)
        {
            InitializeComponent();

            this.sqlWhere = sqlWhere;

            Search(string.Empty);
        }

        private void FrmCarModel_Select_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Output = null;
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void txtInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (superGridControl1.PrimaryGrid.Rows.Count > 0) superGridControl1.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                Return();
            }
            else
            {
                Search(txtInput.Text.Trim());
            }
        }

        void Search(string input)
        {
            List<CmcsCarModel> list = Dbers.GetInstance().SelfDber.Entities<CmcsCarModel>("where ModelName like '%'|| :ModelName ||'%' " + sqlWhere, new { ModelName = input.ToUpper().Trim() });
            superGridControl1.PrimaryGrid.DataSource = list;
        }

        void Return()
        {
            GridRow gridRow = superGridControl1.PrimaryGrid.ActiveRow as GridRow;
            if (gridRow == null) return;

            this.Output = (gridRow.DataItem as CmcsCarModel);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void superGridControl1_BeginEdit(object sender, DevComponents.DotNetBar.SuperGrid.GridEditEventArgs e)
        {
            // 取消编辑模式
            e.Cancel = true;
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

        private void superGridControl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Return();
        }

        private void superGridControl1_CellDoubleClick(object sender, GridCellDoubleClickEventArgs e)
        {
            Return();
        }


        private void superGridControl1_DataBindingComplete(object sender, DevComponents.DotNetBar.SuperGrid.GridDataBindingCompleteEventArgs e)
        {

            foreach (GridRow gridRow in e.GridPanel.Rows)
            {
                CmcsCarModel entity = gridRow.DataItem as CmcsCarModel;
                if (entity == null) return;

                // 填充有效状态
                gridRow.Cells["Obstacle1"].Value = entity.LeftObstacle1 + "|" + entity.RightObstacle1;
                gridRow.Cells["Obstacle2"].Value = entity.LeftObstacle2 + "|" + entity.RightObstacle2;
                gridRow.Cells["Obstacle3"].Value = entity.LeftObstacle3 + "|" + entity.RightObstacle3;
                gridRow.Cells["Obstacle4"].Value = entity.LeftObstacle4 + "|" + entity.RightObstacle4;
                gridRow.Cells["Obstacle5"].Value = entity.LeftObstacle5 + "|" + entity.RightObstacle5;
                gridRow.Cells["Obstacle6"].Value = entity.LeftObstacle6 + "|" + entity.RightObstacle6;
            }
        }
    }
}