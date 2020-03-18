// 此代码由 NhGenerator v1.0.9.0 工具生成。

using System;
using System.Collections;
using CMCS.Common.Entities.Sys;

namespace CMCS.Common.Entities.Fuel
{
    /// <summary>
    /// 入厂煤来煤预报明细
    /// </summary>
    [Serializable]
    [CMCS.DapperDber.Attrs.DapperBind("FultbLMYBDetail")]
    public class CmcsLMYBDetail : EntityBase1
    {
        private String _CarNumber;
        /// <summary>
        /// 车号
        /// </summary>
        public virtual String CarNumber { get { return _CarNumber; }  set { _CarNumber = value; }}

        private String _LMYBId;
        /// <summary>
        /// 来煤预报Id
        /// </summary>
        public virtual String LMYBId { get { return _LMYBId; } set { _LMYBId = value; } }

    }
}
