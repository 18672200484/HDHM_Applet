using System;
using System.Collections.Generic;
//
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Text;
using CMCS.DapperDber.Attrs;
using CMCS.DapperDber.Util;

namespace CMCS.DapperDber.Dbs
{
    /// <summary>
    /// BaseDber
    /// </summary>
    public abstract class BaseDber : IDapperDber
    {
        private string connectionString;
        private ISqlBuilder sqlBuilder;
        private DbDataAdapter adapter;

        /// <summary>
        /// 数据库连接字符
        /// </summary>
        public string ConnectionString
        {
            get { return connectionString; }
        }

        /// <summary>
        /// SQL语句对象
        /// </summary>
        public ISqlBuilder SqlBuilder
        {
            get { return sqlBuilder; }
        }

        /// <summary>
        /// SqlWatchEventHandler
        /// </summary>
        /// <param name="type"></param>
        /// <param name="sql"></param>
        public delegate void SqlWatchEventHandler(string type, string sql);

        /// <summary>
        /// 监听执行的SQL语句
        /// </summary>
        public event SqlWatchEventHandler SqlWatch;

        /// <summary>
        /// BaseDber
        /// </summary>
        /// <param name="connectionString">数据库连接字符</param>
        /// <param name="adapter">DbDataAdapter</param>
        /// <param name="sqlBuilder">语句生成对象</param>
        public BaseDber(string connectionString, DbDataAdapter adapter, ISqlBuilder sqlBuilder)
        {
            this.connectionString = connectionString;
            this.sqlBuilder = sqlBuilder;
            this.adapter = adapter;
        }

        /// <summary>
        /// 创建一个 DbConnection 对象
        /// </summary>
        /// <returns></returns>
        public abstract DbConnection CreateConnection();

        /// <summary>
        /// 创建一个 DbCommand 对象
        /// </summary>
        /// <param name="connection">DbConnection</param> 
        /// <param name="commandText">SQL语句</param> 
        /// <param name="parameters">参数</param>
        /// <param name="commandType">命令类型</param> 
        /// <returns></returns>
        protected DbCommand CreateCommand(DbConnection connection, string commandText, DbParameter[] parameters, CommandType commandType = CommandType.Text)
        {
            DbCommand cmd = connection.CreateCommand();
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;

            if (parameters != null && parameters.Length > 0)
                cmd.Parameters.AddRange(parameters);

            return cmd;
        }

        /// <summary>
        /// 根据实体创建动态参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">实体</param>
        /// <returns></returns>
        protected DynamicParameters CreateDynamicParameters<T>(T t)
        {
            DynamicParameters res = new DynamicParameters();

            foreach (PropertyInfo pi in typeof(T).GetProperties())
            {
                if (EntityReflectionUtil.HasPropertyInfoAttribute(pi, typeof(DapperIgnoreAttribute)))
                    continue;

                if (pi.PropertyType == typeof(DateTime))
                {
                    if (Convert.ToDateTime(pi.GetValue(t, null)).Year < 2000)
                        res.Add(pi.Name, null);
                    else
                        //格式化微秒 防止6.0平台错误，同时7.0时间可为空
                        res.Add(pi.Name, DateTime.Parse(Convert.ToDateTime(pi.GetValue(t, null)).ToString("yyyy-MM-dd HH:mm:ss")));
                }
                else
                    res.Add(pi.Name, pi.GetValue(t, null));
            }

            return res;
        }

        /// <summary>
        /// 触发 SqlWatch 事件
        /// </summary>
        /// <param name="type">类型 SELECT、INSERT、UPDATE、DELETE</param>
        /// <param name="sql">语句</param>
        protected void SqlWatchMethod(string type, string sql)
        {
            if (SqlWatch != null) SqlWatch(type, sql);
        }

        #region SQL访问

        /// <summary>
        /// 执行SQL语句并返回 DataTable
        /// </summary>
        /// <param name="sql">SQL语句</param> 
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public virtual DataTable ExecuteDataTable(string sql, DbParameter[] parameters = null)
        {
            DataTable res = new DataTable();

            using (DbConnection connection = CreateConnection())
            {
                connection.Open();

                DbCommand cmd = this.CreateCommand(connection, sql, parameters);
                adapter.SelectCommand = cmd;
                adapter.Fill(res);
            }

            return res;
        }

        /// <summary>
        /// 执行SQL语句并返回影响行数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="param">参数</param>
        /// <param name="transaction">事物</param>
        /// <param name="commandTimeout">超时时长</param>
        /// <param name="commandType">命令类型</param>
        /// <returns></returns>
        public virtual int Execute(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (DbConnection connection = CreateConnection())
            {
                return connection.Execute(sql, param, transaction, commandTimeout, commandType);
            }
        }

        public virtual T ExecuteScalar<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (DbConnection connection = CreateConnection())
            {
                return connection.ExecuteScalar<T>(sql, param, transaction, commandTimeout, commandType);
            }
        }

        #endregion

        #region ORM访问

        /// <summary>
        /// 根据查询条件获取实体集
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">条件语句</param>
        /// <param name="param">查询参数</param>
        /// <returns></returns>
        public IEnumerable<T> Query<T>(string sql, object param = null) where T : class
        {
            using (DbConnection connection = CreateConnection())
            {
                return connection.Query<T>(sql, param);
            }
        }

        /// <summary>
        /// 根据主键 Id 获取单个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public T Get<T>(string id) where T : class
        {
            return TopEntities<T>(1, sqlBuilder.PrimaryKeyCondition<T>(), new { Dapper_PKey = id }).FirstOrDefault();
        }

        /// <summary>
        /// 根据查询条件获取实体集
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition">条件语句</param>
        /// <param name="param">查询参数</param>
        /// <returns></returns>
        public List<T> Entities<T>(string condition = "", object param = null) where T : class
        {
            string sql = sqlBuilder.Select<T>() + condition;

            if (typeof(T).GetProperty("IsDeleted") != null)
            {
                if (string.IsNullOrEmpty(condition))
                    sql = sql + "where IsDeleted=0";
                else
                    sql = sql.Replace("where", "where IsDeleted=0 and ");
            }

            SqlWatchMethod("SELECT", sql);

            using (DbConnection connection = CreateConnection())
            {
                return connection.Query<T>(sql, param).ToList();
            }
        }

        /// <summary>
        /// 根据查询条件获取指定个数实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="top">指定个数</param>
        /// <param name="condition">条件语句</param>
        /// <param name="param">查询参数</param>
        /// <returns></returns>
        public List<T> TopEntities<T>(int top, string condition = "", object param = null) where T : class
        {
            string sql = sqlBuilder.SelectTop<T>(top, condition);

            if (typeof(T).GetProperty("IsDeleted") != null)
            {
                if (string.IsNullOrEmpty(condition))
                    sql = sql + "where IsDeleted=0";
                else
                    sql = sql.Replace("where", "where IsDeleted=0 and ");
            }

            SqlWatchMethod("SELECT", sql);

            using (DbConnection connection = CreateConnection())
            {
                return connection.Query<T>(sql, param).ToList();
            }
        }

        /// <summary>
        /// 根据查询条件获取单个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition">条件语句</param>
        /// <param name="param">查询参数</param>
        /// <returns></returns>
        public T Entity<T>(string condition = "", object param = null) where T : class
        {
            return TopEntities<T>(1, condition, param).FirstOrDefault();
        }

        /// <summary>
        /// 根据查询条件获取分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageSize">每页条数</param>
        /// <param name="pageIndex">页索引，从零开始</param>
        /// <param name="condition">条件语句</param>
        /// <param name="param">查询参数</param>
        /// <returns></returns>
        public List<T> ExecutePager<T>(int pageSize, int pageIndex, string condition = "", object param = null) where T : class
        {
            string sql = sqlBuilder.SelectPager<T>(condition, pageSize, pageIndex);

            if (typeof(T).GetProperty("IsDeleted") != null)
            {
                if (string.IsNullOrEmpty(condition))
                    sql = sql + "where IsDeleted=0";
                else
                    sql = sql.Replace("where", "where IsDeleted=0 and ");
            }

            SqlWatchMethod("SELECT", sql);

            using (DbConnection connection = CreateConnection())
            {
                return connection.Query<T>(sql, param).ToList();
            }
        }

        /// <summary>
        /// 插入实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">实体</param>
        /// <returns></returns>
        public int Insert<T>(T t) where T : class
        {
            string sql = sqlBuilder.Insert<T>();

            SqlWatchMethod("INSERT", sql);

            using (DbConnection connection = CreateConnection())
            {
                //if (connection is OleDbConnection)
                //    return connection.Execute(sql, CreateDynamicParameters(t));
                //else
                //    return connection.Execute(sql, t);

                return connection.Execute(sql, CreateDynamicParameters(t));
            }
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">实体</param>
        /// <returns></returns>
        public int Update<T>(T t) where T : class
        {
            string sql = sqlBuilder.Update<T>();

            SqlWatchMethod("UPDATE", sql);

            using (DbConnection connection = CreateConnection())
            {
                return connection.Execute(sql, t);
            }
        }

        /// <summary>
        /// 根据主键删除数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">实体</param>
        /// <returns></returns>
        public int Delete<T>(string id) where T : class
        {
            string sql = sqlBuilder.Delete<T>() + sqlBuilder.PrimaryKeyCondition<T>();

            SqlWatchMethod("DELETE", sql);

            using (DbConnection connection = CreateConnection())
            {
                return connection.Execute(sql, new { Dapper_PKey = id });
            }
        }

        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition">查询条件</param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int DeleteBySQL<T>(string condition = "", object param = null) where T : class
        {
            string sql = sqlBuilder.Delete<T>() + condition;

            SqlWatchMethod("DELETE", sql);

            using (DbConnection connection = CreateConnection())
            {
                return connection.Execute(sql, param);
            }
        }

        /// <summary>
        /// 根据查询条件获取数量
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition">查询条件</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public int Count<T>(string condition = "", object param = null) where T : class
        {
            string sql = sqlBuilder.Count<T>() + condition;

            SqlWatchMethod("SELECT", sql);

            using (DbConnection connection = CreateConnection())
            {
                return connection.ExecuteScalar<int>(sql, param);
            }
        }

        #endregion
    }
}
