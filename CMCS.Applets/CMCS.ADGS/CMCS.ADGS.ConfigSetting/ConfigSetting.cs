using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using CMCS.ADGS.Core;
using System.Reflection;

namespace CMCS.ADGS.ConfigSetting
{
    public partial class ConfigSetting : Form
    {
        ADGSAppConfig appConfig;

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
            appConfig = ADGSAppConfig.GetInstance();
            FillUIFromConfig();
        }

        private void FillUIFromConfig()
        {
            this.txtAppIdentifier.Text = appConfig.AppIdentifier;
            this.txtSelfConnStr.Text = appConfig.SelfConnStr;
            this.txtGrabInterval.Value = (decimal)appConfig.GrabInterval;
            this.txtOracleKeywords.Text = appConfig.OracleKeywords;
            this.ckStartup.Checked = appConfig.Startup;

            ByoGraber add = new ByoGraber()
            {
                MachineCode = "→点击新增化验设备←",
                TableName = "",
                PrimaryKeys = "",
                ConnStr = "",
            };
            if (appConfig.AssayGrabers.Count(a => a.MachineCode == "→点击新增化验设备←") <= 0)
                appConfig.AssayGrabers.Add(add);

            this.Instruments.DataSource = null;
            this.Instruments.DataSource = appConfig.AssayGrabers;
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
            if(String.IsNullOrWhiteSpace(txtSelfConnStr.Text.Trim()))
                notEmpty += "Oracle数据库连接字符串、";
            if (!String.IsNullOrWhiteSpace(notEmpty))
            {
                MessageBox.Show(String.Format("{0}不能为空！",notEmpty.Trim('、')));
                return;
            }
            if (txtGrabInterval.Value<=0)
            {
                MessageBox.Show("提取时间间隔不能小于等于0！");
                return;
            }
            try
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(ADGSAppConfig.ConfigXmlPath);

                XmlNode node = xdoc.SelectSingleNode("root/AppIdentifier");
                node.InnerText = txtAppIdentifier.Text.Trim();

                node = xdoc.SelectSingleNode("root/SelfConnStr");
                node.InnerText = txtSelfConnStr.Text.Trim();

                node = xdoc.SelectSingleNode("root/GrabInterval");
                node.InnerText = ((int)txtGrabInterval.Value).ToString();

                node = xdoc.SelectSingleNode("root/OracleKeywords");
                node.InnerText = txtOracleKeywords.Text.Trim();

                node = xdoc.SelectSingleNode("root/Startup");
                node.InnerText = ckStartup.Checked ? "True" : "False";

                xdoc.Save(ADGSAppConfig.ConfigXmlPath);
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
            AssayGraber grab = (AssayGraber)this.Instruments.SelectedValue;
            if (grab == null) return;
            if (grab.MachineCode == "→点击新增化验设备←")
            {
                sysGraber.Checked = true;
                selfDefineGraber.Checked = false;
                txtMachineCode.Text = String.Empty;
                txtTableName.Text = String.Empty;
                txtPrimaryKeys.Text = String.Empty;
                txtConnStr.Text = String.Empty;
                ddlDbType.Enabled = true;
                txtSQL.Enabled = true;
                txtSQL.Text = String.Empty;
                ckEnabled.Checked = true;
                txtGaberType.Text = string.Empty;
                txtGaberType.Enabled = false;
                txtDayRange.Enabled = false;
                return;
            }
            if (grab.Parameters.ContainsKey("GaberType"))
            {
                #region 自定义抓取
                sysGraber.Checked = false;
                selfDefineGraber.Checked = true;

                txtGaberType.Enabled = true;
                KeyValuePair<String, String> kp = new KeyValuePair<string, string>();
                kp = grab.Parameters.Where(a => a.Key == "GaberType").FirstOrDefault();
                if (!String.IsNullOrWhiteSpace(kp.Key))
                    txtGaberType.Text = kp.Value;

                txtDayRange.Enabled = true;
                kp = grab.Parameters.Where(a => a.Key == "DayRange").FirstOrDefault();
                if (!String.IsNullOrWhiteSpace(kp.Key))
                    txtDayRange.Text = kp.Value;

                txtSQL.Text = String.Empty;
                ddlDbType.SelectedValue = null;
                txtSQL.Enabled = false;
                ddlDbType.Enabled = false;
                #endregion
            }
            else
            {
                #region 系统内置抓取
                sysGraber.Checked = true;
                selfDefineGraber.Checked = false;

                ddlDbType.Enabled = true;
                KeyValuePair<String, String> kp = new KeyValuePair<string, string>();
                kp = grab.Parameters.Where(a => a.Key == "DbType").FirstOrDefault();
                if (!String.IsNullOrWhiteSpace(kp.Key))
                    ddlDbType.SelectedIndex = ddlDbType.Items.IndexOf(kp.Value);

                txtSQL.Enabled = true;
                kp = grab.Parameters.Where(a => a.Key == "SQL").FirstOrDefault();
                if (!String.IsNullOrWhiteSpace(kp.Key))
                    txtSQL.Text = kp.Value;

                txtGaberType.Text = String.Empty;
                txtGaberType.Enabled = false;
                txtDayRange.Enabled = false;
                #endregion
            }
            txtMachineCode.Text = grab.MachineCode;
            txtTableName.Text = grab.TableName;
            txtPrimaryKeys.Text = grab.PrimaryKeys;
            txtConnStr.Text = grab.ConnStr;
            ckEnabled.Checked = grab.Enabled;
        }
        #endregion

        #region 抓取类型切换
        private void sysGraber_CheckedChanged(object sender, EventArgs e)
        {
            if (sysGraber.Checked)
            {
                ddlDbType.Enabled = true;
                txtGaberType.Text = String.Empty;
                txtGaberType.Enabled = false;
                txtDayRange.Enabled = false;
                txtSQL.Enabled = true;

                if (this.Instruments.SelectedValue == null) return;
                AssayGraber grab = (AssayGraber)this.Instruments.SelectedValue;
                if (grab == null) return;

                KeyValuePair<String, String> kp = new KeyValuePair<string, string>();
                kp = grab.Parameters.Where(a => a.Key == "DbType").FirstOrDefault();
                if (!String.IsNullOrWhiteSpace(kp.Key))
                    ddlDbType.SelectedIndex = ddlDbType.Items.IndexOf(kp.Value);

                kp = grab.Parameters.Where(a => a.Key == "SQL").FirstOrDefault();
                if (!String.IsNullOrWhiteSpace(kp.Key))
                    txtSQL.Text = kp.Value;
            }
            if (selfDefineGraber.Checked)
            {
                txtGaberType.Enabled = true;
                txtSQL.Text = String.Empty;
                ddlDbType.SelectedValue = null;
                txtSQL.Enabled = false;
                ddlDbType.Enabled = false;

                if (this.Instruments.SelectedValue == null) return;
                AssayGraber grab = (AssayGraber)this.Instruments.SelectedValue;
                if (grab == null) return;

                KeyValuePair<String, String> kp = new KeyValuePair<string, string>();
                kp = grab.Parameters.Where(a => a.Key == "GaberType").FirstOrDefault();
                if (!String.IsNullOrWhiteSpace(kp.Key))
                    txtGaberType.Text = kp.Value;

                txtDayRange.Enabled = true;
                kp = grab.Parameters.Where(a => a.Key == "DayRange").FirstOrDefault();
                if (!String.IsNullOrWhiteSpace(kp.Key))
                    txtDayRange.Text = kp.Value;
            }
        }
        #endregion

        #region 保存化验设备配置文件
        private void SaveAssayInstruments()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(ADGSAppConfig.ConfigXmlPath);

            XmlNode root = xdoc.SelectSingleNode("/root/Instruments");
            XmlNodeList nodeList= xdoc.SelectNodes("/root/Instruments/*");
            foreach (XmlNode item in nodeList)
            {
                root.RemoveChild(item);
            }

            foreach (AssayGraber item in appConfig.AssayGrabers)
            {
                if (item.MachineCode == "→点击新增化验设备←") continue;
                XmlElement MachineCode = xdoc.CreateElement("Param");
                MachineCode.SetAttribute("Key", "MachineCode");
                MachineCode.SetAttribute("Value", item.MachineCode);

                XmlElement TableName = xdoc.CreateElement("Param");
                TableName.SetAttribute("Key", "TableName");
                TableName.SetAttribute("Value", item.TableName);

                XmlElement PrimaryKeys = xdoc.CreateElement("Param");
                PrimaryKeys.SetAttribute("Key", "PrimaryKeys");
                PrimaryKeys.SetAttribute("Value", item.PrimaryKeys);

                XmlElement ConnStr = xdoc.CreateElement("Param");
                ConnStr.SetAttribute("Key", "ConnStr");
                ConnStr.SetAttribute("Value", item.ConnStr);

                XmlElement Enabled = xdoc.CreateElement("Param");
                Enabled.SetAttribute("Key", "Enabled");
                Enabled.SetAttribute("Value", item.Enabled ? "True" : "False");

                if (item.Parameters.ContainsKey("GaberType"))
                {
                    #region 自定义抓取
                    XmlElement selfGracer = xdoc.CreateElement("CustomGraber");

                    XmlElement GaberType = xdoc.CreateElement("Param");
                    GaberType.SetAttribute("Key", "GaberType");
                    GaberType.SetAttribute("Value", item.Parameters.Where(a => a.Key == "GaberType").FirstOrDefault().Value);
                    selfGracer.AppendChild(GaberType);

                    selfGracer.AppendChild(MachineCode);
                    selfGracer.AppendChild(TableName);
                    selfGracer.AppendChild(PrimaryKeys);
                    selfGracer.AppendChild(ConnStr);

                    XmlElement DayRange = xdoc.CreateElement("Param");
                    DayRange.SetAttribute("Key", "DayRange");
                    DayRange.SetAttribute("Value", item.Parameters.Where(a => a.Key == "DayRange").FirstOrDefault().Value);
                    selfGracer.AppendChild(DayRange);

                    selfGracer.AppendChild(Enabled);

                    root.AppendChild(selfGracer);
                    #endregion
                }
                else
                {
                    #region 系统内置抓取
                    XmlElement sysGracer = xdoc.CreateElement("ByoGraber");

                    sysGracer.AppendChild(MachineCode);
                    sysGracer.AppendChild(TableName);
                    sysGracer.AppendChild(PrimaryKeys);
                    sysGracer.AppendChild(ConnStr);

                    XmlElement DbType = xdoc.CreateElement("Param");
                    DbType.SetAttribute("Key", "DbType");
                    DbType.SetAttribute("Value", item.Parameters.Where(a => a.Key == "DbType").FirstOrDefault().Value);
                    sysGracer.AppendChild(DbType);

                    XmlElement SQL = xdoc.CreateElement("Param");
                    SQL.SetAttribute("Key", "SQL");
                    SQL.SetAttribute("Value", item.Parameters.Where(a => a.Key == "SQL").FirstOrDefault().Value);
                    sysGracer.AppendChild(SQL);

                    sysGracer.AppendChild(Enabled);

                    root.AppendChild(sysGracer);
                    #endregion
                }
            }
            xdoc.Save(ADGSAppConfig.ConfigXmlPath);
        }
        #endregion

        #region 保存化验设备配置验证
        private String ValidateInput()
        {
            String notEmpty = String.Empty;
            if (String.IsNullOrWhiteSpace(txtMachineCode.Text.Trim()))
                notEmpty += "设备编号、";
            if (String.IsNullOrWhiteSpace(txtTableName.Text.Trim()))
                notEmpty += "Oracle存储表名、";
            if (String.IsNullOrWhiteSpace(txtPrimaryKeys.Text.Trim()))
                notEmpty += "主键名、";
            if (String.IsNullOrWhiteSpace(txtConnStr.Text.Trim()))
                notEmpty += "化验设备数据库连接字符串、";
            if (!String.IsNullOrWhiteSpace(notEmpty))
                return String.Format("{0}不能为空！", notEmpty.Trim('、'));

            if (sysGraber.Checked)
            {
                if (String.IsNullOrWhiteSpace(txtSQL.Text.Trim()))
                    return "数据查询语句不能为空！";
                if (String.IsNullOrWhiteSpace(ddlDbType.SelectedItem.ToString()))
                    return "请选择数据库类型";
            }
            if (selfDefineGraber.Checked)
            {
                if (String.IsNullOrWhiteSpace(txtGaberType.Text.Trim()))
                    return "自定义数据提取类不能为空！";
                if (txtDayRange.Value<=0)
                    return "数据提取范围不能小于等于0！";
            }

            return String.Empty;
        }
        #endregion

        #region 化验设备配置保存
        private void btnSaveAssay_Click(object sender, EventArgs e)
        {
            String valid = ValidateInput();
            if (!String.IsNullOrWhiteSpace(valid))
            {
                MessageBox.Show(valid);
                return;
            }
            int index = this.Instruments.SelectedIndex;
            appConfig.AssayGrabers[index].MachineCode = this.txtMachineCode.Text.Trim();
            appConfig.AssayGrabers[index].TableName = this.txtTableName.Text.Trim();
            appConfig.AssayGrabers[index].PrimaryKeys = this.txtPrimaryKeys.Text.Trim();
            appConfig.AssayGrabers[index].ConnStr = this.txtConnStr.Text.Trim();
            appConfig.AssayGrabers[index].Enabled = ckEnabled.Checked;
            if (sysGraber.Checked)
            {
                if (appConfig.AssayGrabers[index].Parameters.Keys.Contains("GaberType"))
                    appConfig.AssayGrabers[index].Parameters.Remove("GaberType");
                if (appConfig.AssayGrabers[index].Parameters.Keys.Contains("DayRange"))
                    appConfig.AssayGrabers[index].Parameters.Remove("DayRange");
                if (appConfig.AssayGrabers[index].Parameters.Keys.Contains("DbType"))
                    appConfig.AssayGrabers[index].Parameters.Remove("DbType");
                if (appConfig.AssayGrabers[index].Parameters.Keys.Contains("SQL"))
                    appConfig.AssayGrabers[index].Parameters.Remove("SQL");

                appConfig.AssayGrabers[index].Parameters.Add("DbType", ddlDbType.SelectedItem.ToString());
                appConfig.AssayGrabers[index].Parameters.Add("SQL", txtSQL.Text.Trim());
            }
            else if (selfDefineGraber.Checked)
            {
                if (appConfig.AssayGrabers[index].Parameters.Keys.Contains("GaberType"))
                    appConfig.AssayGrabers[index].Parameters.Remove("GaberType");
                if (appConfig.AssayGrabers[index].Parameters.Keys.Contains("DayRange"))
                    appConfig.AssayGrabers[index].Parameters.Remove("DayRange");
                if (appConfig.AssayGrabers[index].Parameters.Keys.Contains("DbType"))
                    appConfig.AssayGrabers[index].Parameters.Remove("DbType");
                if (appConfig.AssayGrabers[index].Parameters.Keys.Contains("SQL"))
                    appConfig.AssayGrabers[index].Parameters.Remove("SQL");

                appConfig.AssayGrabers[index].Parameters.Add("GaberType", txtGaberType.Text.Trim());
                appConfig.AssayGrabers[index].Parameters.Add("DayRange", txtDayRange.Value.ToString());
            }
            try
            {
                SaveAssayInstruments();
                appConfig = ADGSAppConfig.GetInstance();
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
