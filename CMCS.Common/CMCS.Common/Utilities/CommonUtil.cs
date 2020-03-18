using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;

namespace CMCS.Common.Utilities
{
    public static class CommonUtil
    {
        /// <summary>
        /// 测试Ip是否连通
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool PingReplyTest(string ip)
        {
            try
            {
                Ping pingSender = new Ping();
                PingReply reply = pingSender.Send(ip, 120);
                if (reply.Status == IPStatus.Success)
                    return true;
                return false;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
