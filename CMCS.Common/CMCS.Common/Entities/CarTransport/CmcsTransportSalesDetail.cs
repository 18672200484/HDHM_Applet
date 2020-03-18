// 此代码由 NhGenerator v1.0.7.0 工具生成。

using System;
using System.Collections;
//
using CMCS.Common.Entities.Sys;

namespace CMCS.Common.Entities.CarTransport
{
    [Serializable]
    [CMCS.DapperDber.Attrs.DapperBind("FULTBQCXSYBDETAIL")]
    public class CmcsTransportSalesDetail : EntityBase1
    {
        private String _StorageName;
        /// <summary>
        /// 成品仓
        /// </summary>
        public virtual String StorageName { get { return _StorageName; } set { _StorageName = value; } }

        private String _FuelKind;
        /// <summary>
        /// 煤种
        /// </summary>
        public virtual String FuelKind { get { return _FuelKind; } set { _FuelKind = value; } }

        private Decimal _StorageNum;
        /// <summary>
        /// 存煤量
        /// </summary>
        public virtual Decimal StorageNum { get { return _StorageNum; } set { _StorageNum = value; } }

        private String _StorageQuality;
        /// <summary>
        /// 煤质
        /// </summary>
        public virtual String StorageQuality { get { return _StorageQuality; } set { _StorageQuality = value; } }


        private String _Remark;
        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Remark { get { return _Remark; } set { _Remark = value; } }

        private String _IsUpload;
        /// <summary>
        /// 是否上传
        /// </summary>
        public virtual String IsUpload { get { return _IsUpload; } set { _IsUpload = value; } }
        
        private String _DataFrom;
        /// <summary>
        /// 数据来源
        /// </summary>
        public virtual String DataFrom { get { return _DataFrom; } set { _DataFrom = value; } }
        private String _LMYBId;
        /// <summary>
        /// 销售预报Id
        /// </summary>
        public virtual String LMYBId { get { return _LMYBId; } set { _LMYBId = value; } }


        

    }
}
