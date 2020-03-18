
using System;
using System.Collections;
using CMCS.Common.Entities.Sys;

namespace CMCS.Common.Entities.Inf
{
    /// <summary>
    /// 汽车采样机-卸样历史结果表
    /// </summary>
    [Serializable]
    [CMCS.DapperDber.Attrs.DapperBind("InfTbQCJXCYJUnloadResult")]
    public class InfQCJXCYJUnloadResult : EntityBase
    {
        private string _MachineCode;
        private string _SampleCode;
        private string _BarrelCode;
        private DateTime _UnloadTime;
        private int _DataFlag;

        /// <summary>
        /// 设备编号
        /// </summary>
        public string MachineCode
        {
            get { return _MachineCode; }
            set { _MachineCode = value; }
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
        /// <summary>
        /// 采样码
        /// </summary>
        public string SampleCode
        {
            get { return _SampleCode; }
            set { _SampleCode = value; }
        }

        //private string barrelNumber;
        ///// <summary>
        ///// 罐号
        ///// </summary>
        //public string BarrelNumber
        //{
        //    get { return barrelNumber; }
        //    set { barrelNumber = value; }
        //}

        /// <summary>
        /// 样罐编码
        /// </summary>
        public string BarrelCode
        {
            get { return _BarrelCode; }
            set { _BarrelCode = value; }
        }

        /// <summary>
        /// 卸样时间
        /// </summary>
        public DateTime UnloadTime
        {
            get { return _UnloadTime; }
            set { _UnloadTime = value; }
        }

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
