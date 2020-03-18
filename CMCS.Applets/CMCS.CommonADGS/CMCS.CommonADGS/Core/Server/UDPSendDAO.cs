using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net.Sockets;
using System.Threading;
using System.Timers;
using System.IO;
using System.Net;
using CMCS.CommonADGS.UDPDAO;

namespace CMCS.CommonADGS.Core
{
    /// <summary>
    /// UPD发送数据
    /// </summary>
    public class UDPSendDAO
    {
        #region Vars
        private string facilityNumber;
        /// <summary>
        /// 标识
        /// </summary>
        string FacilityNumber
        {
            get { return facilityNumber; }
            set { facilityNumber = value; }
        }

        private IPEndPoint serverPoint;
        /// <summary>
        /// 服务器终端
        /// </summary>
        IPEndPoint ServerPoint
        {
            get { return serverPoint; }
            set { serverPoint = value; }
        }

        private string fileFullName;
        /// <summary>
        /// 文件名
        /// </summary>
        string FileFullName
        {
            get { return fileFullName; }
            set { fileFullName = value; }
        }

        /// <summary>
        /// 监听定时器
        /// </summary>
        System.Timers.Timer timer1 = new System.Timers.Timer();

        private UdpClient listener = null;
        /// <summary>
        /// 当前连接
        /// </summary>
        public UdpClient Listener
        {
            get { return listener; }
        }

        /// <summary>
        /// 等待进程
        /// </summary>
        private ManualResetEvent allDone = new ManualResetEvent(false);

        private bool isListener = false;
        /// <summary>
        /// 监听状态 true 正在监听中 false 监听已断开
        /// </summary>
        public bool IsListener
        {
            get { return isListener; }
            set { isListener = value; }
        }
        #endregion

        #region Var发送文件

        /// <summary>
        /// MD5验证
        /// </summary>
        private string md5Value = "";

        /// <summary>
        /// 本次发送的文件大小
        /// </summary>
        private int partSize = 1024 * 10;

        /// <summary>
        /// 发送次数
        /// </summary>
        private int sendIndex = 0;

        /// <summary>
        /// 文件流对象
        /// </summary>
        private FileStream fileStream;

        /// <summary>
        /// 需要发送的总次数
        /// </summary>
        private long pageCount = 0;

        /// <summary>
        /// 接收文件次数索引集合
        /// </summary>
        private List<int> indexList = new List<int>();
        #endregion

        #region Event

        public delegate void OutputInfoEventHandler(string info);
        public event OutputInfoEventHandler OutputInfo;

        public delegate void OutputErrorEventHandler(string describe, Exception ex);
        public event OutputErrorEventHandler OutputError;

        #endregion

        public UDPSendDAO(string facilityNumber, string ip, int port, string fileFullName, double interval)
        {
            FacilityNumber = facilityNumber;
            FileFullName = fileFullName;
            IPAddress ipAddress = IPAddress.Parse(ip);
            ServerPoint = new IPEndPoint(ipAddress, port);
            timer1.Elapsed += new ElapsedEventHandler(timer1_Elapsed);
            timer1.Interval = interval;
        }

        public void StartSend()
        {
            md5Value = MD5Helper.CretaeMD5(FileFullName);

            timer1_Elapsed(null, null);
        }

        protected void timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer1.Stop();
            try
            {
                OutputInfo(this.FacilityNumber + "开始发送数据");
                //发送文件信息
                fileStream = new FileStream(FileFullName, FileMode.Open, FileAccess.Read, FileShare.Read, partSize * 10, true);
                int length = Convert.ToInt32(fileStream.Length);
                pageCount = fileStream.Length / partSize;
                pageCount = fileStream.Length % partSize != 0 ? ++pageCount : pageCount;
                OutputInfo(this.FacilityNumber + "分包数目:" + pageCount);
                MessageType messageType = new MessageType() { Mtype = MType.Send, Message = md5Value + "|" + pageCount + "|" + partSize + "|" + Path.GetFileName(FileFullName) };
                UdpSend.SendMessage(messageType, ServerPoint);
                //发送文件内容
                while (sendIndex < pageCount)
                {
                    //int index = Interlocked.Increment(ref sendIndex);

                    //Read(index - 1);
                    byte[] buffer = new byte[partSize];
                    int content = 0;
                    fileStream.Position = sendIndex * partSize;

                    if ((fileStream.Length - sendIndex * partSize) < partSize)
                        content = fileStream.Read(buffer, 0, (length - sendIndex * partSize));
                    else
                        content = fileStream.Read(buffer, 0, partSize);

                    TraFransfersFile traFransfersFile = new TraFransfersFile(sendIndex, buffer);
                    UdpSend.SendMessage(traFransfersFile, ServerPoint);
                    sendIndex++;
                    Thread.Sleep(1);
                }
                if (sendIndex == pageCount)
                    messageType = new MessageType() { Mtype = MType.Finish };
                UdpSend.SendMessage(messageType, ServerPoint);
                OutputInfo(this.FacilityNumber + "发送完成");
            }
            catch (Exception ex)
            {
                OutputError("发送数据", ex);
            }
            finally
            {
                timer1.Start();
            }
        }

        /// <summary>
        /// 分流发送文件数据
        /// </summary>
        /// <param name="index"></param>
        private void Read(int index)
        {
            byte[] buffer = new byte[partSize];
            ReadFileObject readFileObject = new ReadFileObject(index, buffer);
            fileStream.Position = index * partSize;

            fileStream.BeginRead(buffer, 0, partSize, (IAsyncResult result) =>
            {
                int length = fileStream.EndRead(result);
                byte[] realBuffer;
                if (length < partSize)
                {
                    realBuffer = new byte[length];
                    Buffer.BlockCopy(buffer, 0, realBuffer, 0, length);
                }
                else
                {
                    realBuffer = buffer;
                }

                TraFransfersFile traFransfersFile = new TraFransfersFile(index, realBuffer);
                UdpSend.SendMessage(traFransfersFile, ServerPoint);

            }, readFileObject);
        }
    }
}
