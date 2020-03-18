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

namespace CMCS.Monitor.Win.Frms
{
    public partial class FrmHomePage : DevComponents.DotNetBar.Metro.MetroForm
    {
        /// <summary>
        /// ����Ψһ��ʶ��
        /// </summary>
        public static string UniqueKey = "FrmHomePage";

        CommonDAO commonDAO = CommonDAO.GetInstance();
        MonitorCommon monitorCommon = MonitorCommon.GetInstance();

        CefWebBrowserEx cefWebBrowser = new CefWebBrowserEx();

        public FrmHomePage()
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
            cefWebBrowser.StartUrl = SelfVars.Url_HomePage;
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

            datas.Add(new HtmlDataItem("�������¶�", commonDAO.GetSignalDataValue(GlobalVars.MachineCode_HomePage_1, "�������¶�"), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("������ʪ��", commonDAO.GetSignalDataValue(GlobalVars.MachineCode_HomePage_1, "������ʪ��"), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("������_�Ѵ�", commonDAO.GetSignalDataValue(GlobalVars.MachineCode_CYG1, "������_�Ѵ�"), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("������_����", commonDAO.GetSignalDataValue(GlobalVars.MachineCode_CYG1, "������_����"), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("������_����", commonDAO.GetSignalDataValue(GlobalVars.MachineCode_CYG1, "������_����"), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("������_��������", commonDAO.GetSignalDataValue(GlobalVars.MachineCode_HomePage_1, "������_��������"), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("������_��������", commonDAO.GetSignalDataValue(GlobalVars.MachineCode_HomePage_1, "������_��������"), eHtmlDataItemType.svg_text));

            datas.Add(new HtmlDataItem("����_�볧����", commonDAO.GetSignalDataValue(GlobalVars.MachineCode_HomePage_1, "����_�볧����"), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("����_��������", commonDAO.GetSignalDataValue(GlobalVars.MachineCode_HomePage_1, "����_��������"), eHtmlDataItemType.svg_text));

            #region ����������

            machineCode = GlobalVars.MachineCode_QC_JxSampler_1;
            datas.Add(new HtmlDataItem("����_1�Ų���_ϵͳ", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(GlobalVars.MachineCode_QCJXCYJ_1, eSignalDataName.ϵͳ.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("����_1�Ų���_����", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��ǰ����.ToString()), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("����_1�Ų���_��բ1", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��բ1����.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("����_1�Ų���_��բ2", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��բ2����.ToString())), eHtmlDataItemType.svg_color));

            machineCode = GlobalVars.MachineCode_QC_JxSampler_2;
            datas.Add(new HtmlDataItem("����_2�Ų���_ϵͳ", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(GlobalVars.MachineCode_QCJXCYJ_2, eSignalDataName.ϵͳ.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("����_2�Ų���_����", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��ǰ����.ToString()), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("����_2�Ų���_��բ1", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��բ1����.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("����_2�Ų���_��բ2", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��բ2����.ToString())), eHtmlDataItemType.svg_color));

            machineCode = GlobalVars.MachineCode_QC_JxSampler_3;
            datas.Add(new HtmlDataItem("����_3�Ų���_ϵͳ", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(GlobalVars.MachineCode_QCJXCYJ_3, eSignalDataName.ϵͳ.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("����_3�Ų���_����", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��ǰ����.ToString()), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("����_3�Ų���_��բ1", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��բ1����.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("����_3�Ų���_��բ2", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��բ2����.ToString())), eHtmlDataItemType.svg_color));

            machineCode = GlobalVars.MachineCode_QC_JxSampler_4;
            datas.Add(new HtmlDataItem("����_4�Ų���_ϵͳ", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(GlobalVars.MachineCode_QCJXCYJ_4, eSignalDataName.ϵͳ.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("����_4�Ų���_����", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��ǰ����.ToString()), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("����_4�Ų���_��բ1", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��բ1����.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("����_4�Ų���_��բ2", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��բ2����.ToString())), eHtmlDataItemType.svg_color));

            machineCode = GlobalVars.MachineCode_QC_JxSampler_5;
            datas.Add(new HtmlDataItem("����_5�Ų���_ϵͳ", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(GlobalVars.MachineCode_QCJXCYJ_5, eSignalDataName.ϵͳ.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("����_5�Ų���_����", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��ǰ����.ToString()), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("����_5�Ų���_��բ1", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��բ1����.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("����_5�Ų���_��բ2", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��բ2����.ToString())), eHtmlDataItemType.svg_color));

            machineCode = GlobalVars.MachineCode_QC_JxSampler_6;
            datas.Add(new HtmlDataItem("����_6�Ų���_ϵͳ", monitorCommon.ConvertMachineStatusToColor(commonDAO.GetSignalDataValue(GlobalVars.MachineCode_QCJXCYJ_6, eSignalDataName.ϵͳ.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("����_6�Ų���_����", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��ǰ����.ToString()), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("����_6�Ų���_��բ1", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��բ1����.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("����_6�Ų���_��բ2", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��բ2����.ToString())), eHtmlDataItemType.svg_color));

            #endregion

            #region ������

            machineCode = GlobalVars.MachineCode_QC_Weighter_1;
            datas.Add(new HtmlDataItem("����_1�ź�_ϵͳ", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.ϵͳ.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("����_1�ź�_����", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��ǰ����.ToString()), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("����_1�ź�_����", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.�ذ��Ǳ�_ʵʱ����.ToString() + "t"), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("����_1�ź�_��բ1", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��բ1����.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("����_1�ź�_��բ2", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��բ2����.ToString())), eHtmlDataItemType.svg_color));
            AddDataItemBySignal(datas, machineCode, "����_1�ź�_���̵�");

            machineCode = GlobalVars.MachineCode_QC_Weighter_2;
            datas.Add(new HtmlDataItem("����_2�ź�_ϵͳ", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.ϵͳ.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("����_2�ź�_����", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��ǰ����.ToString()), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("����_2�ź�_����", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.�ذ��Ǳ�_ʵʱ����.ToString() + "t"), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("����_2�ź�_��բ1", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��բ1����.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("����_2�ź�_��բ2", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��բ2����.ToString())), eHtmlDataItemType.svg_color));
            AddDataItemBySignal(datas, machineCode, "����_2�ź�_���̵�");

            machineCode = GlobalVars.MachineCode_QC_Weighter_3;
            datas.Add(new HtmlDataItem("����_3�ź�_ϵͳ", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.ϵͳ.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("����_3�ź�_����", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��ǰ����.ToString()), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("����_3�ź�_����", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.�ذ��Ǳ�_ʵʱ����.ToString() + "t"), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("����_3�ź�_��բ1", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��բ1����.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("����_3�ź�_��բ2", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��բ2����.ToString())), eHtmlDataItemType.svg_color));
            AddDataItemBySignal(datas, machineCode, "����_3�ź�_���̵�");

            machineCode = GlobalVars.MachineCode_QC_Weighter_4;
            datas.Add(new HtmlDataItem("����_4�ź�_ϵͳ", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.ϵͳ.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("����_4�ź�_����", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��ǰ����.ToString()), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("����_4�ź�_����", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.�ذ��Ǳ�_ʵʱ����.ToString() + "t"), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("����_4�ź�_��բ1", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��բ1����.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("����_4�ź�_��բ2", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��բ2����.ToString())), eHtmlDataItemType.svg_color));
            AddDataItemBySignal(datas, machineCode, "����_4�ź�_���̵�");

            machineCode = GlobalVars.MachineCode_QC_Weighter_5;
            datas.Add(new HtmlDataItem("����_5�ź�_ϵͳ", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.ϵͳ.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("����_5�ź�_����", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��ǰ����.ToString()), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("����_5�ź�_����", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.�ذ��Ǳ�_ʵʱ����.ToString() + "t"), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("����_5�ź�_��բ1", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��բ1����.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("����_5�ź�_��բ2", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��բ2����.ToString())), eHtmlDataItemType.svg_color));
            AddDataItemBySignal(datas, machineCode, "����_5�ź�_���̵�");

            machineCode = GlobalVars.MachineCode_QC_Weighter_6;
            datas.Add(new HtmlDataItem("����_6�ź�_ϵͳ", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.ϵͳ.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("����_6�ź�_����", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��ǰ����.ToString()), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("����_6�ź�_����", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.�ذ��Ǳ�_ʵʱ����.ToString() + "t"), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("����_6�ź�_��բ1", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��բ1����.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("����_6�ź�_��բ2", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��բ2����.ToString())), eHtmlDataItemType.svg_color));
            AddDataItemBySignal(datas, machineCode, "����_6�ź�_���̵�");

            machineCode = GlobalVars.MachineCode_QC_Weighter_7;
            datas.Add(new HtmlDataItem("����_7�ź�_ϵͳ", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.ϵͳ.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("����_7�ź�_����", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��ǰ����.ToString()), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("����_7�ź�_����", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.�ذ��Ǳ�_ʵʱ����.ToString() + "t"), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("����_7�ź�_��բ1", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��բ1����.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("����_7�ź�_��բ2", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��բ2����.ToString())), eHtmlDataItemType.svg_color));
            AddDataItemBySignal(datas, machineCode, "����_7�ź�_���̵�");

            machineCode = GlobalVars.MachineCode_QC_Weighter_8;
            datas.Add(new HtmlDataItem("����_8�ź�_ϵͳ", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.ϵͳ.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("����_8�ź�_����", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��ǰ����.ToString()), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("����_8�ź�_����", commonDAO.GetSignalDataValue(machineCode, eSignalDataName.�ذ��Ǳ�_ʵʱ����.ToString() + "t"), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("����_8�ź�_��բ1", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��բ1����.ToString())), eHtmlDataItemType.svg_color));
            datas.Add(new HtmlDataItem("����_8�ź�_��բ2", monitorCommon.ConvertBooleanToColor(commonDAO.GetSignalDataValue(machineCode, eSignalDataName.��բ2����.ToString())), eHtmlDataItemType.svg_color));
            AddDataItemBySignal(datas, machineCode, "����_8�ź�_���̵�");

            #endregion

            datas.Add(new HtmlDataItem("��_�볧����", commonDAO.GetSignalDataValue(GlobalVars.MachineCode_HomePage_1, "��_�볧����"), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("��_��������", commonDAO.GetSignalDataValue(GlobalVars.MachineCode_HomePage_1, "��_��������"), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("��úͰ��ú��", commonDAO.GetSignalDataValue(GlobalVars.MachineCode_HomePage_1, "��úͰ��ú��"), eHtmlDataItemType.svg_text));

            datas.Add(new HtmlDataItem("�Ž�_�����ҽ�", commonDAO.GetSignalDataValue(GlobalVars.MachineCode_HomePage_1, "�Ž�_�����ҽ�"), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("�Ž�_�����ҽ�", commonDAO.GetSignalDataValue(GlobalVars.MachineCode_HomePage_1, "�Ž�_�����ҽ�"), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("�Ž�_�����ҽ�", commonDAO.GetSignalDataValue(GlobalVars.MachineCode_HomePage_1, "�Ž�_�����ҽ�"), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("�Ž�_�칫¥��", commonDAO.GetSignalDataValue(GlobalVars.MachineCode_HomePage_1, "�Ž�_�칫¥��"), eHtmlDataItemType.svg_text));

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

    }

    public class HomePageCefWebClient : CefWebClient
    {
        CefWebBrowser cefWebBrowser;

        public HomePageCefWebClient(CefWebBrowser cefWebBrowser)
            : base(cefWebBrowser)
        {
            this.cefWebBrowser = cefWebBrowser;
        }

        protected override bool OnProcessMessageReceived(CefBrowser browser, CefProcessId sourceProcess, CefProcessMessage message)
        {
            if (message.Name == "OpenTruckWeighter")
                SelfVars.MainFrameForm.OpenTruckWeighter();
            else if (message.Name == "TruckWeighterChangeSelected")
                SelfVars.TruckWeighterForm.CurrentMachineCode = MonitorCommon.GetInstance().GetTruckWeighterMachineCodeBySelected(message.Arguments.GetString(0));

            return true;
        }

        protected override CefContextMenuHandler GetContextMenuHandler()
        {
            return new CefMenuHandler();
        }
    }
}