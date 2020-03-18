
using System;
using System.Collections;
using CMCS.Common.Entities.Sys;

namespace CMCS.Common.Entities.Inf
{
	/// <summary>
	/// 汽车采样机接口-卸样命令
	/// </summary>
	[Serializable]
	[CMCS.DapperDber.Attrs.DapperBind("INFTBQCJXCYUNLOADCMD")]
	public class InfQCJXCYUnLoadCMD : EntityBase
	{
		private string _MachineCode;
		private string _SampleCode;
		private string _UnLoadType;
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

		private string samplingId;
		/// <summary>
		/// 采样单Id
		/// </summary>
		public string SamplingId
		{
			get { return samplingId; }
			set { samplingId = value; }
		}

		private string _BarrelNumber;
		/// <summary>
		/// 桶号
		/// </summary>
		public string BarrelNumber
		{
			get { return _BarrelNumber; }
			set { _BarrelNumber = value; }
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
		/// 卸样方式
		/// </summary>
		public string UnLoadType
		{
			get { return _UnLoadType; }
			set { _UnLoadType = value; }
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
