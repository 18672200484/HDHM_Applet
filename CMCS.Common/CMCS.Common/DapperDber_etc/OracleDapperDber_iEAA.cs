using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys;
using CMCS.DapperDber.Dbs.OracleDb;
using System.ComponentModel;
using CMCS.Common.DAO;

namespace CMCS.Common.DapperDber_etc
{
    /// <summary>
    /// 针对iEAA平台的DapperDber，
    /// 在修改实体时，判断数据锁并且更新LastModificAtionTime 
    /// </summary>
    public class OracleDapperDber_iEAA : OracleDapperDber
    {
        /// <summary>
        /// OracleDapperDber_iEAA
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        public OracleDapperDber_iEAA(string connectionString)
            : base(connectionString)
        {

        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">实体</param>
        /// <returns></returns>
        public new int Update<T>(T t) where T : EntityBase
        {
            DateTime dtOperDate = this.CreateConnection().ExecuteScalar<DateTime>(string.Format("select LastModificAtionTime from {0} where Id=:Id", DapperDber.Util.EntityReflectionUtil.GetTableName<T>()), new { Id = t.Id });
            if (dtOperDate > t.LastModificAtionTime) throw new Exception("数据已更新，Id=" + t.Id + "，LastModificAtionTime=" + t.LastModificAtionTime.ToString("yyyy-MM-dd HH:mm:ss"));

            // 更新
            t.LastModificAtionTime = DateTime.Now;

            return base.Update<T>(t);
        }

        /// <summary>
        /// 修改实体(带修改日志)
        /// (注意：将需要记录日志的实体添加说明特性，用于定位模块名称)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">实体</param>
        /// <param name="modifyUser">修改人</param>
        /// <param name="modifyCause">修改原因</param>
        /// <returns></returns>
        public new int Update<T>(T t, string modifyUser, string modifyCause = "", string remark = "") where T : EntityBase
        {
            DateTime dtOperDate = this.CreateConnection().ExecuteScalar<DateTime>(string.Format("select LastModificAtionTime from {0} where Id=:Id", DapperDber.Util.EntityReflectionUtil.GetTableName<T>()), new { Id = t.Id });
            if (dtOperDate > t.LastModificAtionTime) throw new Exception("数据已更新，Id=" + t.Id + "，LastModificAtionTime=" + t.LastModificAtionTime.ToString("yyyy-MM-dd HH:mm:ss"));

            //记录修改日志
            object[] objs = t.GetType().GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (objs.Length > 0)
            {
                string description = ((DescriptionAttribute)objs[0]).Description;

                CommonDAO.GetInstance().SaveModifyLog<T>(t, description, modifyUser, modifyCause, remark);
            }

            // 更新
            t.LastModificAtionTime = DateTime.Now;

            return base.Update<T>(t);
        }
    }
}
