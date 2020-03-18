using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities;
using CMCS.Common.Entities.Sys; 

namespace CMCS.Common.Views
{
    /// <summary>
    /// 视图-翻车机对道队列详情视图
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("View_TrainTipperQueue")]
    public class View_TrainTipperQueue : EntityBase2
    {
        private string _TrainTipperMachineCode;
        /// <summary>
        /// 翻车机编号
        /// </summary>
        public string TrainTipperMachineCode
        {
            get { return _TrainTipperMachineCode; }
            set { _TrainTipperMachineCode = value; }
        }

        private int _OrderNumber;
        /// <summary>
        /// 队列顺序
        /// </summary>
        public int OrderNumber
        {
            get { return _OrderNumber; }
            set { _OrderNumber = value; }
        }

        private string _IsTurnover;
        /// <summary>
        /// 翻车标识 已翻、待翻
        /// </summary>
        public string IsTurnover
        {
            get { return _IsTurnover; }
            set { _IsTurnover = value; }
        }

        private string _InFactoryBatchId;
        /// <summary>
        /// 入厂煤批次Id
        /// </summary>
        public string InFactoryBatchId
        {
            get { return _InFactoryBatchId; }
            set { _InFactoryBatchId = value; }
        }

        private string _TransportId;
        /// <summary>
        /// 批次明细Id
        /// </summary>
        public string TransportId
        {
            get { return _TransportId; }
            set { _TransportId = value; }
        }

        private string _TrainNumber;
        /// <summary>
        /// 车船号
        /// </summary>
        public string TrainNumber
        {
            get { return _TrainNumber; }
            set { _TrainNumber = value; }
        }

        private double _TicketQty;
        /// <summary>
        /// 矿发量
        /// </summary>
        public double TicketQty
        {
            get { return _TicketQty; }
            set { _TicketQty = value; }
        }

        private DateTime _InfactoryTime;
        /// <summary>
        /// 到厂时间
        /// </summary>
        public DateTime InfactoryTime
        {
            get { return _InfactoryTime; }
            set { _InfactoryTime = value; }
        }

        private string _TrainSampleSchemeId;
        /// <summary>
        /// 采样方案
        /// </summary>
        public string TrainSampleSchemeId
        {
            get { return _TrainSampleSchemeId; }
            set { _TrainSampleSchemeId = value; }
        }

        private string _YuSampleCode;
        /// <summary>
        /// 预采样码
        /// </summary>
        public string YuSampleCode
        {
            get { return _YuSampleCode; }
            set { _YuSampleCode = value; }
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
    }
}
