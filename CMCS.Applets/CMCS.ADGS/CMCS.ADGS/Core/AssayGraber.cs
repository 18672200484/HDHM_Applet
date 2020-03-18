using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCS.ADGS.Core
{
    public abstract class AssayGraber
    {
        public string TableName
        {
            get { return Parameters["TableName"]; }
            set { Parameters["TableName"] = value; }
        }

        public string MachineCode
        {
            get { return Parameters["MachineCode"]; }
            set { Parameters["MachineCode"] = value; }
        }

        public string PrimaryKeys
        {
            get { return Parameters["PrimaryKeys"]; }
            set { Parameters["PrimaryKeys"] = value; }
        }
        
        public string ConnStr
        {
            get { return Parameters["ConnStr"].Replace("{yyyy}", System.DateTime.Now.Year.ToString()); }
            set { Parameters["ConnStr"] = value; }
        }

        public bool Enabled
        {
            get { return Convert.ToBoolean(Parameters["Enabled"]); }
            set { Parameters["Enabled"] = value.ToString(); }
        }

        public string DataFrom
        {
            get { return Parameters["DataFrom"]; }
            set { Parameters["DataFrom"] = value; }
        }

        private Dictionary<string, string> parameters = new Dictionary<string, string>();
        public Dictionary<string, string> Parameters
        {
            get { return parameters; }
        }

        public abstract System.Data.DataTable ExecuteGrab();
    }
}
