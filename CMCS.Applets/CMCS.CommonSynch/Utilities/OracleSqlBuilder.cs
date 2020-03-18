using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using System.Data.Common;

namespace CMCS.CommonSynch.Utilities
{
    /// <summary>
    /// SQL语句构建
    /// </summary>
    public class OracleSqlBuilder
    {
        /// <summary>
        /// Oracle数据库关键字
        /// </summary>
        public static string[] OracleKeywords;

        /// <summary>
        ///  生成判断表是否存在的 SELECT 语句
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static string BuildHasTableSQL(string tableName)
        {
            return "select count(TABLE_NAME) from USER_TABLES where TABLE_NAME='" + tableName.ToUpper() + "'";
        }

        /// <summary>
        /// 比较两个表字段是否一样
        /// </summary>
        /// <param name="tb1"></param>
        /// <param name="tb2"></param>
        /// <returns></returns>
        public static bool CompareTableField(DataTable tb1, DataTable tb2)
        {
            if (tb1.Columns.Count != tb2.Columns.Count) return false;

            foreach (DataColumn item in tb1.Columns)
            {
                if (!tb2.Columns.Contains(item.ColumnName.ToUpper())) return false;
            }
            return true;
        }

        /// <summary>
        /// 生成空表的查询SQL
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static string BuildGetNullTableSQL(string tableName)
        {
            return string.Format("select * from {0} where 1<>1", tableName);
        }

        /// <summary>
        /// 生成需要同步数据的查询SQL
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="synchField"></param>
        /// <returns></returns>
        public static string BuildGetNeedSynchTableSQL(string tableName, string synchField)
        {
            return string.Format("select * from {0} where {1}='0' or {1} is null", tableName, synchField);
        }

        /// <summary>
        /// 生成 INSERT SQL语句
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="synchField"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static string BuildInsertSQL(string tableName, string synchField, DataRow dr)
        {
            StringBuilder strbColumn = new StringBuilder();
            StringBuilder strbValue = new StringBuilder();

            foreach (DataColumn column in dr.Table.Columns)
            {
                //新增时同步标识默认为已同步
                if (column.ColumnName == synchField.ToUpper())
                {
                    strbColumn.AppendFormat("{0},", column.ColumnName.ToUpper());
                    strbValue.AppendFormat("'{0}',", ToDbValue("1", column.DataType));
                    continue;
                }
                switch (column.DataType.ToString())
                {
                    case "System.String":
                        strbColumn.AppendFormat("{0},", column.ColumnName.ToUpper());
                        strbValue.AppendFormat("'{0}',", ToDbValue(dr[column.ColumnName].ToString(), column.DataType));
                        break;
                    case "System.DateTime":
                        strbColumn.AppendFormat("{0},", column.ColumnName.ToUpper());
                        strbValue.AppendFormat("to_date('{0}','yyyy/mm/dd HH24:MI:SS'),", ToDbValue(dr[column.ColumnName].ToString(), column.DataType));
                        break;
                    case "System.Int16":
                    case "System.Int32":
                    case "System.Int64":
                    case "System.Single":
                    case "System.Double":
                    case "System.Decimal":
                        strbColumn.AppendFormat("{0},", column.ColumnName.ToUpper());
                        strbValue.AppendFormat("{0},", ToDbValue(dr[column.ColumnName].ToString(), column.DataType));
                        break;
                }
            }

            return string.Format("INSERT INTO {0}({1}) values ({2})", tableName.ToUpper(), strbColumn.ToString().TrimEnd(','), strbValue.ToString().TrimEnd(','));
        }

        /// <summary>
        /// 生成 UPDATE SQL语句
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="synchField"></param>
        /// <param name="primaryKey"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static string BuildUpdateSQL(string tableName, string synchField, string primaryKey, DataRow dr)
        {
            StringBuilder strbUpdate = new StringBuilder();

            foreach (DataColumn column in dr.Table.Columns)
            {
                //修改时同步标识默认为已同步
                if (column.ColumnName == synchField.ToUpper())
                {
                    strbUpdate.AppendFormat("{0}='{1}',", column.ColumnName.ToUpper(), ToDbValue("1", column.DataType));
                    continue;
                }
                switch (column.DataType.ToString())
                {
                    case "System.String":
                        strbUpdate.AppendFormat("{0}='{1}',", column.ColumnName.ToUpper(), ToDbValue(dr[column.ColumnName].ToString(), column.DataType));
                        break;
                    case "System.DateTime":
                        strbUpdate.AppendFormat("{0}=to_date('{1}','yyyy/mm/dd HH24:MI:SS'),", column.ColumnName.ToUpper(), ToDbValue(dr[column.ColumnName].ToString(), column.DataType));
                        break;
                    case "System.Int16":
                    case "System.Int32":
                    case "System.Int64":
                    case "System.Single":
                    case "System.Double":
                    case "System.Decimal":
                        strbUpdate.AppendFormat("{0}={1},", column.ColumnName.ToUpper(), ToDbValue(dr[column.ColumnName].ToString(), column.DataType));
                        break;
                }
            }

            return string.Format("UPDATE {0} SET {1} WHERE {2}='{3}'", tableName.ToUpper(), strbUpdate.ToString().TrimEnd(','), primaryKey, dr[primaryKey].ToString());
        }

        /// <summary>
        /// 生成更新同步标识的SQL语句
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="primaryKey"></param>
        /// <param name="primaryKeyValue"></param>
        /// <param name="synchField"></param>
        /// <returns></returns>
        public static string BuildUpdateSynchFieldSQL(string tableName, string primaryKey, string primaryKeyValue, string synchField)
        {
            return string.Format("UPDATE {0} SET {1}='1' WHERE {2}='{3}'", tableName.ToUpper(), synchField, primaryKey, primaryKeyValue);
        }

        /// <summary>
        /// 生成判断数据是否存在的 SELECT 语句
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="primaryKey"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string BuildHasRecordSQL(string tableName, string primaryKey, string value)
        {
            return string.Format("select count(1) from {0} where {1}='{2}'", tableName, primaryKey, value);
        }

        /// <summary>
        /// 转化为指定 INSERT 插入语句的字段值
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string ToDbValue(string value, Type type)
        {
            switch (type.FullName)
            {
                case "System.String":
                    return value != null ? value : string.Empty;
                case "System.DateTime":
                    DateTime resDt;
                    if (!DateTime.TryParse(value, out resDt))
                        resDt = DateTime.MinValue;
                    return resDt.ToString("yyyy-MM-dd HH:mm:ss");
                case "System.Int16":
                case "System.Int32":
                case "System.Int64":
                case "System.Single":
                case "System.Double":
                case "System.Decimal":
                    decimal resDec;
                    if (!Decimal.TryParse(value, out resDec))
                        resDec = 0;
                    return resDec.ToString();
                default:
                    return value;
            }
        }
    }
}
