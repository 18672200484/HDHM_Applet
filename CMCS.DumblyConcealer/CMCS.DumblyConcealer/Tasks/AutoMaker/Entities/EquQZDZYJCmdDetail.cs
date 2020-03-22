using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities;
using CMCS.Common.Entities.Sys;
using CMCS.DapperDber.Attrs;

namespace CMCS.DumblyConcealer.Tasks.AutoMaker.Entities
{
	/// <summary>
	/// 全自动制样机接口表 - 制样计划样品子表
	/// </summary>
	[CMCS.DapperDber.Attrs.DapperBind("T_OPT_SamplePreparetionSub")]
	public class EquQZDZYJCmdDetail
	{
		private string _Id;
		/// <summary>
		/// Id
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

		private string _PrepareDeviceCode;
		/// <summary>
		/// 制样设备编码
		/// </summary>
		public string PrepareDeviceCode
		{
			get { return _PrepareDeviceCode; }
			set { _PrepareDeviceCode = value; }
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

		private double _SampleWeight;
		/// <summary>
		/// 样品重量
		/// </summary>
		public double SampleWeight
		{
			get { return _SampleWeight; }
			set { _SampleWeight = value; }
		}

		private int _UpStatus;
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
		public int UpStatus
		{
			get { return _UpStatus; }
			set { _UpStatus = value; }
		}

		private DateTime _UpTime;
		/// <summary>
		/// 上传时间
		/// </summary>
		public DateTime UpTime
		{
			get { return _UpTime; }
			set { _UpTime = value; }
		}
	}
}
