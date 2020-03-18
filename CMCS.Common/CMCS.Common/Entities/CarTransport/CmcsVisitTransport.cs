// 此代码由 NhGenerator v1.0.9.0 工具生成。

using System;
using System.Collections;
using CMCS.Common.Entities.Sys; 

namespace CMCS.Common.Entities.CarTransport
{
    /// <summary>
    /// 汽车智能化-来访车辆运输记录
    /// </summary>
    [Serializable]
    [CMCS.DapperDber.Attrs.DapperBind("CmcsTbVisitTransport")]
    public class CmcsVisitTransport : EntityBase1
    {
        private String _AutotruckId;
        /// <summary>
        /// 关联：车辆管理
        /// </summary>
        public virtual String AutotruckId { get { return _AutotruckId; } set { _AutotruckId = value; } }

        private string _SerialNumber;
        /// <summary>
        /// 流水号
        /// </summary>
        public virtual string SerialNumber { get { return _SerialNumber; } set { _SerialNumber = value; } }

        private String _CarNumber;
        /// <summary>
        /// 车号
        /// </summary>
        public virtual String CarNumber { get { return _CarNumber; } set { _CarNumber = value; } }

        private DateTime _InFactoryTime;
        /// <summary>
        /// 入厂时间
        /// </summary>
        public virtual DateTime InFactoryTime { get { return _InFactoryTime; } set { _InFactoryTime = value; } }

        private DateTime _OutFactoryTime;
        /// <summary>
        /// 出厂时间
        /// </summary>
        public virtual DateTime OutFactoryTime { get { return _OutFactoryTime; } set { _OutFactoryTime = value; } }

        private Decimal _IsUse;
        /// <summary>
        /// 有效
        /// </summary>
        public virtual Decimal IsUse { get { return _IsUse; } set { _IsUse = value; } }

        private Decimal _IsFinish;
        /// <summary>
        /// 已完结
        /// </summary>
        public virtual Decimal IsFinish { get { return _IsFinish; } set { _IsFinish = value; } }

        private string _Remark;
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get { return _Remark; } set { _Remark = value; } }

        private string _StepName;
        /// <summary>
        /// 所处流程的步骤  入厂、出厂
        /// </summary>
        public virtual string StepName { get { return _StepName; } set { _StepName = value; } }

    }
}
