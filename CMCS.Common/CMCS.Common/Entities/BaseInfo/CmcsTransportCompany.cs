using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys; 

namespace CMCS.Common.Entities.BaseInfo
{
    /// <summary>
    /// 基础信息-运输单位
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("FulTbTransportCompany")]
    public class CmcsTransportCompany : EntityBase1
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

        private int _IsStop;
        /// <summary>
        /// 是否启用
        /// </summary>
        public Int32 IsStop
        {
            get { return _IsStop; }
            set { _IsStop = value; }
        }
    }
}
