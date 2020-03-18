using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Common.Entities;
using CMCS.Common.Entities.TrainInFactory;
using CMCS.DumblyConcealer.Enums;

namespace CMCS.DumblyConcealer.Tasks.TrainDiscriminator
{
    /// <summary>
    /// 火车车号识别-TCP/IP协议
    /// </summary>
    public class TrainDiscriminatorTCPIP
    {
        private static TrainDiscriminatorTCPIP instance;

        public static TrainDiscriminatorTCPIP GetInstance()
        {
            if (instance == null)
            {
                instance = new TrainDiscriminatorTCPIP();
            }
            return instance;
        }

        private class StateObject
        {
            public Socket workSocket = null;
            public const int BufferSize = 1024;
            public byte[] buffer = new byte[BufferSize];
            public StringBuilder sb = new StringBuilder();
        }
        private class Socketoutput
        {
            public StateObject stateobject;
            public Socket socket;
            public Action<string, eOutputType> Output;
            public String interfacetype_chsb = GlobalVars.MachineCode_HCRCCHSB;
        }
        private ManualResetEvent allDone = new ManualResetEvent(false);

        public Socket CreateListening(Action<string, eOutputType> output)
        {
            IPAddress ipAddress = IPAddress.Parse(CommonDAO.GetInstance().GetAppletConfigString("车号识别IP"));
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, CommonDAO.GetInstance().GetAppletConfigInt32("车号识别端口号"));
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);
            listener.Listen(10);
            return listener;
        }
        public void StartListening(Socket listener, Action<string, eOutputType> output)
        {
            while (true)
            {
                allDone.Reset();
                Socketoutput socketoutput = new Socketoutput();
                socketoutput.socket = listener;
                socketoutput.Output = output;
                listener.BeginAccept(new AsyncCallback(AcceptCallback), socketoutput);
                allDone.WaitOne();
            }
        }
        private void AcceptCallback(IAsyncResult ar)
        {
            allDone.Set();
            Socketoutput socketoutput = (Socketoutput)ar.AsyncState;
            Socket listener = (Socket)socketoutput.socket;
            try
            {
                Socket handler = listener.EndAccept(ar);
                StateObject state = new StateObject();
                state.workSocket = handler;
                socketoutput.stateobject = state;
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), socketoutput);
            }
            catch (Exception ex)
            {
                socketoutput.Output(string.Format("AcceptCallback,原因:{0}", ex.ToString()), eOutputType.Error);
            }
        }
        private void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;
            Socketoutput socketoutput = (Socketoutput)ar.AsyncState;
            StateObject state = (StateObject)socketoutput.stateobject;
            try
            {
                Socket handler = state.workSocket;
                int bytesRead = handler.EndReceive(ar);
                if (bytesRead > 0)
                {
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                    content = state.sb.ToString();
                    PrintRecvMssg(content, socketoutput.interfacetype_chsb, socketoutput.Output);
                }
            }
            catch (Exception ex)
            {
                socketoutput.Output(string.Format("ReadCallback,原因:{0}", ex.ToString()), eOutputType.Error);
            }
        }

        private void PrintRecvMssg(string str, String machinecode, Action<string, eOutputType> output)
        {
            int res = 0;
            try
            {
                if (str.Length >= 67)
                {
                    string no = str.Substring(5, 2);
                    if (no == "03")
                    {
                        CmcsTrainCarriagePass item = Dbers.GetInstance().SelfDber.Entity<CmcsTrainCarriagePass>("where TrainNumber=:TrainNumber and PassTime=:PassTime", new { TrainNumber = str.Substring(24, 7).Trim(), PassTime = Convert.ToDateTime(str.Substring(str.Length - 30, 19)) });
                        if (item == null)
                        {
                            res += Dbers.GetInstance().SelfDber.Insert<CmcsTrainCarriagePass>(
                            new CmcsTrainCarriagePass
                            {
                                OrderNum = Convert.ToInt32(str.Substring(0, 2)),
                                CarModel=str.Substring(2, 5).Trim(),
                                TrainNumber=str.Substring(24, 7).Trim(),
                                PassTime=Convert.ToDateTime(str.Substring(str.Length - 30, 19)),
                                Speed=Convert.ToDecimal(str.Substring(31, 3)),
                                MachineCode=machinecode
                            }
                            );
                        }
                        else
                        {

                            item.OrderNum = Convert.ToInt32(str.Substring(0, 2));
                            item.CarModel=str.Substring(2, 5).Trim();
                            item.TrainNumber=str.Substring(24, 7).Trim();
                            item.PassTime=Convert.ToDateTime(str.Substring(str.Length - 30, 19));
                            item.Speed=Convert.ToDecimal(str.Substring(31, 3));
                            item.MachineCode = machinecode;
                            res += Dbers.GetInstance().SelfDber.Update<CmcsTrainCarriagePass>(item);
                        }
                        output(string.Format("成功读取TCPIP文件车号：{0}通过时间：{1}", str.Substring(24, 7).Trim(), Convert.ToDateTime(str.Substring(str.Length - 30, 19))), eOutputType.Normal);
                    }
                }
            }
            catch (Exception ex)
            {
                output(string.Format("解析报文失败,原因:{0}", ex.ToString()), eOutputType.Error);
            }
        }

        private string GetDirection(string value)
        {
            string res = "";
            switch (value)
            {
                case "A":
                    res = "进厂";
                    break;
                case "B":
                    res = "出厂";
                    break;
                default:
                    break;
            }
            return res;
        }


        public void Send(String str)
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 2016);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(localEndPoint);

            client.Send(ASCIIEncoding.ASCII.GetBytes(String.Format("?ZBD103H*********TC70   {0}13Z1082016-09-21 14:19:35B004.04001?", str)));
            client.Close();


        }

        public void sentTime()
        {
            for (int i = 0; i < 9999999; i++)
            {
                Send(i.ToString().PadLeft(7, '0'));
            }
        }
    }
}
