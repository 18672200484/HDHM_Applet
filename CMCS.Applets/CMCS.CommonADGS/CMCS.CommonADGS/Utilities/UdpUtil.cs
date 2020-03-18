using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CMCS.CommonADGS.Utilities
{
    public class UdpUtil
    {
        /// <summary>
        /// 内容间隔符
        /// </summary>
        public const char ContentSeperateChar = '~';
        /// <summary>
        /// 命令间隔符
        /// </summary>
        public const char CmdSperateChar = '^';

        /// <summary>
        /// 分段发送流
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="data"></param>
        public static void SendByteData(Socket socket, byte[] data)
        {
            // 发送流的长度
            byte[] datalength = new byte[4];
            datalength = BitConverter.GetBytes(data.Length);
            socket.Send(datalength);
            int length = data.Length;

            // 发送流
            int start = 0;
            int end = length;
            while (start < length)
            {
                int n = socket.Send(data, start, end, SocketFlags.None);
                start += n;
                end -= n;
            }
        }

        /// <summary>
        /// 分段接收流
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="data"></param>
        public static byte[] ReceiveByteData(Socket socket)
        {
            // 接收流的长度
            byte[] datalength = new byte[4];
            socket.Receive(datalength, 0, 4, SocketFlags.None);
            int length = BitConverter.ToInt32(datalength, 0);

            // 接收流
            int start = 0;
            int end = length;
            byte[] data = new byte[length];
            while (start < length)
            {
                int n = socket.Receive(data, start, end, SocketFlags.None);
                if (n == 0)
                {
                    data = null;
                    break;
                }
                start += n;
                end -= n;
            }

            return data;
        }

        /// <summary>
        /// 发送流
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="data"></param>
        public static int UdpSendByteData(UdpClient socket, IPEndPoint ipendpoint, byte[] data)
        {
            return socket.Send(data, data.Length, ipendpoint);
        }

        /// <summary>
        /// 接收流
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="data"></param>
        public static byte[] UdpReceiveByteData(UdpClient socket, ref IPEndPoint endpoint)
        {
            byte[] data = socket.Receive(ref endpoint);
            return data;
        }

        /// <summary>
        /// 处理文件长度显示
        /// </summary>
        /// <param name="path"></param>
        public static string DisposeFileSize(long length)
        {
            if (length < 1024)
                return "1KB";

            return Math.Round(length / 1024d, 0, MidpointRounding.AwayFromZero) + "KB";
        }

        /// <summary>
        /// 发送文件
        /// </summary>
        /// <param name="filePath"></param>
        public void SendFileRequest(string filePath)
        {
            string m_FilePath = filePath;
            FileInfo m_Info = new FileInfo(filePath);
            bool m_IsReadOnlyAtFirst = m_Info.IsReadOnly;
            string fileName = m_Info.Name;
            byte[] bb = CreateBuilder( fileName,DateTime.Now);
            SendByteData(null, bb);
        }

        private static byte[] CreateBuilder(string fileName, DateTime time)
        {
            StringBuilder build = new StringBuilder();
            string cmd = string.Empty;
            build.Append(cmd);
            build.Append(CmdSperateChar);
            build.Append(CmdSperateChar);
            build.Append(time.ToString("yyyy-MM-dd HH:mm:ss"));
            build.Append(CmdSperateChar);
            return Encoding.Default.GetBytes(build.ToString());
        }
    }
}
