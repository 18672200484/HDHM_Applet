
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys; 

namespace CMCS.Common.Entities.iEAA
{
    /// <summary>
    /// 编码管理
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("sys_codes")]
    public class CodeKind : EntityBase1
    {
        private string _CnName;
        /// <summary>
        /// 编码名称
        /// </summary>
        public string CnName { get { return _CnName; } set { _CnName = value; } }
    }
}
