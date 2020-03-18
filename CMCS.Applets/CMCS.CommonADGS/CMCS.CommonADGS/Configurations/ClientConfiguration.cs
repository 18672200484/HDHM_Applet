using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using CMCS.Common.Utilities;
using CMCS.CommonADGS.Core;
using System.Data;

namespace CMCS.CommonADGS.Configurations
{
    /// <summary>
    /// 客户端配置类（JSON）
    /// </summary>
    public class ClientConfiguration
    {
        /**
         * 相对于App.config配置，此种配置更灵活方便，推荐使用此种方式。
         * 
         * 此种配置方式有以下特点：
         * 1、配置文件不存在时可自动生成配置文件
         * 2、对于新增的配置无须人为修改配置文件
         * 3、支持相对复杂的配置，不仅限于键值对
         * 4、支持在程序中对配置进行增删改操作
         * **/

        private static Object locker = new Object();
        private static ClientConfiguration instance;

        /// <summary>
        /// 配置文件地址
        /// </summary>
        private static string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ADGS.AppConfig.json");

        public static ClientConfiguration Instance
        {
            get
            {
                if (ClientConfiguration.instance == null)
                {
                    lock (locker)
                    {
                        if (ClientConfiguration.instance == null)
                        {
                            if (File.Exists(FilePath))
                            {
                                // 配置文件存在
                                ClientConfiguration.instance = Newtonsoft.Json.JsonConvert.DeserializeObject<ClientConfiguration>(File.ReadAllText(FilePath, Encoding.UTF8));
                            }
                            else
                            {
                                // 生成默认配置并生成配置文件存储到磁盘
                                ClientConfiguration.instance = new ClientConfiguration();
                                ClientConfiguration.instance.Save();
                            }
                        }
                    }
                }

                return ClientConfiguration.instance;
            }
        }

        /// <summary>
        /// 重置
        /// </summary>
        public void Reset()
        {
            ClientConfiguration.instance = null;
            var configuration = ClientConfiguration.Instance;
        }

        /// <summary>
        /// 存储
        /// </summary>
        public void Save()
        {
            try
            {
                File.WriteAllText(FilePath, Newtonsoft.Json.JsonConvert.SerializeObject(this), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Log4Neter.Error("存储配置", ex);
            }
        }

        public ClientConfiguration()
        {

        }

        //*********************************************以下编写配置项*********************************************//

        private string appIdentifier = "Defualt";
        /// <summary>
        /// 程序唯一标识
        /// </summary>
        public string AppIdentifier
        {
            get { return appIdentifier; }
            set { appIdentifier = value; }
        }

        private string dataExtractType;
        /// <summary>
        /// 数据提取类型
        /// </summary>
        public string DataExtractType
        {
            get { return dataExtractType; }
            set { dataExtractType = value; }
        }

        private string selfConnStr = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=10.36.0.109)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL)));User Id=bieos_nxdb;Password=1234;";
        /// <summary>
        /// Oracle数据库连接字符串
        /// </summary>
        public string SelfConnStr
        {
            get { return selfConnStr; }
            set { selfConnStr = value; }
        }

        private double grabInterval;
        /// <summary>
        /// 取数间隔 单位：分钟
        /// </summary>
        public double GrabInterval
        {
            get { return grabInterval; }
            set { grabInterval = value; }
        }

        private string oracleKeywords;
        /// <summary>
        /// Oracle关键字,多个使用“|”分割
        /// </summary>
        public string OracleKeywords
        {
            get { return oracleKeywords; }
            set { oracleKeywords = value; }
        }

        private bool startup;
        /// <summary>
        /// 开机启动
        /// </summary>
        public bool Startup
        {
            get { return startup; }
            set { startup = value; }
        }

        private bool isSecretRunning;
        /// <summary>
        /// 是否最小化运行
        /// </summary>
        public bool IsSecretRunning
        {
            get { return isSecretRunning; }
            set { isSecretRunning = value; }
        }

        private bool verifyBeforeClose;
        /// <summary>
        /// 是否关闭验证
        /// </summary>
        public bool VerifyBeforeClose
        {
            get { return verifyBeforeClose; }
            set { verifyBeforeClose = value; }
        }

        private string serverIp;
        /// <summary>
        /// 服务器IP
        /// </summary>
        public string ServerIp
        {
            get { return serverIp; }
            set { serverIp = value; }
        }

        private List<AssayGraber> assayGrabers = new List<AssayGraber>();
        /// <summary>
        /// 需要提取数据的化验设备
        /// </summary>
        public List<AssayGraber> AssayGrabers
        {
            get { return assayGrabers; }
            set { assayGrabers = value; }
        }

        private List<ByoGraber> byoGrabers = new List<ByoGraber>();
        /// <summary>
        /// 需要提取数据的化验设备
        /// </summary>
        public List<ByoGraber> ByoGrabers
        {
            get { return byoGrabers; }
            set { byoGrabers = value; }
        }
    }

    public abstract class AssayGrabers
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string MachineCode { get; set; }

        /// <summary>
        /// 主键名
        /// </summary>
        public string PrimaryKeys { get; set; }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnStr { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 数据文件路径
        /// </summary>
        public string DataPath { get; set; }

        /// <summary>
        /// 进程名称
        /// </summary>
        public string ProcessName { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 自定义类
        /// </summary>
        public string GaberType { get; set; }

        /// <summary>
        /// 提取数据天数
        /// </summary>
        public double DayRange { get; set; }

        public abstract System.Data.DataTable ExecuteGrab();
    }

    public class ByoGrabers : AssayGraber
    {
        /// <summary>
        /// 数据查询语句
        /// </summary>
        public string SQL { get; set; }

        /// <summary>
        /// 数据库类型：Access SqlServer SQLite
        /// </summary>
        public string DbType { get; set; }

        public override System.Data.DataTable ExecuteGrab()
        {
            DataTable dtl = new DataTable();

            switch (DbType.ToLower())
            {
                case "access":
                    dtl = new CMCS.DapperDber.Dbs.AccessDb.AccessDapperDber(ConnStr).ExecuteDataTable(SQL);
                    break;
                case "sqlserver":
                    dtl = new CMCS.DapperDber.Dbs.SqlServerDb.SqlServerDapperDber(ConnStr).ExecuteDataTable(SQL);
                    break;
                case "sqlite":
                    dtl = new CMCS.DapperDber.Dbs.SQLiteDb.SQLiteDapperDber(ConnStr).ExecuteDataTable(SQL);
                    break;
            }

            return dtl;
        }
    }
}
