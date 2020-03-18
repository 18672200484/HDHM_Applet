using System;
using System.Collections.Generic;
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Common.Entities.CarTransport;
using CMCS.Common.Entities.Fuel;
using CMCS.Common.Entities.Inf;
using CMCS.Common.Enums;
using CMCS.DapperDber.Dbs.SqlServerDb;
using CMCS.DumblyConcealer.Enums;
using CMCS.DumblyConcealer.Tasks.CarJXSampler.Entities;

namespace CMCS.DumblyConcealer.Tasks.CarJXSampler
{
	/// <summary>
	/// 汽车机械采样机接口业务
	/// </summary>
	public class EquCarJXSamplerDAO
	{
		/// <summary>
		/// EquCarJXSamplerDAO
		/// </summary>
		/// <param name="machineCode">设备编码</param>
		/// <param name="equDber">第三方数据库访问对象</param>
		public EquCarJXSamplerDAO(string machineCode, SqlServerDapperDber equDber)
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
		/// <param name="MachineCode">设备编码</param>
		/// <returns></returns>
		public int SyncSignal(Action<string, eOutputType> output)
		{
			int res = 0;

			foreach (EquQCJXCYJSignal entity in this.EquDber.Entities<EquQCJXCYJSignal>("where ReadFlag=0 and DeviceCode=@DeviceCode", new { DeviceCode = this.MachineCode }))
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
			output(string.Format("{0}同步实时信号 {1} 条", this.MachineCode, res), eOutputType.Normal);

			return res;
		}

		/// <summary>
		/// 获取上位机运行状态表 - 心跳值
		/// 每隔30s读取该值，如果数值不变化则表示设备上位机出现故障
		/// </summary>
		/// <param name="MachineCode">设备编码</param>
		public void SyncHeartbeatSignal()
		{
			EquQCJXCYJSignal pDCYSignal = this.EquDber.Entity<EquQCJXCYJSignal>("where DeviceCode=@DeviceCode", new { DeviceCode = this.MachineCode });
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

			if (IsHitch) commonDAO.SetSignalDataValue(this.MachineCode, eSignalDataName.系统.ToString(), eEquInfSamplerSystemStatus.发生故障.ToString());
		}

		/// <summary>
		/// 同步集样罐信息到集中管控
		/// </summary>
		/// <param name="output"></param> 
		/// <returns></returns>
		public void SyncBarrel(Action<string, eOutputType> output)
		{
			int res = 0;

			List<EquQCJXCYJBarrel> infpdcybarrels = this.EquDber.Entities<EquQCJXCYJBarrel>("where DeviceCode=@DeviceCode and ReadFlag=0", new { DeviceCode = this.MachineCode });
			foreach (EquQCJXCYJBarrel entity in infpdcybarrels)
			{
				if (commonDAO.SaveEquInfSampleBarrel(new InfEquInfSampleBarrel
				{
					BarrelNumber = entity.BucketNo.ToString(),
					BarrelStatus = entity.BucketFull == 0 ? "未满" : "已满",
					MachineCode = this.MachineCode,
					InFactoryBatchId = CarSamplerDAO.GetInstance().GetBatchIdBySampleCode(entity.SamplingCode),
					InterfaceType = GlobalVars.InterfaceType_QCJXCYJ,
					//IsCurrent = entity.IsCurrent,
					SampleCode = entity.SamplingCode,
					SampleCount = entity.CurrCapacity,
					UpdateTime = entity.EndTime,
					BarrelType = "底卸式",
				}))
				{

					entity.ReadFlag = 1;
					this.EquDber.Update(entity);

					res++;
				}
			}

			output(string.Format("{0}同步集样罐记录 {1} 条", this.MachineCode, res), eOutputType.Normal);
		}

		/// <summary>
		/// 同步故障信息到集中管控
		/// </summary>
		/// <param name="output"></param>
		/// <returns></returns>
		public void SyncQCJXCYJError(Action<string, eOutputType> output)
		{
			int res = 0;

			foreach (EquQCJXCYJError entity in this.EquDber.Entities<EquQCJXCYJError>("where DataFlag=0"))
			{
				if (commonDAO.SaveEquInfHitch(this.MachineCode, entity.ErrorTime, "故障代码 " + entity.ErrorCode + "，" + entity.ErrorDescribe))
				{
					entity.DataFlag = 1;
					this.EquDber.Update(entity);

					res++;
				}
			}

			output(string.Format("{0}同步故障信息记录 {1} 条", this.MachineCode, res), eOutputType.Normal);
		}

		/// <summary>
		/// 同步采样命令
		/// </summary>
		/// <param name="output"></param>
		/// <param name="MachineCode">设备编码</param>
		public void SyncSampleCmd(Action<string, eOutputType> output)
		{
			int res = 0;

			// 集中管控 > 第三方 
			foreach (InfQCJXCYSampleCMD entity in CarSamplerDAO.GetInstance().GetWaitForSyncSampleCMD(this.MachineCode))
			{
				bool isSuccess = false;
				// 需调整：命令中的水分等信息视接口而定
				EquQCJXCYJSamplePlan samplecmdEqu = this.EquDber.Entity<EquQCJXCYJSamplePlan>("where SamplingCode=@SamplingCode order by Id desc", new { SamplingCode = entity.SampleCode });
				if (samplecmdEqu == null)
				{
					isSuccess = this.EquDber.Insert(new EquQCJXCYJSamplePlan
					{
						OptNum = entity.Id,
						OptType = 1,
						DeviceCode = this.MachineCode,
						SamplingCode = entity.SampleCode,
						SampleWeight = entity.TicketWeight,
						CarCount = entity.CarCount,
						SendTime = DateTime.Now,
						OptTime = DateTime.Now,
						OptUser = "自动"
					}) > 0;
				}
				else
				{
					samplecmdEqu.OptNum = entity.Id;
					samplecmdEqu.OptType = 1;
					samplecmdEqu.DeviceCode = this.MachineCode;
					samplecmdEqu.SampleWeight = entity.TicketWeight;
					samplecmdEqu.CarCount = entity.CarCount;
					samplecmdEqu.SendTime = DateTime.Now;
					samplecmdEqu.OptTime = DateTime.Now;
					samplecmdEqu.OptUser = "自动";
					isSuccess = this.EquDber.Update(samplecmdEqu) > 0;
				}

				EquQCJXCYJSampleCmd sampleCmd = new EquQCJXCYJSampleCmd();
				sampleCmd.Id = entity.Id;
				sampleCmd.ParendID = samplecmdEqu.OptNum;
				sampleCmd.SamplingDeviceCode = this.MachineCode;
				sampleCmd.OptUser = "自动";
				sampleCmd.OptTime = DateTime.Now;
				sampleCmd.CardId = entity.CarNumber;
				sampleCmd.CarNumber = entity.CarNumber;
				sampleCmd.SamplingCount = entity.PointCount;
				sampleCmd.CarLength = entity.CarriageLength / 1000;
				sampleCmd.CarWidth = entity.CarriageWidth / 1000;
				sampleCmd.CarHeight = entity.CarriageHeight / 1000;
				sampleCmd.BottomHeight = entity.CarriageBottomToFloor / 1000;
				if (entity.Obstacle1 > 0)
					sampleCmd.TiePosition = (entity.Obstacle1 / 1000).ToString();
				if (entity.Obstacle2 > 0)
					sampleCmd.TiePosition += "|" + (entity.Obstacle2 / 1000).ToString();
				if (entity.Obstacle3 > 0)
					sampleCmd.TiePosition += "|" + (entity.Obstacle3 / 1000).ToString();
				if (entity.Obstacle4 > 0)
					sampleCmd.TiePosition += "|" + (entity.Obstacle4 / 1000).ToString();
				if (entity.Obstacle5 > 0)
					sampleCmd.TiePosition += "|" + (entity.Obstacle5 / 1000).ToString();
				if (entity.Obstacle6 > 0)
					sampleCmd.TiePosition += "|" + (entity.Obstacle6 / 1000).ToString();

				isSuccess = this.EquDber.Insert(sampleCmd) > 0;
				if (isSuccess)
				{
					entity.SyncFlag = 1;
					Dbers.GetInstance().SelfDber.Update(entity);

					res++;
				}
			}
			output(string.Format("{0}同步采样计划 {1} 条（集中管控 > 第三方）", this.MachineCode, res), eOutputType.Normal);

			res = 0;
			// 第三方 > 集中管控
			foreach (EquQCJXCYJSampleCmd entity in this.EquDber.Entities<EquQCJXCYJSampleCmd>("where ReadFlag=2 and datediff(dd,OptTime,getdate())=0"))
			{
				InfQCJXCYSampleCMD samplecmdInf = Dbers.GetInstance().SelfDber.Get<InfQCJXCYSampleCMD>(entity.Id);
				if (samplecmdInf == null) continue;
				if (!string.IsNullOrEmpty(entity.SamplingCoord))
				{
					string[] points = entity.SamplingCoord.Split('|');
					if (points.Length >= 1)
						samplecmdInf.Point1 = points[0];
					if (points.Length >= 2)
						samplecmdInf.Point2 = points[1];
					if (points.Length >= 3)
						samplecmdInf.Point2 = points[2];
					if (points.Length >= 4)
						samplecmdInf.Point2 = points[3];
					if (points.Length >= 5)
						samplecmdInf.Point2 = points[4];
					if (points.Length >= 6)
						samplecmdInf.Point2 = points[5];
				}
				samplecmdInf.StartTime = entity.StartTime;
				samplecmdInf.EndTime = entity.EndTime;
				samplecmdInf.SampleUser = entity.OptUser;

				if (entity.UpStatus == 2)
					samplecmdInf.ResultCode = eEquInfCmdResultCode.成功.ToString();

				if (Dbers.GetInstance().SelfDber.Update(samplecmdInf) > 0)
				{
					// 我方已读
					entity.ReadFlag = 3;
					this.EquDber.Update(entity);

					res++;
				}
			}
			output(string.Format("{0}同步采样计划 {1} 条（第三方 > 集中管控）", this.MachineCode, res), eOutputType.Normal);
		}

		/// <summary>
		/// 同步卸样命令
		/// </summary>
		/// <param name="output"></param>
		/// <returns></returns>
		public void SyncJXCYControlUnloadCMD(Action<string, eOutputType> output)
		{
			int res = 0;

			// 集中管控 > 第三方
			foreach (InfQCJXCYUnLoadCMD entity in CarSamplerDAO.GetInstance().GetWaitForSyncJXCYSampleUnloadCmd(MachineCode))
			{
				bool isSuccess = false;

				EquQCJXCYJUnloadCmd pJXCYCMD = this.EquDber.Entity<EquQCJXCYJUnloadCmd>("where OptNum=@OptNum", new { OptNum = entity.Id });
				if (pJXCYCMD == null)
				{
					isSuccess = this.EquDber.Insert(new EquQCJXCYJUnloadCmd
					{
						OptNum = entity.Id,
						DeviceCode = this.MachineCode,
						OptType = 1,
						SamplingCode = entity.SampleCode,
						SendTime = DateTime.Now,
						OptUser = "自动",
						OptTime = DateTime.Now,
						BucketNo = entity.BarrelNumber,
						BucketCode = entity.BarrelNumber
					}) > 0;
				}
				else isSuccess = true;

				if (isSuccess)
				{
					entity.SyncFlag = 1;
					Dbers.GetInstance().SelfDber.Update(entity);

					res++;
				}
			}
			output(string.Format("同步卸样命令 {0} 条（集中管控 > 第三方）", res), eOutputType.Normal);

			res = 0;
			// 第三方 > 集中管控
			foreach (EquQCJXCYJUnloadCmd entity in this.EquDber.Entities<EquQCJXCYJUnloadCmd>("where ReadFlag=2"))
			{
				InfQCJXCYUnLoadCMD JXCYCmd = Dbers.GetInstance().SelfDber.Get<InfQCJXCYUnLoadCMD>(entity.OptNum);
				if (JXCYCmd == null) continue;
				// 更新执行结果等
				if (entity.Upstatus == 100)
				{
					JXCYCmd.ResultCode = eEquInfCmdResultCode.成功.ToString();

					#region 同步卸样结果
					// 查找采样命令
					InfQCJXCYSampleCMD qCJXCYJSampleCmd = commonDAO.SelfDber.Entity<InfQCJXCYSampleCMD>("where SampleCode=:SampleCode", new { SampleCode = entity.SamplingCode });
					if (qCJXCYJSampleCmd != null)
					{
						CmcsRCSampling sample = commonDAO.SelfDber.Entity<CmcsRCSampling>("where SamplingType='机械采样' and InFactoryBatchId=:InFactoryBatchId", new { InFactoryBatchId = qCJXCYJSampleCmd.InFactoryBatchId });
						// 生成采样桶记录
						CmcsRCSampleBarrel rCSampleBarrel = new CmcsRCSampleBarrel()
						{
							BarrelCode = entity.BucketCode,
							BarrellingTime = entity.OutBucketTime,
							BarrelNumber = entity.BucketNo,
							InFactoryBatchId = qCJXCYJSampleCmd.InFactoryBatchId,
							SamplerName = this.MachineCode,
							SampleType = eSamplingType.机械采样.ToString(),
							SamplingId = sample != null ? sample.Id : ""
						};

						if (commonDAO.SelfDber.Insert(rCSampleBarrel) > 0)
						{
							commonDAO.SelfDber.Insert(new InfQCJXCYJUnloadResult
							{
								SampleCode = entity.SamplingCode,
								BarrelCode = entity.BucketCode,
								UnloadTime = entity.OutBucketTime,
								SamplingId = sample != null ? sample.Id : "",
								DataFlag = entity.ReadFlag,
								MachineCode = this.MachineCode
							});
						}
					}
					#endregion
				}
				else if (entity.Upstatus == 198 || entity.Upstatus == 199)
					JXCYCmd.ResultCode = eEquInfCmdResultCode.失败.ToString();
				if (Dbers.GetInstance().SelfDber.Update(JXCYCmd) > 0)
				{
					// 我方已读
					entity.ReadFlag = 3;
					this.EquDber.Update(entity);

					res++;
				}
			}
			output(string.Format("同步卸样命令 {0} 条（第三方 > 集中管控）", res), eOutputType.Normal);
		}
	}
}
