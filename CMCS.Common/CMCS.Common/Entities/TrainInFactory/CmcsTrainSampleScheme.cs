using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys; 

namespace CMCS.Common.Entities.TrainInFactory
{
    /// <summary>
    /// 火车入厂煤采样方案表
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("cmcstbtrainsamplescheme")]
    public class CmcsTrainSampleScheme : EntityBase1
    {
        private string _InFactoryBatchId;
        /// <summary>
        /// 入厂煤批次Id
        /// </summary>
        public string InFactoryBatchId
        {
            get { return _InFactoryBatchId; }
            set { _InFactoryBatchId = value; }
        }

        private DateTime _DraftTime;
        /// <summary>
        /// 制定时间
        /// </summary>
        public DateTime DraftTime
        {
            get { return _DraftTime; }
            set { _DraftTime = value; }
        }

        private string _DraftUser;
        /// <summary>
        /// 制定人
        /// </summary>
        public string DraftUser
        {
            get { return _DraftUser; }
            set { _DraftUser = value; }
        }

        private string _SampleType;
        /// <summary>
        /// 采样方式
        /// </summary>
        public string SampleType
        {
            get { return _SampleType; }
            set { _SampleType = value; }
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
    }
}
