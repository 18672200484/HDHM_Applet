using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//
using CMCS.EPCEmpower.Core;
using CMCS.EPCEmpower.Enums;
using CMCS.EPCEmpower.Utilities;
using Oracle.ManagedDataAccess.Client;
using RW.LZR12;

namespace CMCS.EPCEmpower
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OracleHelper oracleHelper;
        SelfAppConfig selfAppConfig = SelfAppConfig.GetInstance();
        //UHFReader18Rwer Rwer = new UHFReader18Rwer();
        Lzr12Rwer Rwer = new Lzr12Rwer();

        bool isConnectedRwer = false;
        /// <summary>
        /// 已连接发卡器
        /// </summary>
        public bool IsConnectRwer
        {
            get { return isConnectedRwer; }
            set
            {
                isConnectedRwer = value;

                btnStartScan.Enabled = value;
                btnStartEmpower.Enabled = value;

                btnOCRwer.Text = value ? "断开发卡器" : "连接发卡器";
            }
        }

        bool isScanning = false;
        /// <summary>
        /// 正在读卡
        /// </summary>
        public bool IsScanning
        {
            get { return isScanning; }
            set
            {
                isScanning = value;

                timer1.Enabled = value;
                btnStartEmpower.Enabled = !value;

                if (value)
                {
                    lvwReadResult.Items.Clear();

                    //this.Rwer.StartRead();
                    timer1.Enabled = true;
                }
                else
                {
                    //this.Rwer.StopRead();
                    timer1.Enabled = false;
                }

                btnStartScan.Text = value ? "结束读卡" : "开始读卡";
            }
        }

        bool isEmpower = false;
        /// <summary>
        /// 正在授权
        /// </summary>
        public bool IsEmpower
        {
            get { return isEmpower; }
            set
            {
                isEmpower = value;

                timer1.Enabled = false;

                timer2.Enabled = value;
                chbAutoIncrease.Enabled = !value;
                btnStartScan.Enabled = !value;
                txtStartNumber.Enabled = !value;
                rbtnClientMode.Enabled = !value;
                rbtnNetMode.Enabled = !value;

                if (value)
                {
                    lvwReadResult.Items.Clear();

                    timer1.Enabled = true;
                }
                else
                {
                    timer1.Enabled = false;
                }

                btnStartEmpower.Text = value ? "结束授权" : "开始授权";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "版本：" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            this.oracleHelper = new OracleHelper(this.selfAppConfig.SelfConnStr);

            LoadConfig();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.IsConnectRwer) btnOCRwer_Click(null, null);

            SaveConfig();
        }

        /// <summary>
        /// 连接\断开发卡器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOCRwer_Click(object sender, EventArgs e)
        {
            if (!this.IsConnectRwer)
            {
                //if (this.Rwer.OpenCom(Convert.ToInt32(cmbCom.Text.Replace("COM", "")), 57600))
                //{
                //    this.IsConnectRwer = true;
                //}
                //else
                //    MessageBox.Show("发卡器连接失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (this.Rwer.OpenCom(Convert.ToInt32(cmbCom.Text.Replace("COM", "")), 18))
                {
                    this.IsConnectRwer = true;
                }
                else
                    MessageBox.Show("发卡器连接失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Rwer.CloseCom();

                this.IsConnectRwer = false;
            }
        }

        /// <summary>
        /// 开始授权
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartEmpower_Click(object sender, EventArgs e)
        {
            this.IsEmpower = !this.IsEmpower;
        }

        /// <summary>
        /// 开始读卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartScan_Click(object sender, EventArgs e)
        {
            this.IsScanning = !this.IsScanning;
        }

        /// <summary>
        /// 显示识别的标签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //foreach (string tempid in this.Rwer.Tags)
                //{
                //    UpdateReadTagIds(tempid);
                //}

                //this.Rwer.Tags.Clear();

                foreach (string tempid in this.Rwer.ScanTags())
                {
                    UpdateReadTagIds(tempid);
                }

                //this.Rwer.Tags.Clear();
            }
            catch { }
        }

        /// <summary>
        /// 更新识别的标签记录
        /// </summary>
        /// <param name="tagId"></param>
        public void UpdateReadTagIds(string tagId)
        {
            bool hasItem = false;
            foreach (ListViewItem item in lvwReadResult.Items)
            {
                if (item.SubItems[1].Text == tagId)
                {
                    item.SubItems[2].Text = Convert.ToString(Convert.ToInt32(item.SubItems[2].Text) + 1);
                    hasItem = true;

                    break;
                }
            }

            if (!hasItem)
            {
                int index = lvwReadResult.Items.Count + 1;
                ListViewItem newitem = new ListViewItem(index.ToString());
                newitem.SubItems.Add(tagId);
                newitem.SubItems.Add("1");

                lvwReadResult.Items.Add(newitem);
            }
        }

        /// <summary>
        /// 开始授权
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();

            string prefixCode = EncodingSMS(selfAppConfig.PrefixCode);
            string newTagId = prefixCode + txtStartNumber.Value.ToString().PadLeft(24 - prefixCode.Length, '0');

            if (this.Rwer.WriteEPC(newTagId))
            {
                if (rbtnNetMode.Checked)
                {
                    if (this.oracleHelper.ExecuteDataTable(this.selfAppConfig.CheckSQL, new OracleParameter[] { new OracleParameter("TagId", newTagId) }).Rows.Count == 0)
                    {
                        this.oracleHelper.ExecuteNonQuery(this.selfAppConfig.InsertSQL, new OracleParameter[] { new OracleParameter("Id", Guid.NewGuid().ToString()), new OracleParameter("TagId", newTagId), new OracleParameter("CardNumber", newTagId.Substring(19)), new OracleParameter("InStorageDate", DateTime.Now.ToString()) });
                    }
                    else
                    {
                        MessageBox.Show("入库失败，该标签号已存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.IsEmpower = false;
                    }
                }

                InsertTagItem(newTagId, DateTime.Now);

                if (chbAutoIncrease.Checked) txtStartNumber.Value++;

                //if (MessageBox.Show("授权成功，标签号：" + newTagId + "\r\n是否继续授权？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                MessageBox.Show("授权成功，标签号：" + newTagId + "\r\n请放入下一张标签卡，已授权的标签卡距离不要太近！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                timer2.Start();
                //}
                //else
                //{
                //    this.IsEmpower = false;
                //}
            }

            timer2.Start();
        }

        /// <summary>
        /// 字符串转十六进制编码
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string EncodingSMS(string value)
        {
            string result = string.Empty;

            byte[] arrByte = System.Text.Encoding.GetEncoding("GB2312").GetBytes(value);
            for (int i = 0; i < arrByte.Length; i++)
            {
                result += System.Convert.ToString(arrByte[i], 16);
            }

            return result.ToUpper();
        }

        /// <summary>
        /// 加载标签卡记录
        /// </summary>
        private void LoadTags()
        {
            if (rbtnNetMode.Checked)
            {
                lvwEmpowered.Items.Clear();

                DataTable dt = this.oracleHelper.ExecuteDataTable(this.selfAppConfig.SelectSQL);
                foreach (DataRow dr in dt.Rows) InsertTagItem(dr["TagId"].ToString(), Convert.ToDateTime(dr["InStorageDate"].ToString()));
            }
        }

        /// <summary>
        /// 插入标签数据到列表
        /// </summary>
        /// <param name="tagId"></param>
        /// <param name="dt"></param> 
        private void InsertTagItem(string tagId, DateTime dt)
        {
            ListViewItem item = new ListViewItem((lvwEmpowered.Items.Count + 1).ToString());
            item.SubItems.Add(tagId);

            item.SubItems.Add(dt.ToString("yyyy-MM-dd HH:mm:ss"));

            lvwEmpowered.Items.Add(item);
        }

        /// <summary>
        /// 加载配置
        /// </summary>
        void LoadConfig()
        {
            cmbCom.Text = "COM" + this.selfAppConfig.RwerCom.ToString();
            txtPrefixCode.Text = this.selfAppConfig.PrefixCode;
            txtStartNumber.Value = this.selfAppConfig.StartNumber;
            chbAutoIncrease.Checked = this.selfAppConfig.AutoIncrease;
            rbtnClientMode.Checked = this.selfAppConfig.EmpowerMode == 1;
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        void SaveConfig()
        {
            this.selfAppConfig.RwerCom = Convert.ToInt32(cmbCom.Text.Replace("COM", ""));
            this.selfAppConfig.StartNumber = (int)txtStartNumber.Value;
            this.selfAppConfig.AutoIncrease = chbAutoIncrease.Checked;
            this.selfAppConfig.EmpowerMode = rbtnClientMode.Checked ? 1 : 2;
            this.selfAppConfig.Save();
        }

        private void rbtnNetMode_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnNetMode.Checked)
                LoadTags();
            else
                lvwEmpowered.Items.Clear();
        }
    }
}
