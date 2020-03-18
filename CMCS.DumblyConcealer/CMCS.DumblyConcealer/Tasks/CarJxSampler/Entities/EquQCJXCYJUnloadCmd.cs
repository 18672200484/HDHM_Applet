using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities;
using CMCS.Common.Entities.Sys;
using CMCS.DapperDber.Attrs;

namespace CMCS.DumblyConcealer.Tasks.CarJXSampler.Entities
{
	/// <summary>
	/// 汽车机械采样机接口 - 出桶操作票
	/// </summary>
	[CMCS.DapperDber.Attrs.DapperBind("T_OPT_OutBucket")]
	public class EquQCJXCYJUnloadCmd
	{
		private int _Id;
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

		private int _OptType;
		/// <summary>
		/// 操作票类型 1：样桶操作票 2：空桶操作票
		/// </summary>
		public int OptType
		{
			get { return _OptType; }
			set { _OptType = value; }
		}

		private string _BucketNo;
		/// <summary>
		/// 桶号
		/// </summary>
		public string BucketNo
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

		private decimal _SampleWeight;
		/// <summary>
		/// 煤样重量
		/// </summary>
		public decimal SampleWeight
		{
			get { return _SampleWeight; }
			set { _SampleWeight = value; }
		}

		private decimal _Status = 1;
		/// <summary>
		/// 状态 1：已生成
		///2：已下票
		///3：执行中
		///4：已完成
		//100: 完成标识
		/// </summary>
		public decimal Status
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

		private string _OptCreateModel = "1";
		/// <summary>
		/// 操作票生成模式1：自动生成模式 2：上位机手动生成
		/// </summary>
		public string OptCreateModel
		{
			get { return _OptCreateModel; }
			set { _OptCreateModel = value; }
		}

		private string _OptExeModel = "1";
		/// <summary>
		/// 操作票执行模式 1：自动 2：人工
		/// </summary>
		public string OptExeModel
		{
			get { return _OptExeModel; }
			set { _OptExeModel = value; }
		}

		private DateTime _OutBucketTime;
		/// <summary>
		/// 出桶时间
		/// </summary>
		public DateTime OutBucketTime
		{
			get { return _OutBucketTime; }
			set { _OutBucketTime = value; }
		}

		private int _ReadFlag = 0;
		/// <summary>
		/// 标志位 0：未读，1：已读  需三德添加 2已更新 3 管控已读取
		/// </summary>
		public int ReadFlag
		{
			get { return _ReadFlag; }
			set { _ReadFlag = value; }
		}

		private int _Upstatus;
		/// <summary>
		/// 上传状态 1：已接收，
		///2: 执行中
		///3: 执行中
		///99：执行中
		///100:已完成
		///198:作废
		///199:异常
		/// </summary>
		public int Upstatus
		{
			get { return _Upstatus; }
			set { _Upstatus = value; }
		}

	}
}
