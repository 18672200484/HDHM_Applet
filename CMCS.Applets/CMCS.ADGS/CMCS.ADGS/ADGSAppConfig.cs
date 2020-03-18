using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using CMCS.ADGS.Core;
using System.Xml;
using System.IO;
using System.Reflection;

namespace CMCS.ADGS
{
    /// <summary>
    /// 程序配置
    /// </summary>
    public class ADGSAppConfig
    {
        public static string ConfigXmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ADGS.AppConfig.xml");

        private static ADGSAppConfig instance;

        public static ADGSAppConfig GetInstance()
        {
            if (instance == null) instance = new ADGSAppConfig();

            return instance;
        }

        private ADGSAppConfig()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(ConfigXmlPath);

            this.AppIdentifier = xdoc.SelectSingleNode("root/AppIdentifier").InnerText;
            this.SelfConnStr = xdoc.SelectSingleNode("root/SelfConnStr").InnerText;
            this.GrabInterval = Convert.ToInt32(xdoc.SelectSingleNode("root/GrabInterval").InnerText);
            this.OracleKeywords = xdoc.SelectSingleNode("root/OracleKeywords").InnerText;
            this.Startup = (xdoc.SelectSingleNode("root/Startup").InnerText.ToLower() == "true");

            foreach (XmlNode xNode in xdoc.SelectNodes("/root/Instruments/*"))
            {
                if (xNode.Name == "ByoGraber")
                {
                    ByoGraber byoGraber = new ByoGraber();

                    foreach (XmlNode xnParam in xNode.SelectNodes("Param"))
                    {
                        byoGraber.Parameters.Add(xnParam.Attributes["Key"].Value, xnParam.Attributes["Value"].Value);
                    }

                    this.AssayGrabers.Add(byoGraber);
                }
                else if (xNode.Name == "CustomGraber")
                {
                    // 提取类
                    string gaberType = xNode.SelectSingleNode("Param[@Key='GaberType']").Attributes["Value"].Value;

                    AssayGraber customGraber = (AssayGraber)Assembly.GetExecutingAssembly().CreateInstance(gaberType, false, BindingFlags.Default, null, null, null, null);
                    if (customGraber == null) continue;

                    foreach (XmlNode xnParam in xNode.SelectNodes("Param"))
                    {
                        customGraber.Parameters.Add(xnParam.Attributes["Key"].Value, xnParam.Attributes["Value"].Value);
                    }

                    this.AssayGrabers.Add(customGraber);
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

        private string selfConnStr;
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

        private List<AssayGraber> assayGrabers = new List<AssayGraber>();
        /// <summary>
        /// 需要提取数据的化验设备
        /// </summary>
        public List<AssayGraber> AssayGrabers
        {
            get { return assayGrabers; }
            set { assayGrabers = value; }
        }
    }
}
