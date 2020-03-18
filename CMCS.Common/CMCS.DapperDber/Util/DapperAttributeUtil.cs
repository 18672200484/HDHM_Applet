using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace CMCS.DapperDber.Util
{
    /// <summary>
    /// DapperAttributeUtil
    /// </summary>
    public static class DapperAttributeUtil
    {
        /// <summary>
        /// 获取 Attribute
        /// </summary>
        /// <param name="attrType"></param>
        /// <returns></returns>
        public static Attribute GetAttribute<T>(Type attrType)
        {
            object[] attrs = typeof(T).GetCustomAttributes(attrType, true);
            if (attrs.Length > 0) return (Attribute)attrs[0];

            throw new Exception(string.Format("在类型{0}中未找到特性{1}", typeof(T).FullName, attrType.FullName));
        } 
    }
}
