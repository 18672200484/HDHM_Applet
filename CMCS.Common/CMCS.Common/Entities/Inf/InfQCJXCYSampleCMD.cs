
using System;
using System.Collections;
using CMCS.Common.Entities.Sys;

namespace CMCS.Common.Entities.Inf
{
	/// <summary>
	/// 汽车采样机-采样命令表
	/// </summary>
	[Serializable]
	[CMCS.DapperDber.Attrs.DapperBind("InfTbQCJXCYSampleCMD")]
	public class InfQCJXCYSampleCMD : EntityBase
	{
		private string _MachineCode;
		private string _CarNumber;
		private string _InFactoryBatchId;
		private string _SampleCode;
		private decimal _Mt;
		private decimal _TicketWeight;
		private int _CarCount;
		private int _PointCount;
		private string _Point1;
		private string _Point2;
		private string _Point3;
		private string _Point4;
		private string _Point5;
		private string _Point6;
		private int _CarriageLength;
		private int _CarriageWidth;
		private int _CarriageBottomToFloor;
		private int _Obstacle1;
		private int _Obstacle2;
		private int _Obstacle3;
		private int _Obstacle4;
		private int _Obstacle5;
		private int _Obstacle6;
		private DateTime _StartTime;
		private DateTime _EndTime;
		private string _SampleUser;
		private string _ResultCode;
		private int _DataFlag;

		/// <summary>
		/// 设备编号
		/// </summary>
		public string MachineCode
		{
			get { return _MachineCode; }
			set { _MachineCode = value; }
		}

		/// <summary>
		/// 车牌号
		/// </summary>
		public string CarNumber
		{
			get { return _CarNumber; }
			set { _CarNumber = value; }
		}

		/// <summary>
		/// 批次Id
		/// </summary>
		public string InFactoryBatchId
		{
			get { return _InFactoryBatchId; }
			set { _InFactoryBatchId = value; }
		}

		/// <summary>
		/// 采样码
		/// </summary>
		public string SampleCode
		{
			get { return _SampleCode; }
			set { _SampleCode = value; }
		}

		/// <summary>
		/// 外水分
		/// </summary>
		public decimal Mt
		{
			get { return _Mt; }
			set { _Mt = value; }
		}

		/// <summary>
		/// 预报总矿发量
		/// </summary>
		public decimal TicketWeight
		{
			get { return _TicketWeight; }
			set { _TicketWeight = value; }
		}

		/// <summary>
		/// 预报总车数
		/// </summary>
		public int CarCount
		{
			get { return _CarCount; }
			set { _CarCount = value; }
		}

		/// <summary>
		/// 采样点数
		/// </summary>
		public int PointCount
		{
			get { return _PointCount; }
			set { _PointCount = value; }
		}

		/// <summary>
		/// 采样坐标1
		/// </summary>
		public string Point1
		{
			get { return _Point1; }
			set { _Point1 = value; }
		}

		/// <summary>
		/// 采样坐标2
		/// </summary>
		public string Point2
		{
			get { return _Point2; }
			set { _Point2 = value; }
		}

		/// <summary>
		/// 采样坐标3
		/// </summary>
		public string Point3
		{
			get { return _Point3; }
			set { _Point3 = value; }
		}

		/// <summary>
		/// 采样坐标4
		/// </summary>
		public string Point4
		{
			get { return _Point4; }
			set { _Point4 = value; }
		}

		/// <summary>
		/// 采样坐标5
		/// </summary>
		public string Point5
		{
			get { return _Point5; }
			set { _Point5 = value; }
		}

		/// <summary>
		/// 采样坐标6
		/// </summary>
		public string Point6
		{
			get { return _Point6; }
			set { _Point6 = value; }
		}

		/// <summary>
		/// 车厢长
		/// </summary>
		public int CarriageLength
		{
			get { return _CarriageLength; }
			set { _CarriageLength = value; }
		}

		/// <summary>
		/// 车厢宽
		/// </summary>
		public int CarriageWidth
		{
			get { return _CarriageWidth; }
			set { _CarriageWidth = value; }
		}

		private int _CarriageHeight;
		/// <summary>
		/// 车厢高
		/// </summary>
		public int CarriageHeight
		{
			get { return _CarriageHeight; }
			set { _CarriageHeight = value; }
		}

		/// <summary>
		/// 车厢底部到地面高
		/// </summary>
		public int CarriageBottomToFloor
		{
			get { return _CarriageBottomToFloor; }
			set { _CarriageBottomToFloor = value; }
		}

		/// <summary>
		/// 车厢尾端到第1根拉筋距离
		/// </summary>
		public int Obstacle1
		{
			get { return _Obstacle1; }
			set { _Obstacle1 = value; }
		}

		/// <summary>
		/// 车厢尾端第1根到第2根拉筋距离
		/// </summary>
		public int Obstacle2
		{
			get { return _Obstacle2; }
			set { _Obstacle2 = value; }
		}

		/// <summary>
		/// 车厢尾端第2根到第3根拉筋距离
		/// </summary>
		public int Obstacle3
		{
			get { return _Obstacle3; }
			set { _Obstacle3 = value; }
		}

		/// <summary>
		/// 车厢尾端第3根到第4根拉筋距离
		/// </summary>
		public int Obstacle4
		{
			get { return _Obstacle4; }
			set { _Obstacle4 = value; }
		}

		/// <summary>
		/// 车厢尾端第4根到第5根拉筋距离
		/// </summary>
		public int Obstacle5
		{
			get { return _Obstacle5; }
			set { _Obstacle5 = value; }
		}

		/// <summary>
		/// 车厢尾端第5根到第6根拉筋距离
		/// </summary>
		public int Obstacle6
		{
			get { return _Obstacle6; }
			set { _Obstacle6 = value; }
		}

		/// <summary>
		/// 采样开始时间
		/// </summary>
		public DateTime StartTime
		{
			get { return _StartTime; }
			set { _StartTime = value; }
		}

		/// <summary>
		/// 采样结束时间
		/// </summary>
		public DateTime EndTime
		{
			get { return _EndTime; }
			set { _EndTime = value; }
		}

		/// <summary>
		/// 采样员
		/// </summary>
		public string SampleUser
		{
			get { return _SampleUser; }
			set { _SampleUser = value; }
		}

		/// <summary>
		/// 采样结果
		/// </summary>
		public string ResultCode
		{
			get { return _ResultCode; }
			set { _ResultCode = value; }
		}

		/// <summary>
		/// 标识符
		/// </summary>
		public int DataFlag
		{
			get { return _DataFlag; }
			set { _DataFlag = value; }
		}

		private int syncFlag = 0;
		/// <summary>
		/// 同步标识 0=未同步 1=已同步
		/// </summary>
		public int SyncFlag
		{
			get { return syncFlag; }
			set { syncFlag = value; }
		}
	}
}
