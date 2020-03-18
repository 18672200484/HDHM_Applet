using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace WB.TOLEDO.IND245
{
    /// <summary>
    /// 托利多 IND245仪表
    /// </summary>
    public class TOLEDO_IND245Wber
    {
        /// <summary>
        /// TOLEDO_IND245Wber
        /// </summary>
        /// <param name="steadySecond">稳定时长 单位：秒</param>
        public TOLEDO_IND245Wber(int steadySecond)
        {
            this.SteadySecond = steadySecond;

            timer1 = new System.Timers.Timer(2000)
            {
                AutoReset = true
            };
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);
        }

        private SerialPort serialPort = new SerialPort();
        private System.Timers.Timer timer1;

        public delegate void SteadyChangeEventHandler(bool steady);
        public event SteadyChangeEventHandler OnSteadyChange;
        public delegate void StatusChangeHandler(bool status);
        public event StatusChangeHandler OnStatusChange;
        public delegate void WeightChangeEventHandler(double weight);
        public event WeightChangeEventHandler OnWeightChange;

        private bool status = false;
        /// <summary>
        /// 连接状态
        /// </summary>
        public bool Status
        {
            get { return status; }
        }

        private double weight;
        /// <summary>
        /// 重量
        /// </summary>
        public double Weight
        {
            get { return weight; }
        }

        private bool steady;
        /// <summary>
        /// 重量稳定
        /// </summary>
        public bool Steady
        {
            get { return steady; }
        }

        /// <summary>
        /// 数据接收次数
        /// </summary>
        private int ReceiveCount = 0;

        /// <summary>
        /// 稳定时长（单位：秒）
        /// </summary>
        private int SteadySecond = 3;

        /// <summary>
        /// 当前稳定时长（单位：秒）
        /// </summary>
        private int CurrentSteadySecond = 0;

        /// <summary>
        /// 上一次重量
        /// </summary>
        private double LastWeight = 0;

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
        /// <param name="parity">校验</param>
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

                    SetStatus(true);

                    this.Closing = false;
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
                this.Closing = true;

                timer1.Enabled = false;

                serialPort.DataReceived -= new SerialDataReceivedEventHandler(serialPort_DataReceived);
                serialPort.Close();

                SetStatus(false);
            }
            catch { }
        }

        bool Closing = false;

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
        /// 设置稳定状态
        /// </summary>
        /// <param name="steady"></param>
        public void SetSteady(bool steady)
        {
            if (this.steady != steady && this.OnSteadyChange != null)
            {

                this.OnSteadyChange(steady);

            }
            this.steady = steady;
        }

        /// <summary>
        /// 串口接收数据
        /// 数据示例：02 31 30 20 20 20 20 32 30 30 20 20 20 20 30 30 0D 1E 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (this.Closing) return;

            this.ReceiveCount++;

            if (serialPort.IsOpen)
            {
                int bytesToRead = serialPort.BytesToRead;
                byte[] buffer = new byte[bytesToRead];
                serialPort.Read(buffer, 0, bytesToRead);

                for (int i = 0; i < bytesToRead; i++)
                {
                    if (buffer[i] == 0x02) ReceiveList.Clear();

                    ReceiveList.Add(buffer[i]);

                    try
                    {
                        if (buffer[i] == 0x0D && ReceiveList.Count == 17)
                        {
                            string temp = string.Empty;
                            for (int j = 3; j < 14; j++)
                            {
                                temp += Convert.ToChar(ReceiveList[j]);
                            }

                            //if (ReceiveList[1] == 0x39)
                            //    this.weight = Convert.ToDouble(temp) / -1000d;
                            //else
                            this.weight = Convert.ToDouble(temp) / 1000d;

                            if (OnWeightChange != null) OnWeightChange(this.weight);

                            ReceiveList.Clear();
                        }
                    }
                    catch { }
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
            #region 判断稳定状态

            if (this.weight == this.LastWeight)
                this.CurrentSteadySecond++;
            else
                this.CurrentSteadySecond = 0;

            this.LastWeight = this.weight;

            if (this.CurrentSteadySecond >= SteadySecond)
                SetSteady(true);
            else
                SetSteady(false);

            #endregion

            #region 判断连接状态

            if (this.ReceiveCount > 0)
                SetStatus(true);
            else
                SetStatus(false);

            ReceiveCount = 0;

            #endregion
        }
    }
}
