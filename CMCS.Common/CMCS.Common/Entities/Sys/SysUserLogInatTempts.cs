using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys;
using CMCS.DapperDber.Attrs;


namespace CMCS.Common.Entities.Sys
{
    /// <summary>
    /// 登录请求表
    /// </summary>
    [DapperBind("SYS_USERLOGINATTEMPTS")]
    public class SysUserLogInatTempts
    {
        [DapperIgnore]
        public int Id { get; }

        public int TenAntId { get; set; }

        public string TenancyName { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户账号或邮箱
        /// </summary>
        public string UserNameOrEmailAddress { get; set; }

        /// <summary>
        /// 客户端地址
        /// </summary>
        public string ClientIpAddress { get; set; }

        /// <summary>
        /// 客户端名称
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// 浏览器信息
        /// </summary>
        public string BrowserInfo { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        public int Result { get; set; }

        /// <summary>
        /// 请求时间
        /// </summary>
        public DateTime CreationTime { get; set; }
    }
}
