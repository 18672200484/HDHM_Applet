using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using CMCS.DapperDber.Util; 

namespace CMCS.DapperDber.Dbs.SQLiteDb
{
    /// <summary>
    /// SQLite 语句生成
    /// </summary>
    public class SQLiteSqlBuilder : SqlBuilder
    {
        /// <summary>
        /// SQLiteSqlBuilder
        /// </summary>
        public SQLiteSqlBuilder()
            : base(":")
        {

        }

        /// <summary>
        /// 生成 TOP 查询的 SELECT 语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="top">条数</param>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public override string SelectTop<T>(int top, string condition)
        {
            return string.Format("{0} {1} LIMIT {2}", base.Select<T>(), condition, top);
        }

        /// <summary>
        /// 生成分页查询的 SELECT 语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition">条件语句</param>
        /// <param name="pageSize">每页个数</param>
        /// <param name="pageIndex">页索引</param>
        /// <returns></returns>
        public override string SelectPager<T>(string condition, int pageSize, int pageIndex)
        {
            return string.Format("{0} {1} LIMIT {2} OFFSET {3}", Select<T>(), condition, pageSize, pageSize * pageIndex);
        }
    }
}
