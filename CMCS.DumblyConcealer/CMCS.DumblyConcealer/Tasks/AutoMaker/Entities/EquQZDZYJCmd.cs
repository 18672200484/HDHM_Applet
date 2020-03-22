using CMCS.Common.Enums;
using CMCS.DapperDber.Attrs;
using System;

namespace CMCS.DumblyConcealer.Tasks.AutoMaker.Entities
{
	/// <summary>
	/// 控制命令表
	/// </summary>
	[CMCS.DapperDber.Attrs.DapperBind("T_OPT_SamplePreparation")]
	public class EquQZDZYJCmd
	{
		private int _Id;

		/// <summary>
		/// 主键
		/// </summary>
		[DapperAutoPrimaryKey]
		public int Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		/// <summary>
		/// 操作票编号
		/// </summary>		
		private string _OptNum;
		public string OptNum
		{
			get { return _OptNum; }
			set { _OptNum = value; }
		}

		/// <summary>
		/// 操作票类型 1:自动制样人工入料，2：自动制样采制皮带对接入料，3：自动制样自动上料，4：人工制样
		/// </summary>		
		private int _OptType = 2;
		public int OptType
		{
			get { return _OptType; }
			set { _OptType = value; }
		}

		/// <summary>
		/// 设备编码
		/// </summary>		
		private string _DeviceCode;
		public string DeviceCode
		{
			get { return _DeviceCode; }
			set { _DeviceCode = value; }
		}

		/// <summary>
		/// 制样编码
		/// </summary>		
		private string _PrepareCode;
		public string PrepareCode
		{
			get { return _PrepareCode; }
			set { _PrepareCode = value; }
		}

		/// <summary>
		/// 采样编码
		/// </summary>		
		private string _SamplingCode;
		public string SamplingCode
		{
			get { return _SamplingCode; }
			set { _SamplingCode = value; }
		}

		/// <summary>
		/// 煤种
		/// </summary>		
		private string _CoalType;
		public string CoalType
		{
			get { return _CoalType; }
			set { _CoalType = value; }
		}

		/// <summary>
		/// 煤粒度
		/// </summary>		
		private decimal _CoalSize;
		public decimal CoalSize
		{
			get { return _CoalSize; }
			set { _CoalSize = value; }
		}

		/// <summary>
		/// 入煤类型  1 入厂煤 2 入炉煤
		/// </summary>		
		private int _UseType = 1;
		public int UseType
		{
			get { return _UseType; }
			set { _UseType = value; }
		}

		/// <summary>
		/// 桶数
		/// </summary>		
		private int _BucketNum;
		public int BucketNum
		{
			get { return _BucketNum; }
			set { _BucketNum = value; }
		}

		/// <summary>
		/// 总样重
		/// </summary>		
		private decimal _SampleWeight;
		public decimal SampleWeight
		{
			get { return _SampleWeight; }
			set { _SampleWeight = value; }
		}

		/// <summary>
		/// 状态
		///1：已生成
		///2：已下票
		///3：执行中
		///4：已完成
		///99：异常
		///100: 完成标识
		/// </summary>		
		private int _Status;
		public int Status
		{
			get { return _Status; }
			set { _Status = value; }
		}

		/// <summary>
		/// 下发时间
		/// </summary>		
		private DateTime _SendTime;
		public DateTime SendTime
		{
			get { return _SendTime; }
			set { _SendTime = value; }
		}

		/// <summary>
		/// 废弃时间
		/// </summary>		
		private DateTime _DiscardTime;
		public DateTime DiscardTime
		{
			get { return _DiscardTime; }
			set { _DiscardTime = value; }
		}

		/// <summary>
		/// 标识符 0：已下发，1：已接收
		/// </summary>		
		private int _DataFlag = 0;
		public int ReadFlag
		{
			get { return _DataFlag; }
			set { _DataFlag = value; }
		}

		/// <summary>
		/// 开票人员
		/// </summary>		
		private string _OptUser;
		public string OptUser
		{
			get { return _OptUser; }
			set { _OptUser = value; }
		}

		/// <summary>
		/// 开票时间
		/// </summary>		
		private DateTime _OptTime;
		public DateTime OptTime
		{
			get { return _OptTime; }
			set { _OptTime = value; }
		}

		/// <summary>
		/// 超时时限
		/// </summary>		
		private DateTime _LimitTime;
		public DateTime LimitTime
		{
			get { return _LimitTime; }
			set { _LimitTime = value; }
		}

		/// <summary>
		/// 操作票生成模式
		///1：燃管自动开票，
		///2：燃管人工开票，
		///3：采样开票，
		///4：自动制样人工开票，
		///5：自动制样自动开票，
		///6：人工制样手工开票。
		/// </summary>		
		private int _OptCreateModel = 1;
		public int OptCreateModel
		{
			get { return _OptCreateModel; }
			set { _OptCreateModel = value; }
		}

		/// <summary>
		/// 操作票执行模式
		///1：自动制样1，
		///2: 自动制样2，
		///3: 自动制样3，
		///4: 人工制样，
		///5：合样归批
		///6:弃料反排
		/// </summary>		
		private int _OptExeModel = 1;
		public int OptExeModel
		{
			get { return _OptExeModel; }
			set { _OptExeModel = value; }
		}

		/// <summary>
		/// 开始时间
		/// </summary>		
		private DateTime _BeginTime;
		public DateTime BeginTime
		{
			get { return _BeginTime; }
			set { _BeginTime = value; }
		}

		/// <summary>
		/// 结束时间
		/// </summary>		
		private DateTime _EndTime;
		public DateTime EndTime
		{
			get { return _EndTime; }
			set { _EndTime = value; }
		}

		/// <summary>
		/// 是否备用样制样
		/// </summary>		
		private int _IsSpare;
		public int IsSpare
		{
			get { return _IsSpare; }
			set { _IsSpare = value; }
		}

		/// <summary>
		/// 作废时间
		/// </summary>		
		private DateTime _SpareTime;
		public DateTime SpareTime
		{
			get { return _SpareTime; }
			set { _SpareTime = value; }
		}

		/// <summary>
		/// 上传状态 
		///1：已接收，
		///2: 执行中
		///3: 执行中
		///99：执行中
		///100:已完成
		///198:作废
		///199:异常
		/// </summary>		
		private int _UpStatus;
		public int UpStatus
		{
			get { return _UpStatus; }
			set { _UpStatus = value; }
		}

	}
}