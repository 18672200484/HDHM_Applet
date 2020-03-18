using Commen;
using Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CMCS.CommonADGS.Utilities
{
    class RevFileManager
    {
        private const string TEMPFILEEXTEND = ".temp";
        private string m_FileName = string.Empty;
        private string m_FullFileName = string.Empty;
        private string m_TempFileName = string.Empty;
        private FileStream m_Stream = null;
        private long m_FileLength = 0;
        private long m_FinishedLength = 0;
        private int m_LastProgress = 0;
        private DateTime m_StartTime = DateTime.Now;
        private bool m_SaveAs = false;
        private readonly object LOCKER = new object();
        
        #region IRevFileManager

        public string FullFileName
        {
            get { return m_FullFileName; }
        }

        public void RevFileRequest(IUdpMessage message)
        {
            m_FileName = message.GetContent();
            m_FullFileName = m_FileName;
        }

        public void RevFileResponse(bool rev)
        {
            byte[] bb = UdpCommandCreator.CreateRevFileResponseCommand(m_ParentTalk.ParentClient.Info.Mac, rev);
            if (rev)
            {
                if (File.Exists(m_FileName))
                {
                    int index = 1;
                    string temp = string.Empty;
                    List<string> fileList = new List<string>();
                    if (m_FileName.Contains("."))
                    {
                        int lastIndex = m_FileName.LastIndexOf(".");
                        fileList.Add(m_FileName.Substring(0, lastIndex));
                        fileList.Add(m_FileName.Substring(lastIndex));
                    }
                    else
                    {
                        fileList.Add(m_FileName);
                        fileList.Add(string.Empty);
                    }
                    do
                    {
                        temp = string.Format("{0}({1}){2}", fileList[0], index++, fileList[1]);
                    } while (File.Exists(temp));
                    m_FileName = temp;
                }
                m_TempFileName = m_FileName + TEMPFILEEXTEND;
                if (!m_SaveAs)
                {
                    m_FullFileName = AppDomain.CurrentDomain.BaseDirectory + m_FileName;
                    m_Stream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + m_TempFileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, UdpSingleTalk.SENDFILELENGTH);
                }
                else
                {
                    m_FullFileName = m_FileName;
                    m_Stream = new FileStream(m_TempFileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, UdpSingleTalk.SENDFILELENGTH);
                }
            }
            else
            {
                m_Stream = null;
            }
            m_StartTime = DateTime.Now;
            Send(bb);
        }

        public void RevFileLength(IUdpMessage message)
        {
            m_FileLength = long.Parse(message.GetContent());
            if (m_FileLength == 0)
            {
                m_Stream.Close();
                FileInfo info = new FileInfo(m_TempFileName);
                info.MoveTo(m_FileName);
                Clear();
                m_ParentTalk.OnFileTransmitProgressEvent(100);
                m_ParentTalk.OnRevFileFinishedEvent();
                Console.WriteLine("接收完成");
                TimeSpan span = DateTime.Now - m_StartTime;
                Console.WriteLine("用时" + span.TotalSeconds);
                return;
            }
            byte[] bb = UdpCommandCreator.CreateRevFileLengthCommand(m_ParentTalk.ParentClient.Info.Mac, m_FileLength);
            Send(bb);
        }

        public void ReceiveFile(IUdpMessage message)
        {
            if (m_Stream == null) return;
            List<byte> data = new List<byte>();
            List<byte> indexList = new List<byte>();
            data.AddRange(message.GetBytes());
            indexList.AddRange(data.GetRange(UdpSingleTalk.SENDFILELENGTH + 1, data.Count - UdpSingleTalk.SENDFILELENGTH - 1));
            data.RemoveRange(UdpSingleTalk.SENDFILELENGTH, data.Count - UdpSingleTalk.SENDFILELENGTH);//去除数据尾
            int m_Index = int.Parse(Encoding.Default.GetString(indexList.ToArray()));
            long next = m_FinishedLength + data.Count;
            int count = UdpSingleTalk.SENDFILELENGTH;
            if (next >= m_FileLength)
            {
                count = (int)(UdpSingleTalk.SENDFILELENGTH - (next - m_FileLength));
            }
            if (data.Count > 0)
            {
                m_Stream.Write(data.ToArray(), 0, count);
                m_Stream.Flush();
            }
            m_FinishedLength += data.Count;
            int now = (int)(((float)(m_FinishedLength)) / ((float)m_FileLength) * 100);
            if (m_LastProgress < now)
            {
                m_LastProgress = now;
                m_ParentTalk.OnFileTransmitProgressEvent(m_LastProgress);
            }
            if (m_FinishedLength >= m_FileLength)
            {
                m_Stream.Close();
                Console.WriteLine("{0}修改名称：{1}", DateTimeHelper.GetTimeString(), m_FileName);
                FileInfo info = new FileInfo(m_TempFileName);
                info.MoveTo(m_FileName);
                Clear();
                
                if (m_ParentTalk.Action == UdpAction.SendFolder)
                {
                    Send(UdpCommandCreator.CreateRevFileInDirectoryFinishedCommand(m_ParentTalk.ParentClient.Info.Mac));
                }
                else if (m_ParentTalk.Action == UdpAction.SendFile)
                {
                    m_ParentTalk.OnRevFileFinishedEvent();
                }
            }
            else
            {
                Send(UdpCommandCreator.CreateFileIndexResponseCommand(m_ParentTalk.ParentClient.Info.Mac, m_Index));
                Console.WriteLine(m_Index);
            }
        }

        public void ReceiveFileAsync(IUdpMessage message)
        {
            Action<IUdpMessage> hand = ReceiveFile;
            hand.BeginInvoke(message, null, null);
        }

        public void SaveAs(string file)
        {
            m_FileName = file;
            m_SaveAs = true;
            RevFileResponse(true);
        }

        public void RevFileInDirectory(IUdpMessage message,string path)
        {
            string[] data = message.GetContent().Split(UdpCommandCreator.ContentSeperateChar);
            m_FileName = path+data[0];
            Console.WriteLine("{0}文件名：{1}",DateTimeHelper.GetTimeString(), m_FileName);
            m_FileLength = long.Parse(data[1]);
            m_TempFileName = m_FileName + TEMPFILEEXTEND;
            m_Stream = new FileStream(m_TempFileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, UdpSingleTalk.SENDFILELENGTH);
            if (m_FileLength == 0)
            {
                m_Stream.Close();
                FileInfo info = new FileInfo(m_TempFileName);
                info.MoveTo(m_FileName);
                Clear();
                if (m_ParentTalk.Action == UdpAction.SendFolder)
                {
                    Send(UdpCommandCreator.CreateRevFileInDirectoryFinishedCommand(m_ParentTalk.ParentClient.Info.Mac));
                }
            }
            else
            {
                Send(UdpCommandCreator.CreateRevFileInDirectoryCommand(m_ParentTalk.ParentClient.Info.Mac, 0));
            }
        }

        #endregion

        #region Private

        private void Send(byte[] bb)
        {
            SendData(m_ParentTalk.Info.IP,bb);
        }

        private void Clear()
        {
            m_LastProgress = 0;
            m_FinishedLength = 0;
            m_FileLength = 0;
            m_Stream = null;
            m_FileName = string.Empty;
            m_TempFileName = string.Empty;
            m_SaveAs = false;
        }

        #endregion
    }
}
