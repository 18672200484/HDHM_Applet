using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace SPCL.ZHLF51
{
    /// <summary>
    /// 地磅防作弊设备 中凌电子 ZHL-F51
    /// </summary>
    public class ZHLF51Spcler
    {
        public ZHLF51Spcler()
        {
            timer1 = new System.Timers.Timer(15000)
            {
                AutoReset = true
            };
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);

            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
        }

        private SerialPort port = new SerialPort();
        private System.Timers.Timer timer1;

        public delegate void ReceivedEventHandler(bool isAlarm);
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

        private bool alarmState = false;
        /// <summary>
        /// 报警状态
        /// </summary>
        public bool AlarmState
        {
            get { return alarmState; }
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
        private int ReceivedCount = 0;

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
        /// <returns></returns>
        public bool OpenCom(int com, int bandrate, int dataBits, StopBits stopBits, Parity parity)
        {
            try
            {
                if (!port.IsOpen)
                {
                    port.PortName = "COM" + com.ToString();
                    port.BaudRate = bandrate;
                    port.DataBits = dataBits;
                    port.StopBits = stopBits;
                    port.Parity = parity;
                    port.ReceivedBytesThreshold = 1;
                    port.RtsEnable = true;
                    port.Open();

                    timer1.Enabled = true;

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
                timer1.Elapsed -= new System.Timers.ElapsedEventHandler(timer1_Elapsed);

                Thread.Sleep(20);

                port.Close();

                SetStatus(false);
            }
            catch { }
        }

        /// <summary>
        /// 串口接收数据
        /// 正常：09 30 00 FA 00 00 00 00 00 00 00 00 00 00 00 0D
        /// 报警：09 30 D4 FC 0C 35 57 42 10 17 05 03 14 15 15 0D
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.ReceivedCount++;

            if (port.IsOpen)
            {
                int bytesToRead = port.BytesToRead;
                byte[] buffer = new byte[bytesToRead];
                port.Read(buffer, 0, bytesToRead);

                for (int i = 0; i < bytesToRead; i++)
                {
                    if (buffer[i] == 0x09) ReceiveList.Clear();

                    ReceiveList.Add(buffer[i]);

                    if (buffer[i] == 0x0D && ReceiveList.Count == 16)
                    {
                        if (ReceiveList[2] == 0x00)
                            this.alarmState = false;
                        else
                            this.alarmState = true;

                        if (this.OnReceived != null) this.OnReceived(this.alarmState);

                        ReceiveList.Clear();
                    }
                }
            }
        }

        /// <summary>
        /// 间隔事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (ReceivedCount > 0)
                SetStatus(true);
            else
                SetStatus(false);

            ReceivedCount = 0;
        }
    }
}
