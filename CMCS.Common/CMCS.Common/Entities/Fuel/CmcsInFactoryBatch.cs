using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys;

namespace CMCS.Common.Entities.Fuel
{
    /// <summary>
    /// 入厂煤批次表
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("FulTbInfactoryBatch")]
    public class CmcsInFactoryBatch : EntityBase1
    {
        /// <summary>
        /// 入厂批次号
        /// </summary>
        public virtual String Batch { get; set; }

        /// <summary>
        /// 批次类型 汽车、火车、船运
        /// </summary>
        public virtual String TransportTypeName { get; set; }

        /// <summary>
        /// 供煤单位
        /// </summary>
        public virtual string SupplierId { get; set; }

        /// <summary>
        /// 托运单位
        /// </summary>
        public virtual string SendSupplierId { get; set; }

        /// <summary>
        /// 矿点 多对一
        /// </summary>
        public virtual string MineId { get; set; }

        /// <summary>
        /// 关联：煤种名称
        /// </summary>
        public virtual string FuelKindName { get; set; }

        /// <summary>
        /// 关联：煤种Id
        /// </summary>
        public virtual string FuelKindId { get; set; }

        /// <summary>
        /// 发货时间
        /// </summary>
        public DateTime DispatchDate { get; set; }

        /// <summary>
        /// 预计到达时间
        /// </summary>
        public DateTime PlanArriveDate { get; set; }

        /// <summary>
        /// 实际到达时间
        /// </summary>
        public virtual DateTime FactArriveDate { get; set; }

        /// <summary>
        /// 归批时间
        /// </summary>
        public DateTime BackBatchDate { get; set; }

        /// <summary>
        /// 接车人员
        /// </summary>
        public virtual String Runner { get; set; }

        /// <summary>
        /// 接车时间
        /// </summary>
        public virtual DateTime RunDate { get; set; }

        /// <summary>
        /// 矿发量(吨)
        /// </summary>
        public Decimal TicketQty { get; set; }

        /// <summary>
        /// 净重(吨)
        /// </summary>
        public Decimal SuttleQty { get; set; }

        /// <summary>
        /// 扣矸(吨)
        /// </summary>
        public Decimal KgQty { get; set; }

        /// <summary>
        /// 扣水(吨)
        /// </summary>
        public Decimal KsQty { get; set; }

        /// <summary>
        /// 验收量(吨)
        /// </summary>
        public Decimal CheckQty { get; set; }

        /// <summary>
        /// 路损(吨)
        /// </summary>
        public Decimal RailLost { get; set; }

        /// <summary>
        /// 盈亏(吨)
        /// </summary>
        public Decimal MarginQty { get; set; }

        /// <summary>
        /// 火车:车皮数.汽车:车辆数
        /// </summary>
        public Int32 TransportNumber { get; set; }

        /// <summary>
        /// 状态 0：初始 1：计量审核结束
        /// </summary>
        public Int32 IsQty { get; set; }

        /// <summary>
        /// 状态 0：初始 1：质检化验结束
        /// </summary>
        public Int32 IsAssay { get; set; }

        /// <summary>
        /// 是否堆放完毕 状态 0：未堆放 1：部分堆放 2堆放完成
        /// </summary>
        public Int32 IsDeposit { get; set; }

        /// <summary>
        /// 是否拆分 默认为0未拆分；1已拆分
        /// </summary>
        public Int32 IsRemove { get; set; }

        /// <summary>
        /// 被拆分的批次id
        /// </summary>
        public virtual string ParentRemoveBatchId { get; set; }

        /// <summary>
        /// 批次创建类型 0 手动录入 1 智能化自动创建
        /// </summary>
        public virtual Int32 BatchCreateType { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Remark { get; set; }

        /// <summary>
        /// 数据来源
        /// </summary>
        public String DataFrom { get; set; }

        /// <summary>
        /// 发站id
        /// </summary>
        public virtual string StationId { get; set; }

        /// <summary>
        /// 调运计划ID
        /// </summary>
        public String LmybId { get; set; }

        /// <summary>
        /// 是否删除 0已删除 1 未删除
        /// </summary>
        public Int32 IsDeleted { get; set; }
    }
}
