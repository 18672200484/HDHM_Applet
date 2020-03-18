using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.DAO;
using CMCS.Common.Entities.CarTransport;
using CMCS.DapperDber.Dbs.OracleDb;
using CMCS.Common;
using CMCS.Common.Entities;
using CMCS.Common.Views;
using CMCS.DapperDber.Util;
using CMCS.Common.Enums;
using CMCS.Common.Entities.Fuel;

namespace CMCS.CarTransport.DAO
{
	/// <summary>
	/// 汽车机械采样业务
	/// </summary>
	public class JxSamplerDAO
	{
		private static JxSamplerDAO instance;

		public static JxSamplerDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new JxSamplerDAO();
			}

			return instance;
		}

		private JxSamplerDAO()
		{ }

		public OracleDapperDber SelfDber
		{
			get { return Dbers.GetInstance().SelfDber; }
		}

		CommonDAO commonDAO = CommonDAO.GetInstance();
		CarTransportDAO carTransportDAO = CarTransportDAO.GetInstance();

		#region 入厂煤业务

		/// <summary>
		/// 获取指定日期已完成的入厂煤运输记录
		/// </summary>
		/// <param name="dtStart"></param>
		/// <param name="dtEnd"></param>
		/// <returns></returns>
		public List<View_BuyFuelTransport> GetFinishedBuyFuelTransport(DateTime dtStart, DateTime dtEnd)
		{
			return SelfDber.Entities<View_BuyFuelTransport>("where SamplingTime>:SamplingTime and IsUse=1 and InFactoryTime>=:dtStart and InFactoryTime<:dtEnd order by InFactoryTime desc", new { SamplingTime = new DateTime(2000, 1, 1), dtStart = dtStart, dtEnd = dtEnd });
		}

		/// <summary>
		/// 获取未完成的入厂煤运输记录
		/// </summary>
		/// <returns></returns>
		public List<View_BuyFuelTransport> GetUnFinishBuyFuelTransport()
		{
			return SelfDber.Entities<View_BuyFuelTransport>("where SamplingTime<:SamplingTime and IsUse=1 order by InFactoryTime desc", new { SamplingTime = new DateTime(2000, 1, 1) });
		}

		/// <summary>
		/// 保存入厂煤运输记录
		/// </summary>
		/// <param name="transportId"></param> 
		/// <param name="place"></param>
		/// <returns></returns>
		public bool SaveBuyFuelTransport(string transportId, DateTime dt, string place)
		{
			CmcsBuyFuelTransport transport = SelfDber.Get<CmcsBuyFuelTransport>(transportId);
			if (transport == null) return false;

			transport.StepName = eTruckInFactoryStep.采样.ToString();
			transport.SamplingTime = dt;
			transport.SamplePlace = place;

			return SelfDber.Update(transport) > 0;
		}

		#endregion

	}
}
