using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys;
using CMCS.DapperDber.Attrs;


namespace CMCS.Common.Entities.Sys
{
    /// <summary>
    /// API调用结果
    /// </summary>
    public class ApiResult
    {
        public Result result { get; set; }

        public string targetUrl { get; set; }
        public bool success { get; set; }
        public Error error { get; set; }

        public bool unAuthorizedRequest { get; set; }

        public bool __abp { get; set; }
    }

    public class Result
    {
        public string accessToken { get; set; }
        public string encryptedAccessToken { get; set; }
        public int expireInSeconds { get; set; }
        public int userId { get; set; }
        public bool legalPassword { get; set; }
        public bool overduePassword { get; set; }
    }

    public class Error
    {
        public int code { get; set; }

        public string message { get; set; }
        public string details { get; set; }
        public string validationErrors { get; set; }
    }
}
