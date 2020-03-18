using System;
using System.Collections.Generic;
// 
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Xml;
using CMCS.CommonADGS.UDPDAO;
using Oracle.ManagedDataAccess.Client;
using CMCS.CommonADGS.Utilities;
using CMCS.Common.Utilities;

namespace CMCS.CommonADGS.Core
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
        TaskSimpleScheduler taskSimpleScheduler = new TaskSimpleScheduler();

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
            timer1.Interval = this._ADGSAppConfig.GrabInterval * 60 * 100000;
            Grab();
        }

        /// <summary>
        /// 提取数据至数据库
        /// </summary>
        private void Grab()
        {
            DapperDber.Dbs.OracleDb.OracleDapperDber selfDber = new DapperDber.Dbs.OracleDb.OracleDapperDber(this._ADGSAppConfig.SelfConnStr);
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
        /// UDP发送
        /// </summary>
        private void UDP()
        {
            foreach (AssayGraber assayGraber in this._ADGSAppConfig.AssayGrabers)
            {
                if (!assayGraber.Enabled) continue;
                if (string.IsNullOrEmpty(assayGraber.DataPath))
                {
                    OutputInfoMethod(string.Format("设备{0},数据库文件路径为空", assayGraber.MachineCode));
                    continue;
                }

                string sendFileFullName = assayGraber.DataPath.Replace("\"", string.Empty);

                if (!File.Exists(sendFileFullName))
                {
                    //File.Create(sendFileFullName);
                    OutputInfoMethod(string.Format("设备{0},文件不存在", assayGraber.MachineCode));
                    continue;
                }
                UDPSendDAO DAO = new UDPSendDAO(assayGraber.MachineCode, this._ADGSAppConfig.ServerIp, int.Parse(assayGraber.Port), assayGraber.DataPath, this._ADGSAppConfig.GrabInterval * 60 * 1000);
                DAO.OutputInfo += new UDPSendDAO.OutputInfoEventHandler(OutputInfoMethod);
                DAO.OutputError += new UDPSendDAO.OutputErrorEventHandler(OutputErrorMethod);
                taskSimpleScheduler.StartNewTask(assayGraber.MachineCode + "发送数据", () =>
                {
                    DAO.StartSend();
                }, 0, OutputErrorMethod);
            }
        }

        /// <summary>
        /// 开始提取
        /// </summary>
        public void StartGrab()
        {
            if (ADGSAppConfig.GetInstance().DataExtractType == "0")
                this.timer1.Start();
            else if (ADGSAppConfig.GetInstance().DataExtractType == "1")
            {
                UDP();
            }
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
