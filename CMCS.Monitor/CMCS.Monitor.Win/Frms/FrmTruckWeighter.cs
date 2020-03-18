using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Common.Entities.CarTransport;
using CMCS.Common.Enums;
using CMCS.Monitor.Win.Core;
using CMCS.Monitor.Win.Html;
using CMCS.Monitor.Win.UserControls;
using CMCS.Monitor.Win.Utilities;
using DevComponents.DotNetBar;
using Xilium.CefGlue.WindowsForms;

namespace CMCS.Monitor.Win.Frms
{
    public partial class FrmTruckWeighter : DevComponents.DotNetBar.Metro.MetroForm
    {
        /// <summary>
        /// 窗体唯一标识符
        /// </summary>
        public static string UniqueKey = "FrmTruckWeighter";

        CommonDAO commonDAO = CommonDAO.GetInstance();
        MonitorCommon monitorCommon = MonitorCommon.GetInstance();

        CefWebBrowserEx cefWebBrowser = new CefWebBrowserEx();

        string currentMachineCode = GlobalVars.MachineCode_QC_Weighter_1;
        /// <summary>
        /// 当前选中的衡器
        /// </summary>
        public string CurrentMachineCode
        {
            get { return currentMachineCode; }
            set { currentMachineCode = value; }
        }

        public FrmTruckWeighter()
        {
            InitializeComponent();
        }

        private void FrmTruckWeighter_Load(object sender, EventArgs e)
        {
            FormInit();
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

            cefWebBrowser.StartUrl = SelfVars.Url_TruckWeighter;
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

        /// <summary>
        /// 请求数据
        /// </summary>
        void RequestData()
        {
            string value = string.Empty, machineCode = string.Empty;
            List<HtmlDataItem> datas = new List<HtmlDataItem>();

            datas.Clear();

            machineCode = this.CurrentMachineCode;

            datas.Add(new HtmlDataItem("汽车衡_当前衡器", machineCode, eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("汽车衡_1号衡系统", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(GlobalVars.MachineCode_QC_Weighter_1, eSignalDataName.系统.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("汽车衡_2号衡系统", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(GlobalVars.MachineCode_QC_Weighter_2, eSignalDataName.系统.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("汽车衡_3号衡系统", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(GlobalVars.MachineCode_QC_Weighter_3, eSignalDataName.系统.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("汽车衡_4号衡系统", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(GlobalVars.MachineCode_QC_Weighter_4, eSignalDataName.系统.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("汽车衡_5号衡系统", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(GlobalVars.MachineCode_QC_Weighter_5, eSignalDataName.系统.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("汽车衡_6号衡系统", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(GlobalVars.MachineCode_QC_Weighter_6, eSignalDataName.系统.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("汽车衡_7号衡系统", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(GlobalVars.MachineCode_QC_Weighter_7, eSignalDataName.系统.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("汽车衡_8号衡系统", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(GlobalVars.MachineCode_QC_Weighter_8, eSignalDataName.系统.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("汽车衡_系统", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.系统.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("汽车衡_IO控制器", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.IO控制器_连接状态.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("汽车衡_地磅仪表", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.地磅仪表_连接状态.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("汽车衡_LED屏", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.LED屏1_连接状态.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("汽车衡_抓拍相机", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.抓拍相机_连接状态.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("汽车衡_仪表重量", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.地磅仪表_实时重量.ToString()) + " 吨", eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("汽车衡_仪表重量", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.地磅仪表_稳定.ToString()).ToLower() == "1" ? ColorTranslator.ToHtml(EquipmentStatusColors.BeReady) : ColorTranslator.ToHtml(EquipmentStatusColors.Working), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("汽车衡_当前车号", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.当前车号.ToString()), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("汽车衡_毛重", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.毛重.ToString()) + " 吨", eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("汽车衡_皮重", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.皮重.ToString()) + " 吨", eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("汽车衡_卡车", (!string.IsNullOrEmpty(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.当前车号.ToString()))).ToString(), eHtmlDataItemType.svg_visible));
            datas.Add(new HtmlDataItem("汽车衡_地感1", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.地感1信号.ToString()).ToLower() == "1" ? ColorTranslator.ToHtml(EquipmentStatusColors.Working) : "#c0c0c0", eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("汽车衡_地感2", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.地感2信号.ToString()).ToLower() == "1" ? ColorTranslator.ToHtml(EquipmentStatusColors.Working) : "#c0c0c0", eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("汽车衡_对射1", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.对射1信号.ToString()).ToLower() == "1" ? ColorTranslator.ToHtml(EquipmentStatusColors.Working) : "#c0c0c0", eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("汽车衡_对射2", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.对射2信号.ToString()).ToLower() == "1" ? ColorTranslator.ToHtml(EquipmentStatusColors.Working) : "#c0c0c0", eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("汽车衡_对射3", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.对射3信号.ToString()).ToLower() == "1" ? ColorTranslator.ToHtml(EquipmentStatusColors.Working) : "#c0c0c0", eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("汽车衡_道闸1", (commonDAO.GetSignalDataValue(machineCode, eSignalDataName.道闸1升杆.ToString()) == "0").ToString(), eHtmlDataItemType.svg_visible));
            datas.Add(new HtmlDataItem("汽车衡_道闸2", (commonDAO.GetSignalDataValue(machineCode, eSignalDataName.道闸2升杆.ToString()) == "0").ToString(), eHtmlDataItemType.svg_visible));
            datas.Add(new HtmlDataItem("汽车衡_卡车", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.上磅方向.ToString()), eHtmlDataItemType.svg_scare));
            // 添加更多...

            // 发送到页面
            cefWebBrowser.Browser.GetMainFrame().ExecuteJavaScript("requestData(" + Newtonsoft.Json.JsonConvert.SerializeObject(datas) + ");", "", 0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 界面不可见时，停止发送数据
            if (!this.Visible) return;

            RequestData();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            // 发送到页面
            cefWebBrowser.Browser.GetMainFrame().ExecuteJavaScript("test1();", "", 0);
        }

    }
}