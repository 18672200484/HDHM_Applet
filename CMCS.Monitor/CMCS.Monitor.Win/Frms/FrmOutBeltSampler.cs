using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//
using Xilium.CefGlue.WindowsForms;
using Xilium.CefGlue;
using CMCS.Monitor.DAO;
using CMCS.Common.Entities;
using DevComponents.DotNetBar.SuperGrid;
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Monitor.Win.CefGlue;
using CMCS.Monitor.Win.Html;
using DevComponents.DotNetBar.Metro;
using CMCS.Monitor.Win.Core;
using CMCS.Common.Entities.Inf;
using CMCS.Common.Enums;

namespace CMCS.Monitor.Win.Frms
{
    public partial class FrmOutBeltSampler : MetroForm
    {
        /// <summary>
        /// 窗体唯一标识符
        /// </summary>
        public static string UniqueKey = "FrmOutBeltSampler";
        public string Device = string.Empty;

        CefWebBrowser cefWebBrowser = new CefWebBrowser();

        public FrmOutBeltSampler()
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

            cefWebBrowser.StartUrl = SelfVars.Url_OutBeltSampler;
            cefWebBrowser.Dock = DockStyle.Fill;
            cefWebBrowser.LoadEnd += new EventHandler<LoadEndEventArgs>(cefWebBrowser_LoadEnd);
            panWebBrower.Controls.Add(cefWebBrowser);
        }

        void cefWebBrowser_LoadEnd(object sender, LoadEndEventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
            //页面初始化完成
            ReadConfig();
        }

        private void FrmTrainBeltSampler_Load(object sender, EventArgs e)
        {
            FormInit();

        }

        private void superGridControl_CancelEdit_BeginEdit(object sender, GridEditEventArgs e)
        {
            // 取消编辑
            e.Cancel = true;
        }

        /// <summary>
        /// 打开卸样界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenUnload_Click(object sender, EventArgs e)
        {

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

            ReadConfig();
        }

        /// <summary>
        /// 请求数据
        /// </summary>
        void RequestData()
        {
            CommonDAO commonDAO = CommonDAO.GetInstance();

            string value = string.Empty, machineCode = string.Empty;
            List<HtmlDataItem> datas = new List<HtmlDataItem>();
            List<InfEquInfHitch> equInfHitchs = new List<InfEquInfHitch>();

            datas.Clear();
            getPDCYJ(commonDAO, ref value, GlobalVars.MachineCode_PDCYJ_3, datas, "皮带采样机3");

            getPDCYJ(commonDAO, ref value, GlobalVars.MachineCode_PDCYJ_4, datas, "皮带采样机4");

            // 添加更多...

            // 发送到页面
            cefWebBrowser.Browser.GetMainFrame().ExecuteJavaScript("requestData(" + Newtonsoft.Json.JsonConvert.SerializeObject(datas) + ");", "", 0);

        }

        private void getPDCYJ(CommonDAO commonDAO, ref string value, string machineCode, List<HtmlDataItem> datas, string type)
        {
            string kfl = "";
            string cym = commonDAO.GetSignalDataValue(machineCode, "采样编码");

            datas.Add(new HtmlDataItem(type + "_采样编码", cym, eHtmlDataItemType.svg_text));
            string sql = string.Format(@"select c.ticketqty from cmcstbrcsampling d 
                left join fultbinfactorybatch c on c.id = d.infactorybatchid
                where d.samplecode = '{0}'", cym);
            DataTable dt = commonDAO.GetSqlDatas(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                kfl = dt.Rows[0][0].ToString();
            }

            datas.Add(new HtmlDataItem(type + "_矿发量", kfl, eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem(type + "_开始时间", commonDAO.GetSignalDataValue(machineCode, "开始时间"), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem(type + "_来煤车数", commonDAO.GetSignalDataValue(machineCode, "来煤车数"), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem(type + "_采样次数", commonDAO.GetSignalDataValue(machineCode, "采样次数"), eHtmlDataItemType.svg_text));

            // 集样罐   
            List<InfEquInfSampleBarrel> barrels1 = MonitorDAO.GetInstance().GetEquInfSampleBarrels(machineCode, eEquInfGatherType.底卸式.ToString());
            datas.Add(new HtmlDataItem(type + "_底卸集样罐", Newtonsoft.Json.JsonConvert.SerializeObject(barrels1.Select(a => new { BarrelNumber = a.BarrelNumber, IsCurrent = a.IsCurrent, BarrelStatus = a.BarrelStatus, SampleCount = a.SampleCount })), eHtmlDataItemType.json_data));
            barrels1 = MonitorDAO.GetInstance().GetEquInfSampleBarrels(machineCode, eEquInfGatherType.密码罐.ToString());
            datas.Add(new HtmlDataItem(type + "_密码集样罐", Newtonsoft.Json.JsonConvert.SerializeObject(barrels1.Select(a => new { BarrelNumber = a.BarrelNumber, IsCurrent = a.IsCurrent, BarrelStatus = a.BarrelStatus, SampleCount = a.SampleCount })), eHtmlDataItemType.json_data));

            value = commonDAO.GetSignalDataValue(machineCode, eSignalDataName.系统.ToString());
            if ("|就绪待机|系统就绪|准备就绪|".Contains("|" + value + "|"))
                datas.Add(new HtmlDataItem(type + "系统", "#00c000", eHtmlDataItemType.svg_color));
            else if ("|正在运行|正在卸样|系统运行|".Contains("|" + value + "|"))
                datas.Add(new HtmlDataItem(type + "系统", "#ff0000", eHtmlDataItemType.svg_color));
            else if ("|发生故障|系统故障|".Contains("|" + value + "|"))
                datas.Add(new HtmlDataItem(type + "系统", "#ffff00", eHtmlDataItemType.svg_color));
            else
                datas.Add(new HtmlDataItem(type + "系统", "#c0c0c0", eHtmlDataItemType.svg_color));

            value = GetColor(commonDAO.GetSignalDataValue(machineCode, "初级采样机"));
            datas.Add(new HtmlDataItem(type + "输煤皮带", value != "" ? value : "#808080", eHtmlDataItemType.svg_color));

            value = GetColor(commonDAO.GetSignalDataValue(machineCode, "初级给料机"));
            datas.Add(new HtmlDataItem(type + "初级给料", value != "" ? value : "#808080", eHtmlDataItemType.svg_color));

            value = GetColor(commonDAO.GetSignalDataValue(machineCode, "破碎机"));
            datas.Add(new HtmlDataItem(type + "初级破碎1", value != "" ? value : "url(#linearGradient5969-9)", eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem(type + "初级破碎2", value != "" ? value : "url(#linearGradient5919-2)", eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem(type + "初级破碎3", value != "" ? value : "url(#linearGradient5921-4)", eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem(type + "初级破碎4", value != "" ? value : "url(#linearGradient5923-5)", eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem(type + "初级破碎5", value != "" ? value : "url(#linearGradient5925-5)", eHtmlDataItemType.svg_color));

            value = GetColor(commonDAO.GetSignalDataValue(machineCode, "二级给料机"));
            datas.Add(new HtmlDataItem(type + "次级给料", value != "" ? value : "#808080", eHtmlDataItemType.svg_color));

            value = GetColor(commonDAO.GetSignalDataValue(machineCode, "密码罐缩分器"));
            datas.Add(new HtmlDataItem(type + "密码罐缩分器1", value != "" ? value : "url(#linearGradient7572)", eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem(type + "密码罐缩分器2", value != "" ? value : "url(#linearGradient5931-6)", eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem(type + "密码罐缩分器3", value != "" ? value : "url(#linearGradient6946)", eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem(type + "密码罐缩分器4", value != "" ? value : "url(#linearGradient5939-1)", eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem(type + "密码罐缩分器5", value != "" ? value : "url(#linearGradient5941-4)", eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem(type + "密码罐缩分器6", value != "" ? value : "url(#linearGradient5905-1)", eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem(type + "密码罐缩分器7", value != "" ? value : "url(#linearGradient7623)", eHtmlDataItemType.svg_color));

            value = GetColor(commonDAO.GetSignalDataValue(machineCode, "底卸料缩分器"));
            datas.Add(new HtmlDataItem(type + "底卸料缩分器1", value != "" ? value : "url(#linearGradient7568-1)", eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem(type + "底卸料缩分器2", value != "" ? value : "url(#linearGradient5931-6)", eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem(type + "底卸料缩分器3", value != "" ? value : "url(#linearGradient6946-2)", eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem(type + "底卸料缩分器4", value != "" ? value : "url(#linearGradient5939-1)", eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem(type + "底卸料缩分器5", value != "" ? value : "url(#linearGradient5941-4)", eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem(type + "底卸料缩分器6", value != "" ? value : "url(#linearGradient5905-1)", eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem(type + "底卸料缩分器7", value != "" ? value : "url(#linearGradient7623-7)", eHtmlDataItemType.svg_color));
        }

        private string GetColor(string value)
        {
            string color = string.Empty;
            switch (value)
            {
                case "就绪":
                    color = ColorTranslator.ToHtml(EquipmentStatusColors.BeReady);
                    break;
                case "运行":
                    color = "Red";
                    break;
                case "故障":
                    color = ColorTranslator.ToHtml(EquipmentStatusColors.Breakdown);
                    break;
                case "停止":
                    color = "";
                    break;
                default:
                    color = "";
                    break;

            }
            return color;
        }

        void ReadConfig()
        {
            List<HtmlDataItem> datas = new List<HtmlDataItem>();
            CommonDAO commonDAO = CommonDAO.GetInstance();
            datas.Add(new HtmlDataItem("ckbfc1", commonDAO.GetAppletConfigString(GlobalVars.CommonAppletConfigName, "#1翻车机对应皮带采样机"), "Set"));
            datas.Add(new HtmlDataItem("ckbfc2", commonDAO.GetAppletConfigString(GlobalVars.CommonAppletConfigName, "#2翻车机对应皮带采样机"), "Set"));
            datas.Add(new HtmlDataItem("ckbjy1", commonDAO.GetAppletConfigString(GlobalVars.CommonAppletConfigName, "#1皮带采样机集样方式"), "Set"));
            datas.Add(new HtmlDataItem("ckbjy2", commonDAO.GetAppletConfigString(GlobalVars.CommonAppletConfigName, "#2皮带采样机集样方式"), "Set"));
            // 发送到页面
            cefWebBrowser.Browser.GetMainFrame().ExecuteJavaScript("requestData(" + Newtonsoft.Json.JsonConvert.SerializeObject(datas) + ");", "", 0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 界面不可见时，停止发送数据
            if (!this.Visible) return;

            RequestData();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            // 界面不可见时，停止发送数据
            if (!this.Visible) return;

            //30秒执行一次读取配置
            ReadConfig();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            // 发送到页面
            cefWebBrowser.Browser.GetMainFrame().ExecuteJavaScript("testColor();", "", 0);
        }

    }
}
