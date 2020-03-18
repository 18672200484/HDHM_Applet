using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml;
using System.IO;
using System.Reflection;

namespace CMCS.EPCEmpower.Core
{
    /// <summary>
    /// 程序配置
    /// </summary>
    public class SelfAppConfig
    {
        public static string ConfigXmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Self.AppConfig.xml");

        private static SelfAppConfig instance;

        public static SelfAppConfig GetInstance()
        {
            if (instance == null) instance = new SelfAppConfig();

            return instance;
        }

        private SelfAppConfig()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(ConfigXmlPath);

            this.AppIdentifier = xdoc.SelectSingleNode("root/AppIdentifier").InnerText;
            this.RwerCom = Convert.ToInt32(xdoc.SelectSingleNode("root/RwerCom").InnerText);
            this.StartNumber = Convert.ToInt32(xdoc.SelectSingleNode("root/StartNumber").InnerText);
            this.AutoIncrease = (xdoc.SelectSingleNode("root/AutoIncrease").InnerText == "1");
            this.EmpowerMode = Convert.ToInt32(xdoc.SelectSingleNode("root/EmpowerMode").InnerText);
            this.PrefixCode = xdoc.SelectSingleNode("root/PrefixCode").InnerText;
            this.SelfConnStr = xdoc.SelectSingleNode("root/SelfConnStr").InnerText;
            this.SelectSQL = xdoc.SelectSingleNode("root/SelectSQL").InnerText;
            this.CheckSQL = xdoc.SelectSingleNode("root/CheckSQL").InnerText;
            this.InsertSQL = xdoc.SelectSingleNode("root/InsertSQL").InnerText;
        }

        public void Save()
        { 
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(ConfigXmlPath);

            xdoc.SelectSingleNode("root/AppIdentifier").InnerText = this.AppIdentifier;
            xdoc.SelectSingleNode("root/RwerCom").InnerText = this.RwerCom.ToString();
            xdoc.SelectSingleNode("root/StartNumber").InnerText = this.StartNumber.ToString();
            xdoc.SelectSingleNode("root/AutoIncrease").InnerText = Convert.ToInt16(this.AutoIncrease).ToString();
            xdoc.SelectSingleNode("root/EmpowerMode").InnerText = this.EmpowerMode.ToString();
            xdoc.SelectSingleNode("root/PrefixCode").InnerText = this.PrefixCode;
            xdoc.SelectSingleNode("root/SelfConnStr").InnerText = this.SelfConnStr;
            xdoc.SelectSingleNode("root/SelectSQL").InnerText = this.SelectSQL;
            xdoc.SelectSingleNode("root/CheckSQL").InnerText = this.CheckSQL;
            xdoc.SelectSingleNode("root/InsertSQL").InnerText = this.InsertSQL;

            xdoc.Save(ConfigXmlPath);
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

        private int rwerCom;
        /// <summary>
        /// 发卡器串口
        /// </summary>
        public int RwerCom
        {
            get { return rwerCom; }
            set { rwerCom = value; }
        }

        private string prefixCode;
        /// <summary>
        /// 授权码 注意：必须四个汉字
        /// </summary>
        public string PrefixCode
        {
            get { return prefixCode; }
            set { prefixCode = value; }
        }

        private int startNumber;
        /// <summary>
        /// 起始编号
        /// </summary>
        public int StartNumber
        {
            get { return startNumber; }
            set { startNumber = value; }
        }

        private bool autoIncrease;
        /// <summary>
        /// 编号递增
        /// </summary>
        public bool AutoIncrease
        {
            get { return autoIncrease; }
            set { autoIncrease = value; }
        }

        private int empowerMode;
        /// <summary>
        /// 授权模式  1=单机模式  2=联网模式
        /// </summary>
        public int EmpowerMode
        {
            get { return empowerMode; }
            set { empowerMode = value; }
        }

        private string selfConnStr;
        /// <summary>
        /// 联网模式需设置，Oracle数据库连接字符串
        /// </summary>
        public string SelfConnStr
        {
            get { return selfConnStr; }
            set { selfConnStr = value; }
        }

        private string selectSQL;
        /// <summary>
        /// 联网模式需设置，查询SQL语句 主键：Id,标签号：TagId，入库时间：InStorageDate
        /// </summary>
        public string SelectSQL
        {
            get { return selectSQL; }
            set { selectSQL = value; }
        }

        private string checkSQL;
        /// <summary>
        /// 联网模式需设置，入库判断SQL语句 标签号：TagId
        /// </summary>
        public string CheckSQL
        {
            get { return checkSQL; }
            set { checkSQL = value; }
        }

        private string insertSQL;
        /// <summary>
        /// 联网模式需设置，入库SQL语句 主键：Id,标签号：TagId，标签编号：CardNumber，入库时间：InStorageDate
        /// </summary>
        public string InsertSQL
        {
            get { return insertSQL; }
            set { insertSQL = value; }
        }
    }
}
