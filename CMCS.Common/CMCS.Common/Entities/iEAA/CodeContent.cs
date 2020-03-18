
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys;
using CMCS.DapperDber.Attrs; 

namespace CMCS.Common.Entities.iEAA
{
    /// <summary>
    /// 编码管理
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("sys_codevalues")]
    public class CodeContent
    {
        [DapperPrimaryKey]
        public string Id { get; set; }

        private string _CodeId;
        /// <summary>
        /// 主编码ID
        /// </summary>
        public string CodeId { get { return _CodeId; } set { _CodeId = value; } }

        private string _Code;
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get { return _Code; } set { _Code = value; } }

        private string _Value;
        /// <summary>
        /// 编码内容
        /// </summary>
        public string Value { get { return _Value; } set { _Value = value; } }

        private int _Sort;
        /// <summary>
        /// 顺序
        /// </summary>
        public int Sort { get { return _Sort; } set { _Sort = value; } }
    }
}
