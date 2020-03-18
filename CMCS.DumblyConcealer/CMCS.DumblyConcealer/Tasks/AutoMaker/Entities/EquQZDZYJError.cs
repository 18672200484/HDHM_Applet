using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using CMCS.Common.Entities.Sys;

namespace CMCS.DumblyConcealer.Tasks.AutoMaker.Entities
{
    /// <summary>
    /// 故障信息表
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("EquTbQZDZYJError")]
    public class EquQZDZYJError : EntityBase2
    {
        /// <summary>
        /// 故障代码
        /// </summary>		
        private decimal _ErrorCode;
        public decimal ErrorCode
        {
            get { return _ErrorCode; }
            set { _ErrorCode = value; }
        }

        /// <summary>
        /// 故障说明
        /// </summary>		
        private string _ErrorDescribe;
        public string ErrorDescribe
        {
            get { return _ErrorDescribe; }
            set { _ErrorDescribe = value; }
        }

        /// <summary>
        /// 故障时间
        /// </summary>		
        private DateTime _ErrorTime;
        public DateTime ErrorTime
        {
            get { return _ErrorTime; }
            set { _ErrorTime = value; }
        }

        /// <summary>
        /// 标识符
        /// </summary>		
        private int _DataFlag;
        public int DataFlag
        {
            get { return _DataFlag; }
            set { _DataFlag = value; }
        }


    }
}