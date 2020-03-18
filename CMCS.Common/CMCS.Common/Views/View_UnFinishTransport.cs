using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities;
using CMCS.Common.Entities.Sys;

namespace CMCS.Common.Views
{
    /// <summary>
    /// 视图-未完成运输记录视图
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("View_UnFinishTransport")]
    public class View_UnFinishTransport : EntityBase2
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

        private String _CarNumber;
        /// <summary>
        /// 车牌号
        /// </summary>
        public virtual String CarNumber
        {
            get { return _CarNumber; }
            set { _CarNumber = value; }
        }

        private String _EpccardId;
        /// <summary>
        /// ECP卡号
        /// </summary>
        public virtual String EpccardId
        {
            get { return _EpccardId; }
            set { _EpccardId = value; }
        }

    }
}
