using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using CMCS.Common.Entities;
using CMCS.DapperDber.Attrs;


namespace CMCS.Common.Entities.iEAA
{
    /// <summary>
    /// 平台用户
    /// </summary>
    
    [Serializable,Obsolete]
    [DapperBind("sys_users")]
    public class User
    {
        [DapperPrimaryKey]
        public string Id { get; set; }

        private string _Name;
        /// <summary>
        /// 用户名称
        /// </summary>
        public string Name { get { return _Name; } set { _Name = value; } }

        private string _UserName;
        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserName { get { return _UserName; } set { _UserName = value; } }

        private string _Password;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get { return _Password; } set { _Password = value; } }

        private int _Stop;
        /// <summary>
        /// 是否启用
        /// </summary>
        public int Stop { get { return _Stop; } set { _Stop = value; } }
    }
}
