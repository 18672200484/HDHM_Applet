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
using CMCS.Common.Entities.Inf;
using CMCS.Common.Enums;
using CMCS.Monitor.DAO;
using CMCS.Monitor.Win.Core;
using CMCS.Monitor.Win.Html;
using DevComponents.DotNetBar.Metro;
using Xilium.CefGlue.WindowsForms;
using CMCS.Monitor.Win.UserControls;

namespace CMCS.Monitor.Win.Frms
{
    public partial class FrmCarMonitor : MetroForm
    {
        /// <summary>
        /// 窗体唯一标识符
        /// </summary>
        public static string UniqueKey = "FrmCarMonitor";

        CefWebBrowserEx cefWebBrowser = new CefWebBrowserEx();

        public FrmCarMonitor()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 窗体初始化
        /// </summary>
        private void FormInit()
        {
#if DEBUG
            gboxTest.Visible = true;
#else
            gboxTest.Visible = false;
#endif
            cefWebBrowser.StartUrl = SelfVars.Url_CarMonitor;
            cefWebBrowser.Dock = DockStyle.Fill;
            cefWebBrowser.WebClient = new HomePageCefWebClient(cefWebBrowser);
            cefWebBrowser.LoadEnd += new EventHandler<LoadEndEventArgs>(cefWebBrowser_LoadEnd);
            panWebBrower.Controls.Add(cefWebBrowser);
        }

        void cefWebBrowser_LoadEnd(object sender, LoadEndEventArgs e)
        {
            timer1.Enabled = true;

            RequestData();
        }

        private void FrmCarMonitor_Load(object sender, EventArgs e)
        {
            FormInit();
        }
        /// <summary>
        /// 请求数据
        /// </summary>
        void RequestData()
        {
            CommonDAO commonDAO = CommonDAO.GetInstance();
            MonitorDAO monitorDAO = MonitorDAO.GetInstance();
            string value = string.Empty, machineCode = string.Empty, machineCode2 = string.Empty;
            List<HtmlDataItem> datas = new List<HtmlDataItem>();
            List<InfEquInfHitch> equInfHitchs = new List<InfEquInfHitch>();

            #region 翻车机

            datas.Clear();

            #region 入厂
            machineCode = GlobalVars.MachineCode_QC_Queue_1;
            datas.Add(new HtmlDataItem("Infactory_State1", commonDAO.GetSignalDataValue(machineCode, "系统"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Infactory_State2", commonDAO.GetSignalDataValue(machineCode, "IO控制器_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Infactory_State3", commonDAO.GetSignalDataValue(machineCode, "LED屏1_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Infactory_State4", commonDAO.GetSignalDataValue(machineCode, "LED屏2_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Infactory_State5", commonDAO.GetSignalDataValue(machineCode, "抓拍相机_连接状态"), eHtmlDataItemType.json_data));
            #endregion

            #region 采样
            machineCode = GlobalVars.MachineCode_QC_JxSampler_1;
            datas.Add(new HtmlDataItem("Sample1_State1", commonDAO.GetSignalDataValue(machineCode, "系统"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Sample1_State2", commonDAO.GetSignalDataValue(machineCode, "IO控制器_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Sample1_State3", commonDAO.GetSignalDataValue(machineCode, "LED屏1_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Sample1_State4", commonDAO.GetSignalDataValue(machineCode, "LED屏2_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Sample1_State5", commonDAO.GetSignalDataValue(machineCode, "抓拍相机_连接状态"), eHtmlDataItemType.json_data));

            machineCode = GlobalVars.MachineCode_QC_JxSampler_2;
            datas.Add(new HtmlDataItem("Sample2_State1", commonDAO.GetSignalDataValue(machineCode, "系统"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Sample2_State2", commonDAO.GetSignalDataValue(machineCode, "IO控制器_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Sample2_State3", commonDAO.GetSignalDataValue(machineCode, "LED屏1_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Sample2_State4", commonDAO.GetSignalDataValue(machineCode, "LED屏2_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Sample2_State5", commonDAO.GetSignalDataValue(machineCode, "抓拍相机_连接状态"), eHtmlDataItemType.json_data));

            machineCode = GlobalVars.MachineCode_QC_JxSampler_3;
            datas.Add(new HtmlDataItem("Sample3_State1", commonDAO.GetSignalDataValue(machineCode, "系统"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Sample3_State2", commonDAO.GetSignalDataValue(machineCode, "IO控制器_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Sample3_State3", commonDAO.GetSignalDataValue(machineCode, "LED屏1_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Sample3_State4", commonDAO.GetSignalDataValue(machineCode, "LED屏2_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Sample3_State5", commonDAO.GetSignalDataValue(machineCode, "抓拍相机_连接状态"), eHtmlDataItemType.json_data));

            machineCode = GlobalVars.MachineCode_QC_JxSampler_4;
            datas.Add(new HtmlDataItem("Sample4_State1", commonDAO.GetSignalDataValue(machineCode, "系统"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Sample4_State2", commonDAO.GetSignalDataValue(machineCode, "IO控制器_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Sample4_State3", commonDAO.GetSignalDataValue(machineCode, "LED屏1_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Sample4_State4", commonDAO.GetSignalDataValue(machineCode, "LED屏2_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Sample4_State5", commonDAO.GetSignalDataValue(machineCode, "抓拍相机_连接状态"), eHtmlDataItemType.json_data));

            machineCode = GlobalVars.MachineCode_QC_JxSampler_5;
            datas.Add(new HtmlDataItem("Sample5_State1", commonDAO.GetSignalDataValue(machineCode, "系统"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Sample5_State2", commonDAO.GetSignalDataValue(machineCode, "IO控制器_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Sample5_State3", commonDAO.GetSignalDataValue(machineCode, "LED屏1_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Sample5_State4", commonDAO.GetSignalDataValue(machineCode, "LED屏2_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Sample5_State5", commonDAO.GetSignalDataValue(machineCode, "抓拍相机_连接状态"), eHtmlDataItemType.json_data));

            machineCode = GlobalVars.MachineCode_QC_JxSampler_6;
            datas.Add(new HtmlDataItem("Sample6_State1", commonDAO.GetSignalDataValue(machineCode, "系统"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Sample6_State2", commonDAO.GetSignalDataValue(machineCode, "IO控制器_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Sample6_State3", commonDAO.GetSignalDataValue(machineCode, "LED屏1_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Sample6_State4", commonDAO.GetSignalDataValue(machineCode, "LED屏2_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Sample6_State5", commonDAO.GetSignalDataValue(machineCode, "抓拍相机_连接状态"), eHtmlDataItemType.json_data));
            #endregion

            #region 汽车衡
            machineCode = GlobalVars.MachineCode_QC_Weighter_1;
            datas.Add(new HtmlDataItem("Weighter1_State1", commonDAO.GetSignalDataValue(machineCode, "系统"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter1_State2", commonDAO.GetSignalDataValue(machineCode, "IO控制器_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter1_State3", commonDAO.GetSignalDataValue(machineCode, "LED屏1_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter1_State4", commonDAO.GetSignalDataValue(machineCode, "LED屏2_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter1_State5", commonDAO.GetSignalDataValue(machineCode, "抓拍相机_连接状态"), eHtmlDataItemType.json_data));

            machineCode = GlobalVars.MachineCode_QC_Weighter_2;
            datas.Add(new HtmlDataItem("Weighter2_State1", commonDAO.GetSignalDataValue(machineCode, "系统"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter2_State2", commonDAO.GetSignalDataValue(machineCode, "IO控制器_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter2_State3", commonDAO.GetSignalDataValue(machineCode, "LED屏1_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter2_State4", commonDAO.GetSignalDataValue(machineCode, "LED屏2_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter2_State5", commonDAO.GetSignalDataValue(machineCode, "抓拍相机_连接状态"), eHtmlDataItemType.json_data));

            machineCode = GlobalVars.MachineCode_QC_Weighter_3;
            datas.Add(new HtmlDataItem("Weighter3_State1", commonDAO.GetSignalDataValue(machineCode, "系统"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter3_State2", commonDAO.GetSignalDataValue(machineCode, "IO控制器_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter3_State3", commonDAO.GetSignalDataValue(machineCode, "LED屏1_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter3_State4", commonDAO.GetSignalDataValue(machineCode, "LED屏2_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter3_State5", commonDAO.GetSignalDataValue(machineCode, "抓拍相机_连接状态"), eHtmlDataItemType.json_data));

            machineCode = GlobalVars.MachineCode_QC_Weighter_4;
            datas.Add(new HtmlDataItem("Weighter4_State1", commonDAO.GetSignalDataValue(machineCode, "系统"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter4_State2", commonDAO.GetSignalDataValue(machineCode, "IO控制器_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter4_State3", commonDAO.GetSignalDataValue(machineCode, "LED屏1_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter4_State4", commonDAO.GetSignalDataValue(machineCode, "LED屏2_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter4_State5", commonDAO.GetSignalDataValue(machineCode, "抓拍相机_连接状态"), eHtmlDataItemType.json_data));

            machineCode = GlobalVars.MachineCode_QC_Weighter_5;
            datas.Add(new HtmlDataItem("Weighter5_State1", commonDAO.GetSignalDataValue(machineCode, "系统"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter5_State2", commonDAO.GetSignalDataValue(machineCode, "IO控制器_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter5_State3", commonDAO.GetSignalDataValue(machineCode, "LED屏1_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter5_State4", commonDAO.GetSignalDataValue(machineCode, "LED屏2_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter5_State5", commonDAO.GetSignalDataValue(machineCode, "抓拍相机_连接状态"), eHtmlDataItemType.json_data));

            machineCode = GlobalVars.MachineCode_QC_Weighter_6;
            datas.Add(new HtmlDataItem("Weighter6_State1", commonDAO.GetSignalDataValue(machineCode, "系统"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter6_State2", commonDAO.GetSignalDataValue(machineCode, "IO控制器_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter6_State3", commonDAO.GetSignalDataValue(machineCode, "LED屏1_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter6_State4", commonDAO.GetSignalDataValue(machineCode, "LED屏2_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter6_State5", commonDAO.GetSignalDataValue(machineCode, "抓拍相机_连接状态"), eHtmlDataItemType.json_data));

            machineCode = GlobalVars.MachineCode_QC_Weighter_7;
            datas.Add(new HtmlDataItem("Weighter7_State1", commonDAO.GetSignalDataValue(machineCode, "系统"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter7_State2", commonDAO.GetSignalDataValue(machineCode, "IO控制器_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter7_State3", commonDAO.GetSignalDataValue(machineCode, "LED屏1_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter7_State4", commonDAO.GetSignalDataValue(machineCode, "LED屏2_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter7_State5", commonDAO.GetSignalDataValue(machineCode, "抓拍相机_连接状态"), eHtmlDataItemType.json_data));

            machineCode = GlobalVars.MachineCode_QC_Weighter_8;
            datas.Add(new HtmlDataItem("Weighter8_State1", commonDAO.GetSignalDataValue(machineCode, "系统"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter8_State2", commonDAO.GetSignalDataValue(machineCode, "IO控制器_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter8_State3", commonDAO.GetSignalDataValue(machineCode, "LED屏1_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter8_State4", commonDAO.GetSignalDataValue(machineCode, "LED屏2_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Weighter8_State5", commonDAO.GetSignalDataValue(machineCode, "抓拍相机_连接状态"), eHtmlDataItemType.json_data));

            #endregion

            #region 出厂
            machineCode = GlobalVars.MachineCode_QC_Out_1;
            datas.Add(new HtmlDataItem("Outfactory_State1", commonDAO.GetSignalDataValue(machineCode, "系统"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Outfactory_State2", commonDAO.GetSignalDataValue(machineCode, "IO控制器_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Outfactory_State3", commonDAO.GetSignalDataValue(machineCode, "LED屏1_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Outfactory_State4", commonDAO.GetSignalDataValue(machineCode, "LED屏2_连接状态"), eHtmlDataItemType.json_data));
            datas.Add(new HtmlDataItem("Outfactory_State5", commonDAO.GetSignalDataValue(machineCode, "抓拍相机_连接状态"), eHtmlDataItemType.json_data));
            #endregion

            // 发送到页面
            cefWebBrowser.Browser.GetMainFrame().ExecuteJavaScript("requestData(" + Newtonsoft.Json.JsonConvert.SerializeObject(datas) + ");", "", 0);

            #endregion
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            RequestData();
            timer1.Start();
        }

        /// <summary>
        /// 测试 - 刷新页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cefWebBrowser.Browser.Reload();
        }

        /// <summary>
        /// 测试 - 数据刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRequestData_Click(object sender, EventArgs e)
        {
            RequestData();
        }

    }
}
