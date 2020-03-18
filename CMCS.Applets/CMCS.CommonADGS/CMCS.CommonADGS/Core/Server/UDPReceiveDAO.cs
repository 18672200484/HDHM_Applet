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
    /// UPD接收数据
    /// </summary>
    public class UDPReceiveDAO
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

        private string savePath;
        /// <summary>
        /// 保存路径
        /// </summary>
        string SavePath
        {
            get { return savePath; }
            set { savePath = value; }
        }

        private int port;
        /// <summary>
        /// 端口
        /// </summary>
        int Port
        {
            get { return port; }
            set { port = value; }
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
        /// 客户端
        /// </summary>
        IPEndPoint clientIP;

        private bool isListener = false;
        /// <summary>
        /// 监听状态 true 正在监听中 false 监听已断开
        /// </summary>
        public bool IsListener
        {
            get { return isListener; }
            set { isListener = value; }
        }

        List<byte> ReceiveStream = new List<byte>();
        #endregion

        #region Var接收文件

        /// <summary>
        /// MD5验证
        /// </summary>
        private string md5Value = "";

        /// <summary>
        /// 文件名
        /// </summary>
        private string fileName = "";

        /// <summary>
        /// 本次发送的文件大小
        /// </summary>
        private int partSize = 0;

        /// <summary>
        /// 接收次数
        /// </summary>
        private int index = 0;

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

        public UDPReceiveDAO(string facilityNumber, int port, string savePath)
        {
            Port = port;
            FacilityNumber = facilityNumber;
            SavePath = savePath;
            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);
        }

        public void StartReceive()
        {
            listener = new UdpClient(port);
            OutputInfo(string.Format("{0}初始化成功", this.FacilityNumber));

            clientIP = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                try
                {
                    byte[] receiveByte = listener.Receive(ref clientIP);
                    if (receiveByte != null && receiveByte.Length > 0)
                    {
                        object data = SerializeObject.Deserialize(receiveByte);
                        ReceiveData(data);
                    }
                }
                catch { }
            }
        }

        private void Receive()
        {
            listener.BeginReceive((IAsyncResult result) =>
            {
                byte[] buffer = null;

                try
                {
                    buffer = listener.EndReceive(result, ref clientIP);
                    object data = SerializeObject.Deserialize(buffer);
                    ReceiveData(data);
                }
                catch (SocketException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    if (listener != null)
                        Receive();
                }
            }, null);
        }

        /// <summary>
        /// 解析数据
        /// </summary>
        /// <param name="data"></param>
        public void ReceiveData(object data)
        {
            try
            {
                if (data is MessageType)//消息
                {
                    MessageType messageType = data as MessageType;

                    switch (messageType.Mtype)
                    {
                        case MType.Send://开始发送数据
                            index = 0;
                            indexList.Clear();
                            string[] message = messageType.Message.Split('|');
                            md5Value = message[0];
                            pageCount = Convert.ToInt64(message[1]);
                            partSize = Convert.ToInt32(message[2]);
                            fileName = message[3];
                            fileName = Path.Combine(SavePath, fileName);
                           
                            fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
                            //fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, partSize * 10, true);
                            OutputInfo(this.FacilityNumber + "开始接收文件");
                            break;
                        case MType.Finish:
                            //if (pageCount == indexList.Count)
                            //{

                            fileStream.Position = 0;
                            fileStream.Write(ReceiveStream.ToArray(), 0, ReceiveStream.Count);
                            ReceiveStream.Clear();
                            fileStream.Close();
                            fileStream.Dispose();
                            OutputInfo(this.FacilityNumber + "文件接收完成");
                            //if (string.Equals(MD5Helper.CretaeMD5(fileName), md5Value))
                            //{
                            //    OutputInfo("文件正确");
                            //}
                            //else
                            //{
                            //    OutputInfo("文件错误");
                            //}
                            //}
                            break;
                        default:
                            break;
                    }
                }
                else//文件流
                {
                    TraFransfersFile traFransfersFile = data as TraFransfersFile;
                    ReceiveStream.AddRange(traFransfersFile.Buffer);

                    //TraFransfersFile traFransfersFile = data as TraFransfersFile;
                    //fileStream.Position = traFransfersFile.Index * partSize;
                    //fileStream.Write(traFransfersFile.Buffer, 0, partSize);

                    //if (!indexList.Contains(traFransfersFile.Index))
                    //{
                    //    indexList.Add(traFransfersFile.Index);
                    //}

                    //fileStream.BeginWrite(traFransfersFile.Buffer, 0, traFransfersFile.Buffer.Length, (IAsyncResult result) =>
                    //{
                    //    fileStream.EndWrite(result);
                    //    if (!indexList.Contains(traFransfersFile.Index))
                    //    {
                    //        indexList.Add(traFransfersFile.Index);
                    //    }
                    //}, traFransfersFile.Index);
                }
            }
            catch (Exception ex)
            {
                OutputError(this.FacilityNumber + "解析数据", ex);
            }
        }

    }
}
