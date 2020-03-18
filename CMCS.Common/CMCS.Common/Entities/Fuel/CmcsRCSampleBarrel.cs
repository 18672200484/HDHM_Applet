using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys;

namespace CMCS.Common.Entities.Fuel
{
    /// <summary>
    /// 采样桶记录表
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("CmcsTbRcSampingDetail")]
    public class CmcsRCSampleBarrel : EntityBase1
    {
        private string _InfactoryBatchId;
        private string _SamplingId;

        /// <summary>
        /// 入厂煤采样Id
        /// </summary>
        public string SamplingId
        {
            get { return _SamplingId; }
            set { _SamplingId = value; }
        }

        /// <summary>
        /// 关联批次id
        /// </summary>
        public string InFactoryBatchId
        {
            get { return _InfactoryBatchId; }
            set { _InfactoryBatchId = value; }
        }

        private string _SampleType;

        /// <summary>
        /// 采样方式 人工采样、机械采样、皮带采样
        /// </summary>
        public string SampleType
        {
            get { return _SampleType; }
            set { _SampleType = value; }
        }
        private string _SamplerName;

        /// <summary>
        /// 采样设备
        /// </summary>
        public string SamplerName
        {
            get { return _SamplerName; }
            set { _SamplerName = value; }
        }
        private string _BarrelNumber;

        /// <summary>
        /// 桶编号（明文）
        /// </summary>
        public string BarrelNumber
        {
            get { return _BarrelNumber; }
            set { _BarrelNumber = value; }
        }
        private string _BarrelCode;

        /// <summary>
        /// 桶编码
        /// </summary>
        public string BarrelCode
        {
            get { return _BarrelCode; }
            set { _BarrelCode = value; }
        }
        private DateTime _BarrellingTime;

        /// <summary>
        /// 装桶时间
        /// </summary>
        public DateTime BarrellingTime
        {
            get { return _BarrellingTime; }
            set { _BarrellingTime = value; }
        }
        private double _SampleWeight;

        /// <summary>
        /// 原始样重
        /// </summary>
        public double SampleWeight
        {
            get { return _SampleWeight; }
            set { _SampleWeight = value; }
        }
        private double _CheckSampleWeight;

        /// <summary>
        /// 校验样重
        /// </summary>
        public double CheckSampleWeight
        {
            get { return _CheckSampleWeight; }
            set { _CheckSampleWeight = value; }
        }

        /// <summary>
        /// 是否删除 0已删除 1 未删除
        /// </summary>
        public Int32 IsDeleted { get; set; }
    }
}
