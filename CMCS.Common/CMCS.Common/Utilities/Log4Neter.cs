using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// 
using log4net.Appender;
using log4net;
using System.IO;

namespace CMCS.Common.Utilities
{
    /// <summary>
    /// 日志记录类
    /// </summary>
    public static class Log4Neter
    {
        /// <summary>
        /// log4net - NormalLoger
        /// </summary>
        private static readonly log4net.ILog NormalLoger = log4net.LogManager.GetLogger("NormalLoger");

        /// <summary>
        /// log4net - ErrorLoger
        /// </summary>
        private static readonly log4net.ILog ErrorLoger = log4net.LogManager.GetLogger("ErrorLoger");

        /// <summary>
        /// 记录异常日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void Error(object message, Exception ex)
        {
            ErrorLoger.Error(message, ex);
        }

        /// <summary>
        /// 记录普通日志
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            NormalLoger.Info(string.Format("{0} - {1}{2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message, Environment.NewLine));
        }
    }
}
