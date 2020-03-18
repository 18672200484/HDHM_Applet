using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using CMCS.Common.Entities;
using CMCS.Common.Entities.Sys;
using CMCS.DapperDber.Attrs;


namespace CMCS.Common.Entities.iEAA
{
    /// <summary>
    /// 智能化用户
    /// </summary>
    [Serializable]
    [DapperBind("cmcstbuserinfo")]
    public class CmcsUser : EntityBase1
    {
        private string _name;
        private string _userpassword;
        private string _username;
        private int _issupper = 0;
        private int _isdeductuser = 0;
        private int _isuse = 1;

        /// <summary>
        /// 昵称
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// 账号
        /// </summary>
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord
        {
            get { return _userpassword; }
            set { _userpassword = value; }
        }
        /// <summary>
        /// 是否是超级管理员，1=是 0=否
        /// </summary>
        public int IsSupper
        {
            get { return _issupper; }
            set { _issupper = value; }
        }
        /// <summary>
        /// 是否是扣吨员，1=是 0=否
        /// </summary>
        public int IsDeductUser
        {
            get { return _isdeductuser; }
            set { _isdeductuser = value; }
        }
        /// <summary>
        /// 是否启用，1=是 0=否
        /// </summary>
        public int IsUse
        {
            get { return _isuse; }
            set { _isuse = value; }
        }
    }
}
