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
		/// ����Ψһ��ʶ��
		/// </summary>
		public static string UniqueKey = "FrmCarSampler";

		CommonDAO commonDAO = CommonDAO.GetInstance();
		MonitorCommon monitorCommon = MonitorCommon.GetInstance();

		CefWebBrowserEx cefWebBrowser = new CefWebBrowserEx();

		string currentMachineCode = GlobalVars.MachineCode_QCJXCYJ_1;
		/// <summary>
		/// ��ǰѡ�е��豸
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
		/// �����ʼ��
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
		/// ���� - ˢ��ҳ��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRefresh_Click(object sender, EventArgs e)
		{
			cefWebBrowser.Browser.Reload();
		}

		/// <summary>
		/// ���� - ����ˢ��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRequestData_Click(object sender, EventArgs e)
		{
			RequestData();
		}

		/// <summary>
		/// ��������
		/// </summary>
		void RequestData()
		{
			string value = string.Empty, machineCode = string.Empty;
			List<HtmlDataItem> datas = new List<HtmlDataItem>();

			datas.Clear();

			machineCode = CurrentMachineCode;
			//������
			IList<InfEquInfSampleBarrel> barrels = commonDAO.SelfDber.Entities<InfEquInfSampleBarrel>("where MachineCode=:MachineCode", new { MachineCode = machineCode });
			foreach (InfEquInfSampleBarrel entity in barrels)
			{
				datas.Add(new HtmlDataItem(entity.BarrelNumber + "�ż���������", entity.SampleWeight.ToString(), eHtmlDataItemType.svg_text));
				datas.Add(new HtmlDataItem(entity.BarrelNumber + "�ż�����״̬", entity.BarrelStatus != "��Ͱ" ? "#22DD48" : "#808080", eHtmlDataItemType.svg_color));
			}
			datas.Add(new HtmlDataItem("����_������_ϵͳ", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.ϵͳ.ToString())), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("����_������_����ͷ�Ѳɴ���", commonDAO.GetSignalDataValue(machineCode, "����_������_����ͷ�Ѳɴ���"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("����_������_Ԥ���������", commonDAO.GetSignalDataValue(machineCode, "����_������_Ԥ���������"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("����_������_��ͣ����", commonDAO.GetSignalDataValue(machineCode, "����_������_��ͣ����"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("����_������_Ԥ���������", commonDAO.GetSignalDataValue(machineCode, "����_������_Ԥ���������"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("����_������_��һ��󳵲�������", commonDAO.GetSignalDataValue(machineCode, "����_������_��һ��󳵲�������"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("����_������_��һ��С����������", commonDAO.GetSignalDataValue(machineCode, "����_������_��һ��С����������"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("����_������_��һ��������������", commonDAO.GetSignalDataValue(machineCode, "����_������_��һ��������������"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("����_������_��Ŀ������", commonDAO.GetSignalDataValue(machineCode, "����_������_��Ŀ������"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("����_������_��ʵʱ����", commonDAO.GetSignalDataValue(machineCode, "����_������_��ʵʱ����"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("����_������_С��Ŀ������", commonDAO.GetSignalDataValue(machineCode, "����_������_С��Ŀ������"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("����_������_С��ʵʱ����", commonDAO.GetSignalDataValue(machineCode, "����_������_С��ʵʱ����"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("����_������_����Ŀ������", commonDAO.GetSignalDataValue(machineCode, "����_������_����Ŀ������"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("����_������_����ʵʱ����", commonDAO.GetSignalDataValue(machineCode, "����_������_����ʵʱ����"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("����_������_�󳵼쳵����", commonDAO.GetSignalDataValue(machineCode, "����_������_�󳵼쳵����"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("����_������_С���쳵����", commonDAO.GetSignalDataValue(machineCode, "����_������_С���쳵����"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("����_������_����", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��ǰ����.ToString()), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("����_������_�Ƿ��г���", commonDAO.GetSignalDataValue(machineCode, "����_������_�Ƿ��г���"), eHtmlDataItemType.svg_visible));

			AddDataItemBySignal(datas, machineCode, "����_1�Ų���_���̵�");
			AddDataItemBySignal2(datas, machineCode, "����_1�Ų���_���̵�");

			datas.Add(new HtmlDataItem("����_������2_ϵͳ", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(GlobalVars.MachineCode_QCJXCYJ_2, eSignalDataName.ϵͳ.ToString())), eHtmlDataItemType.svg_color));
			// ��Ӹ���...

			// ���͵�ҳ��
			cefWebBrowser.Browser.GetMainFrame().ExecuteJavaScript("requestData(" + Newtonsoft.Json.JsonConvert.SerializeObject(datas) + ");", "", 0);
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			// ���治�ɼ�ʱ��ֹͣ��������
			if (!this.Visible) return;

			RequestData();
		}

		/// <summary>
		/// ��Ӻ��̵ƿ����ź�
		/// </summary>
		/// <param name="datas"></param>
		/// <param name="machineCode"></param>
		/// <param name="signalValue"></param>
		private void AddDataItemBySignal(List<HtmlDataItem> datas, string machineCode, string signalValue)
		{
			if (commonDAO.GetSignalDataValue(machineCode, eSignalDataName.�źŵ�1.ToString()) == "1")
			{
				//���
				datas.Add(new HtmlDataItem(signalValue + "_��", "#FF0000", eHtmlDataItemType.svg_color));
				datas.Add(new HtmlDataItem(signalValue + "_��", "#CCCCCC", eHtmlDataItemType.svg_color));
			}
			else
			{
				//�̵�
				datas.Add(new HtmlDataItem(signalValue + "_��", "#CCCCCC", eHtmlDataItemType.svg_color));
				datas.Add(new HtmlDataItem(signalValue + "_��", "#00FF00", eHtmlDataItemType.svg_color));
			}
		}

		/// <summary>
		/// ��Ӻ��̵ƿ����ź�
		/// </summary>
		/// <param name="datas"></param>
		/// <param name="machineCode"></param>
		/// <param name="signalValue"></param>
		private void AddDataItemBySignal2(List<HtmlDataItem> datas, string machineCode, string signalValue)
		{
			if (commonDAO.GetSignalDataValue(machineCode, eSignalDataName.�źŵ�2.ToString()) == "1")
			{
				//���
				datas.Add(new HtmlDataItem(signalValue + "_��2", "#FF0000", eHtmlDataItemType.svg_color));
				datas.Add(new HtmlDataItem(signalValue + "_��2", "#CCCCCC", eHtmlDataItemType.svg_color));
			}
			else
			{
				//�̵�
				datas.Add(new HtmlDataItem(signalValue + "_��2", "#CCCCCC", eHtmlDataItemType.svg_color));
				datas.Add(new HtmlDataItem(signalValue + "_��2", "#00FF00", eHtmlDataItemType.svg_color));
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