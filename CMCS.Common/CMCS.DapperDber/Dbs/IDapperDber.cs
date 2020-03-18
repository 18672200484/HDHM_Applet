using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data.Common;
using System.Data;

namespace CMCS.DapperDber.Dbs
{
    /// <summary>
    /// IDapperDber
    /// </summary>
    public interface IDapperDber
    { 
        /// <summary>
        /// 根据主键 Id 获取单个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">主键</param>
        /// <returns></returns>
        T Get<T>(string id) where T : class;

        /// <summary>
        /// 根据查询条件获取实体集
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition">条件语句</param>
        /// <param name="param">查询参数</param>
        /// <returns></returns>
        List<T> Entities<T>(string condition = "", object param = null) where T : class;

        /// <summary>
        /// 根据查询条件获取指定个数实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="top">指定个数</param>
        /// <param name="condition">条件语句</param>
        /// <param name="param">查询参数</param>
        /// <returns></returns>
        List<T> TopEntities<T>(int top, string condition = "", object param = null) where T : class;

        /// <summary>
        /// 根据查询条件获取分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageSize">每页条数</param>
        /// <param name="pageIndex">页索引，从零开始</param>
        /// <param name="condition">条件语句</param>
        /// <param name="param">查询参数</param>
        /// <returns></returns>
        List<T> ExecutePager<T>(int pageSize, int pageIndex, string condition = "", object param = null) where T : class;

        /// <summary>
        /// 插入实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">实体</param>
        /// <returns></returns>
        int Insert<T>(T t) where T : class;

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">实体</param>
        /// <returns></returns>
        int Update<T>(T t) where T : class;

        /// <summary>
        /// 根据主键删除数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">实体</param>
        /// <returns></returns>
        int Delete<T>(string id) where T : class;

        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition">查询条件</param>
        /// <param name="param"></param>
        /// <returns></returns>
        int DeleteBySQL<T>(string condition = "", object param = null) where T : class; 

        /// <summary>
        /// 根据查询条件获取数量
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition">查询条件</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        int Count<T>(string condition = "", object param = null) where T : class;
    }
}
