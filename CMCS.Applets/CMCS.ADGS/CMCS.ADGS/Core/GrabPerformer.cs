using System;
using System.Collections.Generic;
// 
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using CMCS.DapperDber.Dbs.OracleDb;
using Oracle.ManagedDataAccess.Client;

namespace CMCS.ADGS.Core
{
    /// <summary>
    /// 执行数据提取对象
    /// </summary>
    public class GrabPerformer
    {
        public GrabPerformer()
        {
            InitPerformer();
        }

        System.Timers.Timer timer1 = new System.Timers.Timer();

        ADGSAppConfig _ADGSAppConfig;

        #region Event

        public delegate void OutputInfoEventHandler(string info);
        public event OutputInfoEventHandler OutputInfo;

        public delegate void OutputErrorEventHandler(string describe, Exception ex);
        public event OutputErrorEventHandler OutputError;

        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        void InitPerformer()
        {
            _ADGSAppConfig = ADGSAppConfig.GetInstance();

            OracleSqlBuilder.OracleKeywords = this._ADGSAppConfig.OracleKeywords.Split('|');

            timer1.Interval = 5000;
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);
        }

        /// <summary>
        /// 输出信息
        /// </summary>
        /// <param name="describe"></param>
        /// <param name="ex"></param>
        void OutputInfoMethod(string describe)
        {
            if (OutputInfo != null) OutputInfo(describe);
        }

        /// <summary>
        /// 输出错误
        /// </summary>
        /// <param name="describe"></param>
        /// <param name="ex"></param>
        void OutputErrorMethod(string describe, Exception ex)
        {
            if (OutputError != null) OutputError(describe, ex);
        }

        void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer1.Interval = this._ADGSAppConfig.GrabInterval * 60 * 1000;

            Grab();
        }

        /// <summary>
        /// 提取数据
        /// </summary>
        private void Grab()
        {
            OracleDapperDber selfDber = new OracleDapperDber(this._ADGSAppConfig.SelfConnStr);
            using (OracleConnection connection = selfDber.CreateConnection() as OracleConnection)
            {
                foreach (AssayGraber assayGraber in this._ADGSAppConfig.AssayGrabers)
                {
                    try
                    {
                        if (!assayGraber.Enabled) continue;
                        // 未设置主键名则跳过
                        if (string.IsNullOrEmpty(assayGraber.PrimaryKeys))
                        {
                            OutputInfoMethod(string.Format("{0} 提取未执行，原因：未设置主键(PrimaryKeys)参数", assayGraber.MachineCode));
                            continue;
                        }

                        DataTable dtlAssay = assayGraber.ExecuteGrab();

                        // 在数据中创建表
                        if (connection.ExecuteScalar<int>(OracleSqlBuilder.BuildHasTableSQL(assayGraber.TableName)) == 0)
                            connection.Execute(OracleSqlBuilder.BuildTableSQL(assayGraber.TableName, dtlAssay));

                        int syncCount = 0;
                        foreach (DataRow drAssay in dtlAssay.Rows)
                        {
                            string execSql = string.Empty;

                            // 生成主键值
                            string primaryKeyValue = assayGraber.MachineCode + "-" + OracleSqlBuilder.BuildPrimaryKeyValue(assayGraber.PrimaryKeys, drAssay);

                            if (connection.ExecuteScalar<int>(OracleSqlBuilder.BuildHasRecordSQL(assayGraber.TableName, primaryKeyValue)) == 0)
                                execSql = OracleSqlBuilder.BuildInsertSQL(assayGraber.TableName, primaryKeyValue, assayGraber.MachineCode, drAssay);
                            else
                                execSql = OracleSqlBuilder.BuildUpdateSQL(assayGraber.TableName, primaryKeyValue, assayGraber.MachineCode, drAssay);

                            syncCount += connection.Execute(execSql);
                        }

                        OutputInfoMethod(string.Format("{0} 本次提取 {1} 条", assayGraber.MachineCode, syncCount));
                    }
                    catch (Exception ex)
                    {
                        OutputErrorMethod(string.Format("{0}　提取失败", assayGraber.MachineCode), ex);
                    }
                }
            }
        }

        /// <summary>
        /// 开始提取
        /// </summary>
        public void StartGrab()
        {
            this.timer1.Start();
        }

        /// <summary>
        /// 停止提取
        /// </summary>
        public void StopGrab()
        {
            this.timer1.Stop();
        }
    }
}
