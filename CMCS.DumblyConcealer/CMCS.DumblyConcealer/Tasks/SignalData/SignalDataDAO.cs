using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
//
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Common.Entities.CarTransport;
using CMCS.Common.Entities.Fuel;
using CMCS.DapperDber.Dbs.AccessDb;
using CMCS.DumblyConcealer.Enums;
using CMCS.DumblyConcealer.Tasks.DataHandler.Entities;

namespace CMCS.DumblyConcealer.Tasks.CarSynchronous
{
	/// <summary>
	/// 集控信号点生成
	/// </summary>
	public class SignalDataDAO
	{
		private static SignalDataDAO instance;

		public static SignalDataDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new SignalDataDAO();
			}
			return instance;
		}

		CommonDAO commonDAO = CommonDAO.GetInstance();

		private SignalDataDAO()
		{ }

		/// <summary>
		/// 集控首页信号生成
		/// </summary>
		/// <returns></returns>
		public void PageHome(Action<string, eOutputType> output)
		{
			int res = 0;
			bool succes = false;
			commonDAO.SetSignalDataValue(GlobalVars.MachineCode_HomePage_1, "汽车_入厂车数", commonDAO.SelfDber.Count<CmcsBuyFuelTransport>("where trunc(InFactoryTime)=trunc(sysdate)").ToString());
			commonDAO.SetSignalDataValue(GlobalVars.MachineCode_HomePage_1, "汽车_称重车数", commonDAO.SelfDber.Count<CmcsBuyFuelTransport>("where trunc(GrossTime)=trunc(sysdate)").ToString());
			commonDAO.SetSignalDataValue(GlobalVars.MachineCode_HomePage_1, "汽车_采样车数", commonDAO.SelfDber.Count<CmcsBuyFuelTransport>("where trunc(SamplingTime)=trunc(sysdate)").ToString());
			commonDAO.SetSignalDataValue(GlobalVars.MachineCode_HomePage_1, "汽车_卸煤车数", commonDAO.SelfDber.Count<CmcsBuyFuelTransport>("where trunc(UploadTime)=trunc(sysdate)").ToString());
			commonDAO.SetSignalDataValue(GlobalVars.MachineCode_HomePage_1, "汽车_出厂车数", commonDAO.SelfDber.Count<CmcsBuyFuelTransport>("where trunc(OutFactoryTime)=trunc(sysdate)").ToString());

			DataTable data = commonDAO.SelfDber.ExecuteDataTable("select sum(SuttleWeight) from CmcsTbBuyFuelTransport where trunc(TareTime)=trunc(sysdate)");
			commonDAO.SetSignalDataValue(GlobalVars.MachineCode_HomePage_1, "汽车_入厂煤量", data.Rows[0][0].ToString());

			data = commonDAO.SelfDber.ExecuteDataTable("select sum(SuttleWeight) from CmcsTbBuyFuelTransport where trunc(UploadTime)=trunc(sysdate)");
			commonDAO.SetSignalDataValue(GlobalVars.MachineCode_HomePage_1, "汽车_卸煤煤量", data.Rows[0][0].ToString());

			data = commonDAO.SelfDber.ExecuteDataTable("select sum(num) from(select count(infactorybatchid) num from CmcsTbBuyFuelTransport where trunc(SamplingTime)=trunc(sysdate) group by infactorybatchid)");
			commonDAO.SetSignalDataValue(GlobalVars.MachineCode_HomePage_1, "汽车_卸煤煤量", data.Rows[0][0].ToString());
			output(string.Format("同步批次明细数据 {0} 条", res), eOutputType.Normal);
		}

	}
}
