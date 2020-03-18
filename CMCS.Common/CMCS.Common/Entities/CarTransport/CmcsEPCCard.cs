// 此代码由 NhGenerator v1.0.9.0 工具生成。

using System;
using System.Collections;
using System.ComponentModel;
using CMCS.Common.Entities.Sys; 

namespace CMCS.Common.Entities.CarTransport
{
    /// <summary>
    /// 汽车智能化-标签卡
    /// </summary>
    [Serializable]
    [Description("标签卡管理")]
    [CMCS.DapperDber.Attrs.DapperBind("CmcstbEPCCard")]
    public class CmcsEPCCard : EntityBase1
    {
        private String _CardNumber;
        /// <summary>
        /// 卡号（可见的）
        /// </summary>
        [Description("卡号")]
        public virtual String CardNumber { get { return _CardNumber; }  set { _CardNumber = value; }}

        private String _TagId;
        /// <summary>
        /// 标签号
        /// </summary>
        [Description("标签号")]
        public virtual String TagId { get { return _TagId; }  set { _TagId = value; }}

    }
}
