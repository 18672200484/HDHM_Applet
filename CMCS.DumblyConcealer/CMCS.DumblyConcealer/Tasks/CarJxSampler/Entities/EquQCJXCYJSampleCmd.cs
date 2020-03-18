using System;
using CMCS.DapperDber.Attrs;

namespace CMCS.DumblyConcealer.Tasks.CarJXSampler.Entities
{
	/// <summary>
	/// 汽车机械采样机接口 - 采样操作票子表
	/// </summary>
	[CMCS.DapperDber.Attrs.DapperBind("T_OPT_SamplingSub")]
	public class EquQCJXCYJSampleCmd
	{
		private string _Id = Guid.NewGuid().ToString();

		/// <summary>
		/// ID
		/// </summary>
		[DapperPrimaryKey]
		public string Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		private string _ParendID;
		/// <summary>
		/// 主表操作票号
		/// </summary>
		public string ParendID
		{
			get { return _ParendID; }
			set { _ParendID = value; }
		}

		private string _SamplingDeviceCode;
		/// <summary>
		/// 采样设备编码
		/// </summary>
		public string SamplingDeviceCode
		{
			get { return _SamplingDeviceCode; }
			set { _SamplingDeviceCode = value; }
		}

		private string _OptUser;
		/// <summary>
		/// 开票人员
		/// </summary>
		public string OptUser
		{
			get { return _OptUser; }
			set { _OptUser = value; }
		}

		private DateTime _OptTime;
		/// <summary>
		/// 开票时间
		/// </summary>
		public DateTime OptTime
		{
			get { return _OptTime; }
			set { _OptTime = value; }
		}

		private DateTime _LimitTime;
		/// <summary>
		/// 超时时限
		/// </summary>
		public DateTime LimitTime
		{
			get { return _LimitTime; }
			set { _LimitTime = value; }
		}

		private int _OptCreateModel = 1;
		/// <summary>
		/// 操作票生成模式 1：燃管自动开票，2：燃管人工开票，
		///3：采样自动生成
		///4：采样人工生成
		/// </summary>
		public int OptCreateModel
		{
			get { return _OptCreateModel; }
			set { _OptCreateModel = value; }
		}

		private int _OptExeModel = 1;
		/// <summary>
		/// 操作票执行模式 1：自动 2：人工
		/// </summary>
		public int OptExeModel
		{
			get { return _OptExeModel; }
			set { _OptExeModel = value; }
		}

		private string _CardId;
		/// <summary>
		/// 车辆唯一标识
		/// </summary>
		public string CardId
		{
			get { return _CardId; }
			set { _CardId = value; }
		}

		private int _OrderNum;
		/// <summary>
		/// 顺序号
		/// </summary>
		public int OrderNum
		{
			get { return _OrderNum; }
			set { _OrderNum = value; }
		}

		private string _CarNumber;
		/// <summary>
		/// 车牌号
		/// </summary>
		public string CarNumber
		{
			get { return _CarNumber; }
			set { _CarNumber = value; }
		}

		private int _BucketNo;
		/// <summary>
		/// 桶号
		/// </summary>
		public int BucketNo
		{
			get { return _BucketNo; }
			set { _BucketNo = value; }
		}

		private string _BucketCode;
		/// <summary>
		/// 桶编码
		/// </summary>
		public string BucketCode
		{
			get { return _BucketCode; }
			set { _BucketCode = value; }
		}

		private int _SamplingCount;
		/// <summary>
		/// 采样点数
		/// </summary>
		public int SamplingCount
		{
			get { return _SamplingCount; }
			set { _SamplingCount = value; }
		}

		private int _State = 1;
		/// <summary>
		/// 状态 1：已生成
		///2：已下票
		///3：执行中
		///4：已完成
		///100: 完成标识
		/// </summary>
		public int State
		{
			get { return _State; }
			set { _State = value; }
		}

		private DateTime _BeginTime;
		/// <summary>
		/// 开始采样时间
		/// </summary>
		public DateTime StartTime
		{
			get { return _BeginTime; }
			set { _BeginTime = value; }
		}

		private DateTime _EndTimee;
		/// <summary>
		/// 结束采样时间
		/// </summary>
		public DateTime EndTime
		{
			get { return _EndTimee; }
			set { _EndTimee = value; }
		}

		private int _ReadFlag = 0;
		/// <summary>
		/// 标志位 0 未读取 1 已读取  需三德添加 2 已更新结果 3 已读取结果
		/// </summary>
		public int ReadFlag
		{
			get { return _ReadFlag; }
			set { _ReadFlag = value; }
		}

		private decimal _CarLength;
		/// <summary>
		/// 车厢长度
		/// </summary>
		public decimal CarLength
		{
			get { return _CarLength; }
			set { _CarLength = value; }
		}

		private decimal _CarSecLength;
		/// <summary>
		/// 车厢2长度（米）
		/// </summary>
		public decimal CarSecLength
		{
			get { return _CarSecLength; }
			set { _CarSecLength = value; }
		}

		private decimal _CarDiss;
		/// <summary>
		/// 车厢间距（米）
		/// </summary>
		public decimal CarDiss
		{
			get { return _CarDiss; }
			set { _CarDiss = value; }
		}

		private decimal _CarWidth;
		/// <summary>
		/// 车厢宽度
		/// </summary>
		public decimal CarWidth
		{
			get { return _CarWidth; }
			set { _CarWidth = value; }
		}

		private decimal _CarHeight;
		/// <summary>
		/// 车厢高度
		/// </summary>
		public decimal CarHeight
		{
			get { return _CarHeight; }
			set { _CarHeight = value; }
		}

		private decimal _BottomHeight;
		/// <summary>
		/// 车厢底高
		/// </summary>
		public decimal BottomHeight
		{
			get { return _BottomHeight; }
			set { _BottomHeight = value; }
		}

		private string _TiePosition;
		/// <summary>
		/// 拉筋位置(|)
		/// </summary>
		public string TiePosition
		{
			get { return _TiePosition; }
			set { _TiePosition = value; }
		}

		private string _SamplingCoord;
		/// <summary>
		/// 采样坐标(|)
		/// </summary>
		public string SamplingCoord
		{
			get { return _SamplingCoord; }
			set { _SamplingCoord = value; }
		}

		private string _SamplingImagePath;
		/// <summary>
		/// 采样图片路径
		/// </summary>
		public string SamplingImagePath
		{
			get { return _SamplingImagePath; }
			set { _SamplingImagePath = value; }
		}

		private int _UpStatus;
		/// <summary>
		/// 采样状态 1：正在采样，2：采样结束，3：正在缩分，4：缩分结束
		/// </summary>
		public int UpStatus
		{
			get { return _UpStatus; }
			set { _UpStatus = value; }
		}
	}
}
