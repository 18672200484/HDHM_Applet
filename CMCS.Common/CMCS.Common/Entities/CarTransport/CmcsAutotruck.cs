// 此代码由 NhGenerator v1.0.9.0 工具生成。

using System;
using System.Collections;
using System.ComponentModel;
using CMCS.Common.Entities.Sys; 

namespace CMCS.Common.Entities.CarTransport
{
    /// <summary>
    /// 汽车智能化-车辆管理
    /// </summary>
    [Serializable]
    [Description("车辆管理")]
    [CMCS.DapperDber.Attrs.DapperBind("CmcsTbAutotruck")]
    public class CmcsAutotruck : EntityBase1
    {
        private String _EPCCardId;
        /// <summary>
        /// 标签卡 一对一
        /// </summary>
        public virtual String EPCCardId { get { return _EPCCardId; } set { _EPCCardId = value; } }

        private String _CarNumber;
        /// <summary>
        /// 车号
        /// </summary>
        [Description("车号")]
        public virtual String CarNumber { get { return _CarNumber; } set { _CarNumber = value; } }

        private String _Driver;
        /// <summary>
        /// 司机
        /// </summary>
        public virtual String Driver { get { return _Driver; } set { _Driver = value; } }

        private String _CellPhoneNumber;
        /// <summary>
        /// 电话
        /// </summary>
        public virtual String CellPhoneNumber { get { return _CellPhoneNumber; } set { _CellPhoneNumber = value; } }

        private int _CarriageLength;
        /// <summary>
        /// 车厢长(毫米)
        /// </summary>
        [Description("车厢长")]
        public virtual int CarriageLength { get { return _CarriageLength; } set { _CarriageLength = value; } }

        private int _CarriageWidth;
        /// <summary>
        /// 车厢宽(毫米)
        /// </summary>
        [Description("车厢宽")]
        public virtual int CarriageWidth { get { return _CarriageWidth; } set { _CarriageWidth = value; } }

		private int _CarriageHeight;
		/// <summary>
		/// 车厢高(毫米)
		/// </summary>
		[Description("车厢高")]
		public virtual int CarriageHeight { get { return _CarriageHeight; } set { _CarriageHeight = value; } }

		private int _CarriageBottomToFloor;
        /// <summary>
        /// 车厢底部到地面高(毫米)
        /// </summary>
        [Description("车厢底部到地面高")]
        public virtual int CarriageBottomToFloor { get { return _CarriageBottomToFloor; } set { _CarriageBottomToFloor = value; } }

        private int _RightObstacle1;
        /// <summary>
        /// 右侧-车厢尾端到第1根拉筋距离(毫米)
        /// </summary>
        public virtual int RightObstacle1 { get { return _RightObstacle1; } set { _RightObstacle1 = value; } }

        private int _RightObstacle2;
        /// <summary>
        /// 右侧-车厢尾端到第2根拉筋距离(毫米)
        /// </summary>
        public virtual int RightObstacle2 { get { return _RightObstacle2; } set { _RightObstacle2 = value; } }

        private int _RightObstacle3;
        /// <summary>
        /// 右侧-车厢尾端到第3根拉筋距离(毫米)
        /// </summary>
        public virtual int RightObstacle3 { get { return _RightObstacle3; } set { _RightObstacle3 = value; } }

        private int _RightObstacle4;
        /// <summary>
        /// 右侧-车厢尾端到第4根拉筋距离(毫米)
        /// </summary>
        public virtual int RightObstacle4 { get { return _RightObstacle4; } set { _RightObstacle4 = value; } }

        private int _RightObstacle5;
        /// <summary>
        /// 右侧-车厢尾端到第5根拉筋距离(毫米)
        /// </summary>
        public virtual int RightObstacle5 { get { return _RightObstacle5; } set { _RightObstacle5 = value; } }

        private int _RightObstacle6;
        /// <summary>
        /// 右侧-车厢尾端到第6根拉筋距离(毫米)
        /// </summary>
        public virtual int RightObstacle6 { get { return _RightObstacle6; } set { _RightObstacle6 = value; } }

        private int _LeftObstacle1;
        /// <summary>
        /// 左侧-车厢尾端到第1根拉筋距离(毫米)
        /// </summary>
        [Description("车厢尾端到第1根拉筋距离")]
        public virtual int LeftObstacle1 { get { return _LeftObstacle1; } set { _LeftObstacle1 = value; } }

        private int _LeftObstacle2;
        /// <summary>
        /// 左侧-车厢尾端到第2根拉筋距离(毫米)
        /// </summary>
        [Description("车厢尾端到第2根拉筋距离")]
        public virtual int LeftObstacle2 { get { return _LeftObstacle2; } set { _LeftObstacle2 = value; } }

        private int _LeftObstacle3;
        /// <summary>
        /// 左侧-车厢尾端到第3根拉筋距离(毫米)
        /// </summary>
        [Description("车厢尾端到第3根拉筋距离")]
        public virtual int LeftObstacle3 { get { return _LeftObstacle3; } set { _LeftObstacle3 = value; } }

        private int _LeftObstacle4;
        /// <summary>
        /// 左侧-车厢尾端到第4根拉筋距离(毫米)
        /// </summary>
        [Description("车厢尾端到第4根拉筋距离")]
        public virtual int LeftObstacle4 { get { return _LeftObstacle4; } set { _LeftObstacle4 = value; } }

        private int _LeftObstacle5;
        /// <summary>
        /// 左侧-车厢尾端到第5根拉筋距离(毫米)
        /// </summary>
        [Description("车厢尾端到第5根拉筋距离")]
        public virtual int LeftObstacle5 { get { return _LeftObstacle5; } set { _LeftObstacle5 = value; } }

        private int _LeftObstacle6;
        /// <summary>
        /// 左侧-车厢尾端到第6根拉筋距离(毫米)
        /// </summary>
        [Description("车厢尾端到第6根拉筋距离")]
        public virtual int LeftObstacle6 { get { return _LeftObstacle6; } set { _LeftObstacle6 = value; } }

        private int _IsUse;
        /// <summary>
        /// 是否启用
        /// </summary>
        public virtual int IsUse { get { return _IsUse; } set { _IsUse = value; } }

        private String _ReMark;
        /// <summary>
        /// 备注
        /// </summary>
        public virtual String ReMark { get { return _ReMark; } set { _ReMark = value; } }

        private String _CarType;
        /// <summary>
        /// 车类型
        /// </summary>
        [Description("车辆类型")]
        public virtual String CarType { get { return _CarType; } set { _CarType = value; } }
    }
}
