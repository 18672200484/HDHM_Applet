using System;
using System.Collections.Generic;
using System.Text;
//
using System.Reflection;
using System.IO;
using System.ComponentModel;
using System.Xml;

namespace CMCS.Common.Utilities
{
    /// <summary>
    /// XML配置辅助类
    /// </summary>
    public class XOConverter
    {
        private XOConverter() { }

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

        /// <summary>
        /// 从XML加载配置对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlPath"></param>
        /// <returns></returns>
        public static T LoadConfig<T>(string xmlPath) where T : new()
        {
            T t = new T();

            if (!string.IsNullOrEmpty(xmlPath))
            {
                if (Path.GetExtension(xmlPath).Equals(".xml", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (File.Exists(xmlPath))
                    {
                        XmlDocument xdoc = new XmlDocument();
                        xdoc.LoadXml(File.ReadAllText(xmlPath));

                        return XmlToClass<T>(xdoc.SelectSingleNode("/" + t.GetType().Name), t);
                    }
                }
            }

            return t;
        }

        /// <summary>
        /// 实体转换为XML格式字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        private static T XmlToClass<T>(XmlNode node, T t) where T : new()
        {
            if (node == null || t == null) return t;

            foreach (PropertyInfo pi in t.GetType().GetProperties())
            {
                if (!pi.CanRead || !pi.CanWrite) continue;

                XmlNode theNode = node.SelectSingleNode(pi.Name);
                if (theNode != null)
                {
                    if (SupportType.Contains(pi.PropertyType))
                        pi.SetValue(t, Convert.ChangeType(theNode.InnerText, pi.PropertyType), null);
                    else if (pi.PropertyType.IsClass && !pi.PropertyType.IsArray)
                    {
                        object instance = pi.GetValue(t, null);
                        if (instance == null)
                        {
                            instance = pi.PropertyType.Assembly.CreateInstance(pi.PropertyType.FullName);
                            pi.SetValue(t, instance, null);
                        }
                        XmlToClass(theNode, instance);
                    }
                }
            }

            return t;
        }

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

                    if (!string.IsNullOrEmpty(description)) res.AppendLine(string.Format("{0}<!--{1}-->", BuildSpaceString(deep + 2), description));
                    if (SupportType.Contains(pi.PropertyType))
                        res.AppendLine(string.Format("{0}<{1}>{2}</{1}>", BuildSpaceString(deep + 2), pi.Name, sValue));
                    else if (pi.PropertyType.IsClass && !pi.PropertyType.IsArray)
                    {
                        if (pValue == null) pValue = pi.PropertyType.Assembly.CreateInstance(pi.PropertyType.FullName);
                        if (pValue != null) res.Append(ClassToXml(pValue, pi.Name, deep + 2));
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
    }
}
