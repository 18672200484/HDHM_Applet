using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Reflection;
using CMCS.CommonADGS.Core;
using CMCS.CommonADGS.Configurations;

namespace CMCS.CommonADGS.Server
{
    public partial class ConfigSetting : Form
    {
        public ConfigSetting()
        {
            InitializeComponent();
        }

        private void ConfigSetting_Load(object sender, EventArgs e)
        {
            try
            {
                initPage();
            }
            catch (Exception ex)
            {
                MessageBox.Show("配置文件读取失败，原因：" + ex.Message);
            }
        }

        #region 读取配置文件后内容显示
        private void initPage()
        {
            FillUIFromConfig();
        }

        private void FillUIFromConfig()
        {
            this.txtAppIdentifier.Text = ServerConfiguration.Instance.AppIdentifier;
            this.ckStartup.Checked = ServerConfiguration.Instance.Startup;
            this.ckIsSecretRunning.Checked = ServerConfiguration.Instance.IsSecretRunning;
            this.ckVerifyBeforeClose.Checked = ServerConfiguration.Instance.VerifyBeforeClose;

            ServerConfigurationDetail add = new ServerConfigurationDetail()
            {
                MachineCode = "→点击新增配置←",
                Port = 0,
                SavePath = "",
                Enabled = true
            };
            if (ServerConfiguration.Instance.ServerPortSets.Count(a => a.MachineCode == "→点击新增配置←") <= 0)
                ServerConfiguration.Instance.ServerPortSets.Add(add);

            this.Instruments.DataSource = null;
            this.Instruments.DataSource = ServerConfiguration.Instance.ServerPortSets;
            this.Instruments.DisplayMember = "MachineCode";
            this.Instruments.SelectedIndex = 0;
        }
        #endregion

        #region 保存基础配置
        private void btnBase_Click(object sender, EventArgs e)
        {
            String notEmpty = String.Empty;
            if (String.IsNullOrWhiteSpace(txtAppIdentifier.Text.Trim()))
                notEmpty += "程序唯一标识、";
            if (!String.IsNullOrWhiteSpace(notEmpty))
            {
                MessageBox.Show(String.Format("{0}不能为空！", notEmpty.Trim('、')));
                return;
            }
            try
            {
                ServerConfiguration.Instance.AppIdentifier = txtAppIdentifier.Text.Trim();
                ServerConfiguration.Instance.Startup = ckStartup.Checked;
                ServerConfiguration.Instance.IsSecretRunning = ckIsSecretRunning.Checked;
                ServerConfiguration.Instance.VerifyBeforeClose = ckVerifyBeforeClose.Checked;
                ServerConfiguration.Instance.Save();
                MessageBox.Show("基础配置保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("基础配置保存失败，原因：" + ex.Message);
            }
        }
        #endregion

        #region 左侧节点选择后填充右侧数据
        private void Instruments_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServerConfigurationDetail grab = (ServerConfigurationDetail)this.Instruments.SelectedValue;
            if (grab == null) return;
            if (grab.MachineCode == "→点击新增配置←")
            {
                txtMachineCode.Text = String.Empty;
                txtPort.Value = 0;
                ckEnabled.Checked = true;
                txtSavePath.Text = string.Empty;
                return;
            }

            txtMachineCode.Text = grab.MachineCode;
            ckEnabled.Checked = grab.Enabled;
            txtPort.Value = grab.Port;
            txtSavePath.Text = grab.SavePath;
        }
        #endregion

        #region 保存化验设备配置验证
        private String ValidateInput()
        {
            String notEmpty = String.Empty;
            if (String.IsNullOrWhiteSpace(txtMachineCode.Text.Trim()))
                notEmpty += "设备编号、";
            if (String.IsNullOrWhiteSpace(txtPort.Text.Trim()))
                notEmpty += "端口号、";
            if (String.IsNullOrWhiteSpace(txtSavePath.Text.Trim()))
                notEmpty += "存放路径、";
            if (!String.IsNullOrWhiteSpace(notEmpty))
                return String.Format("{0}不能为空！", notEmpty.Trim('、'));

            return String.Empty;
        }
        #endregion

        #region 配置明细保存
        private void btnSaveAssay_Click(object sender, EventArgs e)
        {
            String valid = ValidateInput();
            if (!String.IsNullOrWhiteSpace(valid))
            {
                MessageBox.Show(valid);
                return;
            }
            int index = this.Instruments.SelectedIndex;

            ServerConfiguration.Instance.ServerPortSets[index].MachineCode = this.txtMachineCode.Text.Trim();
            ServerConfiguration.Instance.ServerPortSets[index].Port = Convert.ToInt32(this.txtPort.Value);
            ServerConfiguration.Instance.ServerPortSets[index].SavePath = this.txtSavePath.Text.Trim();
            ServerConfiguration.Instance.ServerPortSets[index].Enabled = ckEnabled.Checked;

            try
            {
                ServerConfiguration.Instance.Save();
                FillUIFromConfig();
                MessageBox.Show("保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败！原因：" + ex.Message);
            }
        }
        #endregion
    }
}
