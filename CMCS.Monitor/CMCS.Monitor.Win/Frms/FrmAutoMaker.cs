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
		/// ����Ψһ��ʶ��
		/// </summary>
		public static string UniqueKey = "FrmAutoMaker";

		CommonDAO commonDAO = CommonDAO.GetInstance();
		MonitorCommon monitorCommon = MonitorCommon.GetInstance();

		CefWebBrowserEx cefWebBrowser = new CefWebBrowserEx();

		string currentMachineCode = GlobalVars.MachineCode_QZDZYJ_1;
		/// <summary>
		/// ��ǰѡ�е��豸
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
		/// �����ʼ��
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
		/// ���� - ˢ��ҳ��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRefresh_Click(object sender, EventArgs e)
		{
			//string[] test = new string[] { "��Ͳ���ͻ�", "�Զ��������Ͽ�", "һ������", "���ƶԽ����Ͽ�", "����������", "һ������", "��ƿ��װ��Ԫ", "��������", "�������ݴ�"
			//, "���ϲ�", "��������", "ȫˮ����", "�������", "3mm����", "���߲�ȫˮ����", "��������", "��ת����", "�Ʒ۵�Ԫ", "��������", "����ϵͳ"};
			//foreach (string item in test)
			//{
			//	Random random = new Random();
			//	int num = random.Next(1, 3);
			//	if (num == 1)
			//		commonDAO.SetSignalDataValue(CurrentMachineCode, item, eEquInfAutoMakerSystemStatus.��������.ToString());
			//	else if (num == 2)
			//		commonDAO.SetSignalDataValue(CurrentMachineCode, item, eEquInfAutoMakerSystemStatus.��������.ToString());
			//	else if (num == 3)
			//		commonDAO.SetSignalDataValue(CurrentMachineCode, item, eEquInfAutoMakerSystemStatus.��������.ToString());
			//}
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
			datas.Add(new HtmlDataItem("������_ϵͳ", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.ϵͳ.ToString())), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("������_����������Ʒ��", commonDAO.GetSignalDataValue(machineCode, "������_����������Ʒ��"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("������_��ǰ������", commonDAO.GetSignalDataValue(machineCode, "������_��ǰ������"), eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("������_��ǰˮ��ֵ", commonDAO.GetSignalDataValue(machineCode, "������_��ǰˮ��ֵ") + "%", eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("������_ȫˮ������Ʒ����", commonDAO.GetSignalDataValue(machineCode, "������_ȫˮ������Ʒ����") + "����Ʒ���ڽ��в���", eHtmlDataItemType.svg_text));
			datas.Add(new HtmlDataItem("������_��Ͳ���ͻ�_״̬", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "��Ͳ���ͻ�")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("������_�Զ��������Ͽ�_״̬", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "�Զ��������Ͽ�")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("������_һ��������_״̬", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "һ������")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("������_���ƶԽ����Ͽ�_״̬", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "���ƶԽ����Ͽ�")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("������_����������_״̬", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "����������")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("������_һ������_״̬", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "һ������")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("������_��ƿ��װ��Ԫ_״̬", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "��ƿ��װ��Ԫ")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("������_��������_״̬", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "��������")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("������_�������ݴ�_״̬", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "�������ݴ�")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("������_���ϲ�_״̬", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "���ϲ�")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("������_��������_״̬", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "��������")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("������_ȫˮ����_״̬", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "ȫˮ����")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("������_�������_״̬", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "�������")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("������_3mm����_״̬", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "3mm����")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("������_���߲�ȫˮ����_״̬", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "���߲�ȫˮ����")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("������_��������_״̬", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "��������")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("������_��ת����_״̬", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "��ת����")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("������_�Ʒ۵�Ԫ_״̬", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "�Ʒ۵�Ԫ")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("������_��������_״̬", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "��������")), eHtmlDataItemType.svg_color));
			datas.Add(new HtmlDataItem("������_����_״̬", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(machineCode, "����ϵͳ")), eHtmlDataItemType.svg_color));
			//������
			IList<InfEquInfSampleBarrel> barrels = commonDAO.SelfDber.Entities<InfEquInfSampleBarrel>("where MachineCode=:MachineCode", new { MachineCode = machineCode });
			foreach (InfEquInfSampleBarrel entity in barrels)
			{
				datas.Add(new HtmlDataItem(entity.BarrelNumber + "�ż���������", entity.SampleWeight.ToString(), eHtmlDataItemType.svg_text));
				datas.Add(new HtmlDataItem(entity.BarrelNumber + "�ż�����״̬", entity.SampleWeight > 0 ? "#22DD48" : "#808080", eHtmlDataItemType.svg_color));
			}

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