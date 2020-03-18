using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys; 

namespace CMCS.Common.Entities.BaseInfo
{
    /// <summary>
    /// 基础信息-发站
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("fultbstation")]
    public class CmcsStation : EntityBase1
    {
        /// <summary>
        /// 编码
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public String Name { get; set; }

        public int IsStop { get; set; }
    }
}
