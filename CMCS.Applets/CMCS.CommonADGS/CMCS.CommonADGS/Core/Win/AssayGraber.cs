using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCS.CommonADGS.Core
{
    public abstract class AssayGraber
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName
        {
            get { return Parameters["TableName"]; }
            set { Parameters["TableName"] = value; }
        }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string MachineCode
        {
            get { return Parameters["MachineCode"]; }
            set { Parameters["MachineCode"] = value; }
        }

        /// <summary>
        /// 主键名
        /// </summary>
        public string PrimaryKeys
        {
            get { return Parameters["PrimaryKeys"]; }
            set { Parameters["PrimaryKeys"] = value; }
        }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnStr
        {
            get { return Parameters["ConnStr"].Replace("{yyyy}", System.DateTime.Now.Year.ToString()); }
            set { Parameters["ConnStr"] = value; }
        }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled
        {
            get { return Convert.ToBoolean(Parameters["Enabled"]); }
            set { Parameters["Enabled"] = value.ToString(); }
        }

        /// <summary>
        /// 数据文件路径
        /// </summary>
        public string DataPath
        {
            get { return Parameters["DataPath"]; }
            set { Parameters["DataPath"] = value; }
        }

        /// <summary>
        /// 进程名称
        /// </summary>
        public string ProcessName
        {
            get { return Parameters["ProcessName"]; }
            set { Parameters["ProcessName"] = value; }
        }

        /// <summary>
        /// 端口
        /// </summary>
        public string Port
        {
            get { return Parameters["Port"]; }
            set { Parameters["Port"] = value; }
        }

        private Dictionary<string, string> parameters = new Dictionary<string, string>();
        public Dictionary<string, string> Parameters
        {
            get { return parameters; }
        }

        public abstract System.Data.DataTable ExecuteGrab();
    }
}
