using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCS.Common.Entities.Sys
{
    /// <summary>
    /// 通用修改日志记录
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("CMCSTbModifyLog")]
    public class CmcsModifyLog : EntityBase
    {
        /// <summary>
        /// 程序唯一标识
        /// </summary>
        public string AppIdentifier { get; set; }
        /// <summary>
        /// 电脑IP
        /// </summary>
        public string MoudleIP { get; set; }
        /// <summary>
        /// 模块名称
        /// </summary>
        public string MoudleName { get; set; }
        /// <summary>
        /// 修改项名称(中文)
        /// </summary>
        public string ModifyItemCn { get; set; }
        /// <summary>
        /// 修改项名称(英文)
        /// </summary>
        public string ModifyItemEn { get; set; }
        /// <summary>
        /// 业务记录id
        /// </summary>
        public string ModifyId { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifyTime { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string ModifyUser { get; set; }
        /// <summary>
        /// 修改原因
        /// </summary>
        public string ModifyCause { get; set; }
        /// <summary>
        /// 前值
        /// </summary>
        public string OldValue { get; set; }
        /// <summary>
        /// 新值
        /// </summary>
        public string NewValue { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
