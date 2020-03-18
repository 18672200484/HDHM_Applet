using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys;

namespace CMCS.Common.Entities.Inf
{
    /// <summary>
    /// 皮带采样机接口-卸样命令
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("INFTBBELTSAMPLEUNLOADCMD")]
    public class InfBeltSampleUnloadCmd : EntityBase
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

        private string unloadType;
        /// <summary>
        /// 卸样方式
        /// </summary>
        public string UnloadType
        {
            get { return unloadType; }
            set { unloadType = value; }
        }

        private string resultCode;
        /// <summary>
        /// 执行结果
        /// </summary>
        public string ResultCode
        {
            get { return resultCode; }
            set { resultCode = value; }
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
