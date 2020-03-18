using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys;
using CMCS.DapperDber.Dbs.MySqlDb;

namespace CMCS.Common.DapperDber_etc
{
    /// <summary>
    /// 针对iEAA平台的DapperDber，
    /// 在修改实体时，判断数据锁并且更新LastModificAtionTime 
    /// </summary>
    public class MySqlDapperDber_iEAA : MySqlDapperDber
    {
        /// <summary>
        /// MySqlDapperDber_iEAA
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        public MySqlDapperDber_iEAA(string connectionString)
            : base(connectionString)
        {

        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">实体</param>
        /// <returns></returns>
        public new int Update<T>(T t) where T : EntityBase1
        {
            DateTime dtOperDate = this.CreateConnection().ExecuteScalar<DateTime>(string.Format("select LastModificAtionTime from {0} where Id=:Id", DapperDber.Util.EntityReflectionUtil.GetTableName<T>()), new { Id = t.Id });
            if (dtOperDate > t.LastModificAtionTime) throw new Exception("数据已更新，Id=" + t.Id + "，LastModificAtionTime=" + t.LastModificAtionTime.ToString("yyyy-MM-dd HH:mm:ss"));

            // 更新
            t.LastModificAtionTime = DateTime.Now;

            return base.Update<T>(t);
        }
    }
}
