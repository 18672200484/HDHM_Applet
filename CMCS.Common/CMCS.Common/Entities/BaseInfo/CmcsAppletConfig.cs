using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys; 

namespace CMCS.Common.Entities.BaseInfo
{
    /// <summary>
    /// 程序配置类
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("cmcstbappletconfig")]
    public class CmcsAppletConfig : EntityBase1
    {
        private string appIdentifier;
        /// <summary>
        /// 程序唯一标识
        /// </summary>
        public string AppIdentifier
        {
            get { return appIdentifier; }
            set { appIdentifier = value; }
        }

        private string configName;
        /// <summary>
        /// 配置名称
        /// </summary>
        public string ConfigName
        {
            get { return configName; }
            set { configName = value; }
        }

        private string configValue;
        /// <summary>
        /// 值
        /// </summary>
        public string ConfigValue
        {
            get { return configValue; }
            set { configValue = value; }
        }
    }
}
