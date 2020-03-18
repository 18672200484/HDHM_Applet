using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using CMCS.DapperDber.Util;
using System.Reflection;
using CMCS.DapperDber.Attrs;

namespace CMCS.DapperDber.Dbs
{
    /// <summary>
    /// SqlBuilder
    /// </summary>
    public class SqlBuilder : ISqlBuilder
    {
        private string paramPrefix;

        /// <summary>
        /// 参数前缀
        /// </summary>
        public string ParamPrefix
        {
            get { return paramPrefix; }
        }

        /// <summary>
        /// SqlBuilder
        /// </summary>
        /// <param name="paramPrefix">参数前缀</param>
        public SqlBuilder(string paramPrefix)
        {
            this.paramPrefix = paramPrefix;
        }

        /// <summary>
        /// 生成不带条件的 SELECT 语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual string Select<T>()
        {
            return string.Format("SELECT * FROM {0} ", EntityReflectionUtil.GetTableName<T>());
        }

        /// <summary>
        /// 生成查询数量的 SELECT 语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual string Count<T>()
        {
            return string.Format("SELECT COUNT({1}) FROM {0} ", EntityReflectionUtil.GetTableName<T>(), EntityReflectionUtil.GetPrimaryKey<T>());
        }

        /// <summary>
        /// 生成根据主键查询的 WHERE 语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual string PrimaryKeyCondition<T>()
        {
            return string.Format("WHERE {0}={1}Dapper_PKey ", EntityReflectionUtil.GetPrimaryKey<T>(), this.paramPrefix);
        }

        /// <summary>
        /// 生成 TOP 查询的 SELECT 语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="top">条数</param>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public virtual string SelectTop<T>(int top, string condition)
        {
            return string.Empty;
        }

        /// <summary>
        /// 生成分页查询的 SELECT 语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition">条件语句</param>
        /// <param name="pageSize">每页个数</param>
        /// <param name="pageIndex">页索引</param>
        /// <returns></returns>
        public virtual string SelectPager<T>(string sql, int pageSize, int pageIndex)
        {
            return string.Empty;
        }

        /// <summary>
        /// 生成 INSERT 语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual string Insert<T>() where T : class
        {
            StringBuilder strbRes1 = new StringBuilder("INSERT INTO " + EntityReflectionUtil.GetTableName<T>() + "(");
            StringBuilder strbRes2 = new StringBuilder("VALUES(");

            foreach (PropertyInfo pi in typeof(T).GetProperties())
            {
                if (EntityReflectionUtil.HasPropertyInfoAttribute(pi, typeof(DapperIgnoreAttribute)) || EntityReflectionUtil.HasPropertyInfoAttribute(pi, typeof(DapperAutoPrimaryKeyAttribute)))
                    continue;

                strbRes1.AppendFormat("{0},", pi.Name);
                strbRes2.AppendFormat("{1}{0},", pi.Name, this.paramPrefix);
            }

            return string.Format("{0}) {1})", strbRes1.ToString().TrimEnd(','), strbRes2.ToString().TrimEnd(','));
        }

        /// <summary>
        /// 生成 UPDATE 语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual string Update<T>() where T : class
        {
            StringBuilder strbRes1 = new StringBuilder("UPDATE " + EntityReflectionUtil.GetTableName<T>() + " SET ");

            foreach (PropertyInfo pi in typeof(T).GetProperties())
            {
                if (EntityReflectionUtil.HasPropertyInfoAttribute(pi, typeof(DapperPrimaryKeyAttribute)) || EntityReflectionUtil.HasPropertyInfoAttribute(pi, typeof(DapperIgnoreAttribute)) || EntityReflectionUtil.HasPropertyInfoAttribute(pi, typeof(DapperAutoPrimaryKeyAttribute)))
                    continue;

                strbRes1.AppendFormat("{0}={1}{0},", pi.Name, this.paramPrefix);
            }

            return string.Format("{0} WHERE {1}={2}{1} ", strbRes1.ToString().TrimEnd(','), EntityReflectionUtil.GetPrimaryKey<T>(), this.paramPrefix);
        }

        /// <summary>
        /// 生成 DELETE 语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual string Delete<T>() where T : class
        {
            return string.Format("DELETE FROM {0} ", EntityReflectionUtil.GetTableName<T>());
        }
    }
}
