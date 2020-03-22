using System;
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Common.Entities.Fuel;
using CMCS.Common.Entities.Inf;
using CMCS.Common.Enums;
using CMCS.DapperDber.Dbs.SqlServerDb;
using CMCS.DumblyConcealer.Enums;
using CMCS.DumblyConcealer.Tasks.AutoMaker.Entities;

namespace CMCS.DumblyConcealer.Tasks.AutoMaker
{
	/// <summary>
	/// 全自动制样机接口业务
	/// </summary>
	public class EquAutoMakerDAO
	{
		/// <summary>
		/// EquAutoMakerDAO
		/// </summary>
		/// <param name="machineCode">制样机编码</param>
		/// <param name="equDber">第三方数据库访问对象</param>
		public EquAutoMakerDAO(string machineCode, SqlServerDapperDber equDber)
		{
			this.MachineCode = machineCode;
			this.EquDber = equDber;
		}

		CommonDAO commonDAO = CommonDAO.GetInstance();

		/// <summary>
		/// 第三方数据库访问对象
		/// </summary>
		SqlServerDapperDber EquDber;
		/// <summary>
		/// 设备编码
		/// </summary>
		string MachineCode;
		/// <summary>
		/// 是否处于故障状态
		/// </summary>
		bool IsHitch = false;
		/// <summary>
		/// 上一次上位机心跳值
		/// </summary>
		string PrevHeartbeat = string.Empty;

		#region 数据转换方法（此处有点麻烦，后期调整接口方案）


		#endregion

		/// <summary>
		/// 同步实时信号到集中管控
		/// </summary>
		/// <param name="output"></param>
		/// <returns></returns>
		public int SyncSignal(Action<string, eOutputType> output)
		{
			int res = 0;

			foreach (EquQZDZYJSignal entity in this.EquDber.Entities<EquQZDZYJSignal>())
			{
				if (entity.Status == 1)
					res += commonDAO.SetSignalDataValue(this.MachineCode, eSignalDataName.系统.ToString(), eEquInfSamplerSystemStatus.就绪待机.ToString()) ? 1 : 0;
				else if (entity.Status == 2)
					res += commonDAO.SetSignalDataValue(this.MachineCode, eSignalDataName.系统.ToString(), eEquInfSamplerSystemStatus.正在运行.ToString()) ? 1 : 0;
				else if (entity.Status == 9)
					res += commonDAO.SetSignalDataValue(this.MachineCode, eSignalDataName.系统.ToString(), eEquInfSamplerSystemStatus.发生故障.ToString()) ? 1 : 0;

				if (!string.IsNullOrEmpty(entity.FaultDetail))
					commonDAO.SaveEquInfHitch(this.MachineCode, entity.UpdateTime, "故障代码 " + entity.FaultCode + "，" + entity.FaultDetail);
			}
			output(string.Format("同步实时信号 {0} 条", res), eOutputType.Normal);

			return res;
		}

		/// <summary>
		/// 获取上位机运行状态表 - 心跳值
		/// 每隔30s读取该值，如果数值不变化则表示设备上位机出现故障
		/// </summary>
		/// <returns></returns>
		public void SyncHeartbeatSignal()
		{
			EquQZDZYJSignal pDCYSignal = this.EquDber.Entity<EquQZDZYJSignal>("where DeviceCode=@DeviceCode", new { DeviceCode = this.MachineCode });
			ChangeSystemHitchStatus((pDCYSignal != null && pDCYSignal.UpdateTime.ToString("yyyyMMddHH:MI:SS") == this.PrevHeartbeat));
			this.PrevHeartbeat = pDCYSignal != null ? pDCYSignal.UpdateTime.ToString("yyyyMMddHH:MI:SS") : string.Empty;
		}

		/// <summary>
		/// 改变系统状态值
		/// </summary>
		/// <param name="isHitch">是否故障</param>
		public void ChangeSystemHitchStatus(bool isHitch)
		{
			IsHitch = isHitch;

			if (IsHitch) CommonDAO.GetInstance().SetSignalDataValue(this.MachineCode, eSignalDataName.系统.ToString(), eEquInfSamplerSystemStatus.发生故障.ToString());
		}

		/// <summary>
		/// 同步制样计划
		/// </summary>
		/// <param name="output"></param>
		/// <returns></returns>
		public void SyncPlan(Action<string, eOutputType> output)
		{
			int res = 0;

			// 集中管控 > 第三方 
			foreach (InfMakerControlCmd entity in AutoMakerDAO.GetInstance().GetWaitForSyncMakerControlCmd(this.MachineCode))
			{
				bool isSuccess = false;
				InfMakerPlan makePlan = commonDAO.SelfDber.Entity<InfMakerPlan>("where MakeCode=:MakeCode order by CreationTime", new { MakeCode = entity.MakeCode });
				if (makePlan != null)
				{
					// 需调整：计划中的煤种、水分、颗粒度等信息视接口而定
					EquQZDZYJCmd qZDZYJPlan = this.EquDber.Entity<EquQZDZYJCmd>("where OptNum=@OptNum", new { OptNum = entity.Id });

					if (qZDZYJPlan == null)
					{
						isSuccess = this.EquDber.Insert(new EquQZDZYJCmd
						{
							// 保持相同的Id
							OptNum = entity.Id,
							DeviceCode = this.MachineCode,
							PrepareCode = entity.MakeCode,
							CoalType = makePlan.FuelKindName,
							CoalSize = makePlan.CoalSize,
							UseType = 1,
							Status = 1,
							SendTime = DateTime.Now,
							ReadFlag = 0,
							OptUser = "自动",
							OptTime = DateTime.Now,
							OptCreateModel = 1,
							OptExeModel = 1
						}) > 0;
					}
					else
					{
						qZDZYJPlan.DeviceCode = this.MachineCode;
						qZDZYJPlan.PrepareCode = entity.MakeCode;
						qZDZYJPlan.CoalType = makePlan.FuelKindName;
						qZDZYJPlan.CoalSize = makePlan.CoalSize;
						qZDZYJPlan.UseType = 1;
						qZDZYJPlan.Status = 1;
						qZDZYJPlan.SendTime = DateTime.Now;
						qZDZYJPlan.ReadFlag = 0;
						qZDZYJPlan.OptUser = "自动";
						qZDZYJPlan.OptTime = DateTime.Now;
						qZDZYJPlan.OptCreateModel = 1;
						qZDZYJPlan.OptExeModel = 1;
						isSuccess = this.EquDber.Update(qZDZYJPlan) > 0;
					}

					qZDZYJPlan = this.EquDber.Entity<EquQZDZYJCmd>("where OptNum=@OptNum", new { OptNum = entity.Id });
					EquQZDZYJCmdDetail qZDZYJCmd = this.EquDber.Get<EquQZDZYJCmdDetail>(entity.Id);
					if (qZDZYJCmd == null)
					{
						isSuccess = this.EquDber.Insert(new EquQZDZYJCmdDetail
						{
							// 保持相同的Id
							Id = entity.Id,
							ParendID = qZDZYJPlan.Id.ToString(),
							PrepareDeviceCode = entity.MakeCode,
							UpStatus = 0,
							UpTime = DateTime.Now
						}) > 0;
					}
					else
					{
						qZDZYJCmd = new EquQZDZYJCmdDetail();
						qZDZYJCmd.ParendID = qZDZYJPlan.Id.ToString();
						qZDZYJCmd.PrepareDeviceCode = entity.MakeCode;
						qZDZYJCmd.UpStatus = 0;
						qZDZYJCmd.UpTime = DateTime.Now;
						isSuccess = this.EquDber.Update(qZDZYJCmd) > 0;
					}

					if (isSuccess)
					{
						entity.SyncFlag = 1;
						commonDAO.SelfDber.Update(entity);

						res++;
					}
				}
			}
			output(string.Format("同步制样计划 {0} 条（集中管控 > 第三方）", res), eOutputType.Normal);

			res = 0;
			// 第三方 > 集中管控
			foreach (EquQZDZYJCmd entity in this.EquDber.Entities<EquQZDZYJCmd>("where DeviceCode=@DeviceCode and ReadFlag=2", new { DeviceCode = this.MachineCode }))
			{
				InfMakerControlCmd controlCmd = commonDAO.SelfDber.Get<InfMakerControlCmd>(entity.OptNum);
				if (controlCmd != null)
				{
					if (entity.Status == 100)
						controlCmd.ResultCode = eEquInfCmdResultCode.成功.ToString();
					else if (entity.Status == 99)
						controlCmd.ResultCode = eEquInfCmdResultCode.失败.ToString();
					commonDAO.SelfDber.Update(controlCmd);

					entity.ReadFlag = 3;
					res += this.EquDber.Update(entity);
				}
			}
			output(string.Format("同步制样计划 {0} 条（第三方 > 集中管控 ）", res), eOutputType.Normal);

		}

		/// <summary>
		/// 皮带控制命令表
		/// </summary>
		/// <param name="output"></param>
		/// <returns></returns>
		public void SyncCmd(Action<string, eOutputType> output)
		{
			int res = 0;

			// 集中管控 > 第三方 
			foreach (InfMakerControlCmd entity in AutoMakerDAO.GetInstance().GetWaitForSyncMakerControlCmd(this.MachineCode))
			{
				bool isSuccess = false;

				EquQZDZYJCmd qZDZYJCmd = this.EquDber.Get<EquQZDZYJCmd>(entity.Id);
				if (qZDZYJCmd == null)
				{
					isSuccess = this.EquDber.Insert(new EquQZDZYJCmd
					{
						// 保持相同的Id
						//Id = entity.Id,
						//CmdCode = entity.CmdCode,
						//MakeCode = entity.MakeCode,
						//ResultCode = eEquInfCmdResultCode.默认.ToString(),
						//DataFlag = 0
					}) > 0;
				}
				else isSuccess = true;

				if (isSuccess)
				{
					entity.SyncFlag = 1;
					commonDAO.SelfDber.Update(entity);

					res++;
				}
			}
			output(string.Format("同步控制命令 {0} 条（集中管控 > 第三方）", res), eOutputType.Normal);

			res = 0;
			// 第三方 > 集中管控
			foreach (EquQZDZYJCmd entity in this.EquDber.Entities<EquQZDZYJCmd>("where DataFlag=2"))
			{
				InfMakerControlCmd makerControlCmd = commonDAO.SelfDber.Get<InfMakerControlCmd>(entity.OptNum);
				if (makerControlCmd == null) continue;

				// 更新执行结果等
				//makerControlCmd.ResultCode = entity.ResultCode;
				makerControlCmd.DataFlag = 3;

				if (commonDAO.SelfDber.Update(makerControlCmd) > 0)
				{
					// 我方已读
					entity.ReadFlag = 3;
					this.EquDber.Update(entity);

					res++;
				}
			}
			output(string.Format("同步控制命令 {0} 条（第三方 > 集中管控）", res), eOutputType.Normal);
		}

		/// <summary>
		/// 同步制样 出样明细信息到集中管控
		/// </summary>
		/// <param name="output"></param>
		/// <returns></returns>
		public void SyncMakeDetail(Action<string, eOutputType> output)
		{
			int res = 0;

			foreach (EquQZDZYJMakeDetail entity in this.EquDber.Entities<EquQZDZYJMakeDetail>("where ReadFlag=2 and PrepareDeviceCode=@PrepareDeviceCode order by OutOrder asc", new { PrepareDeviceCode = this.MachineCode }))
			{
				if (SyncToRCMakeDetail(entity))
				{
					if (AutoMakerDAO.GetInstance().SaveMakerRecord(new InfMakerRecord
					{
						InterfaceType = CommonDAO.GetInstance().GetMachineInterfaceTypeByCode(this.MachineCode),
						MachineCode = this.MachineCode,
						MakeCode = entity.PrepareCode,
						BarrelCode = entity.BottleCode,
						YPType = SampleTypeChange(entity.SampleType),
						YPWeight = entity.SampleWeight,
						StartTime = entity.ResultTime,
						EndTime = entity.ResultTime,
						DataFlag = 1
					}))
					{
						entity.ReadFlag = 3;
						this.EquDber.Update(entity);
						res++;

						// 需调整：启动传输调度计划需根据现场情况而定
						// 插入气动传输调度计划
						//EquAutoCupboardDAO.GetInstance().AddNewSendSampleId(entity.BarrelCode, entity.YPType, eCmdCode.制样机1, eCmdCode.存样柜);
					}
				}
			}

			output(string.Format("同步出样明细记录 {0} 条", res), eOutputType.Normal);
		}

		/// <summary>
		/// 同步制样 故障信息到集中管控
		/// </summary>
		/// <param name="output"></param>
		/// <returns></returns>
		public void SyncError(Action<string, eOutputType> output)
		{
			int res = 0;

			foreach (EquQZDZYJError entity in this.EquDber.Entities<EquQZDZYJError>("where DataFlag=0"))
			{
				if (CommonDAO.GetInstance().SaveEquInfHitch(this.MachineCode, entity.ErrorTime, entity.ErrorDescribe))
				{
					entity.DataFlag = 1;
					this.EquDber.Update(entity);

					res++;
				}
			}

			output(string.Format("同步故障信息记录 {0} 条", res), eOutputType.Normal);
		}

		/// <summary>
		/// 同步样品信息到集中管控入厂煤制样明细表
		/// </summary>
		/// <param name="makeDetail"></param>
		private bool SyncToRCMakeDetail(EquQZDZYJMakeDetail makeDetail)
		{
			CmcsRCMake rCMake = commonDAO.SelfDber.Entity<CmcsRCMake>("where MakeCode=:MakeCode and IsDeleted=0", new { MakeCode = makeDetail.PrepareCode });
			if (rCMake != null)
			{
				// 修改制样结束时间
				rCMake.MakeType = eMakeType.机械制样.ToString();

				rCMake.GetDate = DateTime.Now;
				rCMake.MakeDate = makeDetail.ResultTime;

				commonDAO.SelfDber.Update(rCMake);

				CmcsRCMakeDetail rCMakeDetail = commonDAO.SelfDber.Entity<CmcsRCMakeDetail>("where MakeId=:MakeId and SampleType=:SampleType and IsDeleted=0", new { MakeId = rCMake.Id, SampleType = SampleTypeChange(makeDetail.SampleType) });
				if (rCMakeDetail != null)
				{
					rCMakeDetail.LastModificAtionTime = DateTime.Now;
					rCMakeDetail.CreationTime = DateTime.Now;
					rCMakeDetail.SampleWeight = makeDetail.SampleWeight;
					rCMakeDetail.SampleCode = makeDetail.SampleCode;
					rCMakeDetail.SampleType = SampleTypeChange(makeDetail.SampleType);
					return commonDAO.SelfDber.Update(rCMakeDetail) > 0;
				}
			}

			return false;
		}

		private string SampleTypeChange(int sampleType)
		{
			string SampleType = string.Empty;
			switch (sampleType)
			{
				case 1:
					SampleType = "3mm存查样";
					break;
				case 2:
					SampleType = "6mm全水样";
					break;
				case 3:
					SampleType = "0.2mm分析样";
					break;
				case 4:
					SampleType = "总经理样";
					break;
				default:
					break;
			}
			return SampleType;
		}
	}
}
