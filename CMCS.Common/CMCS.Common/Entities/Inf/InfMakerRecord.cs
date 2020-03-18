using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys;

namespace CMCS.Common.Entities.Inf
{
    /// <summary>
    /// 全自动制样接口 - 制样出样
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("inftbmakerrecord")]
    public class InfMakerRecord : EntityBase
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

        private string _MakeCode;
        /// <summary>
        /// 制样码
        /// </summary>
        public string MakeCode
        {
            get { return _MakeCode; }
            set { _MakeCode = value; }
        }

        private string _BarrelCode;
        /// <summary>
        /// 样罐编码
        /// </summary>
        public string BarrelCode
        {
            get { return _BarrelCode; }
            set { _BarrelCode = value; }
        }

        private string _YPType;
        /// <summary>
        /// 样品类型
        /// </summary>
        public string YPType
        {
            get { return _YPType; }
            set { _YPType = value; }
        }

        private double _YPWeight;
        /// <summary>
        /// 样品重量
        /// </summary>
        public double YPWeight
        {
            get { return _YPWeight; }
            set { _YPWeight = value; }
        }

        private DateTime _StartTime;
        /// <summary>
        /// 制样开始时间
        /// </summary>
        public DateTime StartTime
        {
            get { return _StartTime; }
            set { _StartTime = value; }
        }

        private DateTime _EndTime;
        /// <summary>
        /// 制样结束时间
        /// </summary>
        public DateTime EndTime
        {
            get { return _EndTime; }
            set { _EndTime = value; }
        }

        private string _MakeUser;
        /// <summary>
        /// 制样员
        /// </summary>
        public string MakeUser
        {
            get { return _MakeUser; }
            set { _MakeUser = value; }
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
