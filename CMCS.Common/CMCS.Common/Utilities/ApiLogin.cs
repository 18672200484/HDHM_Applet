using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// 
using log4net.Appender;
using log4net;
using System.IO;
using System.Net;
using CMCS.Common.Entities.Sys;
using Newtonsoft.Json;
using CMCS.Common.DAO;

namespace CMCS.Common.Utilities
{
    /// <summary>
    /// Api登录
    /// </summary>
    public static class ApiLogin
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static SysUsers Login(string userName, string password)
        {
            SysUsers user = CommonDAO.GetInstance().GetUserByUserName(userName);
            if (user == null) return null;
            string url = "http://localhost:5000/api/TokenAuth/Authenticate";//本地API 正式使用时改为正式API 或者改为可配置API
            var str = HttpApi(url, "{\"userNameOrEmailAddress\":\"" + userName + "\",\"password\":\"" + password + "\",\"rememberClient\":\"true\"}", "post");
            if (string.IsNullOrEmpty(str)) return null;
            ApiResult result = JsonConvert.DeserializeObject<ApiResult>(str);
            if (result.success)
                return user;
            return null;
        }

        public static string HttpApi(string url, string jsonstr, string type)
        {
            try
            {
                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Accept = "text/html,applicaton/xhtml+xml,*/*";
                request.ContentType = "application/json";
                request.Method = type.ToUpper();
                byte[] buffer = encoding.GetBytes(jsonstr);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
            catch
            {
                return string.Empty;
            }
        }

    }
}
