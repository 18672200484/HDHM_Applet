using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
//
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Common.Entities.Inf;
using CMCS.Common.Enums;
using CMCS.Monitor.Win.Core;
using CMCS.Monitor.Win.Html;
using DevComponents.DotNetBar.Metro;
using Xilium.CefGlue.WindowsForms;

namespace CMCS.Monitor.Win.Frms
{
	public partial class FrmAutoCupboardPneumaticTransfer : MetroForm
	{
		/// <summary>
		/// 窗体唯一标识符
		/// </summary>
		public static string UniqueKey = "FrmAutoCupboardPneumaticTransfer";

		CefWebBrowser cefWebBrowser = new CefWebBrowser();

		public FrmAutoCupboardPneumaticTransfer()
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
			cefWebBrowser.StartUrl = SelfVars.Url_AutoCupboardPneumaticTransfer;
			cefWebBrowser.Dock = DockStyle.Fill;
			cefWebBrowser.LoadEnd += new EventHandler<LoadEndEventArgs>(cefWebBrowser_LoadEnd);
			panWebBrower.Controls.Add(cefWebBrowser);
		}

		void cefWebBrowser_LoadEnd(object sender, LoadEndEventArgs e)
		{
			timer1.Enabled = true;
		}

		private void FrmAutoCupboardPneumaticTransfer_Load(object sender, EventArgs e)
		{
			FormInit();
		}

		/// <summary>
		/// 请求数据
		/// </summary>
		void RequestData()
		{
			CommonDAO commonDAO = CommonDAO.GetInstance();
			AutoMakerDAO automakerDAO = AutoMakerDAO.GetInstance();

			string value = string.Empty, machineCode = string.Empty;
			List<HtmlDataItem> datas = new List<HtmlDataItem>();
			List<InfEquInfHitch> equInfHitchs = new List<InfEquInfHitch>();

			#region 智能存样柜 #

			datas.Clear();
			machineCode = GlobalVars.MachineCode_CYG1;
			datas.Add(new HtmlDataItem("#1智能存样柜_共有仓位", commonDAO.GetSignalDataValue(machineCode, "共有仓位"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("#1智能存样柜_已存仓位", commonDAO.GetSignalDataValue(machineCode, "已存仓位"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("#1智能存样柜_未存仓位", commonDAO.GetSignalDataValue(machineCode, "未存仓位"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("#1智能存样柜_存样率", commonDAO.GetSignalDataValue(machineCode, "存样率"), eHtmlDataItemType.svg_text));

			value = commonDAO.GetSignalDataValue(machineCode, "1号柜已存");
			datas.Add(new HtmlDataItem("#1智能存样柜_1号柜已存", value, eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("div1-1", value, commonDAO.GetSignalDataValue(machineCode, "1号柜超期"), "ShowDiv", eHtmlDataItemType.key_value));
			value = commonDAO.GetSignalDataValue(machineCode, "2号柜已存");
			datas.Add(new HtmlDataItem("#1智能存样柜_2号柜已存", value, eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("div1-2", value, commonDAO.GetSignalDataValue(machineCode, "2号柜超期"), "ShowDiv", eHtmlDataItemType.key_value));
			value = commonDAO.GetSignalDataValue(machineCode, "3号柜已存");
			datas.Add(new HtmlDataItem("#1智能存样柜_3号柜已存", value, eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("div1-3", value, commonDAO.GetSignalDataValue(machineCode, "3号柜超期"), "ShowDiv", eHtmlDataItemType.key_value));
			value = commonDAO.GetSignalDataValue(machineCode, "4号柜已存");
			datas.Add(new HtmlDataItem("#1智能存样柜_4号柜已存", value, eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("div1-4", value, commonDAO.GetSignalDataValue(machineCode, "4号柜超期"), "ShowDiv", eHtmlDataItemType.key_value));
			value = commonDAO.GetSignalDataValue(machineCode, "5号柜已存");
			datas.Add(new HtmlDataItem("#1智能存样柜_5号柜已存", value, eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("div1-5", value, commonDAO.GetSignalDataValue(machineCode, "5号柜超期"), "ShowDiv", eHtmlDataItemType.key_value));

			value = commonDAO.GetSignalDataValue(machineCode, eSignalDataName.系统.ToString());
			if ("|就绪待机|".Contains("|" + value + "|"))
				datas.Add(new HtmlDataItem("#1智能存样柜_系统", "#00c000", eHtmlDataItemType.svg_color));
			else if ("|正在运行|正在卸样|".Contains("|" + value + "|"))
				datas.Add(new HtmlDataItem("#1智能存样柜_系统", "#ff0000", eHtmlDataItemType.svg_color));
			else if ("|发生故障|".Contains("|" + value + "|"))
				datas.Add(new HtmlDataItem("#1智能存样柜_系统", "#ffff00", eHtmlDataItemType.svg_color));
			else
				datas.Add(new HtmlDataItem("#1智能存样柜_系统", "#c0c0c0", eHtmlDataItemType.svg_color));

			machineCode = GlobalVars.MachineCode_CYG2;
			datas.Add(new HtmlDataItem("#2智能存样柜_共有仓位", commonDAO.GetSignalDataValue(machineCode, "共有仓位"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("#2智能存样柜_已存仓位", commonDAO.GetSignalDataValue(machineCode, "已存仓位"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("#2智能存样柜_未存仓位", commonDAO.GetSignalDataValue(machineCode, "未存仓位"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("#2智能存样柜_存样率", commonDAO.GetSignalDataValue(machineCode, "存样率"), eHtmlDataItemType.svg_text));

			value = commonDAO.GetSignalDataValue(machineCode, "1号柜已存");
			datas.Add(new HtmlDataItem("#2智能存样柜_1号柜已存", value, eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("div2-1", value, commonDAO.GetSignalDataValue(machineCode, "1号柜超期"), "ShowDiv", eHtmlDataItemType.key_value));
			value = commonDAO.GetSignalDataValue(machineCode, "2号柜已存");
			datas.Add(new HtmlDataItem("#2智能存样柜_2号柜已存", value, eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("div2-2", value, commonDAO.GetSignalDataValue(machineCode, "2号柜超期"), "ShowDiv", eHtmlDataItemType.key_value));
			value = commonDAO.GetSignalDataValue(machineCode, "3号柜已存");
			datas.Add(new HtmlDataItem("#2智能存样柜_3号柜已存", value, eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("div2-3", value, commonDAO.GetSignalDataValue(machineCode, "3号柜超期"), "ShowDiv", eHtmlDataItemType.key_value));
			value = commonDAO.GetSignalDataValue(machineCode, "4号柜已存");
			datas.Add(new HtmlDataItem("#2智能存样柜_4号柜已存", value, eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("div2-4", value, commonDAO.GetSignalDataValue(machineCode, "4号柜超期"), "ShowDiv", eHtmlDataItemType.key_value));
			value = commonDAO.GetSignalDataValue(machineCode, "5号柜已存");
			datas.Add(new HtmlDataItem("#2智能存样柜_5号柜已存", value, eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("div2-5", value, commonDAO.GetSignalDataValue(machineCode, "5号柜超期"), "ShowDiv", eHtmlDataItemType.key_value));

			value = commonDAO.GetSignalDataValue(machineCode, eSignalDataName.系统.ToString());
			if ("|就绪待机|".Contains("|" + value + "|"))
				datas.Add(new HtmlDataItem("#2智能存样柜_系统", "#00c000", eHtmlDataItemType.svg_color));
			else if ("|正在运行|正在卸样|".Contains("|" + value + "|"))
				datas.Add(new HtmlDataItem("#2智能存样柜_系统", "#ff0000", eHtmlDataItemType.svg_color));
			else if ("|发生故障|".Contains("|" + value + "|"))
				datas.Add(new HtmlDataItem("#2智能存样柜_系统", "#ffff00", eHtmlDataItemType.svg_color));
			else
				datas.Add(new HtmlDataItem("#2智能存样柜_系统", "#c0c0c0", eHtmlDataItemType.svg_color));

			machineCode = GlobalVars.MachineCode_QD;
			datas.Add(new HtmlDataItem("Keys", commonDAO.GetSignalDataValue(machineCode, "风机") == "1" ? "气动传输_风机" : "", eHtmlDataItemType.svg_scroll3));

			value = commonDAO.GetSignalDataValue(machineCode, eSignalDataName.系统.ToString());
			if ("|就绪待机|".Contains("|" + value + "|"))
				datas.Add(new HtmlDataItem("气动传输_系统", "#00c000", eHtmlDataItemType.svg_color));
			else if ("|正在运行|正在卸样|".Contains("|" + value + "|"))
				datas.Add(new HtmlDataItem("气动传输_系统", "#ff0000", eHtmlDataItemType.svg_color));
			else if ("|发生故障|".Contains("|" + value + "|"))
				datas.Add(new HtmlDataItem("气动传输_系统", "#ffff00", eHtmlDataItemType.svg_color));
			else
				datas.Add(new HtmlDataItem("气动传输_系统", "#c0c0c0", eHtmlDataItemType.svg_color));

			datas.Add(new HtmlDataItem("四项转换器_旋转", nullif(commonDAO.GetSignalDataValue(machineCode, "四项转换器方向")) ?? "2", eHtmlDataItemType.svg_scroll));
			datas.Add(new HtmlDataItem("四项转换器1", ((nullif(commonDAO.GetSignalDataValue(machineCode, "四项转换器方向")) ?? "2") == "1") ? "#ee4036" : "#ffffff", eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("四项转换器2", ((nullif(commonDAO.GetSignalDataValue(machineCode, "四项转换器方向")) ?? "2") == "2") ? "#ee4036" : "#ffffff", eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("四项转换器3", ((nullif(commonDAO.GetSignalDataValue(machineCode, "四项转换器方向")) ?? "2") == "3") ? "#ee4036" : "#ffffff", eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("四项转换器4", ((nullif(commonDAO.GetSignalDataValue(machineCode, "四项转换器方向")) ?? "2") == "4") ? "#ee4036" : "#ffffff", eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("二项转换器_旋转", nullif(commonDAO.GetSignalDataValue(machineCode, "二项转换器方向")) ?? "2", eHtmlDataItemType.svg_scroll2));
			datas.Add(new HtmlDataItem("二项转换器1", ((nullif(commonDAO.GetSignalDataValue(machineCode, "二项转换器方向")) ?? "2") == "1") ? "#ee4036" : "#ffffff", eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("二项转换器2", ((nullif(commonDAO.GetSignalDataValue(machineCode, "二项转换器方向")) ?? "2") == "2") ? "#ee4036" : "#ffffff", eHtmlDataItemType.svg_color));

			//datas.Add(new HtmlDataItem("取样工作站", commonDAO.GetSignalDataValue(machineCode, "取样工作站") == "1" ? "#ff0000" : "#00c000", eHtmlDataItemType.svg_color));
			//datas.Add(new HtmlDataItem("存样工作站", commonDAO.GetSignalDataValue(machineCode, "存样工作站") == "1" ? "#ff0000" : "#00c000", eHtmlDataItemType.svg_color));
			//datas.Add(new HtmlDataItem("路径探测器1", commonDAO.GetSignalDataValue(machineCode, "路径探测器1") == "1" ? "#ff0000" : "#00c000", eHtmlDataItemType.svg_color));
			//datas.Add(new HtmlDataItem("路径探测器2", commonDAO.GetSignalDataValue(machineCode, "路径探测器2") == "1" ? "#ff0000" : "#00c000", eHtmlDataItemType.svg_color));
			//datas.Add(new HtmlDataItem("路径探测器3", commonDAO.GetSignalDataValue(machineCode, "路径探测器3") == "1" ? "#ff0000" : "#00c000", eHtmlDataItemType.svg_color));

			// 发送到页面
			cefWebBrowser.Browser.GetMainFrame().ExecuteJavaScript("requestData(" + Newtonsoft.Json.JsonConvert.SerializeObject(datas) + ");", "", 0);

			//出样信息
			//List<InfCYGControlCMDDetail> listMakerRecord = automakerDAO.GetCYGControlCMDDetailByTime(DateTime.Now);
			//cefWebBrowser.Browser.GetMainFrame().ExecuteJavaScript("LoadSampleInfo(" + Newtonsoft.Json.JsonConvert.SerializeObject(listMakerRecord.Select(a => new { UpdateTime = a.UpdateTime.Year < 2000 ? "" : a.UpdateTime.ToString("yyyy-MM-dd HH:mm"), Code = a.Code, Status = a.Status == null ? "" : a.Status })) + ");", "", 0);
			#endregion
		}

		String nullif(String st)
		{
			if (String.IsNullOrEmpty(st))
				return null;
			else
				return st;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			// 界面不可见时，停止发送数据
			if (!this.Visible) return;

			RequestData();
		}


		/// <summary>
		/// 刷新页面
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRefreshPage_Click(object sender, EventArgs e)
		{
			cefWebBrowser.Browser.Reload();
		}

		/// <summary>
		/// 刷新数据
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRefreshData_Click(object sender, EventArgs e)
		{
			RequestData();
		}

		private void btnHistory_Click(object sender, EventArgs e)
		{
			//FrmAutoMakerRecord frm = new FrmAutoMakerRecord();
			//frm.ShowDialog();
		}

		/// <summary>
		/// 刷新页面
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRefresh_Click(object sender, EventArgs e)
		{
			cefWebBrowser.Browser.Reload();
		}

		private void btnRequestData_Click(object sender, EventArgs e)
		{
			RequestData();
		}

		private void buttonX1_Click(object sender, EventArgs e)
		{
			// 发送到页面
			cefWebBrowser.Browser.GetMainFrame().ExecuteJavaScript("test();", "", 0);
		}
	}
}
