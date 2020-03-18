using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//
using CMCS.CarTransport.DAO;
using CMCS.CarTransport.Queue.Core;
using CMCS.CarTransport.Queue.Enums;
using CMCS.CarTransport.Queue.Frms.BaseInfo.Autotruck;
using CMCS.CarTransport.Queue.Frms.BaseInfo.Mine;
using CMCS.CarTransport.Queue.Frms.BaseInfo.Supplier;
using CMCS.CarTransport.Queue.Frms.BaseInfo.TransportCompany;
using CMCS.CarTransport.Queue.Frms.Sys;
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Common.Entities.BaseInfo;
using CMCS.Common.Entities.CarTransport;
using CMCS.Common.Entities.Fuel;
using CMCS.Common.Entities.Sys;
using CMCS.Common.Enums;
using CMCS.Common.Utilities;
using CMCS.Common.Views;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using LED.YB14;

namespace CMCS.CarTransport.Queue.Frms
{
	public partial class FrmQueuer : DevComponents.DotNetBar.Metro.MetroForm
	{
		/// <summary>
		/// ����Ψһ��ʶ��
		/// </summary>
		public static string UniqueKey = "FrmQueuer";

		public FrmQueuer()
		{
			InitializeComponent();
		}

		#region Vars

		CarTransportDAO carTransportDAO = CarTransportDAO.GetInstance();
		QueuerDAO queuerDAO = QueuerDAO.GetInstance();
		CommonDAO commonDAO = CommonDAO.GetInstance();

		IocControler iocControler;
		/// <summary>
		/// ��������
		/// </summary>
		VoiceSpeaker voiceSpeaker = new VoiceSpeaker();

		bool inductorCoil1 = false;
		/// <summary>
		/// �ظ�1״̬ true=���ź�  false=���ź�
		/// </summary>
		public bool InductorCoil1
		{
			get
			{
				return inductorCoil1;
			}
			set
			{
				inductorCoil1 = value;

				panCurrentCarNumber.Refresh();

				commonDAO.SetSignalDataValue(CommonAppConfig.GetInstance().AppIdentifier, eSignalDataName.�ظ�1�ź�.ToString(), value ? "1" : "0");
			}
		}

		bool inductorCoil2 = false;
		/// <summary>
		/// �ظ�2״̬ true=���ź�  false=���ź�
		/// </summary>
		public bool InductorCoil2
		{
			get
			{
				return inductorCoil2;
			}
			set
			{
				inductorCoil2 = value;

				panCurrentCarNumber.Refresh();

				commonDAO.SetSignalDataValue(CommonAppConfig.GetInstance().AppIdentifier, eSignalDataName.�ظ�2�ź�.ToString(), value ? "1" : "0");
			}
		}

		int inductorCoil1Port;
		/// <summary>
		/// �ظ�1�˿�
		/// </summary>
		public int InductorCoil1Port
		{
			get { return inductorCoil1Port; }
			set { inductorCoil1Port = value; }
		}

		int inductorCoil2Port;
		/// <summary>
		/// �ظ�2�˿�
		/// </summary>
		public int InductorCoil2Port
		{
			get { return inductorCoil2Port; }
			set { inductorCoil2Port = value; }
		}

		public static PassCarQueuer passCarQueuer = new PassCarQueuer();

		ImperfectCar currentImperfectCar;
		/// <summary>
		/// ʶ���ѡ��ĳ���ƾ֤
		/// </summary>
		public ImperfectCar CurrentImperfectCar
		{
			get { return currentImperfectCar; }
			set
			{
				currentImperfectCar = value;

				if (value != null)
					panCurrentCarNumber.Text = value.Voucher;
				else
					panCurrentCarNumber.Text = "�ȴ�����";
			}
		}

		eFlowFlag currentFlowFlag = eFlowFlag.�ȴ�����;
		/// <summary>
		/// ��ǰҵ�����̱�ʶ
		/// </summary>
		public eFlowFlag CurrentFlowFlag
		{
			get { return currentFlowFlag; }
			set
			{
				currentFlowFlag = value;

				lblFlowFlag.Text = value.ToString();
			}
		}

		CmcsAutotruck currentAutotruck;
		/// <summary>
		/// ��ǰ��
		/// </summary>
		public CmcsAutotruck CurrentAutotruck
		{
			get { return currentAutotruck; }
			set
			{
				currentAutotruck = value;

				txtCarNumber_BuyFuel.ResetText();
				txtCarNumber_Goods.ResetText();

				txtTagId_BuyFuel.ResetText();
				txtTagId_Goods.ResetText();

				panCurrentCarNumber.ResetText();

				if (value != null)
				{
					commonDAO.SetSignalDataValue(CommonAppConfig.GetInstance().AppIdentifier, eSignalDataName.��ǰ��Id.ToString(), value.Id);
					commonDAO.SetSignalDataValue(CommonAppConfig.GetInstance().AppIdentifier, eSignalDataName.��ǰ����.ToString(), value.CarNumber);

					CmcsEPCCard ePCCard = Dbers.GetInstance().SelfDber.Get<CmcsEPCCard>(value.EPCCardId);
					if (value.CarType == eCarType.�볧ú.ToString())
					{
						if (ePCCard != null) txtTagId_BuyFuel.Text = ePCCard.TagId;

						txtCarNumber_BuyFuel.Text = value.CarNumber;
						superTabControlMain.SelectedTab = superTabItem_BuyFuel;
					}
					else if (value.CarType == eCarType.��������.ToString())
					{
						if (ePCCard != null) txtTagId_Goods.Text = ePCCard.TagId;

						txtCarNumber_Goods.Text = value.CarNumber;
						superTabControlMain.SelectedTab = superTabItem_Goods;
					}

					panCurrentCarNumber.Text = value.CarNumber;
				}
				else
				{
					commonDAO.SetSignalDataValue(CommonAppConfig.GetInstance().AppIdentifier, eSignalDataName.��ǰ��Id.ToString(), string.Empty);
					commonDAO.SetSignalDataValue(CommonAppConfig.GetInstance().AppIdentifier, eSignalDataName.��ǰ����.ToString(), string.Empty);

					txtCarNumber_BuyFuel.ResetText();
					txtCarNumber_Goods.ResetText();

					txtTagId_BuyFuel.ResetText();
					txtTagId_Goods.ResetText();

					panCurrentCarNumber.ResetText();
				}
			}
		}

		#endregion

		/// <summary>
		/// �����ʼ��
		/// </summary>
		private void InitForm()
		{
			FrmDebugConsole.GetInstance();

			// ���ó���Զ�̿�������
			commonDAO.ResetAppRemoteControlCmd(CommonAppConfig.GetInstance().AppIdentifier);

			LoadFuelkind(cmbFuelName_BuyFuel);
			//LoadSampleType(cmbSamplingType_BuyFuel);

			btnRefresh_Click(null, null);
		}

		private void FrmQueuer_Load(object sender, EventArgs e)
		{
		}

		private void FrmQueuer_Shown(object sender, EventArgs e)
		{
			InitHardware();

			InitForm();
		}

		private void FrmQueuer_FormClosing(object sender, FormClosingEventArgs e)
		{
			// ж���豸
			UnloadHardware();
		}

		#region �豸���

		#region IO������

		void Iocer_StatusChange(bool status)
		{
			// ����IO������״̬ 
			InvokeEx(() =>
			{
				slightIOC.LightColor = (status ? Color.Green : Color.Red);

				commonDAO.SetSignalDataValue(CommonAppConfig.GetInstance().AppIdentifier, eSignalDataName.IO������_����״̬.ToString(), status ? "1" : "0");
			});
		}

		/// <summary>
		/// IO��������������ʱ����
		/// </summary>
		/// <param name="receiveValue"></param>
		void Iocer_Received(int[] receiveValue)
		{
			// ���յظ�״̬  
			InvokeEx(() =>
			{
				this.InductorCoil1 = (receiveValue[this.InductorCoil1Port - 1] == 1);
			});
		}

		/// <summary>
		/// ����ͨ��
		/// </summary>
		void LetPass()
		{
			if (this.CurrentImperfectCar == null) return;

			if (this.CurrentImperfectCar.PassWay == ePassWay.Way1)
			{
				this.iocControler.Gate1Up();
				this.iocControler.GreenLight1();
			}
			else if (this.CurrentImperfectCar.PassWay == ePassWay.Way2)
			{
				this.iocControler.Gate2Up();
				this.iocControler.GreenLight2();
			}
		}

		/// <summary>
		/// ���ǰ��
		/// </summary>
		void LetBlocking()
		{
			if (this.CurrentImperfectCar == null) return;

			if (this.CurrentImperfectCar.PassWay == ePassWay.Way1)
			{
				this.iocControler.Gate1Down();
				this.iocControler.RedLight1();
			}
			else if (this.CurrentImperfectCar.PassWay == ePassWay.Way2)
			{
				this.iocControler.Gate2Down();
				this.iocControler.RedLight2();
			}
		}

		#endregion

		#region ������

		void Rwer1_OnScanError(Exception ex)
		{
			Log4Neter.Error("������1", ex);
		}

		void Rwer1_OnStatusChange(bool status)
		{
			// ���ն�����1״̬ 
			InvokeEx(() =>
			 {
				 slightRwer1.LightColor = (status ? Color.Green : Color.Red);

				 commonDAO.SetSignalDataValue(CommonAppConfig.GetInstance().AppIdentifier, eSignalDataName.������1_����״̬.ToString(), status ? "1" : "0");
			 });
		}

		#endregion

		#region LED��ʾ��

		/// <summary>
		/// ����12�ֽڵ��ı�����
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		private string GenerateFillLedContent12(string value)
		{
			int length = Encoding.Default.GetByteCount(value);
			if (length < 12) return value + "".PadRight(12 - length, ' ');

			return value;
		}

		/// <summary>
		/// ����LED��̬����
		/// </summary>
		/// <param name="value1">��һ������</param>
		/// <param name="value2">�ڶ�������</param>
		private void UpdateLedShow(string value1 = "", string value2 = "")
		{
			if (this.CurrentImperfectCar == null) return;

			if (this.CurrentImperfectCar.PassWay == ePassWay.Way1)
				UpdateLed1Show(value1, value2);
		}

		#region LED1���ƿ�

		/// <summary>
		/// LED1���ƿ�����
		/// </summary>
		int LED1nScreenNo = 1;
		/// <summary>
		/// LED1��̬�����
		/// </summary>
		int LED1DYArea_ID = 1;
		/// <summary>
		/// LED1���±�ʶ
		/// </summary>
		bool LED1m_bSendBusy = false;

		private bool _LED1ConnectStatus;
		/// <summary>
		/// LED1����״̬
		/// </summary>
		public bool LED1ConnectStatus
		{
			get
			{
				return _LED1ConnectStatus;
			}

			set
			{
				_LED1ConnectStatus = value;

				slightLED1.LightColor = (value ? Color.Green : Color.Red);

				commonDAO.SetSignalDataValue(CommonAppConfig.GetInstance().AppIdentifier, eSignalDataName.LED��1_����״̬.ToString(), value ? "1" : "0");
			}
		}

		/// <summary>
		/// LED1��ʾ�����ı�
		/// </summary>
		string LED1TempFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Led1TempFile.txt");

		/// <summary>
		/// LED1��һ����ʾ����
		/// </summary>
		string LED1PrevLedFileContent = string.Empty;

		/// <summary>
		/// ����LED1��̬����
		/// </summary>
		/// <param name="value1">��һ������</param>
		/// <param name="value2">�ڶ�������</param>
		private void UpdateLed1Show(string value1 = "", string value2 = "")
		{
			FrmDebugConsole.GetInstance().Output("����LED1:|" + value1 + "|" + value2 + "|");

			if (!this.LED1ConnectStatus) return;
			if (this.LED1PrevLedFileContent == value1 + value2) return;

			string ledContent = GenerateFillLedContent12(value1) + GenerateFillLedContent12(value2);

			File.WriteAllText(this.LED1TempFile, ledContent, Encoding.UTF8);

			if (LED1m_bSendBusy == false)
			{
				LED1m_bSendBusy = true;

				//int nResult = YB14DynamicAreaLeder.SendDynamicAreaInfoCommand(this.LED1nScreenNo, this.LED1DYArea_ID);
				//if (nResult != YB14DynamicAreaLeder.RETURN_NOERROR) Log4Neter.Error("����LED��̬����", new Exception(YB14DynamicAreaLeder.GetErrorMessage("SendDynamicAreaInfoCommand", nResult)));

				LED1m_bSendBusy = false;
			}

			this.LED1PrevLedFileContent = value1 + value2;
		}

		#endregion

		#endregion

		#region �豸��ʼ����ж��

		/// <summary>
		/// ��ʼ������豸
		/// </summary>
		private void InitHardware()
		{
			try
			{
				bool success = false;

				this.InductorCoil1Port = commonDAO.GetAppletConfigInt32("IO������_�ظ�1�˿�");

				// IO������
				Hardwarer.Iocer.OnReceived += new IOC.JMDM20DIOV2.JMDM20DIOV2Iocer.ReceivedEventHandler(Iocer_Received);
				Hardwarer.Iocer.OnStatusChange += new IOC.JMDM20DIOV2.JMDM20DIOV2Iocer.StatusChangeHandler(Iocer_StatusChange);
				success = Hardwarer.Iocer.OpenCom(commonDAO.GetAppletConfigInt32("IO������_����"), commonDAO.GetAppletConfigInt32("IO������_������"), commonDAO.GetAppletConfigInt32("IO������_����λ"), (StopBits)commonDAO.GetAppletConfigInt32("IO������_ֹͣλ"), (Parity)commonDAO.GetAppletConfigInt32("IO������_У��λ"));
				if (!success) MessageBoxEx.Show("IO����������ʧ�ܣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.iocControler = new IocControler(Hardwarer.Iocer);

				// ������1
				Hardwarer.Rwer1.StartWith = commonDAO.GetAppletConfigString("������_��ǩ����");
				Hardwarer.Rwer1.OnStatusChange += new RW.LZR12.Lzr12Rwer.StatusChangeHandler(Rwer1_OnStatusChange);
				Hardwarer.Rwer1.OnScanError += new RW.LZR12.Lzr12Rwer.ScanErrorEventHandler(Rwer1_OnScanError);
				success = Hardwarer.Rwer1.OpenCom(commonDAO.GetAppletConfigInt32("������1_����"));
				if (!success) MessageBoxEx.Show("������1����ʧ�ܣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

				#region LED���ƿ�1

				string led1SocketIP = commonDAO.GetAppletConfigString("LED��ʾ��1_IP��ַ");
				if (!string.IsNullOrEmpty(led1SocketIP))
				{
					if (CommonUtil.PingReplyTest(led1SocketIP))
					{
						int nResult = YB14DynamicAreaLeder.AddScreen(YB14DynamicAreaLeder.CONTROLLER_BX_5E1, this.LED1nScreenNo, YB14DynamicAreaLeder.SEND_MODE_NETWORK, 96, 32, 1, 1, "", 0, led1SocketIP, 5005, "");
						if (nResult == YB14DynamicAreaLeder.RETURN_NOERROR)
						{
							nResult = YB14DynamicAreaLeder.AddScreenDynamicArea(this.LED1nScreenNo, this.LED1DYArea_ID, 0, 10, 1, "", 0, 0, 0, 96, 32, 255, 0, 255, 7, 6, 1);
							if (nResult == YB14DynamicAreaLeder.RETURN_NOERROR)
							{
								nResult = YB14DynamicAreaLeder.AddScreenDynamicAreaFile(this.LED1nScreenNo, this.LED1DYArea_ID, this.LED1TempFile, 0, "����", 12, 0, 120, 1, 3, 0);
								if (nResult == YB14DynamicAreaLeder.RETURN_NOERROR)
								{
									// ��ʼ���ɹ�
									this.LED1ConnectStatus = true;
									UpdateLed1Show("  �ȴ�����");
								}
								else
								{
									this.LED1ConnectStatus = false;
									Log4Neter.Error("��ʼ��LED1���ƿ�", new Exception(YB14DynamicAreaLeder.GetErrorMessage("AddScreenDynamicAreaFile", nResult)));
									MessageBoxEx.Show("LED1���ƿ�����ʧ�ܣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
								}
							}
							else
							{
								this.LED1ConnectStatus = false;
								Log4Neter.Error("��ʼ��LED1���ƿ�", new Exception(YB14DynamicAreaLeder.GetErrorMessage("AddScreenDynamicArea", nResult)));
								MessageBoxEx.Show("LED1���ƿ�����ʧ�ܣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							}
						}
						else
						{
							this.LED1ConnectStatus = false;
							Log4Neter.Error("��ʼ��LED1���ƿ�", new Exception(YB14DynamicAreaLeder.GetErrorMessage("AddScreen", nResult)));
							MessageBoxEx.Show("LED1���ƿ�����ʧ�ܣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}
					else
					{
						this.LED1ConnectStatus = false;
						Log4Neter.Error("��ʼ��LED1���ƿ�����������ʧ��", new Exception("�����쳣"));
						MessageBoxEx.Show("LED1���ƿ���������ʧ�ܣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
				commonDAO.SetSignalDataValue(CommonAppConfig.GetInstance().AppIdentifier, eSignalDataName.LED��1_����״̬.ToString(), this.LED1ConnectStatus ? "1" : "0");

				#endregion

				//��������
				voiceSpeaker.SetVoice(commonDAO.GetAppletConfigInt32("����"), commonDAO.GetAppletConfigInt32("����"), commonDAO.GetAppletConfigString("������"));

				timer1.Enabled = true;
			}
			catch (Exception ex)
			{
				Log4Neter.Error("�豸��ʼ��", ex);
			}
		}

		/// <summary>
		/// ж���豸
		/// </summary>
		private void UnloadHardware()
		{
			// ע��˶δ���
			Application.DoEvents();

			try
			{
				commonDAO.SetSignalDataValue(CommonAppConfig.GetInstance().AppIdentifier, eSignalDataName.��ǰ��Id.ToString(), string.Empty);
				commonDAO.SetSignalDataValue(CommonAppConfig.GetInstance().AppIdentifier, eSignalDataName.��ǰ����.ToString(), string.Empty);
			}
			catch { }
			try
			{
				Hardwarer.Iocer.OnReceived -= new IOC.JMDM20DIOV2.JMDM20DIOV2Iocer.ReceivedEventHandler(Iocer_Received);
				Hardwarer.Iocer.OnStatusChange -= new IOC.JMDM20DIOV2.JMDM20DIOV2Iocer.StatusChangeHandler(Iocer_StatusChange);

				Hardwarer.Iocer.CloseCom();
			}
			catch { }
			try
			{
				Hardwarer.Rwer1.CloseCom();
			}
			catch { }

			try
			{
				if (this.LED1ConnectStatus)
				{
					YB14DynamicAreaLeder.SendDeleteDynamicAreasCommand(this.LED1nScreenNo, 1, "");
					YB14DynamicAreaLeder.DeleteScreen(this.LED1nScreenNo);
				}
			}
			catch { }
		}

		#endregion

		#endregion

		#region ��բ���ư�ť

		/// <summary>
		/// ��բ1����
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnGate1Up_Click(object sender, EventArgs e)
		{
			if (this.iocControler != null) this.iocControler.Gate1Up();
		}

		/// <summary>
		/// ��բ1����
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnGate1Down_Click(object sender, EventArgs e)
		{
			if (this.iocControler != null && !this.InductorCoil2) this.iocControler.Gate1Down();
		}

		#endregion

		#region ����ҵ��

		/// <summary>
		/// ����������ʶ������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer1_Tick(object sender, EventArgs e)
		{
			timer1.Stop();
			timer1.Interval = 2000;

			try
			{
				// ִ��Զ������
				ExecAppRemoteControlCmd();

				switch (this.CurrentFlowFlag)
				{
					case eFlowFlag.�ȴ�����:
						#region

						// PassWay.Way1
						if (this.InductorCoil1)
						{
							// ����������ظ����źţ������������߳���ʶ��

							List<string> tags = Hardwarer.Rwer1.ScanTags();
							if (tags.Count > 0) passCarQueuer.Enqueue(ePassWay.Way1, tags[0], true);
						}

						if (passCarQueuer.Count > 0) this.CurrentFlowFlag = eFlowFlag.��֤����;

						#endregion
						break;

					case eFlowFlag.��֤����:
						#region

						// �������޳�ʱ���ȴ�����
						if (passCarQueuer.Count == 0)
						{
							this.CurrentFlowFlag = eFlowFlag.�ȴ�����;
							break;
						}

						this.CurrentImperfectCar = passCarQueuer.Dequeue();

						// ��ʽһ������ʶ��ĳ��ƺŲ��ҳ�����Ϣ
						this.CurrentAutotruck = carTransportDAO.GetAutotruckByCarNumber(this.CurrentImperfectCar.Voucher);
						if (this.CurrentAutotruck == null)
							// ��ʽ��������ʶ��ı�ǩ�����ҳ�����Ϣ
							this.CurrentAutotruck = carTransportDAO.GetAutotruckByTagId(this.CurrentImperfectCar.Voucher);

						if (this.CurrentAutotruck != null)
						{
							UpdateLedShow(this.CurrentAutotruck.CarNumber);

							if (this.CurrentAutotruck.IsUse == 1)
							{
								// �ж��Ƿ����δ���������¼�������������û�ȷ��
								bool hasUnFinish = false;
								CmcsUnFinishTransport unFinishTransport = carTransportDAO.GetUnFinishTransportByAutotruckId(this.CurrentAutotruck.Id, this.CurrentAutotruck.CarType);
								if (unFinishTransport != null)
								{
									FrmTransport_Confirm frm = new FrmTransport_Confirm(unFinishTransport.TransportId, unFinishTransport.CarType);
									if (frm.ShowDialog() == DialogResult.Yes)
									{
										timer2_Tick(null, null);
									}
									else
									{
										this.CurrentAutotruck = null;
										this.CurrentFlowFlag = eFlowFlag.�ȴ�����;
										timer1.Interval = 10000;
										hasUnFinish = true;
									}
								}

								if (!hasUnFinish)
								{
									if (this.CurrentAutotruck.CarType == eCarType.�볧ú.ToString())
									{
										this.timer_BuyFuel_Cancel = false;
										this.CurrentFlowFlag = eFlowFlag.ƥ��Ԥ��;
									}
									else if (this.CurrentAutotruck.CarType == eCarType.��������.ToString())
									{
										this.timer_Goods_Cancel = false;
										this.CurrentFlowFlag = eFlowFlag.����¼��;
									}
								}
							}
							else
							{
								UpdateLedShow(this.CurrentAutotruck.CarNumber, "��ͣ��");
								this.voiceSpeaker.Speak("���ƺ� " + this.CurrentAutotruck.CarNumber + " ��ͣ�ã���ֹͨ��", 1, false);

								timer1.Interval = 8000;
							}
						}
						else
						{
							UpdateLedShow(this.CurrentImperfectCar.Voucher, "δ�Ǽ�");

							// ��ʽ����ˢ����ʽ
							this.voiceSpeaker.Speak("����δ�Ǽǣ���ֹͨ��", 1, false);

							timer1.Interval = 8000;
						}

						#endregion
						break;
				}
			}
			catch (Exception ex)
			{
				Log4Neter.Error("timer1_Tick", ex);
			}
			finally
			{
				timer1.Start();
			}
		}

		/// <summary>
		/// ��������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer2_Tick(object sender, EventArgs e)
		{
			timer2.Stop();
			// ������ִ��һ��
			timer2.Interval = 180000;

			try
			{

			}
			catch (Exception ex)
			{
				Log4Neter.Error("timer2_Tick", ex);
			}
			finally
			{
				timer2.Start();
			}
		}

		/// <summary>
		/// �г����ڵ�ǰ��·��
		/// </summary>
		/// <returns></returns>
		bool HasCarOnCurrentWay()
		{
			if (this.CurrentImperfectCar == null) return false;

			if (this.CurrentImperfectCar.PassWay == ePassWay.UnKnow)
				return false;
			else if (this.CurrentImperfectCar.PassWay == ePassWay.Way1)
				return this.InductorCoil1;
			return true;
		}

		/// <summary>
		/// ����ú��
		/// </summary>
		void LoadFuelkind(params ComboBoxEx[] comboBoxEx)
		{
			foreach (ComboBoxEx item in comboBoxEx)
			{
				item.DisplayMember = "Name";
				item.ValueMember = "Id";
				item.DataSource = Dbers.GetInstance().SelfDber.Entities<CmcsFuelKind>("where IsStop=0 and ParentId is not null");
			}
		}

		/// <summary>
		/// ���ز�����ʽ
		/// </summary>
		void LoadSampleType(ComboBoxEx comboBoxEx)
		{
			comboBoxEx.DisplayMember = "Content";
			comboBoxEx.ValueMember = "Code";
			comboBoxEx.DataSource = commonDAO.GetCodeContentByKind("������ʽ");

			comboBoxEx.Text = eSamplingType.��е����.ToString();
		}

		/// <summary>
		/// ִ��Զ������
		/// </summary>
		void ExecAppRemoteControlCmd()
		{
			// ��ȡ���µ�����
			CmcsAppRemoteControlCmd appRemoteControlCmd = commonDAO.GetNewestAppRemoteControlCmd(CommonAppConfig.GetInstance().AppIdentifier);
			if (appRemoteControlCmd != null)
			{
				if (appRemoteControlCmd.CmdCode == "���Ƶ�բ")
				{
					Log4Neter.Info("����Զ�����" + appRemoteControlCmd.CmdCode + "��������" + appRemoteControlCmd.Param);

					if (appRemoteControlCmd.Param.Equals("Gate1Up", StringComparison.CurrentCultureIgnoreCase))
						this.iocControler.Gate1Up();
					else if (appRemoteControlCmd.Param.Equals("Gate1Down", StringComparison.CurrentCultureIgnoreCase))
						this.iocControler.Gate1Down();
					else if (appRemoteControlCmd.Param.Equals("Gate2Up", StringComparison.CurrentCultureIgnoreCase))
						this.iocControler.Gate2Up();
					else if (appRemoteControlCmd.Param.Equals("Gate2Down", StringComparison.CurrentCultureIgnoreCase))
						this.iocControler.Gate2Down();

					// ����ִ�н��
					commonDAO.SetAppRemoteControlCmdResultCode(appRemoteControlCmd, eEquInfCmdResultCode.�ɹ�);
				}
			}
		}

		/// <summary>
		/// ˢ���б�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRefresh_Click(object sender, EventArgs e)
		{
			// �볧ú
			LoadTodayUnFinishBuyFuelTransport();
			LoadTodayFinishBuyFuelTransport();

			// ��������
			LoadTodayUnFinishGoodsTransport();
			LoadTodayFinishGoodsTransport();
		}

		#endregion

		#region �볧úҵ��

		bool timer_BuyFuel_Cancel = true;

		private CmcsSupplier selectedSupplier_BuyFuel;
		/// <summary>
		/// ѡ��Ĺ�ú��λ
		/// </summary>
		public CmcsSupplier SelectedSupplier_BuyFuel
		{
			get { return selectedSupplier_BuyFuel; }
			set
			{
				selectedSupplier_BuyFuel = value;

				if (value != null)
				{
					txtSupplierName_BuyFuel.Text = value.Name;
				}
				else
				{
					txtSupplierName_BuyFuel.ResetText();
				}
			}
		}

		private CmcsTransportCompany selectedTransportCompany_BuyFuel;
		/// <summary>
		/// ѡ������䵥λ
		/// </summary>
		public CmcsTransportCompany SelectedTransportCompany_BuyFuel
		{
			get { return selectedTransportCompany_BuyFuel; }
			set
			{
				selectedTransportCompany_BuyFuel = value;

				if (value != null)
				{
					txtTransportCompanyName_BuyFuel.Text = value.Name;
				}
				else
				{
					txtTransportCompanyName_BuyFuel.ResetText();
				}
			}
		}

		private CmcsMine selectedMine_BuyFuel;
		/// <summary>
		/// ѡ��Ŀ��
		/// </summary>
		public CmcsMine SelectedMine_BuyFuel
		{
			get { return selectedMine_BuyFuel; }
			set
			{
				selectedMine_BuyFuel = value;

				if (value != null)
				{
					txtMineName_BuyFuel.Text = value.Name;
				}
				else
				{
					txtMineName_BuyFuel.ResetText();
				}
			}
		}

		private CmcsFuelKind selectedFuelKind_BuyFuel;
		/// <summary>
		/// ѡ���ú��
		/// </summary>
		public CmcsFuelKind SelectedFuelKind_BuyFuel
		{
			get { return selectedFuelKind_BuyFuel; }
			set
			{
				if (value != null)
				{
					selectedFuelKind_BuyFuel = value;
					cmbFuelName_BuyFuel.Text = value.Name;
				}
				else
				{
					cmbFuelName_BuyFuel.SelectedIndex = 0;
				}
			}
		}

		/// <summary>
		/// ѡ����
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSelectAutotruck_BuyFuel_Click(object sender, EventArgs e)
		{
			FrmAutotruck_Select frm = new FrmAutotruck_Select("and CarType='" + eCarType.�볧ú.ToString() + "' and IsUse=1 order by CarNumber asc");
			if (frm.ShowDialog() == DialogResult.OK)
			{
				passCarQueuer.Enqueue(ePassWay.Way1, frm.Output.CarNumber, false);
				this.CurrentFlowFlag = eFlowFlag.��֤����;
			}
		}

		/// <summary>
		/// ѡ��ú��λ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSelectSupplier_BuyFuel_Click(object sender, EventArgs e)
		{
			FrmSupplier_Select frm = new FrmSupplier_Select("where IsStop=0 order by Name asc");
			if (frm.ShowDialog() == DialogResult.OK)
			{
				this.SelectedSupplier_BuyFuel = frm.Output;
			}
		}

		/// <summary>
		/// ѡ����
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSelectMine_BuyFuel_Click(object sender, EventArgs e)
		{
			FrmMine_Select frm = new FrmMine_Select("where IsStop=0 order by Name asc");
			if (frm.ShowDialog() == DialogResult.OK)
			{
				this.SelectedMine_BuyFuel = frm.Output;
			}
		}

		/// <summary>
		/// ѡ�����䵥λ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSelectTransportCompany_BuyFuel_Click(object sender, EventArgs e)
		{
			FrmTransportCompany_Select frm = new FrmTransportCompany_Select("where IsStop=0 order by Name asc");
			if (frm.ShowDialog() == DialogResult.OK)
			{
				this.SelectedTransportCompany_BuyFuel = frm.Output;
			}
		}

		/// <summary>
		/// ѡ��ú��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmbFuelName_BuyFuel_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.SelectedFuelKind_BuyFuel = cmbFuelName_BuyFuel.SelectedItem as CmcsFuelKind;
		}

		/// <summary>
		/// �³��Ǽ�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnNewAutotruck_BuyFuel_Click(object sender, EventArgs e)
		{
			// eCarType.�볧ú

			new FrmAutotruck_Oper(Guid.NewGuid().ToString(), eEditMode.����).Show();
		}

		/// <summary>
		/// ѡ���볧ú��úԤ��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSelectForecast_BuyFuel_Click(object sender, EventArgs e)
		{
			FrmBuyFuelForecast_Select frm = new FrmBuyFuelForecast_Select();
			if (frm.ShowDialog() == DialogResult.OK)
			{
				this.SelectedFuelKind_BuyFuel = commonDAO.SelfDber.Get<CmcsFuelKind>(frm.Output.FuelKindId);
				this.SelectedMine_BuyFuel = commonDAO.SelfDber.Get<CmcsMine>(frm.Output.MineId);
				this.SelectedSupplier_BuyFuel = commonDAO.SelfDber.Get<CmcsSupplier>(frm.Output.SupplierId);
				this.SelectedTransportCompany_BuyFuel = commonDAO.SelfDber.Get<CmcsTransportCompany>(frm.Output.TransportCompanyId);
			}
		}

		/// <summary>
		/// �����볧ú�����¼
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSaveTransport_BuyFuel_Click(object sender, EventArgs e)
		{
			SaveBuyFuelTransport();
		}

		/// <summary>
		/// ���������¼
		/// </summary>
		/// <returns></returns>
		bool SaveBuyFuelTransport()
		{
			if (this.CurrentAutotruck == null)
			{
				MessageBoxEx.Show("��ѡ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			if (this.SelectedFuelKind_BuyFuel == null)
			{
				MessageBoxEx.Show("��ѡ��ú��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			if (this.SelectedMine_BuyFuel == null)
			{
				MessageBoxEx.Show("��ѡ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			if (this.SelectedSupplier_BuyFuel == null)
			{
				MessageBoxEx.Show("��ѡ��ú��λ", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			if (this.SelectedTransportCompany_BuyFuel == null)
			{
				MessageBoxEx.Show("��ѡ�����䵥λ", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			if (txtTicketWeight_BuyFuel.Value <= 0)
			{
				MessageBoxEx.Show("��������Ч�Ŀ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			try
			{
				// �����볧ú�ŶӼ�¼��ͬʱ����������Ϣ�Լ����ƻ���������
				if (queuerDAO.JoinQueueBuyFuelTransport(this.CurrentAutotruck, this.SelectedSupplier_BuyFuel, this.SelectedMine_BuyFuel, this.SelectedTransportCompany_BuyFuel, this.SelectedFuelKind_BuyFuel, (decimal)txtTicketWeight_BuyFuel.Value, DateTime.Now, txtRemark_BuyFuel.Text, CommonAppConfig.GetInstance().AppIdentifier))
				{
					btnSaveTransport_BuyFuel.Enabled = false;

					UpdateLedShow("�Ŷӳɹ�", "���뿪");
					MessageBoxEx.Show("�Ŷӳɹ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);

					this.CurrentFlowFlag = eFlowFlag.�ȴ��뿪;

					LoadTodayUnFinishBuyFuelTransport();
					LoadTodayFinishBuyFuelTransport();

					LetPass();

					return true;
				}
			}
			catch (Exception ex)
			{
				MessageBoxEx.Show("����ʧ��\r\n" + ex.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);

				Log4Neter.Error("���������¼", ex);
			}

			return false;
		}

		/// <summary>
		/// �����볧ú�����¼
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnReset_BuyFuel_Click(object sender, EventArgs e)
		{
			ResetBuyFuel();
		}

		/// <summary>
		/// ������Ϣ
		/// </summary>
		void ResetBuyFuel()
		{
			this.timer_BuyFuel_Cancel = true;

			this.CurrentFlowFlag = eFlowFlag.�ȴ�����;

			this.CurrentAutotruck = null;
			this.SelectedMine_BuyFuel = null;
			this.SelectedSupplier_BuyFuel = null;
			this.SelectedTransportCompany_BuyFuel = null;

			txtTagId_BuyFuel.ResetText();
			txtTicketWeight_BuyFuel.Value = 0;
			txtRemark_BuyFuel.ResetText();

			btnSaveTransport_BuyFuel.Enabled = true;

			LetBlocking();
			UpdateLedShow("  �ȴ�����");

			// �������
			this.CurrentImperfectCar = null;
		}

		/// <summary>
		/// �볧ú�����¼ҵ��ʱ��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer_BuyFuel_Tick(object sender, EventArgs e)
		{
			if (this.timer_BuyFuel_Cancel) return;

			timer_BuyFuel.Stop();
			timer_BuyFuel.Interval = 2000;

			try
			{
				switch (this.CurrentFlowFlag)
				{
					case eFlowFlag.ƥ��Ԥ��:
						#region

						//List<CmcsLMYB> lMYBs = queuerDAO.GetBuyFuelForecastByCarNumber(this.CurrentAutotruck.CarNumber, DateTime.Now);
						//if (lMYBs.Count > 1)
						//{
						//    // ����úԤ�����ڶ���ʱ������ѡ��ȷ�Ͽ�
						//    FrmBuyFuelForecast_Confirm frm = new FrmBuyFuelForecast_Confirm(lMYBs);
						//    if (frm.ShowDialog() == DialogResult.OK) BorrowForecast_BuyFuel(frm.Output);
						//}
						//else if (lMYBs.Count == 1)
						//{
						//    BorrowForecast_BuyFuel(lMYBs[0]);
						//}

						this.CurrentFlowFlag = eFlowFlag.����¼��;

						#endregion
						break;

					case eFlowFlag.����¼��:
						#region


						#endregion
						break;

					case eFlowFlag.�ȴ��뿪:
						#region

						// ��ǰ��·�ظ����ź�ʱ����
						if (!HasCarOnCurrentWay()) ResetBuyFuel();

						// ����������
						timer_BuyFuel.Interval = 4000;

						#endregion
						break;
				}

				// ��ǰ��·�ظ����ź�ʱ����
				if (!HasCarOnCurrentWay() && this.CurrentFlowFlag != eFlowFlag.�ȴ����� && (this.CurrentImperfectCar != null && this.CurrentImperfectCar.IsFromDevice)) ResetBuyFuel();
			}
			catch (Exception ex)
			{
				Log4Neter.Error("timer_BuyFuel_Tick", ex);
			}
			finally
			{
				timer_BuyFuel.Start();
			}
		}

		/// <summary>
		/// ��ȡδ��ɵ��볧ú��¼
		/// </summary>
		void LoadTodayUnFinishBuyFuelTransport()
		{
			superGridControl1_BuyFuel.PrimaryGrid.DataSource = queuerDAO.GetUnFinishBuyFuelTransport();
		}

		/// <summary>
		/// ��ȡָ����������ɵ��볧ú��¼
		/// </summary>
		void LoadTodayFinishBuyFuelTransport()
		{
			superGridControl2_BuyFuel.PrimaryGrid.DataSource = queuerDAO.GetFinishedBuyFuelTransport(DateTime.Now.Date, DateTime.Now.Date.AddDays(1));
		}

		/// <summary>
		/// ��ȡԤ����Ϣ
		/// </summary>
		/// <param name="lMYB">��úԤ��</param>
		void BorrowForecast_BuyFuel(CmcsLMYB lMYB)
		{
			if (lMYB == null) return;

			this.SelectedFuelKind_BuyFuel = commonDAO.SelfDber.Get<CmcsFuelKind>(lMYB.FuelKindId);
			this.SelectedMine_BuyFuel = commonDAO.SelfDber.Get<CmcsMine>(lMYB.MineId);
			this.SelectedSupplier_BuyFuel = commonDAO.SelfDber.Get<CmcsSupplier>(lMYB.SupplierId);
			this.SelectedTransportCompany_BuyFuel = commonDAO.SelfDber.Get<CmcsTransportCompany>(lMYB.TransportCompanyId);
		}

		/// <summary>
		/// ˫����ʱ���Զ���乩ú��λ��������Ϣ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void superGridControl_BuyFuel_CellDoubleClick(object sender, DevComponents.DotNetBar.SuperGrid.GridCellDoubleClickEventArgs e)
		{
			GridRow gridRow = (sender as SuperGridControl).PrimaryGrid.ActiveRow as GridRow;
			if (gridRow == null) return;

			View_BuyFuelTransport entity = (gridRow.DataItem as View_BuyFuelTransport);
			if (entity != null)
			{
				this.SelectedFuelKind_BuyFuel = commonDAO.SelfDber.Get<CmcsFuelKind>(entity.FuelKindId);
				this.SelectedMine_BuyFuel = commonDAO.SelfDber.Get<CmcsMine>(entity.MineId);
				this.SelectedSupplier_BuyFuel = commonDAO.SelfDber.Get<CmcsSupplier>(entity.SupplierId);
				this.SelectedTransportCompany_BuyFuel = commonDAO.SelfDber.Get<CmcsTransportCompany>(entity.TransportCompanyId);

			}
		}

		private void superGridControl1_BuyFuel_CellClick(object sender, GridCellClickEventArgs e)
		{
			View_BuyFuelTransport entity = e.GridCell.GridRow.DataItem as View_BuyFuelTransport;
			if (entity == null) return;

			// ������Ч״̬
			if (e.GridCell.GridColumn.Name == "ChangeIsUse") queuerDAO.ChangeBuyFuelTransportToInvalid(entity.Id, Convert.ToBoolean(e.GridCell.Value));
		}

		private void superGridControl1_BuyFuel_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
		{
			foreach (GridRow gridRow in e.GridPanel.Rows)
			{
				View_BuyFuelTransport entity = gridRow.DataItem as View_BuyFuelTransport;
				if (entity == null) return;

				// �����Ч״̬
				gridRow.Cells["ChangeIsUse"].Value = Convert.ToBoolean(entity.IsUse);
			}
		}

		private void superGridControl2_BuyFuel_CellClick(object sender, GridCellClickEventArgs e)
		{
			View_BuyFuelTransport entity = e.GridCell.GridRow.DataItem as View_BuyFuelTransport;
			if (entity == null) return;

			// ������Ч״̬
			if (e.GridCell.GridColumn.Name == "ChangeIsUse") queuerDAO.ChangeBuyFuelTransportToInvalid(entity.Id, Convert.ToBoolean(e.GridCell.Value));
		}

		private void superGridControl2_BuyFuel_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
		{
			foreach (GridRow gridRow in e.GridPanel.Rows)
			{
				View_BuyFuelTransport entity = gridRow.DataItem as View_BuyFuelTransport;
				if (entity == null) return;

				// �����Ч״̬
				gridRow.Cells["ChangeIsUse"].Value = Convert.ToBoolean(entity.IsUse);
			}
		}

		#endregion

		#region ��������ҵ��

		bool timer_Goods_Cancel = true;

		private CmcsSupplier selectedSupplyUnit_Goods;
		/// <summary>
		/// ѡ��Ĺ�����λ
		/// </summary>
		public CmcsSupplier SelectedSupplyUnit_Goods
		{
			get { return selectedSupplyUnit_Goods; }
			set
			{
				selectedSupplyUnit_Goods = value;

				if (value != null)
				{
					txtSupplyUnitName_Goods.Text = value.Name;
				}
				else
				{
					txtSupplyUnitName_Goods.ResetText();
				}
			}
		}

		private CmcsSupplier selectedReceiveUnit_Goods;
		/// <summary>
		/// ѡ����ջ���λ
		/// </summary>
		public CmcsSupplier SelectedReceiveUnit_Goods
		{
			get { return selectedReceiveUnit_Goods; }
			set
			{
				selectedReceiveUnit_Goods = value;

				if (value != null)
				{
					txtReceiveUnitName_Goods.Text = value.Name;
				}
				else
				{
					txtReceiveUnitName_Goods.ResetText();
				}
			}
		}

		private CmcsGoodsType selectedGoodsType_Goods;
		/// <summary>
		/// ѡ�����������
		/// </summary>
		public CmcsGoodsType SelectedGoodsType_Goods
		{
			get { return selectedGoodsType_Goods; }
			set
			{
				selectedGoodsType_Goods = value;

				if (value != null)
				{
					txtGoodsTypeName_Goods.Text = value.GoodsName;
				}
				else
				{
					txtGoodsTypeName_Goods.ResetText();
				}
			}
		}

		/// <summary>
		/// ѡ����
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSelectAutotruck_Goods_Click(object sender, EventArgs e)
		{
			FrmAutotruck_Select frm = new FrmAutotruck_Select("and CarType='" + eCarType.��������.ToString() + "' and IsUse=1 order by CarNumber asc");
			if (frm.ShowDialog() == DialogResult.OK)
			{
				passCarQueuer.Enqueue(ePassWay.UnKnow, frm.Output.CarNumber, false);
				this.CurrentFlowFlag = eFlowFlag.��֤����;
			}
		}

		/// <summary>
		/// ѡ�񹩻���λ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnbtnSelectSupply_Goods_Click(object sender, EventArgs e)
		{
			FrmSupplier_Select frm = new FrmSupplier_Select("where IsStop=0 order by Name asc");
			if (frm.ShowDialog() == DialogResult.OK)
			{
				this.SelectedSupplyUnit_Goods = frm.Output;
			}
		}

		/// <summary>
		/// ѡ���ջ���λ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSelectReceive_Goods_Click(object sender, EventArgs e)
		{
			FrmSupplier_Select frm = new FrmSupplier_Select("where IsStop=0 order by Name asc");
			if (frm.ShowDialog() == DialogResult.OK)
			{
				this.SelectedReceiveUnit_Goods = frm.Output;
			}
		}

		/// <summary>
		/// ѡ����������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSelectGoodsType_Goods_Click(object sender, EventArgs e)
		{
			FrmGoodsType_Select frm = new FrmGoodsType_Select();
			if (frm.ShowDialog() == DialogResult.OK)
			{
				this.SelectedGoodsType_Goods = frm.Output;
			}
		}

		/// <summary>
		/// �³��Ǽ�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnNewAutotruck_Goods_Click(object sender, EventArgs e)
		{
			// eCarType.�������� 

			new FrmAutotruck_Oper(Guid.NewGuid().ToString(), eEditMode.����).Show();
		}

		/// <summary>
		/// �����ŶӼ�¼
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSaveTransport_Goods_Click(object sender, EventArgs e)
		{
			SaveGoodsTransport();
		}

		/// <summary>
		/// ���������¼
		/// </summary>
		/// <returns></returns>
		bool SaveGoodsTransport()
		{
			if (this.CurrentAutotruck == null)
			{
				MessageBoxEx.Show("��ѡ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			if (this.SelectedSupplyUnit_Goods == null)
			{
				MessageBoxEx.Show("��ѡ�񹩻���λ", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			if (this.SelectedReceiveUnit_Goods == null)
			{
				MessageBoxEx.Show("��ѡ���ջ���λ", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			if (this.SelectedGoodsType_Goods == null)
			{
				MessageBoxEx.Show("��ѡ����������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			try
			{
				// �����ŶӼ�¼
				if (queuerDAO.JoinQueueGoodsTransport(this.CurrentAutotruck, this.SelectedSupplyUnit_Goods, this.SelectedReceiveUnit_Goods, this.SelectedGoodsType_Goods, DateTime.Now, txtRemark_Goods.Text, CommonAppConfig.GetInstance().AppIdentifier))
				{
					LetPass();

					btnSaveTransport_Goods.Enabled = false;

					UpdateLedShow("�Ŷӳɹ�", "���뿪");
					MessageBoxEx.Show("�Ŷӳɹ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);

					this.CurrentFlowFlag = eFlowFlag.�ȴ��뿪;

					LoadTodayUnFinishGoodsTransport();
					LoadTodayFinishGoodsTransport();

					return true;
				}
			}
			catch (Exception ex)
			{
				MessageBoxEx.Show("����ʧ��\r\n" + ex.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);

				Log4Neter.Error("���������¼", ex);
			}

			return false;
		}

		/// <summary>
		/// ������Ϣ
		/// </summary>
		void ResetGoods()
		{
			this.timer_Goods_Cancel = true;

			this.CurrentFlowFlag = eFlowFlag.�ȴ�����;

			this.CurrentAutotruck = null;
			this.SelectedSupplyUnit_Goods = null;
			this.SelectedReceiveUnit_Goods = null;
			this.SelectedGoodsType_Goods = null;

			txtTagId_Goods.ResetText();
			txtRemark_Goods.ResetText();

			btnSaveTransport_Goods.Enabled = true;

			LetBlocking();
			UpdateLedShow("  �ȴ�����");

			// �������
			this.CurrentImperfectCar = null;
		}

		/// <summary>
		/// ������Ϣ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnReset_Goods_Click(object sender, EventArgs e)
		{
			ResetGoods();
		}

		/// <summary>
		/// �������������¼ҵ��ʱ��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer_Goods_Tick(object sender, EventArgs e)
		{
			if (this.timer_Goods_Cancel) return;

			timer_Goods.Stop();
			timer_Goods.Interval = 2000;

			try
			{
				switch (this.CurrentFlowFlag)
				{
					case eFlowFlag.����¼��:
						#region



						#endregion
						break;

					case eFlowFlag.�ȴ��뿪:
						#region

						// ��ǰ��·�ظ����ź�ʱ����
						if (!HasCarOnCurrentWay()) ResetGoods();

						#endregion
						break;
				}

				// ��ǰ��·�ظ����ź�ʱ����
				if (!HasCarOnCurrentWay() && this.CurrentFlowFlag != eFlowFlag.�ȴ����� && (this.CurrentImperfectCar != null && this.CurrentImperfectCar.IsFromDevice)) ResetGoods();
			}
			catch (Exception ex)
			{
				Log4Neter.Error("timer_Goods_Tick", ex);
			}
			finally
			{
				timer_Goods.Start();
			}
		}

		/// <summary>
		/// ��ȡδ��ɵ��������ʼ�¼
		/// </summary>
		void LoadTodayUnFinishGoodsTransport()
		{
			superGridControl1_Goods.PrimaryGrid.DataSource = queuerDAO.GetUnFinishGoodsTransport();
		}

		/// <summary>
		/// ��ȡָ����������ɵ��������ʼ�¼
		/// </summary>
		void LoadTodayFinishGoodsTransport()
		{
			superGridControl2_Goods.PrimaryGrid.DataSource = queuerDAO.GetFinishedGoodsTransport(DateTime.Now.Date, DateTime.Now.Date.AddDays(1));
		}

		/// <summary>
		/// ˫����ʱ���Զ����¼����Ϣ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void superGridControl_Goods_CellDoubleClick(object sender, DevComponents.DotNetBar.SuperGrid.GridCellDoubleClickEventArgs e)
		{
			GridRow gridRow = (sender as SuperGridControl).PrimaryGrid.ActiveRow as GridRow;
			if (gridRow == null) return;

			CmcsGoodsTransport entity = (gridRow.DataItem as CmcsGoodsTransport);
			if (entity != null)
			{
				this.SelectedSupplyUnit_Goods = commonDAO.SelfDber.Get<CmcsSupplier>(entity.SupplyUnitId);
				this.SelectedReceiveUnit_Goods = commonDAO.SelfDber.Get<CmcsSupplier>(entity.ReceiveUnitId);
				this.SelectedGoodsType_Goods = commonDAO.SelfDber.Get<CmcsGoodsType>(entity.GoodsTypeId);
			}
		}

		private void superGridControl1_Goods_CellClick(object sender, GridCellClickEventArgs e)
		{
			CmcsGoodsTransport entity = e.GridCell.GridRow.DataItem as CmcsGoodsTransport;
			if (entity == null) return;

			// ������Ч״̬
			if (e.GridCell.GridColumn.Name == "ChangeIsUse") queuerDAO.ChangeGoodsTransportToInvalid(entity.Id, Convert.ToBoolean(e.GridCell.Value));
		}

		private void superGridControl1_Goods_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
		{
			foreach (GridRow gridRow in e.GridPanel.Rows)
			{
				CmcsGoodsTransport entity = gridRow.DataItem as CmcsGoodsTransport;
				if (entity == null) return;

				// �����Ч״̬
				gridRow.Cells["ChangeIsUse"].Value = Convert.ToBoolean(entity.IsUse);
			}
		}

		private void superGridControl2_Goods_CellClick(object sender, GridCellClickEventArgs e)
		{
			CmcsGoodsTransport entity = e.GridCell.GridRow.DataItem as CmcsGoodsTransport;
			if (entity == null) return;

			// ������Ч״̬
			if (e.GridCell.GridColumn.Name == "ChangeIsUse") queuerDAO.ChangeGoodsTransportToInvalid(entity.Id, Convert.ToBoolean(e.GridCell.Value));
		}

		private void superGridControl2_Goods_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
		{
			foreach (GridRow gridRow in e.GridPanel.Rows)
			{
				CmcsGoodsTransport entity = gridRow.DataItem as CmcsGoodsTransport;
				if (entity == null) return;

				// �����Ч״̬
				gridRow.Cells["ChangeIsUse"].Value = Convert.ToBoolean(entity.IsUse);
			}
		}

		#endregion

		#region ��������

		Pen redPen3 = new Pen(Color.Red, 3);
		Pen greenPen3 = new Pen(Color.Lime, 3);

		/// <summary>
		/// ��ǰ����������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panCurrentCarNumber_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				PanelEx panel = sender as PanelEx;

				// ���Ƶظ�1
				e.Graphics.DrawLine(this.InductorCoil1 ? redPen3 : greenPen3, 15, 10, 15, panel.Height - 10);
			}
			catch (Exception ex)
			{
				Log4Neter.Error("panCurrentCarNumber_Paint�쳣", ex);
			}
		}

		private void superGridControl_BeginEdit(object sender, DevComponents.DotNetBar.SuperGrid.GridEditEventArgs e)
		{
			if (e.GridCell.GridColumn.DataPropertyName != "IsUse")
			{
				// ȡ������༭
				e.Cancel = true;
			}
		}

		/// <summary>
		/// �����к�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void superGridControl_GetRowHeaderText(object sender, DevComponents.DotNetBar.SuperGrid.GridGetRowHeaderTextEventArgs e)
		{
			e.Text = (e.GridRow.RowIndex + 1).ToString();
		}

		/// <summary>
		/// Invoke��װ
		/// </summary>
		/// <param name="action"></param>
		public void InvokeEx(Action action)
		{
			if (this.IsDisposed || !this.IsHandleCreated) return;

			this.Invoke(action);
		}

		#endregion

	}
}
