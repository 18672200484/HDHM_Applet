using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCS.Common.Entities.Sys
{
    /// <summary>
    /// 操作日志确认记录表
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("CmcstbConfirmOperationLog")]
    public class CmcsConfirmOperationLog : EntityBase
    {
        private string appIdentifier;
        /// <summary>
        /// 程序唯一标识
        /// </summary>
        public string AppIdentifier
        {
            get { return appIdentifier; }
            set { appIdentifier = value; }
        }

        /// <summary>
        /// 操作人
        /// </summary>
        public string OperMan { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperTime { get; set; }

        /// <summary>
        /// 操作内容
        /// </summary>
        public string OperContent { get; set; }

        /// <summary>
        /// 操作原因
        /// </summary>
        public string OperCause { get; set; }
    }
}
