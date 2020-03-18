using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CMCS.Common
{
    /// <summary>
    /// 程序配置
    /// </summary>
    public class CommonAppConfig
    {
        private static string ConfigXmlPath = "Common.AppConfig.xml";

        private static CommonAppConfig instance;

        public static CommonAppConfig GetInstance()
        {
            return instance;
        }

        static CommonAppConfig()
        {
            instance = CMCS.Common.Utilities.XOConverter.LoadConfig<CommonAppConfig>(ConfigXmlPath);
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        public void Save()
        {
            CMCS.Common.Utilities.XOConverter.SaveConfig(instance, ConfigXmlPath);
        }

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

        private string selfConnStr;
        /// <summary>
        /// 集中管控Oracle数据库连接字符串
        /// </summary>
        [Description("集中管控Oracle数据库连接字符串")]
        public string SelfConnStr
        {
            get { return selfConnStr; }
            set { selfConnStr = value; }
        }
    }
}
