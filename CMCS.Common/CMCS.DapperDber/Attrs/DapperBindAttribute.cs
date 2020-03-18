using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCS.DapperDber.Attrs
{
    /// <summary>
    /// 数据表关联特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class DapperBindAttribute : Attribute
    {
        /// <summary>
        /// DapperBindAttribute
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="bindType"></param>
        public DapperBindAttribute(string tableName)
        {
            this.tableName = tableName;
        }

        private string tableName;

        /// <summary>
        /// 数据表名
        /// </summary>
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }
    }
}