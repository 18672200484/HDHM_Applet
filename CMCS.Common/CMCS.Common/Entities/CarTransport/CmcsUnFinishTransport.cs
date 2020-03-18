// 此代码由 NhGenerator v1.0.9.0 工具生成。

using System;
using System.Collections;
using CMCS.Common.Entities.Sys; 

namespace CMCS.Common.Entities.CarTransport
{
    /// <summary>
    /// 汽车智能化-未完成运输记录
    /// </summary>
    [Serializable]
    [CMCS.DapperDber.Attrs.DapperBind("CmcsTbUnFinishTransport")]
    public class CmcsUnFinishTransport : EntityBase
    {
        private String _TransportId;
        /// <summary>
        /// 运输记录Id
        /// </summary>
        public virtual String TransportId { get { return _TransportId; } set { _TransportId = value; } }

        private String _CarType;
        /// <summary>
        /// 车类型
        /// </summary>
        public virtual String CarType { get { return _CarType; } set { _CarType = value; } }

        private String _AutotruckId;
        /// <summary>
        /// 车Id
        /// </summary>
        public virtual String AutotruckId { get { return _AutotruckId; } set { _AutotruckId = value; } }

        private String _PrevPlace;
        /// <summary>
        /// 上个所在地点
        /// </summary>
        public virtual String PrevPlace { get { return _PrevPlace; } set { _PrevPlace = value; } }

    }
}
