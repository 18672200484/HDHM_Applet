using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using System.Data.Common;

namespace CMCS.ADGS.Core
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
        ///  生成 CREATE TABLE 语句
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="dtl"></param>
        /// <returns></returns>
        public static string BuildTableSQL(string tableName, DataTable dtl)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("CREATE TABLE {0} (", tableName);

            // 默认字段 主键
            sql.Append("PKID NVARCHAR2(64) PRIMARY KEY NOT NULL,");
            sql.Append("MACHINECODE NVARCHAR2(64),");

            foreach (DataColumn column in dtl.Columns)
            {
                switch (column.DataType.ToString())
                {
                    case "System.String":
                        sql.AppendFormat("{0} NVARCHAR2({1}),", RelieveOracleKeywords(column.ColumnName), column.MaxLength > 0 ? column.MaxLength : 1024);
                        break;
                    case "System.DateTime":
                        sql.AppendFormat("{0} TIMESTAMP(4),", RelieveOracleKeywords(column.ColumnName));
                        break;
                    case "System.Int16":
                    case "System.Int32":
                    case "System.Int64":
                    case "System.Single":
                    case "System.Double":
                    case "System.Decimal":
                        sql.AppendFormat("{0} NUMBER,", RelieveOracleKeywords(column.ColumnName));
                        break;
                }
            }

            sql = sql.Remove(sql.Length - 1, 1);

            sql.Append(")");

            return sql.ToString().ToUpper();
        }

        /// <summary>
        /// 生成 INSERT 语句
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="primaryKeyValue"></param>
        /// <param name="uniqueKey"></param>
        /// <param name="machineCode"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static string BuildInsertSQL(string tableName, string primaryKeyValue, string machineCode, DataRow dr)
        {
            StringBuilder strbColumn = new StringBuilder();
            StringBuilder strbValue = new StringBuilder();

            foreach (DataColumn column in dr.Table.Columns)
            {
                switch (column.DataType.ToString())
                {
                    case "System.String":
                        strbColumn.AppendFormat("{0},", RelieveOracleKeywords(column.ColumnName.ToUpper()));
                        strbValue.AppendFormat("'{0}',", ToDbValue(dr[column.ColumnName].ToString(), column.DataType));
                        break;
                    case "System.DateTime":
                        strbColumn.AppendFormat("{0},", RelieveOracleKeywords(column.ColumnName.ToUpper()));
                        strbValue.AppendFormat("to_date('{0}','yyyy/mm/dd HH24:MI:SS'),", ToDbValue(dr[column.ColumnName].ToString(), column.DataType));
                        break;
                    case "System.Int16":
                    case "System.Int32":
                    case "System.Int64":
                    case "System.Single":
                    case "System.Double":
                    case "System.Decimal":
                        strbColumn.AppendFormat("{0},", RelieveOracleKeywords(column.ColumnName.ToUpper()));
                        strbValue.AppendFormat("{0},", ToDbValue(dr[column.ColumnName].ToString(), column.DataType));
                        break;
                }
            }

            return string.Format("INSERT INTO {0}(PKID,MACHINECODE,{1}) values ('{2}','{3}',{4})", tableName.ToUpper(), strbColumn.ToString().TrimEnd(','), primaryKeyValue, machineCode, strbValue.ToString().TrimEnd(','));
        }

        /// <summary>
        /// 生成 UPDATE 语句
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="primaryKeyValue"></param>
        /// <param name="uniqueKey"></param>
        /// <param name="facilityNumber"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static string BuildUpdateSQL(string tableName, string primaryKeyValue, string facilityNumber, DataRow dr)
        {
            StringBuilder strbUpdate = new StringBuilder();

            foreach (DataColumn column in dr.Table.Columns)
            {
                switch (column.DataType.ToString())
                {
                    case "System.String":
                        strbUpdate.AppendFormat("{0}='{1}',", RelieveOracleKeywords(column.ColumnName.ToUpper()), ToDbValue(dr[column.ColumnName].ToString(), column.DataType));
                        break;
                    case "System.DateTime":
                        strbUpdate.AppendFormat("{0}=to_date('{1}','yyyy/mm/dd HH24:MI:SS'),", RelieveOracleKeywords(column.ColumnName.ToUpper()), ToDbValue(dr[column.ColumnName].ToString(), column.DataType));
                        break;
                    case "System.Int16":
                    case "System.Int32":
                    case "System.Int64":
                    case "System.Single":
                    case "System.Double":
                    case "System.Decimal":
                        strbUpdate.AppendFormat("{0}={1},", RelieveOracleKeywords(column.ColumnName.ToUpper()), ToDbValue(dr[column.ColumnName].ToString(), column.DataType));
                        break;
                }
            }

            return string.Format("UPDATE {0} SET {1} WHERE PKID='{2}'", tableName.ToUpper(), strbUpdate.ToString().TrimEnd(','), primaryKeyValue, facilityNumber, strbUpdate.ToString().TrimEnd(','));
        }

        /// <summary>
        /// 生成判断数据是否存在的 SELECT 语句
        /// </summary>
        /// <param name="tableName"></param> 
        /// <param name="value"></param>
        /// <returns></returns>
        public static string BuildHasRecordSQL(string tableName, string value)
        {
            return string.Format("select count(PKID) from {0} where PKID='{1}'", tableName, value);
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

        /// <summary>
        /// 生成唯一主键值
        /// </summary>
        /// <param name="primaryKeys"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static string BuildPrimaryKeyValue(string primaryKeys, DataRow dr)
        {
            string res = string.Empty;

            if (string.IsNullOrEmpty(primaryKeys)) throw new ArgumentException(primaryKeys);

            string[] keys = primaryKeys.Trim().Trim('|').Split('|');
            if (keys.Length == 0) throw new ArgumentException(primaryKeys);

            foreach (string item in keys)
            {
                res += dr[item].ToString() + "-";
            }

            return res.TrimEnd('-');
        }

        /// <summary>
        /// 将Oracle字段关键字转成的可行值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static string RelieveOracleKeywords(string value)
        {
            if (OracleKeywords.Any(a=>a.ToUpper()==value.ToUpper()))
                return value + "_EX";

            return value;
        }
    }
}
