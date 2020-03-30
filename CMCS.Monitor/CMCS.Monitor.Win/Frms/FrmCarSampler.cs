using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Common.Enums;
using CMCS.Monitor.Win.Core;
using CMCS.Monitor.Win.Html;
using CMCS.Monitor.Win.UserControls;
using DevComponents.DotNetBar;
using Xilium.CefGlue;
using Xilium.CefGlue.WindowsForms;
using CMCS.Monitor.Win.Utilities;
using CMCS.Monitor.Win.CefGlue;
using CMCS.Common.Entities.Inf;

namespace CMCS.Monitor.Win.Frms
{
	public partial class FrmCarSampler : DevComponents.DotNetBar.Metro.MetroForm
	{
		/// <summary>
		/// 窗体唯一标识符
		/// </summary>
		public static string UniqueKey = "FrmCarSampler";

		CommonDAO commonDAO = CommonDAO.GetInstance();
		MonitorCommon monitorCommon = MonitorCommon.GetInstance();

		CefWebBrowserEx cefWebBrowser = new CefWebBrowserEx();

		string currentMachineCode = GlobalVars.MachineCode_QCJXCYJ_1;
		/// <summary>
		/// 当前选中的设备
		/// </summary>
		public string CurrentMachineCode
		{
			get { return currentMachineCode; }
			set { currentMachineCode = value; }
		}

		public FrmCarSampler()
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
			cefWebBrowser.StartUrl = SelfVars.Url_CarSampler;
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
			//集样罐
			IList<InfEquInfSampleBarrel> barrels = commonDAO.SelfDber.Entities<InfEquInfSampleBarrel>("where MachineCode=:MachineCode", new { MachineCode = machineCode });
			foreach (InfEquInfSampleBarrel entity in barrels)
			{
				datas.Add(new HtmlDataItem(entity.BarrelNumber + "号集样罐重量", entity.SampleWeight.ToString(), eHtmlDataItemType.svg_text));
				datas.Add(new HtmlDataItem(entity.BarrelNumber + "号集样罐状态", entity.BarrelStatus != "空桶" ? "#22DD48" : "#808080", eHtmlDataItemType.svg_color));
			}
			datas.Add(new HtmlDataItem("汽车_采样机_系统", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.系统.ToString())), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("汽车_采样机_采样头已采次数", commonDAO.GetSignalDataValue(machineCode, "汽车_采样机_采样头已采次数"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("汽车_采样机_预设采样点数", commonDAO.GetSignalDataValue(machineCode, "汽车_采样机_预设采样点数"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("汽车_采样机_暂停次数", commonDAO.GetSignalDataValue(machineCode, "汽车_采样机_暂停次数"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("汽车_采样机_预设放样点数", commonDAO.GetSignalDataValue(machineCode, "汽车_采样机_预设放样点数"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("汽车_采样机_下一点大车采样坐标", commonDAO.GetSignalDataValue(machineCode, "汽车_采样机_下一点大车采样坐标"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("汽车_采样机_下一点小车采样坐标", commonDAO.GetSignalDataValue(machineCode, "汽车_采样机_下一点小车采样坐标"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("汽车_采样机_下一点升降采样坐标", commonDAO.GetSignalDataValue(machineCode, "汽车_采样机_下一点升降采样坐标"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("汽车_采样机_大车目标坐标", commonDAO.GetSignalDataValue(machineCode, "汽车_采样机_大车目标坐标"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("汽车_采样机_大车实时坐标", commonDAO.GetSignalDataValue(machineCode, "汽车_采样机_大车实时坐标"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("汽车_采样机_小车目标坐标", commonDAO.GetSignalDataValue(machineCode, "汽车_采样机_小车目标坐标"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("汽车_采样机_小车实时坐标", commonDAO.GetSignalDataValue(machineCode, "汽车_采样机_小车实时坐标"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("汽车_采样机_升降目标坐标", commonDAO.GetSignalDataValue(machineCode, "汽车_采样机_升降目标坐标"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("汽车_采样机_升降实时坐标", commonDAO.GetSignalDataValue(machineCode, "汽车_采样机_升降实时坐标"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("汽车_采样机_大车检车坐标", commonDAO.GetSignalDataValue(machineCode, "汽车_采样机_大车检车坐标"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("汽车_采样机_小车检车坐标", commonDAO.GetSignalDataValue(machineCode, "汽车_采样机_小车检车坐标"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("汽车_采样机_车号", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.当前车号.ToString()), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("汽车_采样机_是否有车辆", commonDAO.GetSignalDataValue(machineCode, "汽车_采样机_是否有车辆"), eHtmlDataItemType.svg_visible));

			AddDataItemBySignal(datas, machineCode, "汽车_1号采样_红绿灯");
			AddDataItemBySignal2(datas, machineCode, "汽车_1号采样_红绿灯");

			datas.Add(new HtmlDataItem("汽车_采样机2_系统", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(GlobalVars.MachineCode_QCJXCYJ_2, eSignalDataName.系统.ToString())), eHtmlDataItemType.svg_color));
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

		/// <summary>
		/// 添加红绿灯控制信号
		/// </summary>
		/// <param name="datas"></param>
		/// <param name="machineCode"></param>
		/// <param name="signalValue"></param>
		private void AddDataItemBySignal(List<HtmlDataItem> datas, string machineCode, string signalValue)
		{
			if (commonDAO.GetSignalDataValue(machineCode, eSignalDataName.信号灯1.ToString()) == "1")
			{
				//红灯
				datas.Add(new HtmlDataItem(signalValue + "_红", "#FF0000", eHtmlDataItemType.svg_color));
				datas.Add(new HtmlDataItem(signalValue + "_绿", "#CCCCCC", eHtmlDataItemType.svg_color));
			}
			else
			{
				//绿灯
				datas.Add(new HtmlDataItem(signalValue + "_红", "#CCCCCC", eHtmlDataItemType.svg_color));
				datas.Add(new HtmlDataItem(signalValue + "_绿", "#00FF00", eHtmlDataItemType.svg_color));
			}
		}

		/// <summary>
		/// 添加红绿灯控制信号
		/// </summary>
		/// <param name="datas"></param>
		/// <param name="machineCode"></param>
		/// <param name="signalValue"></param>
		private void AddDataItemBySignal2(List<HtmlDataItem> datas, string machineCode, string signalValue)
		{
			if (commonDAO.GetSignalDataValue(machineCode, eSignalDataName.信号灯2.ToString()) == "1")
			{
				//红灯
				datas.Add(new HtmlDataItem(signalValue + "_红2", "#FF0000", eHtmlDataItemType.svg_color));
				datas.Add(new HtmlDataItem(signalValue + "_绿2", "#CCCCCC", eHtmlDataItemType.svg_color));
			}
			else
			{
				//绿灯
				datas.Add(new HtmlDataItem(signalValue + "_红2", "#CCCCCC", eHtmlDataItemType.svg_color));
				datas.Add(new HtmlDataItem(signalValue + "_绿2", "#00FF00", eHtmlDataItemType.svg_color));
			}
		}

	}

	public class FrmCarSamplerCefWebClient : CefWebClient
	{
		CefWebBrowser cefWebBrowser;

		public FrmCarSamplerCefWebClient(CefWebBrowser cefWebBrowser)
			: base(cefWebBrowser)
		{
			this.cefWebBrowser = cefWebBrowser;
		}

		protected override bool OnProcessMessageReceived(CefBrowser browser, CefProcessId sourceProcess, CefProcessMessage message)
		{
			if (message.Name == "OpenCarSampler")
				SelfVars.MainFrameForm.OpenTruckWeighter();
			else if (message.Name == "CarSamplerChangeSelected")
				SelfVars.CarSamplerForm.CurrentMachineCode = MonitorCommon.GetInstance().GetCarSamplerMachineCodeBySelected(message.Arguments.GetString(0));

			return true;
		}

		protected override CefContextMenuHandler GetContextMenuHandler()
		{
			return new CefMenuHandler();
		}
	}
}