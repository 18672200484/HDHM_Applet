using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.WeighCheck.SampleCheck.Frms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;

namespace CMCS.WeighCheck.SampleCheck.Frms
{
    public partial class FrmSetting : DevComponents.DotNetBar.Metro.MetroForm
    {
        CommonDAO commonDAO = CommonDAO.GetInstance();

        string Old_Param = string.Empty;
        public FrmSetting()
        {
            InitializeComponent();
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            try
            {
                cmbLibra_COM.SelectedIndex = 0;
                cmbLibra_Bandrate.SelectedIndex = 0;
                cmbDataBits.SelectedIndex = 0;
                cmbParity.SelectedIndex = 0;

                labelX1.ForeColor = Color.Red;
                labelX4.ForeColor = Color.Red;

                txtCommonAppConfig.Text = CommonAppConfig.GetInstance().AppIdentifier;
                //制样机设备编码
                txtAutoMakerCode.Text = commonDAO.GetAppletConfigString("全自动制样机编码");

                //电子秤
                SelectedComboItem("COM" + commonDAO.GetAppletConfigInt32("电子秤串口"), cmbLibra_COM);
                SelectedComboItem(commonDAO.GetAppletConfigString("电子秤波特率"), cmbLibra_Bandrate);
                SelectedComboItem(commonDAO.GetAppletConfigString("电子秤数据位"), cmbDataBits);
                SelectedComboItem(commonDAO.GetAppletConfigString("电子秤停止位"), cmbParity);
                // 读卡器
                //SelectedComboItem("COM" + commonDAO.GetAppletConfigInt32("Read_Write_COM"), cmbRead_Write_COM);
                //SelectedComboItem(commonDAO.GetAppletConfigString("Read_Write_Bandrate"), cmbRead_Write_Bandrate);
                //电子秤最小重量
                dInputLibraWeight.Value = commonDAO.GetAppletConfigDouble("电子秤最小重量");
                //是否启用称重
                chkIsUseWeight.Checked = Convert.ToBoolean(commonDAO.GetAppletConfigInt32("启用称重"));

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show("参数初始化失败" + ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// 选中ComboItem
        /// </summary>
        /// <param name="text"></param>
        /// <param name="cmb"></param>
        private void SelectedComboItem(string text, ComboBoxEx cmb)
        {
            foreach (ComboItem item in cmb.Items)
            {
                if (item.Text == text)
                {
                    cmb.SelectedItem = item;
                    break;
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //制样机设备编码
            commonDAO.SetAppletConfig("全自动制样机编码", txtAutoMakerCode.Text);
            //电子秤
            commonDAO.SetAppletConfig("电子秤串口", (cmbLibra_COM.SelectedIndex + 1).ToString());
            commonDAO.SetAppletConfig("电子秤波特率", (cmbLibra_Bandrate.SelectedItem as ComboItem).Text);
            commonDAO.SetAppletConfig("电子秤数据位", (cmbDataBits.SelectedItem as ComboItem).Text);
            commonDAO.SetAppletConfig("电子秤停止位", (cmbParity.SelectedItem as ComboItem).Text);
            //读卡器
            //commonDAO.SetAppletConfig("Read_Write_COM", (cmbRead_Write_COM.SelectedIndex + 1).ToString());
            //commonDAO.SetAppletConfig("Read_Write_Bandrate", (cmbRead_Write_Bandrate.SelectedItem as ComboItem).Text);
            //电子秤最小重量
            commonDAO.SetAppletConfig("电子秤最小重量", dInputLibraWeight.Value.ToString());
            //是否启用称重
            commonDAO.SetAppletConfig("启用称重", (chkIsUseWeight.Checked ? 1 : 0).ToString());

            if (MessageBoxEx.Show("更改的配置需要重启程序才能生效，是否立刻重启？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Restart();
            else
                this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}