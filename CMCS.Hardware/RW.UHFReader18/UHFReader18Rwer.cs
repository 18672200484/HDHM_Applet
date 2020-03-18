using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
//
using System.Timers;
using ReaderB;

namespace RW.UHFReader18
{
    public class UHFReader18Rwer
    {
        public UHFReader18Rwer()
        {

        }

        /// <summary>
        /// 读卡器地址
        /// </summary>
        private byte ComAdr = 0xff;
        /// <summary>
        /// 读卡器句柄
        /// </summary>
        private int FrmHandle = -1;
        /// <summary>
        /// 询查TID的起始地址
        /// </summary>
        private byte AdrTID = 0;
        /// <summary>
        /// 询查TID的字数
        /// </summary>
        private byte LenTID = 0;
        /// <summary>
        /// 询查TID的标志。1=TID;0=EPC;
        /// </summary>
        private byte TIDFlag = 0;
        /// <summary>
        /// 读取到的数据
        /// </summary>
        private byte[] EPClenandEPC = new byte[5000];
        /// <summary>
        /// 串口
        /// </summary>
        private int Com = 1;

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

        private List<string> tags = new List<string>();
        /// <summary>
        /// 当前读取到的标签集
        /// </summary>
        public List<string> Tags
        {
            get { return tags; }
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
        /// <param name="bandrate">波特率</param>
        /// <returns></returns>
        public bool OpenCom(int com)
        {
            try
            {
                this.Com = com;
                this.ComAdr = 0xff;
                this.FrmHandle = -1;

                if (StaticClassReaderB.OpenComPort(com, ref ComAdr, Convert.ToByte(5), ref FrmHandle) == 0)
                {
                    Com = com;

                    byte[] Parameter = new byte[6];
                    /**
                     * 工作模式选择
                     * Bit1Bit0=0：应答模式；
                     * Bit1Bit0=1：主动模式；
                     * Bit1Bit0=2：触发模式(低电平有效)；
                     * Bit1Bit0=3：触发模式(高电平有效)。
                     * */
                    Parameter[0] = 0;
                    /**
                     *标签卡类型
                     *输出模式
                     **/
                    Parameter[1] = 1;
                    //存储区或询查标签
                    Parameter[2] = 0;
                    Parameter[3] = (byte)24;
                    Parameter[4] = (byte)0;
                    Parameter[5] = (byte)FrmHandle;
                    StaticClassReaderB.SetWorkMode(ref ComAdr, Parameter, Com);

                    SetStatus(true);
                }
                else
                {
                    this.status = false;
                    if (this.OnStatusChange != null) this.OnStatusChange(this.status);
                }
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
        public bool CloseCom()
        {
            try
            {
                SetStatus(false);

                StaticClassReaderB.CloseSpecComPort(this.Com);

                return true;
            }
            catch (Exception ex)
            {
                if (OnScanError != null) OnScanError(ex);
            }

            return false;
        }

        /// <summary>
        /// 扫描标签卡
        /// </summary>
        /// <returns></returns>
        public List<string> ScanTags()
        {
            List<string> tags = new List<string>();
            try
            {
                // EPClenandEPC的字节数
                int Totallen = 0;
                // 电子标签的张数
                int CardNum = 0;
                int index = 0, rflen = 0;
                string tempstr = string.Empty, tag = string.Empty;

                int res = StaticClassReaderB.Inventory_G2(ref ComAdr, AdrTID, LenTID, TIDFlag, EPClenandEPC, ref Totallen, ref CardNum, FrmHandle);
                if ((res == 1) | (res == 2) | (res == 3) | (res == 4) | (res == 0xFB))
                {
                    byte[] TempByte = new byte[Totallen];
                    Array.Copy(EPClenandEPC, TempByte, Totallen);
                    tempstr = ByteArrayToHexString(TempByte);

                    for (int i = 0; i < CardNum; i++)
                    {
                        rflen = TempByte[index];
                        tag = tempstr.Substring(index * 2 + 2, rflen * 2);
                        index = index + rflen + 1;
                        if (tag.Length != rflen * 2) continue;

                        if (string.IsNullOrEmpty(this.startWith) || (!string.IsNullOrEmpty(this.startWith) && tag.StartsWith(this.startWith)))
                        {
                            tags.Add(tag);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (OnScanError != null) OnScanError(ex);

                SetStatus(false);
            }
            finally
            {

            }

            return tags;
        }

        /// <summary>
        /// 字节数组转字符串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            return sb.ToString().ToUpper();
        }

        /// <summary>
        /// 字符串转字节数组
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private byte[] HexStringToByteArray(string str)
        {
            str = str.Replace(" ", "");
            byte[] buffer = new byte[str.Length / 2];
            for (int i = 0; i < str.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(str.Substring(i, 2), 16);
            return buffer;
        }

        /// <summary>
        /// 修改标签号
        /// </summary>
        /// <param name="epc">新标签号</param>
        /// <param name="password">访问密码</param>
        /// <returns></returns>
        public bool WriteEPC(string epc, string password)
        {
            int ErrorCode = 0;
            if (StaticClassReaderB.WriteEPC_G2(ref ComAdr, HexStringToByteArray(password), HexStringToByteArray(epc), Convert.ToByte(epc.Length / 2), ref ErrorCode, Com) == 0)
                return true;

            return false;
        }

        /// <summary>
        /// 修改标签号(注意功率不能过低)
        /// </summary>
        /// <param name="epc">新标签号</param>
        /// <returns></returns>
        public bool WriteEPC(string epc)
        {
            return WriteEPC(epc, "00000000");
        }
    }
}
