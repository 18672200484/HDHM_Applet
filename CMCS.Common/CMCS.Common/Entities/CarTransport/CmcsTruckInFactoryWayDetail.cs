// 此代码由 NhGenerator v1.0.9.0 工具生成。

using System;
using System.Collections;
using CMCS.Common.Entities.Sys;
//

namespace CMCS.Common.Entities.CarTransport
{
    /// <summary>
    /// 汽车智能化-汽车入厂路线明细
    /// </summary>
    [Serializable]
    [CMCS.DapperDber.Attrs.DapperBind("CMCSTBTRUCKINFACTORYWAYDETAIL")]
    public class CmcsTruckInFactoryWayDetail : EntityBase1
    {
        private String _StepName;
        /// <summary>
        /// 步骤名字
        /// </summary>
        public virtual String StepName { get { return _StepName; } set { _StepName = value; } }

        private Int32 _StepNumber;
        /// <summary>
        /// 步骤编号
        /// </summary>
        public virtual Int32 StepNumber { get { return _StepNumber; } set { _StepNumber = value; } }

        private String _WayPalce;
        /// <summary>
        /// 流程位置
        /// </summary>
        public virtual String WayPalce { get { return _WayPalce; } set { _WayPalce = value; } }

        private String _TruckInFactoryWayId;
        /// <summary>
        /// 路线主表Id
        /// </summary>
        public virtual String TruckInFactoryWayId { get { return _TruckInFactoryWayId; } set { _TruckInFactoryWayId = value; } }
    }
}
