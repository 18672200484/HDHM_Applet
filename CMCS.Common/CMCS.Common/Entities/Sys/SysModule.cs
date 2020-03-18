using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys;
using CMCS.DapperDber.Attrs;


namespace CMCS.Common.Entities.Sys
{
    /// <summary>
    /// 菜单模块信息表
    /// </summary>
    [DapperBind("CmcsTbSysModule")]
    public class SysModule : EntityBase1
    {
        private string _Moduleno;
        private string _ModuleName;
        private string _ModuleDll;
        private int _StopUse = 0;

        /// <summary>
        /// 模块编码
        /// </summary>
        public string Moduleno
        {
            get { return _Moduleno; }
            set { _Moduleno = value; }
        }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName
        {
            get { return _ModuleName; }
            set { _ModuleName = value; }
        }

        /// <summary>
        /// 模块完整命名空间名
        /// </summary>
        public string ModuleDll
        {
            get { return _ModuleDll; }
            set { _ModuleDll = value; }
        }

        /// <summary>
        /// 停用
        /// </summary>
        public int StopUse
        {
            get { return _StopUse; }
            set { _StopUse = value; }
        }
       
    }
}
