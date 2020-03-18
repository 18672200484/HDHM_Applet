using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys;

namespace CMCS.Common.Entities.Fuel
{
    /// <summary>
    /// 入厂煤采样表
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("CmcsTbRcSampling")]
    public class CmcsRCSampling : EntityBase1
    {
        private string _InFactoryBatchId;

        /// <summary>
        /// 关联批次id
        /// </summary>
        public string InFactoryBatchId
        {
            get { return _InFactoryBatchId; }
            set { _InFactoryBatchId = value; }
        }
        private DateTime _SamplingDate;

        /// <summary>
        /// 采样时间
        /// </summary>
        public DateTime SamplingDate
        {
            get { return _SamplingDate; }
            set { _SamplingDate = value; }
        }
        private string _SamplingPle;

        /// <summary>
        /// 采样人
        /// </summary>
        public string SamplingPle
        {
            get { return _SamplingPle; }
            set { _SamplingPle = value; }
        }
        private string _SamplingType;

        /// <summary>
        /// 采样方式
        /// </summary>
        public string SamplingType
        {
            get { return _SamplingType; }
            set { _SamplingType = value; }
        }
        private string _SampleCode;

        /// <summary>
        /// 采样码
        /// </summary>
        public string SampleCode
        {
            get { return _SampleCode; }
            set { _SampleCode = value; }
        }

        private string _Remark;

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        /// <summary>
        /// 是否删除 0已删除 1 未删除
        /// </summary>
        public Int32 IsDeleted { get; set; }
    }
}
