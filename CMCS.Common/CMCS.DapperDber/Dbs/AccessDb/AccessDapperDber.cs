using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// 
using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace CMCS.DapperDber.Dbs.AccessDb
{
    /// <summary>
    /// Access 数据库访问对象
    /// </summary>
    public class AccessDapperDber : BaseDber
    {
        /// <summary>
        /// AccessDapperDber
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        public AccessDapperDber(string connectionString)
            : base(connectionString, new OleDbDataAdapter(), new AccessSqlBuilder())
        {

        }

        /// <summary>
        /// 创建一个 DbConnection 对象
        /// </summary>
        /// <returns></returns>
        public override DbConnection CreateConnection()
        {
            return new OleDbConnection(this.ConnectionString);
        }
    }
}
