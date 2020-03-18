using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys;

namespace CMCS.Common.Entities.Inf
{
    /// <summary>
    /// 第三方设备接口 - 实时集样罐表
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("inftbequinfsamplebarrel")]
    public class InfEquInfSampleBarrel : EntityBase
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

        private string barrelNumber;
        /// <summary>
        /// 样罐编号
        /// </summary>
        public string BarrelNumber
        {
            get { return barrelNumber; }
            set { barrelNumber = value; }
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

        private string sampleCode;
        /// <summary>
        /// 采样码
        /// </summary>
        public string SampleCode
        {
            get { return sampleCode; }
            set { sampleCode = value; }
        }

        private int sampleCount;
        /// <summary>
        /// 子样数
        /// </summary>
        public int SampleCount
        {
            get { return sampleCount; }
            set { sampleCount = value; }
        }

        private int isCurrent;
        /// <summary>
        /// 是当前进料罐
        /// </summary>
        public int IsCurrent
        {
            get { return isCurrent; }
            set { isCurrent = value; }
        }

        private string barrelStatus;
        /// <summary>
        /// 桶满状态
        /// </summary>
        public string BarrelStatus
        {
            get { return barrelStatus; }
            set { barrelStatus = value; }
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

        private int dataFlag;
        /// <summary>
        /// 标识符
        /// </summary>
        public int DataFlag
        {
            get { return dataFlag; }
            set { dataFlag = value; }
        }

        private string _CarNumbers;
        /// <summary>
        /// 车号集合
        /// </summary>
        public string CarNumbers
        {
            get { return _CarNumbers; }
            set { _CarNumbers = value; }
        }

        private string _TransportIds;
        /// <summary>
        /// 批次明细Ids
        /// </summary>
        public string TransportIds
        {
            get { return _TransportIds; }
            set { _TransportIds = value; }
        }

        private string _BarrelType;
        /// <summary>
        /// 样罐类型
        /// </summary>
        public string BarrelType
        {
            get { return _BarrelType; }
            set { _BarrelType = value; }
        }
         
        
    }
}
