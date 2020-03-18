using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CMCS.ADGS.Core
{
    /// <summary>
    /// 内置通用提取类
    /// </summary>
    public class ByoGraber : AssayGraber
    {
        /// <summary>
        /// 数据查询语句
        /// </summary>
        public string SQL
        {
            get { return Parameters["SQL"]; } 
        }

        /// <summary>
        /// 数据库类型：Access SqlServer SQLite
        /// </summary>
        public string DbType
        {
            get { return Parameters["DbType"]; } 
        }

        public override System.Data.DataTable ExecuteGrab()
        {
            DataTable dtl = new DataTable();

            switch (DbType.ToLower())
            {
                case "access":
                    dtl = new CMCS.DapperDber.Dbs.AccessDb.AccessDapperDber(ConnStr).ExecuteDataTable(SQL);
                    break;
                case "sqlserver":
                    dtl = new CMCS.DapperDber.Dbs.SqlServerDb.SqlServerDapperDber(ConnStr).ExecuteDataTable(SQL);
                    break;
                case "sqlite":
                    dtl = new CMCS.DapperDber.Dbs.SQLiteDb.SQLiteDapperDber(ConnStr).ExecuteDataTable(SQL);
                    break;
            }

            return dtl;
        }
    }
}
