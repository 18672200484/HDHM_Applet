// 此代码由 NhGenerator v1.0.9.0 工具生成。

using System;
using System.Collections;
using System.ComponentModel;
using CMCS.Common.Entities.Sys;

namespace CMCS.Common.Entities.CarTransport
{
    /// <summary>
    /// 汽车智能化-销售煤运输记录
    /// </summary>
    [Serializable]
    [Description("销售煤运输记录")]
    [CMCS.DapperDber.Attrs.DapperBind("CmcsTbSaleFuelTransport")]
    public class CmcsSaleFuelTransport : EntityBase1
    {
        private String _AutotruckId;
        /// <summary>
        /// 关联：车辆管理
        /// </summary>
        public virtual String AutotruckId { get { return _AutotruckId; } set { _AutotruckId = value; } }

        private String _TransportSalesId;
        /// <summary>
        /// 预报Id
        /// </summary>
        public virtual String TransportSalesId { get { return _TransportSalesId; } set { _TransportSalesId = value; } }

        private String _TransportSalesNum;
        /// <summary>
        /// 预报编号
        /// </summary>
        public virtual String TransportSalesNum { get { return _TransportSalesNum; } set { _TransportSalesNum = value; } }

        private string _SerialNumber;
        /// <summary>
        /// 流水号
        /// </summary>
        public virtual string SerialNumber { get { return _SerialNumber; } set { _SerialNumber = value; } }

        private String _CarNumber;
        /// <summary>
        /// 车号
        /// </summary>
        public virtual String CarNumber { get { return _CarNumber; } set { _CarNumber = value; } }

        private Decimal _GrossWeight;
        /// <summary>
        /// 毛重(吨)
        /// </summary>
        [Description("毛重")]
        public virtual Decimal GrossWeight { get { return _GrossWeight; } set { _GrossWeight = value; } }

        private Decimal _TareWeight;
        /// <summary>
        /// 皮重(吨)
        /// </summary>
        [Description("皮重")]
        public virtual Decimal TareWeight { get { return _TareWeight; } set { _TareWeight = value; } }

        private Decimal _SuttleWeight;
        /// <summary>
        /// 净重(吨)
        /// </summary>
        [Description("净重")]
        public virtual Decimal SuttleWeight { get { return _SuttleWeight; } set { _SuttleWeight = value; } }


        private DateTime _InFactoryTime;
        /// <summary>
        /// 入厂时间
        /// </summary>
        public virtual DateTime InFactoryTime { get { return _InFactoryTime; } set { _InFactoryTime = value; } }

        private DateTime _TareTime;
        /// <summary>
        /// 皮重时间
        /// </summary>
        [Description("皮重时间")]
        public virtual DateTime TareTime { get { return _TareTime; } set { _TareTime = value; } }

        private DateTime _LoadTime;
        /// <summary>
        /// 接煤时间
        /// </summary>
        public virtual DateTime LoadTime { get { return _LoadTime; } set { _LoadTime = value; } }

        private DateTime _GrossTime;
        /// <summary>
        /// 毛重时间
        /// </summary>
        [Description("毛重时间")]
        public virtual DateTime GrossTime { get { return _GrossTime; } set { _GrossTime = value; } }

        private DateTime _OutFactoryTime;
        /// <summary>
        /// 出厂时间
        /// </summary>
        public virtual DateTime OutFactoryTime { get { return _OutFactoryTime; } set { _OutFactoryTime = value; } }

        private string _SupplierName;
        /// <summary>
        /// 供煤单位
        /// </summary>
        [Description("供煤单位")]
        public virtual string SupplierName { get { return _SupplierName; } set { _SupplierName = value; } }

        private string _SupplierId;
        /// <summary>
        /// 供煤单位
        /// </summary>
        public virtual string SupplierId { get { return _SupplierId; } set { _SupplierId = value; } }

        private string _FuelKindName;
        /// <summary>
        /// 煤种
        /// </summary>
        [Description("煤种")]
        public virtual string FuelKindName { get { return _FuelKindName; } set { _FuelKindName = value; } }

        private string _FuelKindId;
        /// <summary>
        /// 煤种
        /// </summary>
        public virtual string FuelKindId { get { return _FuelKindId; } set { _FuelKindId = value; } }

        private string _TransportCompanyName;
        /// <summary>
        /// 运输单位
        /// </summary>
        [Description("运输单位")]
        public virtual string TransportCompanyName { get { return _TransportCompanyName; } set { _TransportCompanyName = value; } }

        private string _TransportCompanyId;
        /// <summary>
        /// 运输单位
        /// </summary>
        public virtual string TransportCompanyId { get { return _TransportCompanyId; } set { _TransportCompanyId = value; } }

        private Decimal _IsUse;
        /// <summary>
        /// 有效
        /// </summary>
        public virtual Decimal IsUse { get { return _IsUse; } set { _IsUse = value; } }

        private Decimal _IsFinish;
        /// <summary>
        /// 已完结
        /// </summary>
        public virtual Decimal IsFinish { get { return _IsFinish; } set { _IsFinish = value; } }

        private string _GrossPlace;
        /// <summary>
        /// 毛重地点
        /// </summary>
        public virtual string GrossPlace { get { return _GrossPlace; } set { _GrossPlace = value; } }

        private string _TarePlace;
        /// <summary>
        /// 皮重地点
        /// </summary>
        public virtual string TarePlace { get { return _TarePlace; } set { _TarePlace = value; } }


        private string _Remark;
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get { return _Remark; } set { _Remark = value; } }

        private string _StepName;
        /// <summary>
        /// 所处流程的步骤  入厂、重车、采样、轻车、出厂
        /// </summary>
        public virtual string StepName { get { return _StepName; } set { _StepName = value; } }

        /// <summary>
        /// 接煤地点
        /// </summary>
        public virtual String LoadArea { get; set; }
        /// <summary>
        /// 接煤人
        /// </summary>
        public virtual String Loader { get; set; }
        /// <summary>
        /// 运输单号
        /// </summary>
        public virtual String TransportNo { get; set; }
    }
}
