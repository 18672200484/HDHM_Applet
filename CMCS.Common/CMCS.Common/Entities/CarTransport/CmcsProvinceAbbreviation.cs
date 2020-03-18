// 此代码由 NhGenerator v1.0.9.0 工具生成。

using System;
using System.Collections;
using CMCS.Common.Entities.Sys;

namespace CMCS.Common.Entities.CarTransport
{
    /// <summary>
    /// 省份简称
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("CmcsTbProvinceAbbreviation")]
    public class CmcsProvinceAbbreviation : EntityBase
    {
        /// <summary>
        /// PaName
        /// </summary>		
        private string _PaName;
        public string PaName
        {
            get { return _PaName; }
            set { _PaName = value; }
        }

        /// <summary>
        /// UseCount
        /// </summary>		
        private int _UseCount;
        public int UseCount
        {
            get { return _UseCount; }
            set { _UseCount = value; }
        }


    }
}