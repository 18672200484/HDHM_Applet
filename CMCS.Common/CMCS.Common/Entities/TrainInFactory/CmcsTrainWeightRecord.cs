using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys;

namespace CMCS.Common.Entities.TrainInFactory
{
    /// <summary>
    /// 火车车厢入厂记录表
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("cmcstbtrainweightrecord")]
    public class CmcsTrainWeightRecord : EntityBase
    {
        /// <summary>
        /// 供煤单位
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// 矿点
        /// </summary>
        public string MineName { get; set; }

        /// <summary>
        /// 煤种
        /// </summary>
        public string FuelKind { get; set; }

        /// <summary>
        /// 发站
        /// </summary>
        public string StationName { get; set; }

        /// <summary>
        /// 第三方主键
        /// </summary>
        public string PKID { get; set; }

        /// <summary>
        /// 设备编号
        /// </summary>
        public String MachineCode { get; set; }

        /// <summary>
        /// 入厂顺序，自增
        /// </summary>
        public Int32 OrderNumber { get; set; }

        /// <summary>
        /// 车号
        /// </summary>
        public String TrainNumber { get; set; }

        /// <summary>
        /// 车型
        /// </summary>
        public String TrainType { get; set; }

        /// <summary>
        /// 矿发量(吨)
        /// </summary>
        public Decimal TicketWeight { get; set; }

        /// <summary>
        /// 毛重(吨)
        /// </summary>
        public Decimal GrossWeight { get; set; }

        /// <summary>
        /// 皮重(吨)
        /// </summary>
        public Decimal SkinWeight { get; set; }

        /// <summary>
        /// 净重(吨)
        /// </summary>
        public Decimal StandardWeight { get; set; }

        /// <summary>
        /// 车速
        /// </summary>
        public Decimal Speed { get; set; }

        /// <summary>
        /// 过衡人
        /// </summary>
        public String MesureMan { get; set; }

        /// <summary>
        /// 入厂时间
        /// </summary>
        public DateTime ArriveTime { get; set; }

        /// <summary>
        /// 毛重时间
        /// </summary>
        public DateTime GrossTime { get; set; }

        /// <summary>
        /// 皮重时间
        /// </summary>
        public DateTime SkinTime { get; set; }

        /// <summary>
        /// 出厂时间
        /// </summary>
        public DateTime LeaveTime { get; set; }

        /// <summary>
        /// 卸车时间
        /// </summary>
        public DateTime UnloadTime { get; set; }

        /// <summary>
        /// 翻车机编号
        /// </summary>
        public virtual String TrainTipperMachineCode { get; set; }

        /// <summary>
        /// 翻车标识 已翻、待翻
        /// </summary>
        public virtual String IsTurnover { get; set; }

        /// <summary>
        /// 数据标识
        /// </summary>
        public Int32 DataFlag { get; set; } 
    }
}
