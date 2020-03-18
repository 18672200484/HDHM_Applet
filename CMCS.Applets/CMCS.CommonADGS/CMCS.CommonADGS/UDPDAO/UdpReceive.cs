using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace CMCS.CommonADGS.UDPDAO
{
    public class UdpReceive : IDisposable
    {
        Queue<byte[]> receiveBytes = new Queue<byte[]>();
        UdpClient udpClient;
        IPEndPoint remoteIP;
        bool finish = true;
        Thread th;

        #region Event

        public event ReceiveDataHandle ReceiveData;
        public delegate void ReceiveDataHandle(object data);

        public delegate void OutputInfoEventHandler(string info);
        public event OutputInfoEventHandler OutputInfo;

        public delegate void OutputErrorEventHandler(string describe, Exception ex);
        public event OutputErrorEventHandler OutputError;

        #endregion

        /// <summary>
        /// 开始监听
        /// </summary>
        /// <param name="remoteIP"></param>
        public void Start(IPEndPoint remoteIP)
        {
            IPList = new Queue<IPEndPoint>();
            this.remoteIP = remoteIP;
            udpClient = new UdpClient(remoteIP.Port);
            OutputInfo("监听成功，等待收信息");
            th = new Thread(StartReceive);
            th.Start();
            StartData();
        }

        /// <summary>
        /// 接收到的IP列表
        /// </summary>
        public Queue<IPEndPoint> IPList { get; set; }

        /// <summary>
        /// 开始接收
        /// </summary>
        private void StartReceive()
        {
            udpClient.BeginReceive((IAsyncResult result) =>
            {
                byte[] buffer = null;
                if (udpClient == null) return;
                try
                {
                    buffer = udpClient.EndReceive(result, ref remoteIP);
                    lock (IPList)
                    {
                        IPList.Enqueue(remoteIP);
                    }

                    lock (receiveBytes)
                    {
                        receiveBytes.Enqueue(buffer);
                    }
                }
                catch (SocketException ex)
                {
                    OutputError("接收消息", ex);
                }
                finally
                {
                    if (udpClient != null)
                        StartReceive();
                }
            }, null);
        }

        private void StartData()
        {
            new Thread(() =>
            {
                while (finish)
                {
                    try
                    {
                        byte[] currentByte = null;
                        lock (receiveBytes)
                        {
                            if (receiveBytes.Count != 0)
                            {
                                currentByte = receiveBytes.Dequeue();
                            }
                        }

                        if (currentByte != null)
                        {
                            object data = SerializeObject.Deserialize(currentByte);
                            if (ReceiveData != null)
                            {
                                ReceiveData.BeginInvoke(data, null, null);
                            }
                        }
                    }
                    catch
                    {
                    }
                    finally
                    {
                        Thread.Sleep(10);
                    }
                }

            }).Start();
        }

        /// <summary>
        /// 释放连接
        /// </summary>
        public void Dispose()
        {
            th.Abort();
            th = null;
            finish = false;
            udpClient.Close();
            udpClient = null;
        }

    }
}
