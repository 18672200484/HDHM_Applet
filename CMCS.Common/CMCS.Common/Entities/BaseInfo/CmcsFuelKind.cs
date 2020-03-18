using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys; 

namespace CMCS.Common.Entities.BaseInfo
{
    /// <summary>
    /// 基础信息-煤种
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("fultbfuelkind")]
    public class CmcsFuelKind : EntityBase1
    {
        private string _Code;
        /// <summary>
        /// 编码
        /// </summary>
        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }

        private string _Name;
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _ParentId;
        /// <summary>
        /// 父Id
        /// </summary>
        public string ParentId
        {
            get { return _ParentId; }
            set { _ParentId = value; }
        }

        public int Sort { get;set; }

        public string ReMark { get; set; }

        public int IsStop { get; set; }
    } 
}
