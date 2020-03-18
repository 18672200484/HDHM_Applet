using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace BeltBalancer.SM6000
{
    /// <summary>
    /// 斗轮机皮带秤取数类  仪表型号：赛摩SM6000A
    /// </summary>
    public class SM6000ABber
    {
        /// <summary>
        /// SM6000ABber
        /// </summary>
        public SM6000ABber(byte[] cmd, int interval = 1000)
        {
            timer1 = new System.Timers.Timer(interval)
            {
                AutoReset = true
            };
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);

            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);

            this.Cmd = cmd;
        }

        private SerialPort port = new SerialPort();
        private System.Timers.Timer timer1;

        public delegate void DataReceivedEventHandler(float total, float instant, float speed);
        public event DataReceivedEventHandler OnDataReceived;

        public delegate void ReceiveErrorEventHandler(Exception ex);
        public event ReceiveErrorEventHandler OnReceiveError;

        /// <summary>
        /// 命令报文1
        /// </summary>
        private byte[] Cmd = new byte[] { 0x01, 0x03, 0x90, 0x00, 0x00, 0x03, 0x28, 0xCB };

        private float Total = new float();
        private float Instant = new float();
        private float Speed = new float();

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

                    return true;
                }
            }
            catch (Exception ex)
            {
                if (this.OnReceiveError != null) this.OnReceiveError(ex);
            }

            return false;
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

                if (!port.IsOpen) return;
                port.DataReceived -= new SerialDataReceivedEventHandler(port_DataReceived);
                port.Close();
            }
            catch { }
        }

        /// <summary>
        /// 串口接收数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!port.IsOpen) return;

            try
            {
                int bytesToRead = port.BytesToRead;
                byte[] buffer = new byte[bytesToRead];
                port.Read(buffer, 0, bytesToRead);

                for (int i = 0; i < bytesToRead; i++)
                {
                    if ((this.ReceiveList.Count >= 3 && (this.ReceiveList[1] != 0x03 || this.ReceiveList[2] != 0x0C)) || ReceiveList.Count >= 500) ReceiveList.Clear();

                    ReceiveList.Add(buffer[i]);

                    if (ReceiveList.Count == 17 && ReceiveList[1] == 0x03 && ReceiveList[2] == 0x0C)
                    {
                        byte[] tempBytes = this.ReceiveList.ToArray();

                        try
                        {
                            this.Total = BitConverter.ToSingle(tempBytes, 3);
                            this.Instant = BitConverter.ToSingle(tempBytes, 7);
                            this.Speed = BitConverter.ToSingle(tempBytes, 11);
                        }
                        catch { }

                        ReceiveList.Clear();

                        if (this.OnDataReceived != null) this.OnDataReceived(this.Total, this.Instant, this.Speed);
                    }
                }
            }
            catch (Exception ex)
            {
                ReceiveList.Clear();
                if (this.OnReceiveError != null) this.OnReceiveError(ex);
            }
        }

        /// <summary>
        /// 间隔事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!port.IsOpen) return;

            timer1.Stop();

            port.Write(this.Cmd, 0, this.Cmd.Length);

            timer1.Start();
        }
    }
}
