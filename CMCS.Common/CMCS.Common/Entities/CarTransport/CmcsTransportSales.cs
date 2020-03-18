// 此代码由 NhGenerator v1.0.2.0 工具生成。

using System;
using System.Collections;
using CMCS.Common.Entities.Sys;
//
namespace CMCS.Common.Entities.CarTransport
{
    [Serializable]
    [CMCS.DapperDber.Attrs.DapperBind("FULTBQCXSYB")]
    public class CmcsTransportSales : EntityBase1
    {
        private String _YbNum;
        /// <summary>
        /// 预报编号
        /// </summary>
        public virtual String YbNum { get { return _YbNum; } set { _YbNum = value; } }

        private DateTime _ZcDate;
        /// <summary>
        /// 预计装车日期
        /// </summary>
        public virtual DateTime ZcDate { get { return _ZcDate; } set { _ZcDate = value; } }

        private Int32 _HourStart;
        /// <summary>
        /// 装车时段1
        /// </summary>
        public virtual Int32 HourStart { get { return _HourStart; } set { _HourStart = value; } }

        private Int32 _HourEnd;
        /// <summary>
        /// 装车时段2
        /// </summary>
        public virtual Int32 HourEnd { get { return _HourEnd; } set { _HourEnd = value; } }

        private String _SaleSorderId;
        /// <summary>
        /// 收货单位id
        /// </summary>
        public virtual String SaleSorderId { get { return _SaleSorderId; } set { _SaleSorderId = value; } }

        private String _Consignee;
        /// <summary>
        /// 收货单位
        /// </summary>
        public virtual String Consignee { get { return _Consignee; } set { _Consignee = value; } }

        private String _TransportCompayId;
        /// <summary>
        /// 运输单位id
        /// </summary>
        public virtual String TransportCompayId { get { return _TransportCompayId; } set { _TransportCompayId = value; } }

        private String _TransportCompayName;
        /// <summary>
        /// 运输单位名称
        /// </summary>
        public virtual String TransportCompayName { get { return _TransportCompayName; } set { _TransportCompayName = value; } }

        private Int32 _TransportNumber;
        /// <summary>
        /// 车数
        /// </summary>
        public virtual Int32 TransportNumber { get { return _TransportNumber; } set { _TransportNumber = value; } }

        private String _TransportNo;
        /// <summary>
        /// 运输单号
        /// </summary>
        public virtual String TransportNo { get { return _TransportNo; } set { _TransportNo = value; } }

        private String _TransportDetails;
        /// <summary>
        /// 车辆明细
        /// </summary>
        public virtual String TransportDetails { get { return _TransportDetails; } set { _TransportDetails = value; } }

       

        private decimal _ProductNumbering;
        /// <summary>
        /// 订单正在排产计划量
        /// </summary>
        public virtual decimal ProductNumbering { get { return _ProductNumbering; } set { _ProductNumbering = value; } }

        private decimal _ReadyProductNumber;
        /// <summary>
        /// 订单已排产量
        /// </summary>
        public virtual decimal ReadyProductNumber { get { return _ReadyProductNumber; } set { _ReadyProductNumber = value; } }

        private decimal _ReadySalesNumber;
        /// <summary>
        /// 订单已销售量
        /// </summary>
        public virtual decimal ReadySalesNumber { get { return _ReadySalesNumber; } set { _ReadySalesNumber = value; } }

        private String _CheckStatus;
        /// <summary>
        /// 是否审核
        /// </summary>
        public virtual String CheckStatus { get { return _CheckStatus; } set { _CheckStatus = value; } }

        private String _Remark;
        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Remark { get { return _Remark; } set { _Remark = value; } }

        private String _IsUpload;
        /// <summary>
        /// 是否上传
        /// </summary>
        public virtual String IsUpload { get { return _IsUpload; } set { _IsUpload = value; } }

        private String _DataFrom;
        /// <summary>
        /// 数据来源
        /// </summary>
        public virtual String DataFrom { get { return _DataFrom; } set { _DataFrom = value; } }

    }
}
