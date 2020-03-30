using System;
using System.Collections.Generic;
using System.Windows.Forms;
//
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Common.Entities.Inf;
using CMCS.Common.Enums;
using CMCS.Monitor.Win.CefGlue;
using CMCS.Monitor.Win.Core;
using CMCS.Monitor.Win.Html;
using CMCS.Monitor.Win.UserControls;
using CMCS.Monitor.Win.Utilities;
using Xilium.CefGlue;
using Xilium.CefGlue.WindowsForms;

namespace CMCS.Monitor.Win.Frms
{
	public partial class FrmAutoMaker : DevComponents.DotNetBar.Metro.MetroForm
	{
		/// <summary>
		/// 窗体唯一标识符
		/// </summary>
		public static string UniqueKey = "FrmAutoMaker";

		CommonDAO commonDAO = CommonDAO.GetInstance();
		MonitorCommon monitorCommon = MonitorCommon.GetInstance();

		CefWebBrowserEx cefWebBrowser = new CefWebBrowserEx();

		string currentMachineCode = GlobalVars.MachineCode_QZDZYJ_1;
		/// <summary>
		/// 当前选中的设备
		/// </summary>
		public string CurrentMachineCode
		{
			get { return currentMachineCode; }
			set { currentMachineCode = value; }
		}

		public FrmAutoMaker()
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
			cefWebBrowser.StartUrl = SelfVars.Url_AutoMaker;
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

		private void FrmHomePage_Load(object sender, EventArgs e)
		{
			FormInit();
		}

		/// <summary>
		/// 测试 - 刷新页面
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRefresh_Click(object sender, EventArgs e)
		{
			//string[] test = new string[] { "辊筒输送机", "自动倒料入料口", "一级提升", "采制对接入料口", "定质量缩分", "一级破碎", "样瓶封装单元", "弃料提升", "备份样暂存"
			//, "弃料仓", "二级提升", "全水缩分", "存查缩分", "3mm干燥", "在线测全水缩分", "三级提升", "旋转缩分", "制粉单元", "气动传输", "除尘系统"};
			//foreach (string item in test)
			//{
			//	Random random = new Random();
			//	int num = random.Next(1, 3);
			//	if (num == 1)
			//		commonDAO.SetSignalDataValue(CurrentMachineCode, item, eEquInfAutoMakerSystemStatus.就绪待机.ToString());
			//	else if (num == 2)
			//		commonDAO.SetSignalDataValue(CurrentMachineCode, item, eEquInfAutoMakerSystemStatus.正在运行.ToString());
			//	else if (num == 3)
			//		commonDAO.SetSignalDataValue(CurrentMachineCode, item, eEquInfAutoMakerSystemStatus.发生故障.ToString());
			//}
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

			machineCode = CurrentMachineCode;
			datas.Add(new HtmlDataItem("制样机_系统", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.系统.ToString())), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("制样机_今日已制样品数", commonDAO.GetSignalDataValue(machineCode, "制样机_今日已制样品数"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("制样机_当前制样码", commonDAO.GetSignalDataValue(machineCode, "制样机_当前制样码"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("制样机_当前水分值", commonDAO.GetSignalDataValue(machineCode, "制样机_当前水分值") + "%", eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("制样机_全水测试样品个数", commonDAO.GetSignalDataValue(machineCode, "制样机_全水测试样品个数") + "个样品正在进行测试", eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("制样机_辊筒输送机_状态", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "辊筒输送机")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("制样机_自动倒料入料口_状态", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "自动倒料入料口")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("制样机_一级提升机_状态", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "一级提升")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("制样机_采制对接入料口_状态", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "采制对接入料口")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("制样机_定质量缩分_状态", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "定质量缩分")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("制样机_一级破碎_状态", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "一级破碎")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("制样机_样瓶封装单元_状态", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "样瓶封装单元")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("制样机_弃料提升_状态", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "弃料提升")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("制样机_备份样暂存_状态", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "备份样暂存")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("制样机_弃料仓_状态", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "弃料仓")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("制样机_二级提升_状态", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "二级提升")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("制样机_全水缩分_状态", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "全水缩分")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("制样机_存查缩分_状态", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "存查缩分")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("制样机_3mm干燥_状态", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "3mm干燥")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("制样机_在线测全水缩分_状态", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "在线测全水缩分")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("制样机_三级提升_状态", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "三级提升")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("制样机_旋转缩分_状态", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "旋转缩分")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("制样机_制粉单元_状态", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "制粉单元")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("制样机_气动传输_状态", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "气动传输")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("制样机_除尘_状态", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "除尘系统")), eHtmlDataItemType.svg_color));
			//集样罐
			IList<InfEquInfSampleBarrel> barrels = commonDAO.SelfDber.Entities<InfEquInfSampleBarrel>("where MachineCode=:MachineCode", new { MachineCode = machineCode });
			foreach (InfEquInfSampleBarrel entity in barrels)
			{
				datas.Add(new HtmlDataItem(entity.BarrelNumber + "号集样罐重量", entity.SampleWeight.ToString(), eHtmlDataItemType.svg_text));
				datas.Add(new HtmlDataItem(entity.BarrelNumber + "号集样罐状态", entity.SampleWeight > 0 ? "#22DD48" : "#808080", eHtmlDataItemType.svg_color));
			}

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

	}

	public class FrmAutoMakerCefWebClient : CefWebClient
	{
		CefWebBrowser cefWebBrowser;

		public FrmAutoMakerCefWebClient(CefWebBrowser cefWebBrowser)
			: base(cefWebBrowser)
		{
			this.cefWebBrowser = cefWebBrowser;
		}

		protected override bool OnProcessMessageReceived(CefBrowser browser, CefProcessId sourceProcess, CefProcessMessage message)
		{
			if (message.Name == "OpenAutoMaker")
				SelfVars.MainFrameForm.OpenAutoMaker();
			else if (message.Name == "AutoMakerChangeSelected")
				SelfVars.AutoMakerForm.CurrentMachineCode = MonitorCommon.GetInstance().GetAutoMakerMachineCodeBySelected(message.Arguments.GetString(0));

			return true;
		}

		protected override CefContextMenuHandler GetContextMenuHandler()
		{
			return new CefMenuHandler();
		}
	}
}