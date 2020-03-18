using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CMCS.CommonSynch.Utilities
{
    public class TableSynch
    {
        /// <summary>
        /// 标题
        /// </summary>
        [Description("标题")]
        public string SynchTitle { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        [Description("表名")]
        public string TableName { get; set; }

        /// <summary>
        /// 表名(中文名)
        /// </summary>
        [Description("表名(中文名)")]
        public string TableZNName { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        [Description("主键")]
        public string PrimaryKey { get; set; }

        /// <summary>
        /// 同步标识字段（0未同步 1已同步）
        /// </summary>
        [Description("同步标识字段（0未同步 1已同步）")]
        public string SynchField { get; set; }

        /// <summary>
        /// 同步类型（上传 下达 双向）
        /// </summary>
        [Description("同步类型（上传 下达 双向）")]
        public string SynchType { get; set; }

        /// <summary>
        /// 同步顺序
        /// </summary>
        [Description("同步顺序")]
        public int Sequence { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        [Description("是否启用")]
        public bool Enabled { get; set; }
    }
}
