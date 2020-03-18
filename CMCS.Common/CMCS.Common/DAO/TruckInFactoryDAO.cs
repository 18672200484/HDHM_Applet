using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using CMCS.DapperDber.Dbs.OracleDb;

namespace CMCS.Common.DAO
{
    /// <summary>
    /// 汽车入厂业务
    /// </summary>
    public class TruckInFactoryDAO
    {
        private static TruckInFactoryDAO instance;

        public static TruckInFactoryDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new TruckInFactoryDAO();
            }

            return instance;
        }

        private TruckInFactoryDAO()
        { }

        public OracleDapperDber SelfDber
        {
            get { return Dbers.GetInstance().SelfDber; }
        }

        #region 汽车智能化 

        #endregion
    }
}
