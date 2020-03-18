using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys;

namespace CMCS.DumblyConcealer.Tasks.DataHandler.Entities
{
    /// <summary>
    /// 门禁记录表
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("CmcstbGuardInfo")]
    public class CmcsGuardInfo : EntityBase1
    {
        /// <summary>
        /// 刷卡时间
        /// </summary>
        public DateTime F_ReadDate { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public string F_ConsumerId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string F_ConsumerName { get; set; }

        /// <summary>
        /// 进出状态 1:进 0:出
        /// </summary>
        public string F_InOut { get; set; }

        /// <summary>
        /// 门id
        /// </summary>
        public string F_ReaderId { get; set; }

        /// <summary>
        /// 门名称
        /// </summary>
        public string F_ReaderName { get; set; }

        /// <summary>
        /// 数据来源
        /// </summary>
        public string DataFrom { get; set; }

        /// <summary>
        /// 第三方数据id
        /// </summary>
        public string NId { get; set; }
    }
}
