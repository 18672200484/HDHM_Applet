using System;
using System.Collections.Generic;
using System.Data;
//
using Oracle.ManagedDataAccess.Client;


namespace CMCS.EPCEmpower.Utilities
{
    /// <summary>
    /// OracleHelper
    /// </summary>
    public class OracleHelper
    {
        private string ConnStr = string.Empty;

        public bool WriteLog = false;

        public OracleHelper(string _ConnStr)
        {
            ConnStr = _ConnStr;
        }

        public OracleHelper(string _ConnStr, bool _WriteLog)
        {
            ConnStr = _ConnStr;
            WriteLog = _WriteLog;
        }

        public bool ConnectTesting()
        {
            using (OracleConnection conn = new OracleConnection(ConnStr))
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        #region Oracle∑√Œ 

        public DataTable ExecuteDataTable(string sql, OracleParameter[] parems)
        {
            using (OracleConnection conn = new OracleConnection(ConnStr))
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.AddRange(parems);
                OracleDataAdapter sda = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                conn.Close();
                return ds.Tables[0];
            }
        }

        public DataTable ExecuteDataTable(string sql)
        {
            return ExecuteDataTable(sql, new OracleParameter[] { });
        }

        public int ExecuteNonQuery(string sql, OracleParameter[] parems)
        {

            using (OracleConnection conn = new OracleConnection(ConnStr))
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.AddRange(parems);
                int count = cmd.ExecuteNonQuery();
                conn.Close();
                return count;
            }
        }

        public int ExecuteNonQuery(string sql)
        {
            return ExecuteNonQuery(sql, new OracleParameter[] { });
        }

        public string ExecuteScalar(string sql, OracleParameter[] parems)
        {
            using (OracleConnection conn = new OracleConnection(ConnStr))
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.AddRange(parems);
                object result = cmd.ExecuteScalar();
                conn.Close();
                if (result == null)
                    return string.Empty;
                if (result == DBNull.Value)
                    return string.Empty;
                return result.ToString();
            }
        }

        public string ExecuteScalar(string sql)
        {
            return ExecuteScalar(sql, new OracleParameter[] { });
        }

        #endregion
    }
}
