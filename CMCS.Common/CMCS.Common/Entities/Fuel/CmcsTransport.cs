using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys;

namespace CMCS.Common.Entities.Fuel
{
    /// <summary>
    /// 入厂煤车次明细表
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("FulTbTransport")]
    public class CmcsTransport : EntityBase1
    {
        /// <summary>
        /// 关联：批次
        /// </summary>
        public string InFactoryBatchId { get; set; }

        /// <summary>
        /// 第三方主键
        /// </summary>
        public string PKID { get; set; }

        /// <summary>
        /// 车船号
        /// </summary>
        public String TransportNo { get; set; }

        /// <summary>
        /// 入厂时间
        /// </summary>
        public DateTime InfactoryTime { get; set; }

        /// <summary>
        /// 出厂时间
        /// </summary>
        public DateTime OutfactoryTime { get; set; }

        /// <summary>
        /// 毛重时间
        /// </summary>
        public DateTime ArriveDate { get; set; }

        /// <summary>
        /// 回皮时间
        /// </summary>
        public DateTime TareDate { get; set; }

        /// <summary>
        /// 矿发量(吨)
        /// </summary>
        public Decimal TicketQty { get; set; }

        /// <summary>
        /// 毛重(吨)
        /// </summary>
        public Decimal GrossQty { get; set; }

        /// <summary>
        /// 皮重(吨)
        /// </summary>
        public Decimal SkinQty { get; set; }

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
        /// 过衡人
        /// </summary>
        public String MeasureMan { get; set; }

        /// <summary>
        /// 入厂顺序
        /// </summary>
        public Int32 OrderNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Remark { get; set; }

        /// <summary>
        /// 数据来源
        /// </summary>
        public String DataFrom { get; set; }

        /// <summary>
        /// 是否删除 0已删除 1 未删除
        /// </summary>
        public Int32 IsDeleted { get; set; }
    }
}
