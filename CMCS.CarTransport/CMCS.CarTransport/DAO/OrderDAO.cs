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

namespace CMCS.CarTransport.DAO
{
    /// <summary>
    /// 汽车煤仓业务
    /// </summary>
    public class OrderDAO
    {
        private static OrderDAO instance;

        public static OrderDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new OrderDAO();
            }

            return instance;
        }

        private OrderDAO()
        { }

        public OracleDapperDber SelfDber
        {
            get { return Dbers.GetInstance().SelfDber; }
        }

        CommonDAO commonDAO = CommonDAO.GetInstance();
        CarTransportDAO carTransportDAO = CarTransportDAO.GetInstance();

        #region 销售煤业务
        /// <summary>
        /// 保存入厂煤运输记录
        /// </summary>
        /// <param name="transportId"></param> 
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool SaveSaleFuelTransport(string transportId, DateTime dt)
        {
            CmcsSaleFuelTransport transport = SelfDber.Get<CmcsSaleFuelTransport>(transportId);
            if (transport == null) return false;

            transport.StepName = eTruckInFactoryStep.装载.ToString();
            transport.LoadTime = dt;
            return SelfDber.Update(transport) > 0;
        }


        /// <summary>
        /// 获取指定日期已完成的销售煤运输记录
        /// </summary>
        /// <param name="dtStart"></param>
        /// <param name="dtEnd"></param>
        /// <returns></returns>
        public List<View_SaleFuelTransport> GetFinishedSaleFuelTransport(DateTime dtStart, DateTime dtEnd)
        {
            return SelfDber.Entities<View_SaleFuelTransport>("where SuttleWeight!=0 and InFactoryTime>=:dtStart and InFactoryTime<:dtEnd order by InFactoryTime desc", new { dtStart = dtStart, dtEnd = dtEnd });
        }

        /// <summary>
        /// 获取未完成的销售煤运输记录
        /// </summary>
        /// <returns></returns>
        public List<View_SaleFuelTransport> GetUnFinishSaleFuelTransport()
        {
            return SelfDber.Entities<View_SaleFuelTransport>("where SuttleWeight=0 and IsUse=1 and UnFinishTransportId is not null order by InFactoryTime desc");
        }

        /// <summary>
        /// 保存销售煤运输记录
        /// </summary>
        /// <param name="transportId"></param>
        /// <param name="weight">重量</param>
        /// <param name="place"></param>
        /// <returns></returns>
        public bool SaveSaleFuelTransport(string transportId, decimal weight, DateTime dt, string place)
        {
            CmcsSaleFuelTransport transport = SelfDber.Get<CmcsSaleFuelTransport>(transportId);
            if (transport == null) return false;
            if (transport.TareWeight == 0 && transport.GrossWeight != 0)
            {
                transport.StepName = eTruckInFactoryStep.装载.ToString();
                transport.LoadArea = place;
                transport.Loader = "";
                transport.LoadTime = dt;
            }
            else
                return false;

            return SelfDber.Update(transport) > 0;
        }
        #endregion


    }
}
