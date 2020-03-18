using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// 
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;
using CMCS.DapperDber.Attrs;
using CMCS.DapperDber.Util;

namespace CMCS.DapperDber.Dbs.SqlServerDb
{
    /// <summary>
    /// Sql Server 数据库访问对象
    /// </summary>
    public class SqlServerDapperDber : BaseDber
    {
        /// <summary>
        /// SqlServerDapperDber
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        public SqlServerDapperDber(string connectionString)
            : base(connectionString, new SqlDataAdapter(), new SqlServerSqlBuilder())
        {

        }

        /// <summary>
        /// 创建一个 DbConnection 对象
        /// </summary>
        /// <returns></returns>
        public override DbConnection CreateConnection()
        {
            return new SqlConnection(this.ConnectionString);
        }

        /// <summary>
        /// 插入实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">实体</param>
        /// <returns></returns>
        public new int Insert<T>(T t) where T : class
        {
            CheckEntityDateTime<T>(t);

            return base.Insert<T>(t);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">实体</param>
        /// <returns></returns>
        public new int Update<T>(T t) where T : class
        {
            CheckEntityDateTime<T>(t);

            return base.Update<T>(t);
        }

        /// <summary>
        /// 检查实体DateTime的合法性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void CheckEntityDateTime<T>(T t) where T : class
        {
            foreach (PropertyInfo pi in typeof(T).GetProperties().Where(a => a.PropertyType == typeof(DateTime)))
            {
                if (EntityReflectionUtil.HasPropertyInfoAttribute(pi, typeof(DapperIgnoreAttribute)))
                    continue;

                DateTime dt = (DateTime)pi.GetValue(t, null);
                if (dt == DateTime.MinValue) pi.SetValue(t, System.Data.SqlTypes.SqlDateTime.MinValue.Value, null);
            }
        }
    }
}
