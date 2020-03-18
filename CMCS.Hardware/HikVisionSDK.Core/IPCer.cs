using HikVisionSDK.Core.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HikVisionSDK.Core
{
    /// <summary>
    /// 网络摄像机 预览、抓拍、录像功能封装
    /// </summary>
    public class IPCer
    {
        /// <summary>
        /// 用户登录ID
        /// </summary>
        int m_lUserID = -1;
        /// <summary>
        /// 预览句柄ID
        /// </summary>
        int lRealHandle = -1;

        /// <summary>
        /// 初始化 SDK
        /// </summary>
        /// <returns></returns>
        public static bool InitSDK()
        {
            bool res = CHCNetSDK.NET_DVR_Init();
            CHCNetSDK.NET_DVR_SetConnectTime(2000, 1);
            CHCNetSDK.NET_DVR_SetReconnect(10000, 1);
            return res;
        }

        /// <summary>
        /// 卸载 SDK
        /// </summary>
        /// <returns></returns>
        public static bool CleanupSDK()
        {
            return CHCNetSDK.NET_DVR_Cleanup();
        }

        /// <summary>
        /// 返回最后操作的错误码 
        /// </summary>
        /// <returns></returns>
        public static uint GetLastErrorCode()
        {
            return CHCNetSDK.NET_DVR_GetLastError();
        }

        /// <summary>
        /// 登录摄像机
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="port"></param>
        /// <param name="userAccount"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string ipAddress, int port, string userAccount, string password)
        {
            CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();

            m_lUserID = CHCNetSDK.NET_DVR_Login_V30(ipAddress, port, userAccount, password, ref DeviceInfo);
            return m_lUserID >= 0;
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public bool LoginOut()
        {
            if (m_lUserID < 0) return false;

            bool res = CHCNetSDK.NET_DVR_Logout(m_lUserID);
            if (res) this.m_lUserID = -1;

            return res;
        }

        /// <summary>
        /// 开始预览
        /// </summary>
        /// <param name="previewInfo"></param>
        /// <returns></returns>
        public bool StartPreview(CHCNetSDK.NET_DVR_PREVIEWINFO previewInfo)
        {
            if (m_lUserID < 0) return false;

            lRealHandle = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref previewInfo, null, new IntPtr());
            return lRealHandle < 0;
        }

        /// <summary>
        /// 开始预览
        /// </summary>
        /// <param name="previewHandle">预览句柄</param>
        /// <param name="channel">通道号</param>
        /// <param name="linkMode">连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP </param>
        /// <param name="streamType">码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推</param>
        /// <returns></returns>
        public bool StartPreview(IntPtr previewHandle, int channel, int linkMode = 0, int streamType = 0)
        {
            CHCNetSDK.NET_DVR_PREVIEWINFO previewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
            // 预览窗口
            previewInfo.hPlayWnd = previewHandle;
            // 预览的设备通道
            previewInfo.lChannel = channel;
            // 码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
            previewInfo.dwStreamType = 0;
            // 连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
            previewInfo.dwLinkMode = 0;
            // 0- 非阻塞取流，1- 阻塞取流
            previewInfo.bBlocked = true;
            // 播放库播放缓冲区最大缓冲帧数
            previewInfo.dwDisplayBufNum = 15;
            return StartPreview(previewInfo);
        }

        /// <summary>
        /// 停止预览
        /// </summary>
        /// <returns></returns>
        public bool StopPreview()
        {
            if (m_lUserID < 0 || lRealHandle < 0) return false;

            bool res = CHCNetSDK.NET_DVR_StopRealPlay(lRealHandle);
            if (res) this.lRealHandle = -1;

            return res;
        }

        /// <summary>
        /// 抓拍照片
        /// </summary>
        /// <param name="fileName">保存文件路径</param>
        /// <returns></returns>
        public bool CapturePicture(string fileName)
        {
            if (m_lUserID < 0 || lRealHandle < 0) return false;

            return CHCNetSDK.NET_DVR_CapturePicture(lRealHandle, fileName);
        }

        /// <summary>
        /// 开始录像
        /// </summary>
        /// <param name="fileName">录像文件路径 *.mp4</param>
        /// <param name="channel">通道号</param>
        /// <returns></returns>
        public bool StartRecord(string fileName, int channel)
        {
            if (m_lUserID < 0 || lRealHandle < 0) return false;

            CHCNetSDK.NET_DVR_MakeKeyFrame(m_lUserID, channel);

            return CHCNetSDK.NET_DVR_SaveRealData(this.lRealHandle, fileName);
        }

        /// <summary>
        /// 停止录像
        /// </summary>
        /// <returns></returns>
        public bool StopRecord()
        {
            if (m_lUserID < 0 || lRealHandle < 0) return false;

            return CHCNetSDK.NET_DVR_StopSaveRealData(lRealHandle);
        }
    }
}
