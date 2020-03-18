// 此代码由 NhGenerator v1.0.9.0 工具生成。

using System;
using System.Collections;
using CMCS.Common.Entities.Sys;
//

namespace CMCS.Common.Entities.CarTransport
{
    /// <summary>
    /// 汽车智能化-汽车入厂路线
    /// </summary>
    [Serializable]
    [CMCS.DapperDber.Attrs.DapperBind("CMCSTBTRUCKINFACTORYWAY")]
    public class CmcsTruckInFactoryWay : EntityBase1
    {
        private String _WayType;
        /// <summary>
        /// 流程方式
        /// </summary>
        public virtual String WayType { get { return _WayType; }  set { _WayType = value; }}

        private String _WayLine;
        /// <summary>
        /// 流程线
        /// </summary>
        public virtual String WayLine { get { return _WayLine; }  set { _WayLine = value; }}
          
        private Int32 _IsUse;
        /// <summary>
        /// 是否有效
        /// </summary>
        public virtual Int32 IsUse { get { return _IsUse; } set { _IsUse = value; } }

    }
}
