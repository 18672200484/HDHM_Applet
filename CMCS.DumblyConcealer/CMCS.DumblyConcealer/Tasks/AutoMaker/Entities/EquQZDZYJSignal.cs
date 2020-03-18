using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities;
using CMCS.Common.Entities.Sys;

namespace CMCS.DumblyConcealer.Tasks.AutoMaker.Entities
{
    /// <summary>
    /// 全自动制样机接口表 - 实时信号表
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("EquTbQZDZYJSignal")]
    public class EquQZDZYJSignal : EntityBase2
    {
        private string _TagName;
        /// <summary>
        /// 信号名
        /// </summary>
        public string TagName
        {
            get { return _TagName; }
            set { _TagName = value; }
        }

        private string _TagValue;
        /// <summary>
        /// 信号值
        /// </summary>
        public string TagValue
        {
            get { return _TagValue; }
            set { _TagValue = value; }
        }

        private DateTime _UpdateTime;
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime
        {
            get { return _UpdateTime; }
            set { _UpdateTime = value; }
        }

        private int _DataFlag;
        /// <summary>
        /// 标识符
        /// </summary>
        public int DataFlag
        {
            get { return _DataFlag; }
            set { _DataFlag = value; }
        } 
    }
}
