using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CMCS.Common.Entities.CarTransport;

namespace CMCS.CarTransport.JxSampler.Core
{
    public class PreviewCarBmp
    {
        /// <summary>
        /// 车辆信息封装类
        /// </summary>
        public TruckMeasure CurrTruck;

        /// <summary>
        /// 采样点坐标
        /// </summary>
        public List<Point> CurrPoints = new List<Point>();

        public PreviewCarBmp(CmcsAutotruck autoTruck)
        {
            CurrTruck = new TruckMeasure(autoTruck.CarriageWidth, autoTruck.CarriageLength);
            CurrTruck.LeftObstacle1 = autoTruck.LeftObstacle1;
            CurrTruck.LeftObstacle2 = autoTruck.LeftObstacle2;
            CurrTruck.LeftObstacle3 = autoTruck.LeftObstacle3;
            CurrTruck.LeftObstacle4 = autoTruck.LeftObstacle4;
            CurrTruck.LeftObstacle5 = autoTruck.LeftObstacle5;
            CurrTruck.LeftObstacle6 = autoTruck.LeftObstacle6;
            CurrTruck.RightObstacle1 = autoTruck.RightObstacle1;
            CurrTruck.RightObstacle2 = autoTruck.RightObstacle2;
            CurrTruck.RightObstacle3 = autoTruck.RightObstacle3;
            CurrTruck.RightObstacle4 = autoTruck.RightObstacle4;
            CurrTruck.RightObstacle5 = autoTruck.RightObstacle5;
            CurrTruck.RightObstacle6 = autoTruck.RightObstacle6;
        }

        public PreviewCarBmp(CmcsAutotruck autotruck, List<Point> Points)
        {
            CurrTruck = new TruckMeasure(autotruck.CarriageWidth, autotruck.CarriageLength);
            CurrTruck.LeftObstacle1 = autotruck.LeftObstacle1;
            CurrTruck.LeftObstacle2 = autotruck.LeftObstacle2;
            CurrTruck.LeftObstacle3 = autotruck.LeftObstacle3;
            CurrTruck.LeftObstacle4 = autotruck.LeftObstacle4;
            CurrTruck.LeftObstacle5 = autotruck.LeftObstacle5;
            CurrTruck.LeftObstacle6 = autotruck.LeftObstacle6;
            CurrTruck.RightObstacle1 = autotruck.RightObstacle1;
            CurrTruck.RightObstacle2 = autotruck.RightObstacle2;
            CurrTruck.RightObstacle3 = autotruck.RightObstacle3;
            CurrTruck.RightObstacle4 = autotruck.RightObstacle4;
            CurrTruck.RightObstacle5 = autotruck.RightObstacle5;
            CurrTruck.RightObstacle6 = autotruck.RightObstacle6;

            CurrPoints = Points;
        }

        public Bitmap GetPreviewBitmap(Bitmap bCar, int imageWidth, int imageHeight)
        {
            Graphics g = Graphics.FromImage(bCar);

            //图片车头长 需固定
            float CarriageHeadLength = 153f;
            // 车厢宽
            float carriageWidth = 243f;

            // 边距
            float padding = imageWidth * 0.02f;
            //// 整体缩放比例  
            //float zoomRate = Math.Min((imageWidth - CarriageHeadLength - padding * 2) / this.CurrTruck.CarriageLength, (imageHeight - padding * 2 - 40) / this.CurrTruck.CarriageWidth);
            // 整体缩放比例长  
            float zoomRateLength = (imageWidth - CarriageHeadLength - padding * 2) / this.CurrTruck.CarriageLength;
            // 整体缩放比例宽  
            float zoomRateWidth = (imageHeight - padding * 2 - 40) / this.CurrTruck.CarriageWidth;
            // 车厢长
            float carriageLength = this.CurrTruck.CarriageLength * zoomRateLength;
            // 车总长
            float truckTotalLength = imageWidth;

            // 车厢尾部到第1根拉筋距离
            float leftFromTailObstacle1 = this.CurrTruck.LeftFromTailObstacle1 * zoomRateLength;
            // 车厢尾部到第2根拉筋距离
            float leftFromTailObstacle2 = this.CurrTruck.LeftFromTailObstacle2 * zoomRateLength;
            // 车厢尾部到第3根拉筋距离
            float leftFromTailObstacle3 = this.CurrTruck.LeftFromTailObstacle3 * zoomRateLength;
            // 车厢尾部到第4根拉筋距离
            float leftFromTailObstacle4 = this.CurrTruck.LeftFromTailObstacle4 * zoomRateLength;
            // 车厢尾部到第5根拉筋距离
            float leftFromTailObstacle5 = this.CurrTruck.LeftFromTailObstacle5 * zoomRateLength;
            // 车厢尾部到第6根拉筋距离
            float leftFromTailObstacle6 = this.CurrTruck.LeftFromTailObstacle6 * zoomRateLength;

            // 车厢尾部到第1根拉筋距离
            float rightFromTailObstacle1 = this.CurrTruck.RightFromTailObstacle1 * zoomRateLength;
            // 车厢尾部到第2根拉筋距离
            float rightFromTailObstacle2 = this.CurrTruck.RightFromTailObstacle2 * zoomRateLength;
            // 车厢尾部到第3根拉筋距离
            float rightFromTailObstacle3 = this.CurrTruck.RightFromTailObstacle3 * zoomRateLength;
            // 车厢尾部到第4根拉筋距离
            float rightFromTailObstacle4 = this.CurrTruck.RightFromTailObstacle4 * zoomRateLength;
            // 车厢尾部到第5根拉筋距离
            float rightFromTailObstacle5 = this.CurrTruck.RightFromTailObstacle5 * zoomRateLength;
            // 车厢尾部到第6根拉筋距离
            float rightFromTailObstacle6 = this.CurrTruck.RightFromTailObstacle6 * zoomRateLength;

            // x轴位移
            float xOffest = (imageWidth - padding * 2 - truckTotalLength) / 2f;
            // y轴位移
            float yOffest = (imageHeight - padding * 2 - carriageWidth) / 2f;

            // 绘制拉筋
            Pen obstaclePen = new Pen(Color.FromArgb(146, 148, 151), 3) { DashStyle = System.Drawing.Drawing2D.DashStyle.Solid };
            Font obstacleFont = new Font("微软雅黑", 12, FontStyle.Regular);
            if (this.CurrTruck.LeftObstacle1 > 0 && this.CurrTruck.RightObstacle1 > 0)
            {
                g.DrawString(this.CurrTruck.RightFromTailObstacle1.ToString(), obstacleFont, Brushes.Red, padding + xOffest + truckTotalLength - rightFromTailObstacle1 - 18, padding + yOffest - 30);
                g.DrawString(this.CurrTruck.LeftFromTailObstacle1.ToString(), obstacleFont, Brushes.Red, padding + xOffest + truckTotalLength - leftFromTailObstacle1 - 11, padding + carriageWidth + yOffest + 5);
                g.DrawLine(obstaclePen, padding + xOffest + truckTotalLength - rightFromTailObstacle1, padding + yOffest, padding + xOffest + truckTotalLength - leftFromTailObstacle1, padding + carriageWidth + yOffest);
            }
            if (this.CurrTruck.LeftObstacle2 > 0 && this.CurrTruck.RightObstacle2 > 0)
            {
                g.DrawString(this.CurrTruck.RightFromTailObstacle2.ToString(), obstacleFont, Brushes.Red, padding + xOffest + truckTotalLength - rightFromTailObstacle2 - 18, padding + yOffest - 30);
                g.DrawString(this.CurrTruck.LeftFromTailObstacle2.ToString(), obstacleFont, Brushes.Red, padding + xOffest + truckTotalLength - leftFromTailObstacle2 - 11, padding + carriageWidth + yOffest + 5);
                g.DrawLine(obstaclePen, padding + xOffest + truckTotalLength - rightFromTailObstacle2, padding + yOffest, padding + xOffest + truckTotalLength - leftFromTailObstacle2, padding + carriageWidth + yOffest);
            }
            if (this.CurrTruck.LeftObstacle3 > 0 && this.CurrTruck.RightObstacle3 > 0)
            {
                g.DrawString(this.CurrTruck.RightFromTailObstacle3.ToString(), obstacleFont, Brushes.Red, padding + xOffest + truckTotalLength - rightFromTailObstacle3 - 18, padding + yOffest - 30);
                g.DrawString(this.CurrTruck.LeftFromTailObstacle3.ToString(), obstacleFont, Brushes.Red, padding + xOffest + truckTotalLength - leftFromTailObstacle3 - 11, padding + carriageWidth + yOffest + 5);
                g.DrawLine(obstaclePen, padding + xOffest + truckTotalLength - rightFromTailObstacle3, padding + yOffest, padding + xOffest + truckTotalLength - leftFromTailObstacle3, padding + carriageWidth + yOffest);
            }
            if (this.CurrTruck.LeftObstacle4 > 0 && this.CurrTruck.RightObstacle4 > 0)
            {
                g.DrawString(this.CurrTruck.RightFromTailObstacle4.ToString(), obstacleFont, Brushes.Red, padding + xOffest + truckTotalLength - rightFromTailObstacle4 - 18, padding + yOffest - 30);
                g.DrawString(this.CurrTruck.LeftFromTailObstacle4.ToString(), obstacleFont, Brushes.Red, padding + xOffest + truckTotalLength - leftFromTailObstacle4 - 11, padding + carriageWidth + yOffest + 5);
                g.DrawLine(obstaclePen, padding + xOffest + truckTotalLength - rightFromTailObstacle4, padding + yOffest, padding + xOffest + truckTotalLength - leftFromTailObstacle4, padding + carriageWidth + yOffest);
            }
            if (this.CurrTruck.LeftObstacle5 > 0 && this.CurrTruck.RightObstacle5 > 0)
            {
                g.DrawString(this.CurrTruck.RightFromTailObstacle5.ToString(), obstacleFont, Brushes.Red, padding + xOffest + truckTotalLength - rightFromTailObstacle5 - 18, padding + yOffest - 30);
                g.DrawString(this.CurrTruck.LeftFromTailObstacle5.ToString(), obstacleFont, Brushes.Red, padding + xOffest + truckTotalLength - leftFromTailObstacle5 - 11, padding + carriageWidth + yOffest + 5);
                g.DrawLine(obstaclePen, padding + xOffest + truckTotalLength - rightFromTailObstacle5, padding + yOffest, padding + xOffest + truckTotalLength - leftFromTailObstacle5, padding + carriageWidth + yOffest);
            }
            if (this.CurrTruck.LeftObstacle6 > 0 && this.CurrTruck.RightObstacle6 > 0)
            {
                g.DrawString(this.CurrTruck.RightFromTailObstacle6.ToString(), obstacleFont, Brushes.Red, padding + xOffest + truckTotalLength - rightFromTailObstacle6 - 18, padding + yOffest - 30);
                g.DrawString(this.CurrTruck.LeftFromTailObstacle6.ToString(), obstacleFont, Brushes.Red, padding + xOffest + truckTotalLength - leftFromTailObstacle6 - 11, padding + carriageWidth + yOffest + 5);
                g.DrawLine(obstaclePen, padding + xOffest + truckTotalLength - rightFromTailObstacle6, padding + yOffest, padding + xOffest + truckTotalLength - leftFromTailObstacle6, padding + carriageWidth + yOffest);
            }

            // 绘制坐标点
            Font pointFont = new Font("微软雅黑", (float)Math.Floor(Math.Max(6, this.CurrTruck.AiguilleRadius * Math.Min(zoomRateLength, zoomRateWidth))), FontStyle.Regular);
            for (int i = 0; i < CurrPoints.Count; i++) g.DrawString((i + 1).ToString(), pointFont, Brushes.Red, padding + xOffest + truckTotalLength - CurrPoints[i].X * zoomRateLength, CurrPoints[i].Y * zoomRateWidth + yOffest);

            return bCar;
        }
    }

    /// <summary>
    /// 汽车测量数据 单位：厘米
    /// </summary>
    public class TruckMeasure
    {
        int aiguilleRadius = 15;
        /// <summary>
        /// 钻头半径
        /// </summary>
        public int AiguilleRadius
        {
            get { return aiguilleRadius; }
            set { aiguilleRadius = value; }
        }

        /// <summary>
        /// TruckMeasure
        /// </summary>
        /// <param name="truckHeadLength">车头长</param>
        /// <param name="carriageWidth">车厢宽</param>
        /// <param name="carriageLength">车厢长</param>
        public TruckMeasure(int carriageWidth, int carriageLength)
        {
            this.carriageWidth = carriageWidth;
            this.carriageLength = carriageLength;
        }

        private int carriageLength = 0;
        /// <summary>
        /// 车厢长
        /// </summary>
        public int CarriageLength
        {
            get { return carriageLength; }
            set { carriageLength = value; }
        }

        private int carriageWidth = 0;
        /// <summary>
        /// 车厢宽
        /// </summary>
        public int CarriageWidth
        {
            get { return carriageWidth; }
            set { carriageWidth = value; }
        }

        private int carriageToFloor = 0;
        /// <summary>
        /// 车厢底部距地面高
        /// </summary>
        public int CarriageToFloor
        {
            get { return carriageToFloor; }
            set { carriageToFloor = value; }
        }

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

        /// <summary>
        /// 右侧-车厢尾部到第1根拉筋距离
        /// </summary>
        public int RightFromTailObstacle1
        {
            get { return _RightObstacle1; }
        }

        /// <summary>
        /// 右侧-车厢尾部到第2根拉筋距离
        /// </summary>
        public int RightFromTailObstacle2
        {
            get { return _RightObstacle2; }
        }

        /// <summary>
        /// 右侧-车厢尾部到第3根拉筋距离
        /// </summary>
        public int RightFromTailObstacle3
        {
            get { return _RightObstacle3; }
        }

        /// <summary>
        /// 右侧-车厢尾部到第4根拉筋距离
        /// </summary>
        public int RightFromTailObstacle4
        {
            get { return _RightObstacle4; }
        }

        /// <summary>
        /// 右侧-车厢尾部到第5根拉筋距离
        /// </summary>
        public int RightFromTailObstacle5
        {
            get { return _RightObstacle5; }
        }

        /// <summary>
        /// 右侧-车厢尾部到第6根拉筋距离
        /// </summary>
        public int RightFromTailObstacle6
        {
            get { return _RightObstacle6; }
        }

        /// <summary>
        /// 左侧-车厢尾部到第1根拉筋距离
        /// </summary>
        public int LeftFromTailObstacle1
        {
            get { return _LeftObstacle1; }
        }

        /// <summary>
        /// 左侧-车厢尾部到第2根拉筋距离
        /// </summary>
        public int LeftFromTailObstacle2
        {
            get { return _LeftObstacle2; }
        }

        /// <summary>
        /// 左侧-车厢尾部到第3根拉筋距离
        /// </summary>
        public int LeftFromTailObstacle3
        {
            get { return _LeftObstacle3; }
        }

        /// <summary>
        /// 左侧-车厢尾部到第4根拉筋距离
        /// </summary>
        public int LeftFromTailObstacle4
        {
            get { return _LeftObstacle4; }
        }

        /// <summary>
        /// 左侧-车厢尾部到第5根拉筋距离
        /// </summary>
        public int LeftFromTailObstacle5
        {
            get { return _LeftObstacle5; }
        }

        /// <summary>
        /// 左侧-车厢尾部到第6根拉筋距离
        /// </summary>
        public int LeftFromTailObstacle6
        {
            get { return _LeftObstacle6; }
        }
    }
}
