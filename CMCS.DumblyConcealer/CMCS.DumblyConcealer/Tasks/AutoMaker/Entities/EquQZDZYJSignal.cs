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
    /// 全自动制样机接口表 - 实时信号表
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("T_TFM_DeviceStatus")]
    public class EquQZDZYJSignal
	{
		private string _DeviceCode;
		/// <summary>
		/// 设备编码
		/// </summary>
		[DapperPrimaryKey]
		public string DeviceCode
		{
			get { return _DeviceCode; }
			set { _DeviceCode = value; }
		}

		private int _DeviceType;
		/// <summary>
		/// 设备类型 1：制样，2：采样，3：气动，4：存查柜，5：在线测全水
		/// </summary>
		public int DeviceType
		{
			get { return _DeviceType; }
			set { _DeviceType = value; }
		}

		private string _DeviceModel;
		/// <summary>
		/// 设备模块
		/// </summary>
		public string DeviceModel
		{
			get { return _DeviceModel; }
			set { _DeviceModel = value; }
		}

		private string _DeviceName;
		/// <summary>
		/// 设备名称
		/// </summary>
		public string DeviceName
		{
			get { return _DeviceName; }
			set { _DeviceName = value; }
		}

		private string _DeviceAdr;
		/// <summary>
		/// 设备地址
		/// </summary>
		public string DeviceAdr
		{
			get { return _DeviceAdr; }
			set { _DeviceAdr = value; }
		}

		private int _Mode;
		/// <summary>
		/// 
		/// </summary>
		public int Mode
		{
			get { return _Mode; }
			set { _Mode = value; }
		}

		private int _Status;
		/// <summary>
		/// 状态 0：无意义，
		/// 1：就绪（对于需要访问的设备状态，表示空闲），
		/// 2：忙碌（设备处于动作阶段，不允许向设备发送数据），
		/// 9：故障（设备处于故障，不允许向设备发送数据）
		/// </summary>
		public int Status
		{
			get { return _Status; }
			set { _Status = value; }
		}

		private int _Command;
		/// <summary>
		/// 命令
		/// </summary>
		public int Command
		{
			get { return _Command; }
			set { _Command = value; }
		}

		private int _FaultLevel;
		/// <summary>
		/// 命令
		/// </summary>
		public int FaultLevel
		{
			get { return _FaultLevel; }
			set { _FaultLevel = value; }
		}

		private string _FaultCode;
		/// <summary>
		/// 故障代码
		/// </summary>
		public string FaultCode
		{
			get { return _FaultCode; }
			set { _FaultCode = value; }
		}

		private string _FaultDetail;
		/// <summary>
		/// 故障内容
		/// </summary>
		public string FaultDetail
		{
			get { return _FaultDetail; }
			set { _FaultDetail = value; }
		}

		private int _ReadFlag = 0;
		/// <summary>
		/// 读写标识
		/// </summary>
		public int ReadFlag
		{
			get { return _ReadFlag; }
			set { _ReadFlag = value; }
		}

		private DateTime _UpdateTime;
		/// <summary>
		/// 更新时间  心跳
		/// 设备定时更新时间，采用数据库时间，间隔时间3~5秒，不宜过长，访问时需要加上时间，比如20秒内设备未更新时间，视为设备未联网。
		/// </summary>
		public DateTime UpdateTime
		{
			get { return _UpdateTime; }
			set { _UpdateTime = value; }
		}

	}
}
