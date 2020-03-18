using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCS.Common.Utilities
{
    public class MD5Util
    {
        /// <summary>
        /// 使用MD5加密字符串
        /// </summary>
        /// <param name="strScrString">加密的原数据字符串</param>
        /// <returns>加密后的数据字符串</returns>
        public static string Encrypt(string strScrString)
        {
            string strRet = "";
            byte[] bDesc = System.Text.Encoding.GetEncoding(1252).GetBytes(strScrString);
            bDesc = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(bDesc);

            for (int i = 0; i < bDesc.Length; i++)
            {
                strRet += bDesc[i].ToString("x").PadLeft(2, '0');
            }

            return strRet;
        }
    }
}
