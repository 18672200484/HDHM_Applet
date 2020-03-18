using System;
using System.Collections.Generic;
//
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;

namespace CMCS.DapperDber.Dbs.OracleDb
{
    /// <summary>
    /// Oracle 数据库访问对象
    /// </summary>
    public class OracleDapperDber : BaseDber
    {
        /// <summary>
        /// OracleDapperDber
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        public OracleDapperDber(string connectionString)
            : base(connectionString, new OracleDataAdapter(), new OracleSqlBuilder())
        {

        }

        /// <summary>
        /// 创建一个 DbConnection 对象
        /// </summary>
        /// <returns></returns>
        public override DbConnection CreateConnection()
        {
            return new OracleConnection(this.ConnectionString);
        }
    }
}
