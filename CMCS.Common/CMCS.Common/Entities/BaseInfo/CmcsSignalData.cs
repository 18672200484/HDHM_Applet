using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys; 

namespace CMCS.Common.Entities.BaseInfo
{
    /// <summary>
    /// 实时信号表
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("cmcstbsignaldata")]
    public class CmcsSignalData : EntityBase
    {
        private string signalPrefix;
        /// <summary>
        /// 信号前缀
        /// </summary>
        public string SignalPrefix
        {
            get { return signalPrefix; }
            set { signalPrefix = value; }
        }
        private string signalName;
        /// <summary>
        /// 信号名
        /// </summary>
        public string SignalName
        {
            get { return signalName; }
            set { signalName = value; }
        }

        private string signalValue;
        /// <summary>
        /// 值
        /// </summary>
        public string SignalValue
        {
            get { return signalValue; }
            set { signalValue = value; }
        }

        private DateTime updateTime;
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime
        {
            get { return updateTime; }
            set { updateTime = value; }
        }

        private string remark;
        /// <summary>
        /// 备注
        /// </summary> 
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
