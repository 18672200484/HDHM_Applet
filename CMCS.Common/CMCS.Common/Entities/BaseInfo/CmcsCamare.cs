// 此代码由 NhGenerator v1.0.9.0 工具生成。

using System;
using System.Collections;
using CMCS.Common.Entities.Sys;

namespace CMCS.Common.Entities.BaseInfo
{
    /// <summary>
    /// 基础信息-摄像机
    /// </summary>
    [Serializable]
    [CMCS.DapperDber.Attrs.DapperBind("CMCSTBCAMERA")]
    public class CmcsCamare : EntityBase1
    {
        private String _NodeCode;
        /// <summary>
        /// 编码
        /// </summary>
        public virtual String NodeCode { get { return _NodeCode; } set { _NodeCode = value; } }

        private String _Name;
        /// <summary>
        /// 名称
        /// </summary>
        public virtual String Name { get { return _Name; } set { _Name = value; } }

        private String _Ip;
        /// <summary>
        /// ip
        /// </summary>
        public virtual String Ip { get { return _Ip; } set { _Ip = value; } }

        private int _Port;
        /// <summary>
        /// 端口号
        /// </summary>
        public virtual int Port { get { return _Port; } set { _Port = value; } }

        private int _Channel;
        /// <summary>
        /// 通道号
        /// </summary>
        public virtual int Channel { get { return _Channel; } set { _Channel = value; } }

        private String _UserName;
        /// <summary>
        /// 用户名
        /// </summary>
        public virtual String UserName { get { return _UserName; } set { _UserName = value; } }

        private String _Password;
        /// <summary>
        /// 密码
        /// </summary>
        public virtual String Password { get { return _Password; } set { _Password = value; } }

        private String _Type;
        /// <summary>
        /// 类型
        /// </summary>
        public virtual String Type { get { return _Type; } set { _Type = value; } }

        private Int32 _Sequence;
        /// <summary>
        /// 顺序号
        /// </summary>
        public virtual Int32 Sort { get { return _Sequence; } set { _Sequence = value; } }

        private IList _ChildVedios;
        [DapperDber.Attrs.DapperIgnore]
        public virtual IList ChildVedios { get { return _ChildVedios; } set { _ChildVedios = value; } }

        private String _ParentId;
        public virtual String ParentId { get { return _ParentId; } set { _ParentId = value; } }

        private String _Remark;
        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Remark { get { return _Remark; } set { _Remark = value; } }


        private String _EquipmentCode;
        /// <summary>
        /// 设备编码
        /// </summary>
        public virtual String EquipmentCode { get { return _EquipmentCode; } set { _EquipmentCode = value; } }
    }
}
