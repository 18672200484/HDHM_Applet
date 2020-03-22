using System;

namespace CMCS.DumblyConcealer.Tasks.AutoMaker.Entities
{
	/// <summary>
	/// 第三方接口 - 设备状态信息表
	/// </summary>
	[CMCS.DapperDber.Attrs.DapperBind("T_TFM_SubDeviceStatus")]
	public class EquQZDZYJSignalDetail
	{
		private string _SubDeviceCode;
		/// <summary>
		/// 子设备编码
		/// </summary>
		public string SubDeviceCode
		{
			get { return _SubDeviceCode; }
			set { _SubDeviceCode = value; }
		}

		private string _SubDeviceNamel;
		/// <summary>
		/// 子设备名称
		/// </summary>
		public string SubDeviceName
		{
			get { return _SubDeviceNamel; }
			set { _SubDeviceNamel = value; }
		}

		private string _ParendDeviceCode;
		/// <summary>
		/// 主表设备编码
		/// </summary>
		public string ParendDeviceCode
		{
			get { return _ParendDeviceCode; }
			set { _ParendDeviceCode = value; }
		}

		private int _Status;
		/// <summary>
		/// 状态 0：无意义，1：就绪（对于需要访问的设备状态，表示空闲），
		/// 2：忙碌（设备处于动作阶段，不允许向设备发送数据），
		/// 9：故障（设备处于故障，不允许向设备发送数据）
		/// </summary>
		public int Status
		{
			get { return _Status; }
			set { _Status = value; }
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
