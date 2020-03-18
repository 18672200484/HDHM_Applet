using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys;

namespace CMCS.Common.Entities.Inf
{
    /// <summary>
    /// 皮带采样机接口-采样计划
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("inftbbeltsampleplan")]
    public class InfBeltSamplePlan : EntityBase
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

        private string fuelKindName;
        /// <summary>
        /// 煤种
        /// </summary>
        public string FuelKindName
        {
            get { return fuelKindName; }
            set { fuelKindName = value; }
        }

        private double mt;
        /// <summary>
        /// 外水分
        /// </summary>
        public double Mt
        {
            get { return mt; }
            set { mt = value; }
        }

        private double ticketWeight;
        /// <summary>
        /// 该批次矿发量
        /// </summary>
        public double TicketWeight
        {
            get { return ticketWeight; }
            set { ticketWeight = value; }
        }

        private int carCount;
        /// <summary>
        /// 该批次车节数
        /// </summary>
        public int CarCount
        {
            get { return carCount; }
            set { carCount = value; }
        }

        private string sampleType;
        /// <summary>
        /// 采样方式
        /// </summary>
        public string SampleType
        {
            get { return sampleType; }
            set { sampleType = value; }
        }

        private string gatherType;
        /// <summary>
        /// 集样方式
        /// </summary>
        public string GatherType
        {
            get { return gatherType; }
            set { gatherType = value; }
        }

        private DateTime startTime;
        /// <summary>
        /// 采样开始时间
        /// </summary>
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        private DateTime endTime;
        /// <summary>
        /// 采样结束时间
        /// </summary>
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        private string sampleUser;
        /// <summary>
        /// 采样员
        /// </summary>
        public string SampleUser
        {
            get { return sampleUser; }
            set { sampleUser = value; }
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
