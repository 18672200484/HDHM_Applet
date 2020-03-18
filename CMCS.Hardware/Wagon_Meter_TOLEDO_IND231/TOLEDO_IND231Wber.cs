using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.IO.Ports;
using System.Threading;

namespace WB.TOLEDO.IND231
{
    /// <summary>
    /// 地磅 For 托利多
    /// 型号：IND231(60KG)
    /// 
    /// </summary>
    public class TOLEDO_IND231Wber
    {
        /// <summary>
        /// IND231(60KG)
        /// </summary>
        /// <param name="steadySecond">稳定时长 单位：秒</param>
        public TOLEDO_IND231Wber(int steadySecond)
        {
            this.SteadySecond = steadySecond;

            timer1 = new System.Timers.Timer(1000)
            {
                AutoReset = true
            };
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);
        }
        private SerialPort port = new SerialPort();
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
        public bool OpenCom(int com, int bandrate, int dataBits, int parity)
        {
            try
            {
                if (!port.IsOpen)
                {
                    port.PortName = "COM" + com.ToString();
                    port.BaudRate = bandrate;
                    port.DataBits = 7;
                    port.StopBits = StopBits.One;
                    port.Parity = (Parity)parity;
                    port.ReceivedBytesThreshold = 1;
                    port.RtsEnable = true;
                    port.Open();
                    port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);

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

                port.DataReceived -= new SerialDataReceivedEventHandler(port_DataReceived);
                port.Close();

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
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            ReceiveCount++;

            if (port.IsOpen)
            {
                int bytesToRead = port.BytesToRead;
                byte[] buffer = new byte[bytesToRead];
                port.Read(buffer, 0, bytesToRead);

                for (int i = 0; i < bytesToRead; i++)
                {
                    if (buffer[i] == 0x02)
                        ReceiveList.Clear();

                    ReceiveList.Add(buffer[i]);

                    if (buffer[i] == 0x0D && ReceiveList.Count == 17)
                    {
                        try
                        {
                            string temp = string.Empty;
                            for (int j = 4; j < 14; j++)
                            {
                                temp += Convert.ToChar(ReceiveList[j].ToString("X").Substring(1, 1));
                            }

                            if (ReceiveList[1] == 0x3D)
                            {//15Kg Kg g 
                                if (ReceiveList[2] == 0x32)
                                    this.weight = Math.Round(Convert.ToDouble(temp) / -10000d / 10d, 2);
                                else
                                    this.weight = Math.Round(Convert.ToDouble(temp) / 10000d / 10d, 2);
                            }
                            else if (ReceiveList[1] == 0x3A)
                            {//15Kg 5g 
                                if (ReceiveList[2] == 0x22)
                                    this.weight = Math.Round(Convert.ToDouble(temp) / -10000d, 2);
                                else
                                    this.weight = Math.Round(Convert.ToDouble(temp) / 10000d, 2);
                            }
                            else if (ReceiveList[1] == 0x3B)
                            {//15Kg 0.5g 
                                if (ReceiveList[2] == 0x22)
                                    this.weight = Math.Round(Convert.ToDouble(temp) / -10000d / 10d, 2);
                                else
                                    this.weight = Math.Round(Convert.ToDouble(temp) / 10000d / 10d, 2);
                            }
                            else
                            {//60Kg Kg ReceiveList[1]== 34
                                if (ReceiveList[2] == 0x32)
                                    this.weight = Math.Round(Convert.ToDouble(temp) / -10000d / 100d, 2);
                                else
                                    this.weight = Math.Round(Convert.ToDouble(temp) / 10000d / 100d, 2);
                            }

                            if (OnWeightChange != null) OnWeightChange(this.weight);
                        }
                        catch (Exception)
                        {

                        }

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
