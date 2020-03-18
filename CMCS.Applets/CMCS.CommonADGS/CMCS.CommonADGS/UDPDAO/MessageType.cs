using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCS.CommonADGS.UDPDAO
{
    /// <summary>
    /// 消息类型
    /// </summary>
    [Serializable]
    public class MessageType
    {
        public MType Mtype
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 消息操作
    /// </summary>
    public enum MType
    {
        /// <summary>
        /// 发送
        /// </summary>
        Send,
        /// <summary>
        /// 接收
        /// </summary>
        Receive,
        /// <summary>
        /// 丢失
        /// </summary>
        Lost,

        // 完成发送
        Finish,

        // 登录
        login

    }
}
