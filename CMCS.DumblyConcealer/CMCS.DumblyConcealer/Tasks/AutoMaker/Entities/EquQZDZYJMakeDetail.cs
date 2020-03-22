using CMCS.Common.Enums;
using CMCS.DapperDber.Attrs;
using System;

namespace CMCS.DumblyConcealer.Tasks.AutoMaker.Entities
{
	/// <summary>
	/// 出样结果表
	/// </summary>
	[CMCS.DapperDber.Attrs.DapperBind("T_OPT_SamplePrepareResult")]
	public class EquQZDZYJMakeDetail
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

		private string _PrepareDeviceCode;

		/// <summary>
		/// 设备编码
		/// </summary>		
		public string PrepareDeviceCode
		{
			get { return _PrepareDeviceCode; }
			set { _PrepareDeviceCode = value; }
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

		/// <summary>
		/// 制样票ID
		/// </summary>		
		private string _SamplePraparationID;
		public string SamplePraparationID
		{
			get { return _SamplePraparationID; }
			set { _SamplePraparationID = value; }
		}

		/// <summary>
		/// 样瓶编码
		/// </summary>		
		private string _SampleCode;
		public string SampleCode
		{
			get { return _SampleCode; }
			set { _SampleCode = value; }
		}

		/// <summary>
		/// 制样序号
		/// </summary>		
		private string _SampleIndex;
		public string SampleIndex
		{
			get { return _SampleIndex; }
			set { _SampleIndex = value; }
		}

		/// <summary>
		/// 样瓶重量
		/// </summary>		
		private double _SampleWeight;
		public double SampleWeight
		{
			get { return _SampleWeight; }
			set { _SampleWeight = value; }
		}

		/// <summary>
		///样瓶规格 
		///1：3mm
		///2：6mm
		///3：0.2mm
		///4:13mm
		/// </summary>		
		private int _SampleStandard;
		public int SampleStandard
		{
			get { return _SampleStandard; }
			set { _SampleStandard = value; }
		}

		/// <summary>
		/// 样瓶型号 
		///1：存查样
		///2：全水样
		///3：分析样
		///4：总经理样
		/// </summary>		
		private int _SampleType;
		public int SampleType
		{
			get { return _SampleType; }
			set { _SampleType = value; }
		}

		/// <summary>
		/// 瓶底码
		/// </summary>		
		private string _BottleCode;
		public string BottleCode
		{
			get { return _BottleCode; }
			set { _BottleCode = value; }
		}

		/// <summary>
		///出样序号
		/// </summary>		
		private int _OutOrder;
		public int OutOrder
		{
			get { return _OutOrder; }
			set { _OutOrder = value; }
		}

		/// <summary>
		/// 出瓶时间
		/// </summary>		
		private DateTime _ResultTime;
		public DateTime ResultTime
		{
			get { return _ResultTime; }
			set { _ResultTime = value; }
		}

		/// <summary>
		/// 制样类型 1：自动制样，2：人工制样
		/// </summary>		
		private int _SamplePrepType;
		public int SamplePrepType
		{
			get { return _SamplePrepType; }
			set { _SamplePrepType = value; }
		}

		/// <summary>
		/// 状态 1：制样完成 2：发送完成
		/// </summary>		
		private int _Status;
		public int Status
		{
			get { return _Status; }
			set { _Status = value; }
		}

		/// <summary>
		/// 标识
		/// </summary>		
		private int _ReadFlag;
		public int ReadFlag
		{
			get { return _ReadFlag; }
			set { _ReadFlag = value; }
		}
	}
}