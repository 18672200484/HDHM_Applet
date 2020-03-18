// 此代码由 NhGenerator v1.0.9.0 工具生成。

using System;
using System.Collections;
using CMCS.Common.Entities.Sys; 

namespace CMCS.Common.Entities.CarTransport
{
    /// <summary>
    /// 汽车智能化-车辆管理
    /// </summary>
    [Serializable]
    [CMCS.DapperDber.Attrs.DapperBind("CmcsTbCarModel")]
    public class CmcsCarModel : EntityBase1
    {
        private String _ModelName;
        /// <summary>
        /// 车型
        /// </summary>
        public virtual String ModelName { get { return _ModelName; } set { _ModelName = value; } }

        private int _CarriageLength;
        /// <summary>
        /// 车厢长(毫米)
        /// </summary>
        public virtual int CarriageLength { get { return _CarriageLength; } set { _CarriageLength = value; } }

        private int _CarriageWidth;
        /// <summary>
        /// 车厢宽(毫米)
        /// </summary>
        public virtual int CarriageWidth { get { return _CarriageWidth; } set { _CarriageWidth = value; } }

        private int _CarriageBottomToFloor;
        /// <summary>
        /// 车厢底部到地面高(毫米)
        /// </summary>
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
        public virtual int LeftObstacle1 { get { return _LeftObstacle1; } set { _LeftObstacle1 = value; } }

        private int _LeftObstacle2;
        /// <summary>
        /// 左侧-车厢尾端到第2根拉筋距离(毫米)
        /// </summary>
        public virtual int LeftObstacle2 { get { return _LeftObstacle2; } set { _LeftObstacle2 = value; } }

        private int _LeftObstacle3;
        /// <summary>
        /// 左侧-车厢尾端到第3根拉筋距离(毫米)
        /// </summary>
        public virtual int LeftObstacle3 { get { return _LeftObstacle3; } set { _LeftObstacle3 = value; } }

        private int _LeftObstacle4;
        /// <summary>
        /// 左侧-车厢尾端到第4根拉筋距离(毫米)
        /// </summary>
        public virtual int LeftObstacle4 { get { return _LeftObstacle4; } set { _LeftObstacle4 = value; } }

        private int _LeftObstacle5;
        /// <summary>
        /// 左侧-车厢尾端到第5根拉筋距离(毫米)
        /// </summary>
        public virtual int LeftObstacle5 { get { return _LeftObstacle5; } set { _LeftObstacle5 = value; } }

        private int _LeftObstacle6;
        /// <summary>
        /// 左侧-车厢尾端到第6根拉筋距离(毫米)
        /// </summary>
        public virtual int LeftObstacle6 { get { return _LeftObstacle6; } set { _LeftObstacle6 = value; } }

        private String _ReMark;
        /// <summary>
        /// 备注
        /// </summary>
        public virtual String ReMark { get { return _ReMark; } set { _ReMark = value; } }
    }
}
