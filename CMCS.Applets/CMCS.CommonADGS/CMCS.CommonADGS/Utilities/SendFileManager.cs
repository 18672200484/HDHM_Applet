using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CMCS.CommonADGS.Utilities
{
    class SendFileManager 
    {
        private string m_FilePath = string.Empty;
        private FileStream m_Stream = null;
        private long m_FileLength = 0;
        private int m_Index = 0;
        private long m_FinishedLength = 0;
        private int m_LastProgress = 0;
        private readonly object LOCKER = new object();
        private bool m_IsReadOnlyAtFirst = false;
        private FileInfo m_Info = null;

        #region ISendFileManager

        public void SendFileRequest(string filePath)
        {
            m_FilePath = filePath;
            m_Info = new FileInfo(filePath);
            m_IsReadOnlyAtFirst = m_Info.IsReadOnly;
            string fileName = m_Info.Name;
            byte[] bb = UdpCommandCreator.CreateSendFileRequestCommand(m_ParentTalk.ParentClient.Info.Mac, fileName);
            Send(bb);
        }

        public void SendFileLength()
        {
            m_Info.IsReadOnly = false;
            m_Stream = new FileStream(m_FilePath, FileMode.Open);
            m_FileLength = m_Stream.Length;
            byte[] bb = UdpCommandCreator.CreateSendFileLengthCommand(m_ParentTalk.ParentClient.Info.Mac, m_FileLength);
            Send(bb);
        }

        public void SendFile(int index)
        {
            if (index != m_Index)
            {
                throw new Exception("发送与接收的数据不匹配");
            }

            FileStream fs = m_Stream;
            List<byte> byteList = new List<byte>();

            int count = byteList.Count;
            byte[] byteArray = new byte[UdpSingleTalk.SENDFILELENGTH];
            bool canSend = true;
            canSend = fs.Read(byteArray, 0, byteArray.Length) > 0;
            if (canSend)
            {
                m_Index++;
                byte[] bb = UdpCommandCreator.CreateSendFileCommand(m_ParentTalk.ParentClient.Info.Mac, byteArray, m_Index);
                Send(bb);
                m_FinishedLength += byteArray.Length;
                fs.Seek(m_FinishedLength, SeekOrigin.Begin);
                int now = (int)(((float)(m_FinishedLength)) / ((float)m_FileLength) * 100);
                if (m_LastProgress < now)
                {
                    m_LastProgress = now;
                    m_ParentTalk.OnFileTransmitProgressEvent(m_LastProgress);
                }
            }
            if (m_FinishedLength >= m_FileLength)
            {
                fs.Close();
                m_Info.IsReadOnly = m_IsReadOnlyAtFirst;
                Clear();
                if (m_ParentTalk.Action == UdpAction.SendFile)
                {
                    m_ParentTalk.OnSendFileFinishedEvent();
                    m_ParentTalk.OnFileTransmitProgressEvent(100);
                }

            }
        }

        public void SendFileAsync(int index)
        {
            Action<int> hand = SendFile;
            hand.BeginInvoke(index, null, null);
        }

        public void SendFileInDirectory(string filePath,string rootDirectory)
        {
            m_FilePath = filePath;
            m_Info = new FileInfo(filePath);
            m_IsReadOnlyAtFirst = m_Info.IsReadOnly;
            m_Info.IsReadOnly = false;
            m_Stream = new FileStream(m_FilePath, FileMode.Open);
            m_FileLength = m_Stream.Length;
           
            string fileName = m_Info.Name;
            Send(UdpCommandCreator.CreateSendFileInDirectoryCommand(m_ParentTalk.ParentClient.Info.Mac,fileName, m_FileLength, rootDirectory));
        }

        #endregion

        #region Private

        private void Send(byte[] bb)
        {
            SendData(m_ParentTalk.Info.IP,bb);
        }

        private void Clear()
        {
            m_FinishedLength = 0;
            m_FileLength = 0;
            m_Stream = null;
            m_FilePath = string.Empty;
            m_Index = 0;
            m_LastProgress = 0;
            m_Info = null;
        }

        #endregion
    }
}
