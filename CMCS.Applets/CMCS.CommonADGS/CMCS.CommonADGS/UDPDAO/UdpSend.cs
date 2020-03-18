using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace CMCS.CommonADGS.UDPDAO
{
    public class UdpSend
    {
        /// <summary>
        /// 异步发送消息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="debugMessage"></param>
        /// <param name="remoteIP"></param>
        public static void SendMessage(object data, IPEndPoint remoteIP)
        {
            UdpClient udpClient = new UdpClient();
            byte[] sendBytes = SerializeObject.Serialize(data);
            udpClient.Send(sendBytes, sendBytes.Length, remoteIP);
            udpClient.Close();
            //udpClient.BeginSend(sendBytes, sendBytes.Length, remoteIP, (IAsyncResult bResult) =>
            //{
            //    udpClient.EndSend(bResult);
            //}, null);
        }
    }
}
