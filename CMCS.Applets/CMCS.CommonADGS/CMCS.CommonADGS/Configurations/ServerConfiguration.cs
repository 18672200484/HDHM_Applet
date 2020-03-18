using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CMCS.CommonADGS.Core;
using CMCS.Common.Utilities;

namespace CMCS.CommonADGS.Configurations
{
    /// <summary>
    /// 客户端配置类（JSON）
    /// </summary>
    public class ServerConfiguration
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
        private static ServerConfiguration instance;

        /// <summary>
        /// 配置文件地址
        /// </summary>
        private static string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ADGS.ServerConfig.json");

        public static ServerConfiguration Instance
        {
            get
            {
                if (ServerConfiguration.instance == null)
                {
                    lock (locker)
                    {
                        if (ServerConfiguration.instance == null)
                        {
                            if (File.Exists(FilePath))
                            {
                                // 配置文件存在
                                ServerConfiguration.instance = Newtonsoft.Json.JsonConvert.DeserializeObject<ServerConfiguration>(File.ReadAllText(FilePath, Encoding.UTF8));
                            }
                            else
                            {
                                // 生成默认配置并生成配置文件存储到磁盘
                                ServerConfiguration.instance = new ServerConfiguration();
                                ServerConfiguration.instance.Save();
                            }
                        }
                    }
                }

                return ServerConfiguration.instance;
            }
        }

        /// <summary>
        /// 重置
        /// </summary>
        public void Reset()
        {
            ServerConfiguration.instance = null;
            var configuration = ServerConfiguration.Instance;
        }

        /// <summary>
        /// 存储
        /// </summary>
        public void Save()
        {
            try
            {
                if (this.ServerPortSets.Select(a => a.MachineCode).Contains("→点击新增配置←"))
                    this.ServerPortSets.RemoveAt(this.ServerPortSets.Select(a => a.MachineCode).ToList().IndexOf("→点击新增配置←"));
                File.WriteAllText(FilePath, Newtonsoft.Json.JsonConvert.SerializeObject(this), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Log4Neter.Error("存储配置", ex);
            }
        }

        public ServerConfiguration()
        {

        }

        //*********************************************以下编写配置项*********************************************//

        private string appIdentifier = "Default";
        /// <summary>
        /// 程序唯一标识
        /// </summary>
        public string AppIdentifier
        {
            get { return appIdentifier; }
            set { appIdentifier = value; }
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

        private List<ServerConfigurationDetail> serverPortSets = new List<ServerConfigurationDetail>();
        /// <summary>
        /// 需要配置的服务接收端
        /// </summary>
        public List<ServerConfigurationDetail> ServerPortSets
        {
            get { return serverPortSets; }
            set { serverPortSets = value; }
        }
    }
    public class ServerConfigurationDetail
    {

        /// <summary>
        /// 设备编号
        /// </summary>
        public string MachineCode { get; set; }

        /// <summary>
        /// 端口号
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 数据存储路径
        /// </summary>
        public string SavePath { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled { get; set; }

    }
}
