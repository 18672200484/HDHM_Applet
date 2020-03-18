using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys;
using CMCS.DapperDber.Attrs;


namespace CMCS.Common.Entities.Sys
{
    /// <summary>
    /// 用户表
    /// </summary>
    [DapperBind("SYS_USERS")]
    public class SysUsers
    {
        [DapperAutoPrimaryKey]
        public int Id { get; set; }

        public DateTime CreationTime { get; set; }

        public string CreatorUserId { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDeleted { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string UserName { get; set; }

        public int TenantId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string SurName { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [DapperIgnore]
        public string EmailAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int AccessFailedCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IsLockOutEnabled { get; set; }

        /// <summary>
        /// 最后修改密码时间
        /// </summary>
        public DateTime LastPassWordUpdateTime { get; set; }

        /// <summary>
        /// 顺序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NORMALIZEDEMAILADDRESS { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int DEPARTMENTID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NORMALIZEDUSERNAME { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IsEmailConfirmed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IsTwoFactorEnabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IsPhoneNumberConfirmed { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public int IsActive { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        public string WorkNumber { get; set; }
    }
}
