using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.IO.Ports;
using System.Threading;

namespace IOC.JMDM20DIOV2
{
	/// <summary>
	/// 精敏IO控制器 JMDM20DIOV2
	/// </summary>
	public class JMDM20DIOV2Iocer
	{
		public JMDM20DIOV2Iocer()
		{
			timer1 = new System.Timers.Timer(3000)
			{
				AutoReset = true
			};
			timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);

			timer2 = new System.Timers.Timer(200)
			{
				AutoReset = true,
			};
			timer2.Elapsed += new System.Timers.ElapsedEventHandler(timer2_Elapsed);
		}

		private SerialPort serialPort = new SerialPort();
		private System.Timers.Timer timer1;
		private System.Timers.Timer timer2;

		public delegate void ReceivedEventHandler(int[] receiveValue);
		public event ReceivedEventHandler OnReceived;
		public delegate void StatusChangeHandler(bool status);
		public event StatusChangeHandler OnStatusChange;

		private bool status = false;
		/// <summary>
		/// 连接状态
		/// </summary>
		public bool Status
		{
			get { return status; }
		}

		/// <summary>
		/// 设置连接状态
		/// </summary>
		/// <param name="status"></param>
		public void SetStatus(bool status)
		{
			if (this.status != status && this.OnStatusChange != null) this.OnStatusChange(status);
			this.status = status;
		}

		/// <summary>
		/// 接收数据次数
		/// </summary>
		private int IOStateCount = 0;

		/// <summary>
		/// 接收到的数据
		/// </summary>
		public int[] ReceiveValue = new int[20];

		/// <summary>
		/// 临时数据
		/// </summary>
		private List<byte> ReceiveList = new List<byte>();

		/// <summary>
		/// 打开串口
		/// 成功返回True;失败返回False;
		/// </summary>
		/// <param name="com">串口号</param>
		/// <param name="bandrate">波特率</param>
		/// <param name="dataBits">数据位</param>
		/// <param name="stopBits">停止位</param>
		/// <param name="parity">奇偶校验位</param>
		/// <returns></returns>
		public bool OpenCom(int com, int bandrate, int dataBits = 8, StopBits stopBits = StopBits.One, Parity parity = Parity.None)
		{
			try
			{
				if (!serialPort.IsOpen)
				{
					serialPort.PortName = "COM" + com.ToString();
					serialPort.BaudRate = bandrate;
					serialPort.DataBits = dataBits;
					serialPort.StopBits = stopBits;
					serialPort.Parity = parity;
					serialPort.ReceivedBytesThreshold = 1;
					serialPort.RtsEnable = true;
					serialPort.Open();
					serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);

					timer1.Enabled = true;
					timer2.Enabled = true;

					SetStatus(true);
				}
			}
			catch (Exception)
			{
				this.status = false;
				if (this.OnStatusChange != null) this.OnStatusChange(status);
			}

			return this.status;
		}

		/// <summary>
		/// 关闭串口
		/// 成功返回True;失败返回False;
		/// </summary>
		/// <returns></returns>
		public void CloseCom()
		{
			try
			{
				timer1.Enabled = false;
				timer2.Enabled = false;

				serialPort.DataReceived -= new SerialDataReceivedEventHandler(serialPort_DataReceived);
				//serialPort.Close();
				serialPort.Dispose();
				SetStatus(false);
			}
			catch { }
		}

		/// <summary>
		/// 串口接收数据
		/// 数据示例：49 28 49 2C 30 30 30 30 30 30 31 30 31 30 30 30 30 29
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			this.IOStateCount++;

			if (serialPort.IsOpen)
			{
				int bytesToRead = serialPort.BytesToRead;
				byte[] buffer = new byte[bytesToRead];
				serialPort.Read(buffer, 0, bytesToRead);

				//byte[] buffer = new byte[bytesToRead];
				//for (int i = 0; i < buffer10.Length; i++)
				//{
				//	buffer[i] = Convert.ToByte(buffer10[i].ToString("x8"));
				//}

				try
				{
					for (int i = 0; i < bytesToRead; i++)
					{
						if (buffer[i] == 0x28) ReceiveList.Clear();

						this.ReceiveList.Add(buffer[i]);

						if (buffer[i] == 0x29 && ReceiveList.Count == 17)
						{
							for (int j = 4; j < 15; j++)
							{
								int temp = Convert.ToInt32(Convert.ToChar(ReceiveList[j]).ToString());

								this.ReceiveValue[j - 4] = temp;
							}

							if (OnReceived != null) OnReceived(this.ReceiveValue);

							ReceiveList.Clear();
						}
					}
				}
				catch (Exception ex)
				{ ReceiveList.Clear(); }
				finally { }
			}
		}

		/// <summary>
		/// 输入
		/// </summary>
		/// <param name="pnum">通道号</param>
		/// <param name="type"></param>
		public void Output(int pnum, bool type)
		{
			if (serialPort.IsOpen)
			{
				byte[] buffer = new byte[8];
				buffer[0] = 0x4f;
				buffer[1] = 0x28;
				buffer[2] = 0x30;
				buffer[3] = 0x30;
				buffer[4] = Convert.ToByte((int)(0x30 + pnum));
				buffer[5] = 0x2c;

				if (type)
					buffer[6] = 0x31;
				else
					buffer[6] = 0x30;

				buffer[7] = 0x29;
				serialPort.Write(buffer, 0, 8);

			}
		}

		/// <summary>
		/// 间隔事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			if (IOStateCount > 0)
				SetStatus(true);
			else
				SetStatus(false);

			IOStateCount = 0;
		}

		/// <summary>
		/// 发送取数指令
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void timer2_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			if (serialPort.IsOpen) serialPort.Write("O(100,1)");
		}
	}
}
