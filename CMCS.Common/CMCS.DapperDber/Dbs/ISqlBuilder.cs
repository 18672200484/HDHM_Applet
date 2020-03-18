using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCS.DapperDber.Dbs
{
    /// <summary>
    /// ISqlBuilder
    /// </summary>
    public interface ISqlBuilder
    {
        /// <summary>
        /// 生成不带条件的 SELECT 语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        string Select<T>();

        /// <summary>
        /// 生成查询数量的 SELECT 语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        string Count<T>();

        /// <summary>
        /// 生成根据主键查询的 WHERE 语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        string PrimaryKeyCondition<T>();

        /// <summary>
        /// 生成 TOP 查询的 SELECT 语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="top">条数</param>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        string SelectTop<T>(int top, string condition);

        /// <summary>
        /// 生成分页查询的 SELECT 语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition">条件语句</param>
        /// <param name="pageSize">每页个数</param>
        /// <param name="pageIndex">页索引</param>
        /// <returns></returns>
        string SelectPager<T>(string condition, int pageSize, int pageIndex);

        /// <summary>
        /// 生成 INSERT 语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        string Insert<T>() where T : class;

        /// <summary>
        /// 生成 UPDATE 语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        string Update<T>() where T : class;

        /// <summary>
        /// 生成 DELETE 语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        string Delete<T>() where T : class;
    }
}
