using System;
using CMCS.DapperDber.Attrs;

namespace CMCS.DumblyConcealer.Tasks.CarJXSampler.Entities
{
	/// <summary>
	/// 汽车机械采样机接口 - 采样操作票主表
	/// </summary>
	[CMCS.DapperDber.Attrs.DapperBind("T_OPT_Sampling")]
	public class EquQCJXCYJSamplePlan
	{
		private int _Id;

		/// <summary>
		/// ID
		/// </summary>
		[DapperAutoPrimaryKey]
		public int Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		private string _OptNum;
		/// <summary>
		/// 操作票编号
		/// </summary>
		public string OptNum
		{
			get { return _OptNum; }
			set { _OptNum = value; }
		}

		private int _OptType = 1;
		/// <summary>
		/// 操作票类型 1：汽车采样 2：火车采样 3：皮带采样
		/// </summary>
		public int OptType
		{
			get { return _OptType; }
			set { _OptType = value; }
		}

		private string _DeviceCode;
		/// <summary>
		/// 设备编码
		/// </summary>
		public string DeviceCode
		{
			get { return _DeviceCode; }
			set { _DeviceCode = value; }
		}

		private string _SamplingCode;
		/// <summary>
		/// 采样编码
		/// </summary>
		public string SamplingCode
		{
			get { return _SamplingCode; }
			set { _SamplingCode = value; }
		}

		private string _PrepareCode;
		/// <summary>
		/// 制样编码
		/// </summary>
		public string PrepareCode
		{
			get { return _PrepareCode; }
			set { _PrepareCode = value; }
		}

		private decimal _CoalSize;
		/// <summary>
		/// 煤粒度
		/// </summary>
		public decimal CoalSize
		{
			get { return _CoalSize; }
			set { _CoalSize = value; }
		}

		private int _UseType = 1;
		/// <summary>
		/// 入煤类型1 入厂煤 2 入炉煤
		/// </summary>
		public int UseType
		{
			get { return _UseType; }
			set { _UseType = value; }
		}

		private string _MineralNo;
		/// <summary>
		/// 矿别编码
		/// </summary>
		public string MineralNo
		{
			get { return _MineralNo; }
			set { _MineralNo = value; }
		}

		private decimal _SampleWeight;
		/// <summary>
		/// 预计来煤量
		/// </summary>
		public decimal SampleWeight
		{
			get { return _SampleWeight; }
			set { _SampleWeight = value; }
		}

		private int _Status = 1;
		/// <summary>
		/// 状态  1：已生成
		///2：已下票
		///3：执行中
		///4：已完成
		///100: 完成标识
		/// </summary>
		public int Status
		{
			get { return _Status; }
			set { _Status = value; }
		}

		private DateTime _SendTime;
		/// <summary>
		/// 下发时间
		/// </summary>
		public DateTime SendTime
		{
			get { return _SendTime; }
			set { _SendTime = value; }
		}

		private int _ReadFlag = 0;
		/// <summary>
		/// 标志位 0：未读 1：已读
		/// </summary>
		public int ReadFlag
		{
			get { return _ReadFlag; }
			set { _ReadFlag = value; }
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

		private DateTime _BeginTime;
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime BeginTime
		{
			get { return _BeginTime; }
			set { _BeginTime = value; }
		}

		private DateTime _EndTimee;
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime EndTime
		{
			get { return _EndTimee; }
			set { _EndTimee = value; }
		}

		private string _CoalType;
		/// <summary>
		/// 煤种
		/// </summary>
		public string CoalType
		{
			get { return _CoalType; }
			set { _CoalType = value; }
		}

		private int _SamplingType = 1;
		/// <summary>
		/// 采样方式 1：螺旋 2：铲桶
		/// </summary>
		public int SamplingType
		{
			get { return _SamplingType; }
			set { _SamplingType = value; }
		}

		private int _CarCount;
		/// <summary>
		/// 预计来煤车数
		/// </summary>
		public int CarCount
		{
			get { return _CarCount; }
			set { _CarCount = value; }
		}

		private decimal _ShrinkageRate;
		/// <summary>
		/// 缩分比
		/// </summary>
		public decimal ShrinkageRate
		{
			get { return _ShrinkageRate; }
			set { _ShrinkageRate = value; }
		}

		private decimal _SamplingRate;
		/// <summary>
		/// 采样频率
		/// </summary>
		public decimal SamplingRate
		{
			get { return _SamplingRate; }
			set { _SamplingRate = value; }
		}

		private int _DelayStop = 0;
		/// <summary>
		/// 延时停止 0：不延时 1：延时停止
		/// </summary>
		[DapperIgnore]
		public int DelayStop
		{
			get { return _DelayStop; }
			set { _DelayStop = value; }
		}

		private int _UpStatus = 0;
		/// <summary>
		/// 上传状态 1：已接收，
		///2: 执行中
		///3: 执行中
		///99：执行中
		///100:已完成
		///198:作废
		///199:异常
		/// </summary>
		public int UpStatus
		{
			get { return _UpStatus; }
			set { _UpStatus = value; }
		}

	}
}
