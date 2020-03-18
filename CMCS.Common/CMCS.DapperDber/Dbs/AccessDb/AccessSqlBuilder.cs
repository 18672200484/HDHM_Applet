using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using CMCS.DapperDber.Util;

namespace CMCS.DapperDber.Dbs.AccessDb
{
    /// <summary>
    /// Access 语句生成
    /// </summary>
    public class AccessSqlBuilder : SqlBuilder
    {
        /// <summary>
        /// AccessSqlBuilder
        /// </summary>
        public AccessSqlBuilder()
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
            return string.Format("{0} {1}", base.Select<T>().Insert(6, " TOP " + top.ToString()), condition, top);
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
            if (pageIndex <= 0)
                return SelectTop<T>(pageSize, condition);
            else
                return string.Format("select top {0} pg.* from {1} pg where pg.{2} not in (select top {3} t.{2} from {1} t {4}) {5}", pageSize, EntityReflectionUtil.GetTableName<T>(), EntityReflectionUtil.GetPrimaryKey<T>(), pageSize * pageIndex, condition, condition.ToUpper().Replace("WHERE", "AND"));
        }
    }
}
