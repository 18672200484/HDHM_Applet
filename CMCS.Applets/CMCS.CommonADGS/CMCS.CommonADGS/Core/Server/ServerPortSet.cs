using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CMCS.CommonADGS.Core
{
    /// <summary>
    /// 服务端配置
    /// </summary>
    public class ServerPortSet
    {
        private Dictionary<string, string> parameters = new Dictionary<string, string>();
        public Dictionary<string, string> Parameters
        {
            get { return parameters; }
        }

        /// <summary>
        /// 设备编号
        /// </summary>
        public string MachineCode
        {
            get { return Parameters["MachineCode"]; }
            set { Parameters["MachineCode"] = value.ToString(); }
        }

        /// <summary>
        /// 端口号
        /// </summary>
        public int Port
        {
            get { return Convert.ToInt32(Parameters["Port"]); }
            set { Parameters["Port"] = value.ToString(); }
        }

        /// <summary>
        /// 数据存储路径
        /// </summary>
        public string SavePath
        {
            get { return Parameters["SavePath"]; }
            set { Parameters["SavePath"] = value.ToString(); }
        }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled
        {
            get { return Convert.ToBoolean(Parameters["Enabled"]); }
            set { Parameters["Enabled"] = value.ToString(); }
        }

    }
}
