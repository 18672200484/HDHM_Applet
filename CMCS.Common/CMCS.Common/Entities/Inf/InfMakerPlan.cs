using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys;

namespace CMCS.Common.Entities.Inf
{
    /// <summary>
    /// 全自动制样接口 - 制样计划
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("inftbmakerplan")]
    public class InfMakerPlan : EntityBase
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

        private string inFactoryBatchId;
        /// <summary>
        /// 批次Id
        /// </summary>
        public string InFactoryBatchId
        {
            get { return inFactoryBatchId; }
            set { inFactoryBatchId = value; }
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

        private string _FuelKindName;
        /// <summary>
        /// 煤种
        /// </summary>
        public string FuelKindName
        {
            get { return _FuelKindName; }
            set { _FuelKindName = value; }
        }

        private string _Mt;
        /// <summary>
        /// 外水分
        /// </summary>
        public string Mt
        {
            get { return _Mt; }
            set { _Mt = value; }
        }

        private string _MakeType;
        /// <summary>
        /// 制样方式
        /// </summary>
        public string MakeType
        {
            get { return _MakeType; }
            set { _MakeType = value; }
        }

        private string _CoalSize;
        /// <summary>
        /// 煤炭粒度
        /// </summary>
        public string CoalSize
        {
            get { return _CoalSize; }
            set { _CoalSize = value; }
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

        private int syncFlag = 0;
        /// <summary>
        /// 同步标识 0=未同步 1=已同步
        /// </summary>
        public int SyncFlag
        {
            get { return syncFlag; }
            set { syncFlag = value; }
        }
    }
}
