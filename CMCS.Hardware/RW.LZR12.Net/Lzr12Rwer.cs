using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace RW.LZR12.Net
{
    /// <summary>
    /// LZR12 读卡器 网口
    /// </summary>
    public class Lzr12Rwer
    {
        public Lzr12Rwer()
        {

        }

        RfidApiLib.RfidApi Api = new RfidApiLib.RfidApi();

        private string errorMessage = string.Empty;
        /// <summary>
        /// 当前读卡类错误信息
        /// </summary>
        public string ErrorMessage
        {
            get { return errorMessage; }
        }

        private bool status = false;
        /// <summary>
        /// 连接状态
        /// </summary>
        public bool Status
        {
            get { return status; }
        }

        /// <summary>
        /// 设置连接状态
        /// </summary>
        /// <param name="status"></param>
        public void SetStatus(bool status)
        {
            if (this.status != status && this.OnStatusChange != null) this.OnStatusChange(status);
            this.status = status;
        }

        private string startWith = string.Empty;
        /// <summary>
        /// 标签号筛选过滤
        /// </summary>
        public string StartWith
        {
            get { return startWith; }
            set { startWith = value; }
        }

        public delegate void ScanErrorEventHandler(Exception ex);
        public event ScanErrorEventHandler OnScanError;

        public delegate void StatusChangeHandler(bool status);
        public event StatusChangeHandler OnStatusChange;

        /// <summary>
        /// 连接设备
        /// </summary>
        /// <param name="com">端口号</param>
        /// <param name="power">功率值，取值为0~30，对应0~30dBm.</param>
        /// <param name="freq_type">频率类型 取0时为国标（920M~925M），取1时为美标（902M~928M） </param>
        /// <returns></returns>
        public bool OpenCom(string ipAddress, int port, byte power = 30, byte freq_type = 0)
        {
            try
            {
                if (this.Api.TcpConnectReader(ipAddress, port) == 0)
                {
                    if (Api.SetRf(power, freq_type) == 0)
                    {
                        SetStatus(true);
                        return true;
                    }
                }

                SetStatus(false);
                if (this.OnStatusChange != null) this.OnStatusChange(this.status);
            }
            catch (Exception ex)
            {
                if (OnScanError != null) OnScanError(ex);

                this.status = false;
                if (this.OnStatusChange != null) this.OnStatusChange(status);
            }

            return this.status;

        }

        /// <summary>
        /// 关闭设备
        /// </summary>
        /// <returns></returns>
        public void CloseCom()
        {
            try
            {
                SetStatus(false);

                Api.TcpCloseConnect();
            }
            catch (Exception ex)
            {
                if (OnScanError != null) OnScanError(ex);
            }
        }

        /// <summary>
        /// 扫描标签卡
        /// </summary>
        /// <returns></returns>
        public List<string> ScanTags()
        {
            List<string> tags = new List<string>();

            byte tagCount = 0, tagFlag = 0;
            byte[,] tagBuffer = new byte[100, 12];

            try
            {
                this.Api.ClearIdBuf();

                if (this.Api.EpcMultiTagIdentify(ref tagBuffer, ref tagCount, ref tagFlag) == 0)
                {
                    if (tagCount >= 100) tagCount = 100;

                    if (tagCount > 0)
                    {
                        SetStatus(true);

                        for (int i = 0; i < tagCount; i++)
                        {
                            string tag = string.Empty;
                            for (int j = 0; j < 12; j++)
                            {
                                tag += string.Format("{0:X2}", tagBuffer[i, j]);
                            }

                            if (string.IsNullOrEmpty(this.startWith) || (!string.IsNullOrEmpty(this.startWith) && tag.StartsWith(this.startWith)))
                                tags.Add(tag);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Api.ClearIdBuf();

                if (OnScanError != null) OnScanError(ex);

                SetStatus(false);
            }
            finally
            {

            }

            return tags;
        }
    }
}
