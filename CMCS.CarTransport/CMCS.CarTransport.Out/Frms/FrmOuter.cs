using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
//
using CMCS.CarTransport.DAO;
using CMCS.CarTransport.Out.Core;
using CMCS.CarTransport.Out.Enums;
using CMCS.CarTransport.Out.Frms.Sys;
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Common.Entities.CarTransport;
using CMCS.Common.Entities.Sys;
using CMCS.Common.Enums;
using CMCS.Common.Utilities;
using CMCS.Common.Views;
using CMCS.CarTransport.Out.Frms.Print;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using LED.YB14;

namespace CMCS.CarTransport.Out.Frms
{
	public partial class FrmOuter : DevComponents.DotNetBar.Metro.MetroForm
	{
		/// <summary>
		/// ����Ψһ��ʶ��
		/// </summary>
		public static string UniqueKey = "FrmOuter";

		public FrmOuter()
		{
			InitializeComponent();
		}

		#region Vars

		CarTransportDAO carTransportDAO = CarTransportDAO.GetInstance();
		OuterDAO outerDAO = OuterDAO.GetInstance();
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

		int inductorCoil1Port;
		/// <summary>
		/// �ظ�1�˿�
		/// </summary>
		public int InductorCoil1Port
		{
			get { return inductorCoil1Port; }
			set { inductorCoil1Port = value; }
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

		int inductorCoil2Port;
		/// <summary>
		/// �ظ�2�˿�
		/// </summary>
		public int InductorCoil2Port
		{
			get { return inductorCoil2Port; }
			set { inductorCoil2Port = value; }
		}

		bool autoHandMode = true;
		/// <summary>
		/// �Զ�ģʽ=true  �ֶ�ģʽ=false
		/// </summary>
		public bool AutoHandMode
		{
			get { return autoHandMode; }
			set
			{
				autoHandMode = value;

				btnSelectAutotruck_BuyFuel.Visible = !value;
				btnSelectAutotruck_Goods.Visible = !value;

				btnSaveTransport_BuyFuel.Visible = !value;
				btnSaveTransport_Goods.Visible = !value;

				btnReset_BuyFuel.Visible = !value;
				btnReset_Goods.Visible = !value;
			}
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

				if (value != null)
				{
					commonDAO.SetSignalDataValue(CommonAppConfig.GetInstance().AppIdentifier, eSignalDataName.��ǰ��Id.ToString(), value.Id);
					commonDAO.SetSignalDataValue(CommonAppConfig.GetInstance().AppIdentifier, eSignalDataName.��ǰ����.ToString(), value.CarNumber);

					CmcsEPCCard ePCCard = Dbers.GetInstance().SelfDber.Get<CmcsEPCCard>(value.EPCCardId);
					if (value.CarType == eCarType.�볧ú.ToString())
					{
						if (ePCCard != null) txtTagId_BuyFuel.Text = ePCCard.TagId;

						txtCarNumber_BuyFuel.Text = value.CarNumber;
						superTabControl2.SelectedTab = superTabItem_BuyFuel;
					}

					else if (value.CarType == eCarType.��������.ToString())
					{
						if (ePCCard != null) txtTagId_Goods.Text = ePCCard.TagId;

						txtCarNumber_Goods.Text = value.CarNumber;
						superTabControl2.SelectedTab = superTabItem_Goods;
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

			// Ĭ���Զ�
			sbtnChangeAutoHandMode.Value = true;

			// ���ó���Զ�̿�������
			commonDAO.ResetAppRemoteControlCmd(CommonAppConfig.GetInstance().AppIdentifier);

			btnRefresh_Click(null, null);
		}

		private void FrmWeighter_Load(object sender, EventArgs e)
		{
		}

		private void FrmWeighter_Shown(object sender, EventArgs e)
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
			// �����豸״̬ 
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
				this.InductorCoil2 = (receiveValue[this.InductorCoil2Port - 1] == 1);
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
			// �����豸״̬ 
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
				this.InductorCoil2Port = commonDAO.GetAppletConfigInt32("IO������_�ظ�2�˿�");

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
				YB14DynamicAreaLeder.SendDeleteDynamicAreasCommand(this.LED1nScreenNo, 1, "");
				YB14DynamicAreaLeder.DeleteScreen(this.LED1nScreenNo);
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
			if (this.iocControler != null) this.iocControler.Gate1Down();
		}

		/// <summary>
		/// ��բ2����
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnGate2Up_Click(object sender, EventArgs e)
		{
			if (this.iocControler != null) this.iocControler.Gate2Up();
		}

		/// <summary>
		/// ��բ2����
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnGate2Down_Click(object sender, EventArgs e)
		{
			if (this.iocControler != null) this.iocControler.Gate2Down();
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

						//���������
						timer1.Interval = 50;
						if (this.InductorCoil1)
						{
							List<string> tags = Hardwarer.Rwer1.ScanTags();
							if (tags.Count > 0) passCarQueuer.Enqueue(ePassWay.Way1, tags[0], true);
						}
						if (passCarQueuer.Count > 0) this.CurrentFlowFlag = eFlowFlag.ʶ����;
						#endregion
						break;

					case eFlowFlag.ʶ����:
						#region

						// �������޳�ʱ���ȴ�����
						if (passCarQueuer.Count == 0)
						{
							UpdateLedShow("  �ȴ�����");
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
							if (this.CurrentAutotruck.IsUse == 1)
							{
								if (this.CurrentAutotruck.CarType == eCarType.�볧ú.ToString())
								{
									this.timer_BuyFuel_Cancel = false;
									this.CurrentFlowFlag = eFlowFlag.��֤��Ϣ;
								}
								else if (this.CurrentAutotruck.CarType == eCarType.��������.ToString())
								{
									this.timer_Goods_Cancel = false;
									this.CurrentFlowFlag = eFlowFlag.��֤��Ϣ;
								}
							}
							else
							{
								UpdateLedShow(this.CurrentAutotruck.CarNumber, "��ͣ��");
								this.voiceSpeaker.Speak("���ƺ� " + this.CurrentAutotruck.CarNumber + " ��ͣ�ã���ֹͨ��", 1, false);

								timer1.Interval = 20000;
							}
						}
						else
						{
							UpdateLedShow(this.CurrentImperfectCar.Voucher, "δ�Ǽ�");

							// ��ʽһ������ʶ��
							this.voiceSpeaker.Speak("���ƺ� " + this.CurrentImperfectCar.Voucher + " δ�Ǽǣ���ֹͨ��", 1, false);
							//// ��ʽ����ˢ����ʽ
							this.voiceSpeaker.Speak("����δ�Ǽǣ���ֹͨ��", 1, false);

							timer1.Interval = 20000;
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
				return this.InductorCoil1 || this.InductorCoil2;

			return true;
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
		/// �л��ֶ�/�Զ�ģʽ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void sbtnChangeAutoHandMode_ValueChanged(object sender, EventArgs e)
		{
			this.AutoHandMode = sbtnChangeAutoHandMode.Value;
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

		CmcsBuyFuelTransport currentBuyFuelTransport;
		/// <summary>
		/// ��ǰ�����¼
		/// </summary>
		public CmcsBuyFuelTransport CurrentBuyFuelTransport
		{
			get { return currentBuyFuelTransport; }
			set
			{
				currentBuyFuelTransport = value;

				if (value != null)
				{
					commonDAO.SetSignalDataValue(CommonAppConfig.GetInstance().AppIdentifier, eSignalDataName.��ǰ�����¼Id.ToString(), value.Id);

					txtFuelKindName_BuyFuel.Text = value.FuelKindName;
					txtMineName_BuyFuel.Text = value.MineName;
					txtSupplierName_BuyFuel.Text = value.SupplierName;
					txtTransportCompanyName_BuyFuel.Text = value.TransportCompanyName;

					txtGrossWeight_BuyFuel.Text = value.GrossWeight.ToString("F2");
					txtTicketWeight_BuyFuel.Text = value.TicketWeight.ToString("F2");
					txtTareWeight_BuyFuel.Text = value.TareWeight.ToString("F2");
					txtDeductWeight_BuyFuel.Text = value.DeductWeight.ToString("F2");
					txtSuttleWeight_BuyFuel.Text = value.SuttleWeight.ToString("F2");
				}
				else
				{
					commonDAO.SetSignalDataValue(CommonAppConfig.GetInstance().AppIdentifier, eSignalDataName.��ǰ�����¼Id.ToString(), string.Empty);

					txtFuelKindName_BuyFuel.ResetText();
					txtMineName_BuyFuel.ResetText();
					txtSupplierName_BuyFuel.ResetText();
					txtTransportCompanyName_BuyFuel.ResetText();

					txtGrossWeight_BuyFuel.ResetText();
					txtTicketWeight_BuyFuel.ResetText();
					txtTareWeight_BuyFuel.ResetText();
					txtDeductWeight_BuyFuel.ResetText();
					txtSuttleWeight_BuyFuel.ResetText();
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
			FrmUnFinishTransport_Select frm = new FrmUnFinishTransport_Select("where CarType='" + eCarType.�볧ú.ToString() + "' order by CreationTime desc");
			if (frm.ShowDialog() == DialogResult.OK)
			{

				passCarQueuer.Enqueue(ePassWay.UnKnow, frm.Output.CarNumber, true);

				this.CurrentFlowFlag = eFlowFlag.ʶ����;
			}
		}

		/// <summary>
		/// �����볧ú�����¼
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSaveTransport_BuyFuel_Click(object sender, EventArgs e)
		{
			if (!SaveBuyFuelTransport()) MessageBoxEx.Show("����ʧ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		/// <summary>
		/// ���������¼
		/// </summary>
		/// <returns></returns>
		bool SaveBuyFuelTransport()
		{
			if (this.CurrentBuyFuelTransport == null) return false;

			try
			{
				if (outerDAO.SaveBuyFuelTransport(this.CurrentBuyFuelTransport.Id, DateTime.Now))
				{
					// ��ӡ����
					// TODO

					btnSaveTransport_BuyFuel.Enabled = false;
					this.CurrentFlowFlag = eFlowFlag.�ȴ��뿪;

					UpdateLedShow("�����ɹ�", "���뿪");

					if (!this.AutoHandMode) MessageBoxEx.Show("�����ɹ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
			this.CurrentBuyFuelTransport = null;

			txtTagId_BuyFuel.ResetText();

			btnSaveTransport_BuyFuel.Enabled = false;

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
					case eFlowFlag.��֤��Ϣ:
						#region

						this.CurrentBuyFuelTransport = commonDAO.SelfDber.Entity<CmcsBuyFuelTransport>("where AutotruckId=:AutotruckId order by InFactoryTime desc", new { AutotruckId = this.CurrentAutotruck.Id });
						if (this.CurrentBuyFuelTransport != null)
						{
							if (this.CurrentBuyFuelTransport.StepName != eTruckInFactoryStep.����.ToString())
							{
								//// �ж�·������
								//string nextPlace;
								//if (carTransportDAO.CheckNextTruckInFactoryWay(this.CurrentAutotruck.CarType, this.CurrentBuyFuelTransport.StepName, eTruckInFactoryStep.����.ToString(), CommonAppConfig.GetInstance().AppIdentifier, out nextPlace))
								//{
								if (this.CurrentBuyFuelTransport.SuttleWeight > 0)
								{
									this.CurrentFlowFlag = eFlowFlag.������Ϣ;
								}
								else
								{
									UpdateLedShow(this.CurrentAutotruck.CarNumber, "����δ���");
									this.voiceSpeaker.Speak("���ƺ� " + this.CurrentAutotruck.CarNumber + " ����δ���", 1, false);
									this.CurrentFlowFlag = eFlowFlag.�쳣����;

									timer_BuyFuel.Interval = 8000;
								}
								//}
								//else
								//{
								//	UpdateLedShow("·�ߴ���", "��ֹͨ��");
								//	this.voiceSpeaker.Speak("·�ߴ��� ��ֹͨ�� ", 1, false);
								//	this.CurrentFlowFlag = eFlowFlag.�쳣����;

								//	timer_BuyFuel.Interval = 8000;
								//}
							}
							else
							{
								UpdateLedShow(this.CurrentAutotruck.CarNumber, "���뿪");
								this.voiceSpeaker.Speak(this.CurrentAutotruck.CarNumber + "���뿪", 1, false);
								this.CurrentFlowFlag = eFlowFlag.�ȴ��뿪;

								timer_BuyFuel.Interval = 2000;
							}
						}
						else
						{
							UpdateLedShow(this.CurrentAutotruck.CarNumber, "δ�ҵ������¼");
							this.voiceSpeaker.Speak("���ƺ� " + this.CurrentAutotruck.CarNumber + " δ�ҵ������¼", 1, false);
							this.CurrentFlowFlag = eFlowFlag.�쳣����;

							timer_BuyFuel.Interval = 8000;
						}

						#endregion
						break;

					case eFlowFlag.������Ϣ:
						#region

						if (this.AutoHandMode)
						{
							// �Զ�ģʽ
							if (!SaveBuyFuelTransport())
							{
								UpdateLedShow(this.CurrentAutotruck.CarNumber, "����ʧ��");
								this.voiceSpeaker.Speak("���ƺ� " + this.CurrentAutotruck.CarNumber + " ����ʧ�ܣ�����ϵ����Ա", 1, false);
							}
						}
						else
						{
							btnSaveTransport_BuyFuel.Enabled = true;
							// �ֶ�ģʽ 
						}

						#endregion
						break;

					case eFlowFlag.�ȴ��뿪:
						#region

						ResetBuyFuel();

						// ����������
						timer_BuyFuel.Interval = 1000;

						#endregion
						break;

					case eFlowFlag.�쳣����:

						//��������
						ResetBuyFuel();

						break;
				}
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
			superGridControl1_BuyFuel.PrimaryGrid.DataSource = outerDAO.GetUnFinishBuyFuelTransport();
		}

		/// <summary>
		/// ��ȡָ����������ɵ��볧ú��¼
		/// </summary>
		void LoadTodayFinishBuyFuelTransport()
		{
			superGridControl2_BuyFuel.PrimaryGrid.DataSource = outerDAO.GetFinishedBuyFuelTransport(DateTime.Now.Date, DateTime.Now.Date.AddDays(1));
		}

		/// <summary>
		/// ��ӡ����
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tsmiPrint_BuyFuel_Click(object sender, EventArgs e)
		{
			GridRow gridRow = superGridControl2_BuyFuel.PrimaryGrid.ActiveRow as GridRow;
			if (gridRow == null) return;
			View_BuyFuelTransport entity = gridRow.DataItem as View_BuyFuelTransport;
			CmcsBuyFuelTransport entity2 = Dbers.GetInstance().SelfDber.Get<CmcsBuyFuelTransport>(entity.Id);
			FrmPrintWeb frm = new FrmPrintWeb(entity2);
			frm.ShowDialog();
		}
		#endregion

		#region ��������ҵ��

		bool timer_Goods_Cancel = true;

		CmcsGoodsTransport currentGoodsTransport;
		/// <summary>
		/// ��ǰ�����¼
		/// </summary>
		public CmcsGoodsTransport CurrentGoodsTransport
		{
			get { return currentGoodsTransport; }
			set
			{
				currentGoodsTransport = value;

				if (value != null)
				{
					txtSupplyUnitName_Goods.Text = value.SupplyUnitName;
					txtReceiveUnitName_Goods.Text = value.ReceiveUnitName;
					txtGoodsTypeName_Goods.Text = value.GoodsTypeName;

					txtFirstWeight_Goods.Text = value.FirstWeight.ToString("F2");
					txtSecondWeight_Goods.Text = value.SecondWeight.ToString("F2");
					txtSuttleWeight_Goods.Text = value.SuttleWeight.ToString("F2");
				}
				else
				{
					txtSupplyUnitName_Goods.ResetText();
					txtReceiveUnitName_Goods.ResetText();
					txtGoodsTypeName_Goods.ResetText();

					txtFirstWeight_Goods.ResetText();
					txtSecondWeight_Goods.ResetText();
					txtSuttleWeight_Goods.ResetText();
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
			FrmUnFinishTransport_Select frm = new FrmUnFinishTransport_Select("where CarType='" + eCarType.��������.ToString() + "' order by CreationTime desc");
			if (frm.ShowDialog() == DialogResult.OK)
			{
				passCarQueuer.Enqueue(ePassWay.UnKnow, frm.Output.CarNumber, false);

				this.CurrentFlowFlag = eFlowFlag.ʶ����;
			}
		}

		/// <summary>
		/// ���������¼
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSaveTransport_Goods_Click(object sender, EventArgs e)
		{
			if (!SaveGoodsTransport()) MessageBoxEx.Show("����ʧ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		/// <summary>
		/// ���������¼
		/// </summary>
		/// <returns></returns>
		bool SaveGoodsTransport()
		{
			if (this.CurrentGoodsTransport == null) return false;

			try
			{
				if (outerDAO.SaveGoodsTransport(this.CurrentGoodsTransport.Id, DateTime.Now))
				{
					this.CurrentGoodsTransport = commonDAO.SelfDber.Get<CmcsGoodsTransport>(this.CurrentGoodsTransport.Id);

					btnSaveTransport_Goods.Enabled = false;
					this.CurrentFlowFlag = eFlowFlag.�ȴ��뿪;

					UpdateLedShow("�����ɹ�", "���뿪");
					if (!this.AutoHandMode) MessageBoxEx.Show("�����ɹ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);

					LoadTodayUnFinishGoodsTransport();
					LoadTodayFinishGoodsTransport();

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
		/// ������Ϣ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnReset_Goods_Click(object sender, EventArgs e)
		{
			ResetGoods();
		}

		/// <summary>
		/// ������Ϣ
		/// </summary>
		void ResetGoods()
		{
			this.timer_Goods_Cancel = true;

			this.CurrentFlowFlag = eFlowFlag.�ȴ�����;

			this.CurrentAutotruck = null;
			this.CurrentGoodsTransport = null;

			txtTagId_Goods.ResetText();

			btnSaveTransport_Goods.Enabled = false;

			LetBlocking();
			UpdateLedShow("  �ȴ�����");

			// �������
			this.CurrentImperfectCar = null;
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
					case eFlowFlag.��֤��Ϣ:
						#region

						// ���Ҹó�δ��ɵ������¼
						CmcsUnFinishTransport unFinishTransport = carTransportDAO.GetUnFinishTransportByAutotruckId(this.CurrentAutotruck.Id, eCarType.��������.ToString());
						if (unFinishTransport != null)
						{
							this.CurrentGoodsTransport = commonDAO.SelfDber.Get<CmcsGoodsTransport>(unFinishTransport.TransportId);
							if (this.CurrentGoodsTransport != null)
							{
								//// �ж�·������
								//string nextPlace;
								//if (carTransportDAO.CheckNextTruckInFactoryWay(this.CurrentAutotruck.CarType, this.CurrentBuyFuelTransport.StepName, "����", CommonAppConfig.GetInstance().AppIdentifier, out nextPlace))
								//{
								if (this.CurrentGoodsTransport.SuttleWeight > 0)
								{
									this.CurrentFlowFlag = eFlowFlag.������Ϣ;

									UpdateLedShow(this.CurrentAutotruck.CarNumber, "���뿪");
								}
								else
								{
									UpdateLedShow(this.CurrentAutotruck.CarNumber, "����δ���");
									this.voiceSpeaker.Speak("���ƺ� " + this.CurrentAutotruck.CarNumber + " ����δ���", 1, false);

									timer_Goods.Interval = 20000;
								}
								//}
								//else
								//{
								//	UpdateLedShow("·�ߴ���", "��ֹͨ��");
								//	this.voiceSpeaker.Speak("·�ߴ��� ��ֹͨ�� " + (!string.IsNullOrEmpty(nextPlace) ? "��ǰ��" + nextPlace : ""), 1, false);

								//	timer_Goods.Interval = 20000;
								//}
							}
							else
							{
								commonDAO.SelfDber.Delete<CmcsUnFinishTransport>(unFinishTransport.Id);
							}
						}
						else
						{
							UpdateLedShow(this.CurrentAutotruck.CarNumber, "δ�Ŷ�");
							this.voiceSpeaker.Speak("���ƺ� " + this.CurrentAutotruck.CarNumber + " δ�ҵ��ŶӼ�¼", 1, false);

							timer_Goods.Interval = 20000;
						}

						#endregion
						break;

					case eFlowFlag.������Ϣ:
						#region

						if (this.AutoHandMode)
						{
							// �Զ�ģʽ
							if (!SaveGoodsTransport())
							{
								UpdateLedShow(this.CurrentAutotruck.CarNumber, "����ʧ��");
								this.voiceSpeaker.Speak("���ƺ� " + this.CurrentAutotruck.CarNumber + " ����ʧ�ܣ�����ϵ����Ա", 1, false);
							}
						}
						else
						{
							btnSaveTransport_Goods.Enabled = true;
							// �ֶ�ģʽ 
						}

						#endregion
						break;

					case eFlowFlag.�ȴ��뿪:
						#region

						// ��ǰ��·�ظ����ź�ʱ����
						if (!HasCarOnCurrentWay()) ResetGoods();

						// ����������
						timer_Goods.Interval = 4000;

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
			superGridControl1_Goods.PrimaryGrid.DataSource = outerDAO.GetUnFinishGoodsTransport();
		}

		/// <summary>
		/// ��ȡָ����������ɵ��������ʼ�¼
		/// </summary>
		void LoadTodayFinishGoodsTransport()
		{
			superGridControl2_Goods.PrimaryGrid.DataSource = outerDAO.GetFinishedGoodsTransport(DateTime.Now.Date, DateTime.Now.Date.AddDays(1));
		}

		/// <summary>
		/// ��ӡ����
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tsmiPrint_Goods_Click(object sender, EventArgs e)
		{
			GridRow gridRow = superGridControl2_Goods.PrimaryGrid.ActiveRow as GridRow;
			if (gridRow == null) return;
			CmcsGoodsTransport entity = gridRow.DataItem as CmcsGoodsTransport;
			FrmPrintWeb frm = new FrmPrintWeb(null, entity);
			frm.ShowDialog();
		}
		#endregion

		#region ��������

		Pen redPen3 = new Pen(Color.Red, 3);
		Pen greenPen3 = new Pen(Color.Lime, 3);

		/// <summary>
		/// ��ǰ�Ǳ�����������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panCurrentWeight_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				PanelEx panel = sender as PanelEx;

				// ���Ƶظ�1
				e.Graphics.DrawLine(this.InductorCoil1 ? redPen3 : greenPen3, 15, 10, 15, panel.Height - 10);
				// ���Ƶظ�2                                                               
				e.Graphics.DrawLine(this.InductorCoil2 ? redPen3 : greenPen3, 25, 10, 25, panel.Height - 10);
			}
			catch (Exception ex)
			{
				Log4Neter.Error("panCurrentCarNumber_Paint�쳣", ex);
			}
		}

		private void superGridControl_BeginEdit(object sender, DevComponents.DotNetBar.SuperGrid.GridEditEventArgs e)
		{
			// ȡ������༭
			e.Cancel = true;
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