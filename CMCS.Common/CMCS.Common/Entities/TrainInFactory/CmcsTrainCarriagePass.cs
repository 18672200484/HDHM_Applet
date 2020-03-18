using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys; 

namespace CMCS.Common.Entities.TrainInFactory
{
    /// <summary>
    /// 火车车厢通过车号识别表
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("CmcstbTrainCarriagePass")]
    public class CmcsTrainCarriagePass : EntityBase
    {
        /// <summary>
        /// 设备编号
        /// </summary>
        public string MachineCode { get; set; }

        /// <summary>
        /// 车号
        /// </summary>
        public string TrainNumber { get; set; }

        /// <summary>
        /// 通过时间
        /// </summary>
        public DateTime PassTime { get; set; }

        /// <summary>
        /// 方向
        /// </summary>
        public string Direction { get; set; }

        /// <summary>
        /// 顺序
        /// </summary>
        public int OrderNum { get; set; }

        /// <summary>
        /// 车型
        /// </summary>
        public string CarModel { get; set; }

        /// <summary>
        /// 速度
        /// </summary>
        public decimal Speed { get; set; }

        /// <summary>
        /// 标识符
        /// </summary>
        public int DataFlag { get; set; }
    }
}
