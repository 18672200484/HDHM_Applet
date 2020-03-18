using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys;

namespace CMCS.Common.Entities.Inf
{
    /// <summary>
    /// 第三方设备接口 - 故障信息表
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("inftbequinfhitch")]
    public class InfEquInfHitch : EntityBase
    {
        private string interfaceType;
        /// <summary>
        /// 接口类型
        /// </summary>
        public string InterfaceType
        {
            get { return interfaceType; }
            set { interfaceType = value; }
        }

        private string machineCode;
        /// <summary>
        /// 设备编号
        /// </summary>
        public string MachineCode
        {
            get { return machineCode; }
            set { machineCode = value; }
        }
        
        private DateTime _HitchTime;
        /// <summary>
        /// 故障时间
        /// </summary>
        public DateTime HitchTime
        {
            get { return _HitchTime; }
            set { _HitchTime = value; }
        } 

        private string _HitchDescribe;
        /// <summary>
        /// 故障描述
        /// </summary>
        public string HitchDescribe
        {
            get { return _HitchDescribe; }
            set { _HitchDescribe = value; }
        }

        private int dataFlag;
        /// <summary>
        /// 标识符
        /// </summary>
        public int DataFlag
        {
            get { return dataFlag; }
            set { dataFlag = value; }
        }

        /// <summary>
        /// 是否已读 0：否 1：是
        /// </summary>
        public int IsRead { get; set; }
    }
}
