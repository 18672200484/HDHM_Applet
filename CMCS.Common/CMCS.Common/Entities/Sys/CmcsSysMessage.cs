using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCS.Common.Entities.Sys
{
    /// <summary>
    /// 系统消息提醒
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("cmcstbsysmessage")]
    public class CmcsSysMessage : EntityBase
    {
        /// <summary>
        /// 消息代码
        /// </summary>
        public String MsgCode { get; set; }

        /// <summary>
        /// 消息参数
        /// </summary>
        public String MsgParam { get; set; }

        /// <summary>
        /// 消息时间
        /// </summary>
        public DateTime MsgTime { get; set; }

        /// <summary>
        /// 消息内容（支持Html标签显示）
        /// </summary>
        public String MsgContent { get; set; }

        /// <summary>
        /// 提示方式（默认右下角）：对话框：0、右下角：1
        /// </summary>
        public int MsgWarnType { get; set; }

        /// <summary>
        /// 操作按钮,最多四个,多个用“|”分开 （如：确定|查看|取消）
        /// </summary>
        public String MsgButton { get; set; }

        /// <summary>
        /// 是否自动关闭（默认自动关闭） 0：否 1：是
        /// </summary>
        public int IsAutoClose { get; set; }

        /// <summary>
        /// 消息窗口标题（默认“系统提示”）
        /// </summary>
        public String WindowsTitle { get; set; }

        /// <summary>
        /// 消息状态  默认、处理中、已处理
        /// </summary>
        public String MsgStatus { get; set; }
    }
}
