// 此代码由 NhGenerator v1.0.9.0 工具生成。

using System;
using System.Collections;
using CMCS.Common.Entities.Sys; 

namespace CMCS.Common.Entities.CarTransport
{
    /// <summary>
    /// 汽车智能化-供货、收货单位
    /// </summary>
    [Serializable]
    [CMCS.DapperDber.Attrs.DapperBind("CmcsTbSupplyReceive")]
    public class CmcsSupplyReceive : EntityBase1
    {
        private String _UnitName;
        /// <summary>
        /// 单位名称
        /// </summary>
        public virtual String UnitName { get { return _UnitName; }  set { _UnitName = value; }}

        private Int32 _IsValid;
        /// <summary>
        /// 是否启用
        /// </summary>
        public virtual Int32 IsValid { get { return _IsValid; }  set { _IsValid = value; }}

        private String _Remark;
        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Remark { get { return _Remark; }  set { _Remark = value; }}

    }
}
