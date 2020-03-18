using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CMCS.CommonSynch.Utilities;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar;

namespace CMCS.CommonSynch
{
    public partial class FrmConfigSet : MetroForm
    {
        CommonAppConfig _CommonAppConfig;

        public FrmConfigSet()
        {
            this._CommonAppConfig = CommonAppConfig.GetInstance();

            InitializeComponent();
        }

        private void FrmConfigSet_Load(object sender, EventArgs e)
        {
            superGridControl1.PrimaryGrid.AutoGenerateColumns = false;

            txtCommonAppConfig.Text = this._CommonAppConfig.AppIdentifier;
            intIptSynchInterval.Value = this._CommonAppConfig.SynchInterval;
            chkStartup.Checked = this._CommonAppConfig.Startup;
            txtServerConnStr.Text = this._CommonAppConfig.ServerConnStr;
            txtClientConnStr.Text = this._CommonAppConfig.ClientConnStr;

            GridComboBoxExEditControl control = superGridControl1.PrimaryGrid.Columns["SynchType"].EditControl as GridComboBoxExEditControl;
            BindGridCombox(control, new List<string>() { "上传", "下达", "双向" });

            superGridControl1.PrimaryGrid.DataSource = this._CommonAppConfig.TableSynchs;
        }

        #region 操作

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<TableSynch> list = GetGridTableSynch();
            //list.Add(new TableSynch() { Enabled = false, SynchField = "Id", PrimaryKey = "Id", Sequence = 1, SynchTitle = "aa", SynchType = "上传", TableName = "aa", TableZNName = "aa" });
            list.Add(new TableSynch());
            superGridControl1.PrimaryGrid.DataSource = list;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (superGridControl1.PrimaryGrid.ActiveRow != null) superGridControl1.PrimaryGrid.Rows.Remove(superGridControl1.PrimaryGrid.ActiveRow as GridRow);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCommonAppConfig.Text.Trim()))
            {
                MessageBoxEx.Show("程序唯一标识不能为空!");
                return;
            }
            if (string.IsNullOrEmpty(txtServerConnStr.Text.Trim()))
            {
                MessageBoxEx.Show("服务器端Oracle数据库连接字符串不能为空!");
                return;
            }
            if (string.IsNullOrEmpty(txtClientConnStr.Text.Trim()))
            {
                MessageBoxEx.Show("就地端Oracle数据库连接字符串不能为空!");
                return;
            }

            string message = string.Empty;
            List<TableSynch> list = GetGridTableSynch();
            if (!VerifyGridData(list, ref message))
            {
                MessageBoxEx.Show(message);
                return;
            }

            this._CommonAppConfig.AppIdentifier = txtCommonAppConfig.Text;
            this._CommonAppConfig.ServerConnStr = txtServerConnStr.Text;
            this._CommonAppConfig.ClientConnStr = txtClientConnStr.Text;
            this._CommonAppConfig.SynchInterval = intIptSynchInterval.Value;
            this._CommonAppConfig.Startup = chkStartup.Checked;
            this._CommonAppConfig.TableSynchs = list;
            this._CommonAppConfig.Save();

            MessageBoxEx.Show("保存成功");

            //刷新
            superGridControl1.PrimaryGrid.DataSource = this._CommonAppConfig.TableSynchs;
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region 其他

        /// <summary>
        /// 绑定Grid下拉列表
        /// </summary>
        /// <param name="control"></param>
        /// <param name="list"></param>
        private void BindGridCombox(GridComboBoxExEditControl control, List<string> list)
        {
            control.DataSource = list;
        }

        /// <summary>
        /// 获取Grid列表数据
        /// </summary>
        /// <returns></returns>
        private List<TableSynch> GetGridTableSynch()
        {
            List<TableSynch> list = new List<TableSynch>();
            foreach (GridRow item in superGridControl1.PrimaryGrid.GridPanel.Rows)
            {
                list.Add(item.DataItem as TableSynch);
            }
            return list;
        }

        /// <summary>
        /// 验证Grid数据
        /// </summary>
        /// <returns></returns>
        private bool VerifyGridData(List<TableSynch> list, ref string message)
        {
            for (int i = 0; i < list.Count; i++)
            {
                TableSynch item = list[i];

                string res = string.Empty;
                if (string.IsNullOrEmpty(item.TableName.Trim()))
                    res += "表名不能为空!、";
                if (string.IsNullOrEmpty(item.PrimaryKey.Trim()))
                    res += "主键名不能为空!、";
                if (string.IsNullOrEmpty(item.SynchTitle.Trim()))
                    res += "标题不能为空!、";
                if (string.IsNullOrEmpty(item.SynchField.Trim()))
                    res += "同步标识字段不能为空!、";
                if (string.IsNullOrEmpty(item.SynchType.Trim()))
                    res += "同步类型不能为空!、";

                if (!string.IsNullOrEmpty(res))
                    message += "第" + (i + 1) + "行：" + res.Substring(0, res.Length - 1) + "<br />";
            }
            if (!string.IsNullOrEmpty(message))
                return false;
            else
                return true;
        }

        #endregion

        /// <summary>
        /// 重绘序列号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void superGridControl1_GetRowHeaderText(object sender, GridGetRowHeaderTextEventArgs e)
        {
            e.Text = (e.GridRow.RowIndex + 1).ToString();
        }

        private void superGridControl1_CellActivated(object sender, GridCellActivatedEventArgs e)
        {
            e.NewActiveCell.BeginEdit(true);
        }

    }
}