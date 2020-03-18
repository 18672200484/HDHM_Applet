using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CMCS.DapperDber.Dbs.AccessDb;
// 
using CMCS.DapperDber.Dbs.OracleDb;
using CMCS.DapperDber.Dbs.SqlServerDb;
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Common.Utilities;

namespace CMCS.DumblyConcealer
{
    /// <summary>
    /// 数据库访问
    /// </summary>
    public class DcDbers
    {
        private static DcDbers instance;

        public static DcDbers GetInstance()
        {
            if (instance == null)
            {
                instance = new DcDbers();
            }

            return instance;
        }

        CommonDAO commonDAO = CommonDAO.GetInstance();

        private DcDbers()
        {
            BeltSampler_Dber = new SqlServerDapperDber(commonDAO.GetCommonAppletConfigString("皮带采样机接口连接字符串"));
            AutoCupboard_Dber = new SqlServerDapperDber(commonDAO.GetCommonAppletConfigString("智能存样柜接口连接字符串"));
            PneumaticTransfer_Dber = new SqlServerDapperDber(commonDAO.GetCommonAppletConfigString("气动传输接口连接字符串"));
         
            WeightBridger_Dber = new SqlServerDapperDber(commonDAO.GetCommonAppletConfigString("轨道衡数据库连接字符串"));
            CarJXSampler_Dber1 = new SqlServerDapperDber(commonDAO.GetCommonAppletConfigString("#1汽车机械采样机接口连接字符串"));
            CarJXSampler_Dber2 = new SqlServerDapperDber(commonDAO.GetCommonAppletConfigString("#2汽车机械采样机接口连接字符串"));

            WeightBridger_Dber1 = new AccessDapperDber(string.Format(commonDAO.GetAppletConfigString("轨道衡数据库连接字符串1"), DateTime.Now.Year));
        }

        void Dber_SqlWatch(string type, string sql)
        {
            Log4Neter.Info(sql);
        }

        /// <summary>
        /// 皮带采样机接口
        /// </summary>
        public SqlServerDapperDber BeltSampler_Dber;
        /// <summary>
        /// 智能存样柜接口
        /// </summary>
        public SqlServerDapperDber AutoCupboard_Dber;
        /// <summary>
        /// 气动传输接口
        /// </summary>
        public SqlServerDapperDber PneumaticTransfer_Dber;
      
        /// <summary>
        /// #1汽车机械采样机接口
        /// </summary>
        public SqlServerDapperDber CarJXSampler_Dber1;
        /// <summary>
        /// #2汽车机械采样机接口
        /// </summary>
        public SqlServerDapperDber CarJXSampler_Dber2;
        /// <summary>
        /// #3汽车机械采样机接口
        /// </summary>
        public SqlServerDapperDber CarJXSampler_Dber3;
        /// <summary>
        /// 轨道衡数据库链接
        /// </summary>
        public SqlServerDapperDber WeightBridger_Dber;

        /// <summary>
        /// 轨道衡数据库链接
        /// </summary>
        public AccessDapperDber WeightBridger_Dber1;
    }
}
