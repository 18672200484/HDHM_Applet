using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Common.Entities;
using CMCS.Common.Entities.BaseInfo;
using CMCS.Common.Enums;
using CMCS.TrainTipper.DAO;
using CMCS.TrainTipper.Frms;
using CMCS.TrainTipper.Utilities;
using DevComponents.DotNetBar; 

namespace CMCS.TrainTipper
{
    public partial class Form1 : DevComponents.DotNetBar.Metro.MetroForm
    {
        CommonDAO commonDAO = CommonDAO.GetInstance();

        public static SuperTabControlManager superTabControlManager;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "版本：" + new AU.Updater().Version;

            superTabControlManager = new SuperTabControlManager(superTabControl1);

            CreateTrainTipperTab(); 

            timer_CurrentTime.Enabled = true;
        }

        /// <summary>
        /// 创建翻车机选项卡
        /// </summary>
        private void CreateTrainTipperTab()
        {
            superTabControl1.SuspendLayout();

            // 获取翻车机编码
            List<CmcsCMEquipment> trainTippers = TrainTipperDAO.GetInstance().GetTrainTippers();
            // 车号识别设备编码，跟翻车机一一对应
            string[] carriageRecognitionerMachineCodes = CommonDAO.GetInstance().GetAppletConfigString("翻车机车号识别编码").Split('|');
            for (int i = 0; i < trainTippers.Count; i++)
            {
                CmcsCMEquipment cMEquipment = trainTippers[i];
                superTabControlManager.CreateTab(cMEquipment.EquipmentName, cMEquipment.EquipmentCode, new Frms.FrmTrainTipper(cMEquipment, carriageRecognitionerMachineCodes[i]), false);
            }

            superTabControl1.ResumeLayout();

            // 选中第一个选项卡
            if (superTabControl1.Tabs.Count > 0)
                superTabControl1.SelectedTabIndex = 0;
            else
            {
                MessageBoxEx.Show("翻车机参数未设置！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //Application.Exit();
            }
        } 

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBoxEx.Show("确认退出系统？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    commonDAO.SetSignalDataValue(CommonAppConfig.GetInstance().AppIdentifier, eSignalDataName.系统.ToString(), "0");

                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// 打开参数设置界面
        /// </summary>
        public void OpenSetting()
        {
            FrmSetting frm = new FrmSetting();
            frm.ShowDialog();
        }

        private void btnApplicationExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpenSetting_Click(object sender, EventArgs e)
        {
            OpenSetting();
        }

        private void timer_CurrentTime_Tick(object sender, EventArgs e)
        {
            lblCurrentTime.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
        }
    }
}
