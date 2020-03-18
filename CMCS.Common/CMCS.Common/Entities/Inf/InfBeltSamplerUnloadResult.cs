using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys;

namespace CMCS.Common.Entities.Inf
{
    /// <summary>
    /// 皮带采样机接口-卸样结果表
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("InfTbBeltSampleUnloadResult")]
    public class InfBeltSamplerUnloadResult : EntityBase
    {
        private string machineCode;
        /// <summary>
        /// 设备编号
        /// </summary>
        public string MachineCode
        {
            get { return machineCode; }
            set { machineCode = value; }
        }

        private string samplingId;
        /// <summary>
        /// 采样单Id
        /// </summary>
        public string SamplingId
        {
            get { return samplingId; }
            set { samplingId = value; }
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

        private string barrelNumber;
        /// <summary>
        /// 样罐编号
        /// </summary>
        public string BarrelNumber
        {
            get { return barrelNumber; }
            set { barrelNumber = value; }
        }

        private string barrelCode;
        /// <summary>
        /// 样罐编码
        /// </summary>
        public string BarrelCode
        {
            get { return barrelCode; }
            set { barrelCode = value; }
        }

        private DateTime unloadTime;
        /// <summary>
        /// 卸样时间
        /// </summary>
        public DateTime UnloadTime
        {
            get { return unloadTime; }
            set { unloadTime = value; }
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
    }
}
