using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml;
using System.IO;
using System.Reflection;

namespace CMCS.CommonSynch.Utilities
{
    /// <summary>
    /// 程序配置
    /// </summary>
    public class CommonAppConfig
    {
        /// <summary>
        /// 支持的转化类型
        /// </summary>
        private static List<Type> SupportType = new List<Type> {
           typeof(System.Int16),
           typeof(System.Int32),
           typeof(System.Int64),
           typeof(System.String),
           typeof(System.Double),
           typeof(System.Decimal),
           typeof(System.Single),
           typeof(System.Boolean)
        };

        public static string ConfigXmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Common.AppConfig.xml");

        private static CommonAppConfig instance;

        public static CommonAppConfig GetInstance()
        {
            instance = new CommonAppConfig();
            return instance;
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        public void Save()
        {
            CommonAppConfig.SaveConfig(instance, ConfigXmlPath);
        }

        private CommonAppConfig()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(ConfigXmlPath);

            this.AppIdentifier = xdoc.SelectSingleNode("CommonAppConfig/AppIdentifier").InnerText;
            this.ServerConnStr = xdoc.SelectSingleNode("CommonAppConfig/ServerConnStr").InnerText;
            this.ClientConnStr = xdoc.SelectSingleNode("CommonAppConfig/ClientConnStr").InnerText;
            this.SynchInterval = Convert.ToInt32(xdoc.SelectSingleNode("CommonAppConfig/SynchInterval").InnerText);
            this.Startup = (xdoc.SelectSingleNode("CommonAppConfig/Startup").InnerText.ToLower() == "true");

            foreach (XmlNode xNode in xdoc.SelectNodes("/CommonAppConfig/Synchs/*"))
            {
                if (xNode.Name == "Table")
                {
                    TableSynch tableSynch = new TableSynch();

                    foreach (PropertyInfo pi in tableSynch.GetType().GetProperties())
                    {
                        foreach (XmlNode xnParam in xNode.SelectNodes("Param"))
                        {
                            if (!pi.CanRead || !pi.CanWrite) continue;

                            if (pi.Name.ToLower() == xnParam.Attributes["Key"].Value.ToLower())
                                pi.SetValue(tableSynch, Convert.ChangeType(xnParam.Attributes["Value"].Value, pi.PropertyType), null);
                        }
                    }

                    this.tableSynchs.Add(tableSynch);
                }
            }
        }

        #region XOConverter

        /// <summary>
        /// 保存配置对象到XML
        /// </summary>
        /// <param name="t"></param>
        /// <param name="xmlPath"></param>
        public static void SaveConfig(object t, string xmlPath)
        {
            if (t == null) return;
            if (!Path.GetExtension(xmlPath).Equals(".xml", StringComparison.CurrentCultureIgnoreCase)) return;

            StringBuilder contents = new StringBuilder();
            contents.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");

            Type type = t.GetType();
            if (type.IsClass && !type.IsArray) contents.AppendLine(ClassToXml(t));

            File.WriteAllText(xmlPath, contents.ToString(), Encoding.UTF8);
        }

        /// <summary>
        /// 实体转换为XML格式字符串
        /// </summary>
        /// <param name="t"></param>
        /// <param name="name"></param>
        /// <param name="deep"></param>
        /// <returns></returns>
        private static string ClassToXml(object t, string name = "", int deep = 0)
        {
            StringBuilder res = new StringBuilder();

            if (t != null)
            {
                Type type = t.GetType();
                if (!type.IsClass) return string.Empty;

                res.AppendLine(string.Format("{0}<{1}>", BuildSpaceString(deep), string.IsNullOrEmpty(name) ? type.Name : name));

                foreach (PropertyInfo pi in type.GetProperties())
                {
                    if (!pi.CanRead) continue;

                    object pValue = pi.GetValue(t, null);
                    string sValue = pValue != null ? pValue.ToString() : string.Empty;
                    string description = GetPropertyInfoDescription(pi);

                    if (SupportType.Contains(pi.PropertyType))
                    {
                        if (!string.IsNullOrEmpty(description)) res.AppendLine(string.Format("{0}<!--{1}-->", BuildSpaceString(deep + 2), description));

                        res.AppendLine(string.Format("{0}<{1}>{2}</{1}>", BuildSpaceString(deep + 2), pi.Name, sValue));
                    }
                    else if (pi.PropertyType.IsClass && !pi.PropertyType.IsArray && !pi.PropertyType.IsGenericType)
                    {
                        if (pValue == null) pValue = pi.PropertyType.Assembly.CreateInstance(pi.PropertyType.FullName);
                        if (pValue != null) res.Append(ClassToXml(pValue, pi.Name, deep + 2));
                    }
                    else if (pi.PropertyType.IsGenericType)
                    {
                        List<TableSynch> list = (List<TableSynch>)pi.GetValue(t, null);

                        res.AppendLine(string.Format("{0}<!--需要自动同步的数据表-->", BuildSpaceString(deep + 2)));
                        res.AppendLine(string.Format("{0}<{1}>", BuildSpaceString(deep + 2), "Synchs"));
                        foreach (TableSynch item in list)
                        {
                            res.AppendLine(string.Format("{0}<{1}>", BuildSpaceString(deep + 4), "Table"));
                            foreach (PropertyInfo piChild in item.GetType().GetProperties())
                            {
                                if (piChild.Name.ToLower() == "parameters") continue;

                                pValue = piChild.GetValue(item, null);
                                sValue = pValue != null ? pValue.ToString() : string.Empty;
                                description = GetPropertyInfoDescription(piChild);

                                if (!string.IsNullOrEmpty(description)) res.AppendLine(string.Format("{0}<!--{1}-->", BuildSpaceString(deep + 6), description));

                                res.AppendLine(string.Format("{0}<Param Key=\"{1}\" Value=\"{2}\" />", BuildSpaceString(deep + 6), piChild.Name, pValue));
                            }
                            res.AppendLine(string.Format("{0}</{1}>", BuildSpaceString(deep + 4), "Table"));
                        }
                        res.AppendLine(string.Format("{0}</{1}>", BuildSpaceString(deep + 2), "Synchs"));
                    }
                }

                res.AppendLine(string.Format("{0}</{1}>", BuildSpaceString(deep), string.IsNullOrEmpty(name) ? type.Name : name));
            }

            return res.ToString();
        }

        /// <summary>
        /// 生成空白字符
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private static string BuildSpaceString(int length)
        {
            return string.Empty.PadLeft(length, ' ');
        }

        /// <summary>
        /// 获取属性的 DescriptionAttribute
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        private static string GetPropertyInfoDescription(PropertyInfo pi)
        {
            object[] attrs = pi.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (attrs.Length > 0) return (attrs[0] as DescriptionAttribute).Description;

            return string.Empty;
        }

        #endregion

        private string appIdentifier;
        /// <summary>
        /// 程序唯一标识
        /// </summary>
        [Description("程序唯一标识")]
        public string AppIdentifier
        {
            get { return appIdentifier; }
            set { appIdentifier = value; }
        }

        private string serverConnStr;
        /// <summary>
        /// 服务器端(下达)Oracle数据库连接字符串
        /// </summary>
        [Description("服务器端(下达)Oracle数据库连接字符串")]
        public string ServerConnStr
        {
            get { return serverConnStr; }
            set { serverConnStr = value; }
        }

        private string clientConnStr;
        /// <summary>
        /// 就地端(上传)Oracle数据库连接字符串
        /// </summary>
        [Description("就地端(上传)Oracle数据库连接字符串")]
        public string ClientConnStr
        {
            get { return clientConnStr; }
            set { clientConnStr = value; }
        }

        private int synchInterval;
        /// <summary>
        /// 取数间隔 单位：秒
        /// </summary>
        [Description("取数间隔 单位：秒")]
        public int SynchInterval
        {
            get { return synchInterval; }
            set { synchInterval = value; }
        }

        private bool startup;
        /// <summary>
        /// 开机启动
        /// </summary>
        [Description("开机启动")]
        public bool Startup
        {
            get { return startup; }
            set { startup = value; }
        }

        private List<TableSynch> tableSynchs = new List<TableSynch>();
        /// <summary>
        /// 需要自动同步的数据表
        /// </summary>
        public List<TableSynch> TableSynchs
        {
            get { return tableSynchs.OrderBy(a => a.Sequence).ToList(); }
            set { tableSynchs = value; }
        }
    }
}
