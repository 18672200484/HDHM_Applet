using System;

using CMCS.DapperDber.Attrs;

namespace CMCS.DumblyConcealer.Tasks.CarJXSampler.Entities
{
	/// <summary>
	/// 汽车机械采样机接口 - 实时集样罐表
	/// </summary>
	[CMCS.DapperDber.Attrs.DapperBind("T_OPT_SampleTank")]
	public class EquQCJXCYJBarrel
	{
		private int _Id;
		[DapperPrimaryKey]
		public int Id
		{
			get { return _Id; }
			set { _Id = value; }
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

		private string _MineralNo;
		/// <summary>
		/// 矿别编码
		/// </summary>
		public string MineralNo
		{
			get { return _MineralNo; }
			set { _MineralNo = value; }
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

		private int _BucketFull;
		/// <summary>
		/// 桶满标志  0 未满 1 已满
		/// </summary>
		public int BucketFull
		{
			get { return _BucketFull; }
			set { _BucketFull = value; }
		}

		private int _TotalCapacity;
		/// <summary>
		/// 总量（个数/重量）
		/// </summary>
		public int TotalCapacity
		{
			get { return _TotalCapacity; }
			set { _TotalCapacity = value; }
		}

		private int _CurrCapacity;
		/// <summary>
		/// 当前量（个数/重量）
		/// </summary>
		public int CurrCapacity
		{
			get { return _CurrCapacity; }
			set { _CurrCapacity = value; }
		}

		private DateTime _StartTime;
		/// <summary>
		/// 开始集样时间
		/// </summary>
		public DateTime StartTime
		{
			get { return _StartTime; }
			set { _StartTime = value; }
		}

		private DateTime _EndTime;
		/// <summary>
		/// 结束集样时间
		/// </summary>
		public DateTime EndTime
		{
			get { return _EndTime; }
			set { _EndTime = value; }
		}

		private int _ReadFlag;
		/// <summary>
		///标示位
		/// </summary>
		public int ReadFlag
		{
			get { return _ReadFlag; }
			set { _ReadFlag = value; }
		}

		private int _UpStatus;
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
