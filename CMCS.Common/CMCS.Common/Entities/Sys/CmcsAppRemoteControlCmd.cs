using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCS.Common.Entities.Sys
{
    /// <summary>
    /// 程序远程控制命令
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("CmcsTbAppRemoteControlCmd")]
    public class CmcsAppRemoteControlCmd : EntityBase
    {
        /// <summary>
        /// 程序唯一标识
        /// </summary>
        public String AppIdentifier { get; set; }

        /// <summary>
        /// 命令代码
        /// </summary>
        public String CmdCode { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        public String Param { get; set; }

        /// <summary>
        /// 执行结果
        /// </summary>
        public String ResultCode { get; set; }

        /// <summary>
        /// 数据标识
        /// </summary>
        public Int32 DataFlag { get; set; }
    }
}
