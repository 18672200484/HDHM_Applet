using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using CMCS.CommonADGS.Core;
using System.Xml;
using System.IO;
using System.Reflection;

namespace CMCS.CommonADGS
{
    /// <summary>
    /// 服务端程序配置
    /// </summary>
    public class ADGSServerConfig
    {
        public static string ConfigXmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ADGS.ServerConfig.xml");

        private static ADGSServerConfig instance;

        public static ADGSServerConfig GetInstance()
        {
            if (instance == null) instance = new ADGSServerConfig();

            return instance;
        }

        private ADGSServerConfig()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(ConfigXmlPath);

            this.AppIdentifier = xdoc.SelectSingleNode("root/AppIdentifier").InnerText;
            this.Startup = (xdoc.SelectSingleNode("root/Startup").InnerText.ToLower() == "true");
            this.IsSecretRunning = (xdoc.SelectSingleNode("root/IsSecretRunning").InnerText.ToLower() == "true");
            this.VerifyBeforeClose = (xdoc.SelectSingleNode("root/VerifyBeforeClose").InnerText.ToLower() == "true");

            foreach (XmlNode xNode in xdoc.SelectNodes("/root/ReceiveSettings/*"))
            {
                if (xNode.Name == "PortSetting")
                {
                    ServerPortSet byoGraber = new ServerPortSet();

                    foreach (XmlNode xnParam in xNode.SelectNodes("Param"))
                    {
                        byoGraber.Parameters.Add(xnParam.Attributes["Key"].Value, xnParam.Attributes["Value"].Value);
                    }

                    this.ServerPortSets.Add(byoGraber);
                }
            }
        }

        private string appIdentifier;
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

        private List<ServerPortSet> serverPortSets = new List<ServerPortSet>();
        /// <summary>
        /// 需要配置的服务接收端
        /// </summary>
        public List<ServerPortSet> ServerPortSets
        {
            get { return serverPortSets; }
            set { serverPortSets = value; }
        }
    }
}
