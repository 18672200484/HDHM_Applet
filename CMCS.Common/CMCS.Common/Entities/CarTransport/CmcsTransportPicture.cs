// 此代码由 NhGenerator v1.0.9.0 工具生成。

using System;
using System.Collections;
using CMCS.Common.Entities.Sys; 
//

namespace CMCS.Common.Entities.CarTransport
{
    /// <summary>
    /// 汽车智能化-抓拍照片
    /// </summary>
    [Serializable]
    [CMCS.DapperDber.Attrs.DapperBind("CmcsTbTransportPicture")]
    public class CmcsTransportPicture : EntityBase
    {
        private String _TransportId;
        /// <summary>
        /// 运输纪录Id
        /// </summary>
        public virtual String TransportId { get { return _TransportId; }  set { _TransportId = value; }}

        private String _CaptureType;
        /// <summary>
        /// 抓拍类型
        /// </summary>
        public virtual String CaptureType { get { return _CaptureType; }  set { _CaptureType = value; }}

        private DateTime _CaptureTime;
        /// <summary>
        /// 抓拍时间
        /// </summary>
        public virtual DateTime CaptureTime { get { return _CaptureTime; } set { _CaptureTime = value; } }

        private String _PicturePath;
        /// <summary>
        /// 照片访问路径
        /// </summary>
        public virtual String PicturePath { get { return _PicturePath; }  set { _PicturePath = value; }}

    }
}
