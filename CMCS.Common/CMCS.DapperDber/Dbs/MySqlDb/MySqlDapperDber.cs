using System;
using System.Collections.Generic;
// 
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace CMCS.DapperDber.Dbs.MySqlDb
{
    /// <summary>
    /// MySql 数据库访问对象
    /// </summary>
    public class MySqlDapperDber : BaseDber
    {
        /// <summary>
        /// MySqlDapperDber
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        public MySqlDapperDber(string connectionString)
            : base(connectionString, new MySqlDataAdapter(), new MySqlSqlBuilder())
        {

        }

        /// <summary>
        /// 创建一个 DbConnection 对象
        /// </summary>
        /// <returns></returns>
        public override DbConnection CreateConnection()
        {
            return new MySqlConnection(this.ConnectionString);
        }
    }
}
