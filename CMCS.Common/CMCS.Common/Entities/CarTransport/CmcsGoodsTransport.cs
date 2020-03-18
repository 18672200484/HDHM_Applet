// 此代码由 NhGenerator v1.0.9.0 工具生成。

using System;
using System.Collections;
using System.ComponentModel;
using CMCS.Common.Entities.Sys; 

namespace CMCS.Common.Entities.CarTransport
{
    /// <summary>
    /// 汽车智能化-其他物资运输记录
    /// </summary>
    [Serializable]
    [Description("其他物资运输记录")]
    [CMCS.DapperDber.Attrs.DapperBind("CmcsTbGoodsTransport")]
    public class CmcsGoodsTransport : EntityBase1
    {
        private string _AutotruckId;
        /// <summary>
        /// 车辆
        /// </summary>
        public virtual string AutotruckId { get { return _AutotruckId; } set { _AutotruckId = value; } }

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

        private Decimal _FirstWeight;
        /// <summary>
        /// 重量一(吨)
        /// </summary>
        [Description("重量一")]
        public virtual Decimal FirstWeight { get { return _FirstWeight; } set { _FirstWeight = value; } }

        private Decimal _SecondWeight;
        /// <summary>
        /// 重量二(吨)
        /// </summary>
        [Description("重量二")]
        public virtual Decimal SecondWeight { get { return _SecondWeight; } set { _SecondWeight = value; } }

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

        private DateTime _FirstTime;
        /// <summary>
        /// 第一次称重时间
        /// </summary>
        [Description("第一次称重时间")]
        public virtual DateTime FirstTime { get { return _FirstTime; } set { _FirstTime = value; } }

        private DateTime _SecondTime;
        /// <summary>
        /// 第二次称重时间
        /// </summary>
        [Description("第二次称重时间")]
        public virtual DateTime SecondTime { get { return _SecondTime; } set { _SecondTime = value; } }

        private DateTime _OutFactoryTime;
        /// <summary>
        /// 出厂时间
        /// </summary>
        public virtual DateTime OutFactoryTime { get { return _OutFactoryTime; } set { _OutFactoryTime = value; } }

        private String _SupplyUnitId;
        /// <summary>
        /// 发货单位
        /// </summary>
        public virtual String SupplyUnitId { get { return _SupplyUnitId; } set { _SupplyUnitId = value; } }

        private String _SupplyUnitName;
        /// <summary>
        /// 发货单位
        /// </summary>
        [Description("发货单位")]
        public virtual String SupplyUnitName { get { return _SupplyUnitName; } set { _SupplyUnitName = value; } }

        private String _ReceiveUnitId;
        /// <summary>
        /// 收货单位
        /// </summary>
        public virtual String ReceiveUnitId { get { return _ReceiveUnitId; } set { _ReceiveUnitId = value; } }

        private String _ReceiveUnitName;
        /// <summary>
        /// 收货单位
        /// </summary>
        [Description("收货单位")]
        public virtual String ReceiveUnitName { get { return _ReceiveUnitName; } set { _ReceiveUnitName = value; } }

        private String _GoodsTypeId;
        /// <summary>
        /// 运输单位
        /// </summary>
        public virtual String GoodsTypeId { get { return _GoodsTypeId; } set { _GoodsTypeId = value; } }

        private String _GoodsTypeName;
        /// <summary>
        /// 运输单位
        /// </summary>
        [Description("运输单位")]
        public virtual String GoodsTypeName { get { return _GoodsTypeName; } set { _GoodsTypeName = value; } }

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

        private string _Remark;
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get { return _Remark; } set { _Remark = value; } }

        private string _FirstPlace;
        /// <summary>
        /// 重量一地点
        /// </summary>
        public virtual string FirstPlace { get { return _FirstPlace; } set { _FirstPlace = value; } }

        private string _SecondPlace;
        /// <summary>
        /// 重量二地点
        /// </summary>
        public virtual string SecondPlace { get { return _SecondPlace; } set { _SecondPlace = value; } }

        private string _StepName;
        /// <summary>
        /// 所处流程的步骤  入厂、重车、轻车、出厂
        /// </summary>
        public virtual string StepName { get { return _StepName; } set { _StepName = value; } }

    }
}
