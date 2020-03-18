using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// 
using System.Data;
using System.Data.Common;
using System.Data.SQLite;

namespace CMCS.DapperDber.Dbs.SQLiteDb
{
    /// <summary>
    /// SQLite 数据库访问对象
    /// </summary>
    public class SQLiteDapperDber : BaseDber
    {
        /// <summary>
        /// SQLiteDapperDber
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        public SQLiteDapperDber(string connectionString)
            : base(connectionString, new SQLiteDataAdapter(), new SQLiteSqlBuilder())
        {

        }

        /// <summary>
        /// 创建一个 DbConnection 对象
        /// </summary>
        /// <returns></returns>
        public override DbConnection CreateConnection()
        {
            return new SQLiteConnection(this.ConnectionString);
        }
    }
}
