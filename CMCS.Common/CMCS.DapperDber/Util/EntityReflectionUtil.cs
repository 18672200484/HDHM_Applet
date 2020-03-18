using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using CMCS.DapperDber.Attrs;
using System.Reflection;

namespace CMCS.DapperDber.Util
{
    /// <summary>
    /// EntityReflectionUtil
    /// </summary>
    public static class EntityReflectionUtil
    {
        /// <summary>
        /// 根据特性获取实体属性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="attrType">特性类型</param>
        /// <returns></returns>
        public static PropertyInfo GetPropertyInfoByAttribute<T>(Type attrType)
        {
            PropertyInfo p = typeof(T).GetProperties().Where(a => a.GetCustomAttributes(attrType, true).Length > 0).FirstOrDefault();
            if (p == null) throw new Exception(string.Format("在类型{0}中未找到特性{1}", typeof(T).FullName, attrType.FullName));

            return p;
        }

        /// <summary>
        /// 判断属性是否包含某个特性
        /// </summary>
        /// <param name="pi">属性</param>
        /// <param name="attrType">特性类型</param>
        /// <returns></returns>
        public static bool HasPropertyInfoAttribute(PropertyInfo pi, Type attrType)
        {
            return pi.GetCustomAttributes(attrType, true).Length > 0;
        }

        /// <summary>
        /// 获取实体对应的数据表名
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string GetTableName<T>()
        {
            DapperBindAttribute attr = DapperAttributeUtil.GetAttribute<T>(typeof(DapperBindAttribute)) as DapperBindAttribute;
            return attr != null ? attr.TableName : "";
        }

        /// <summary>
        /// 获取实体对应的数据表主键字段名
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string GetPrimaryKey<T>()
        {
            return GetPropertyInfoByAttribute<T>(typeof(DapperPrimaryKeyAttribute)).Name;
        }
    }
}
