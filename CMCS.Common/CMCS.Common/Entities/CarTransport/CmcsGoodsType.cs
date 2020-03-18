// 此代码由 NhGenerator v1.0.9.0 工具生成。

using System;
using System.Collections;
using System.ComponentModel;
using CMCS.Common.Entities.Sys; 

namespace CMCS.Common.Entities.CarTransport
{
    /// <summary>
    /// 汽车智能化-物资类型
    /// </summary>
    [Serializable]
    [Description("物资类型")]
    [CMCS.DapperDber.Attrs.DapperBind("CmcsTbGoodsType")]
    public class CmcsGoodsType : EntityBase1
    {
        private String _ParentId;
        public virtual String ParentId { get { return _ParentId; } set { _ParentId = value; } }

        private String _TreeCode;
        /// <summary>
        /// 节点编码
        /// </summary>
        [Description("节点编码")]
        public virtual String TreeCode { get { return _TreeCode; } set { _TreeCode = value; } }

        private String _GoodsName;
        /// <summary>
        /// 物资名称
        /// </summary>
        [Description("物资名称")]
        public virtual String GoodsName { get { return _GoodsName; } set { _GoodsName = value; } }

        private Int32 _OrderNumber;
        /// <summary>
        /// 顺序号
        /// </summary>
        public virtual Int32 OrderNumber { get { return _OrderNumber; } set { _OrderNumber = value; } }

        private Decimal _IsValid;
        /// <summary>
        /// 有效
        /// </summary>
        public virtual Decimal IsValid { get { return _IsValid; } set { _IsValid = value; } }

        private String _Remark;
        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Remark { get { return _Remark; } set { _Remark = value; } }

    }
}
