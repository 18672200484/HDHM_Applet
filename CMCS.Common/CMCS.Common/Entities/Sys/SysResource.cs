using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys;
using CMCS.DapperDber.Attrs;


namespace CMCS.Common.Entities.Sys
{
    /// <summary>
    /// 模块资源表
    /// </summary>
    [DapperBind("CmcsTbSysResource")]
    public class SysResource : EntityBase1
    {
        private string _Resno;
        private string _ResName;
        private string _ModuleId;
        private int _OrderNO;

        /// <summary>
        /// 排序号
        /// </summary>
        public int OrderNO
        {
            get { return _OrderNO; }
            set { _OrderNO = value; }
        }

        /// <summary>
        /// 功能编码
        /// </summary>
        public string Resno
        {
            get { return _Resno; }
            set { _Resno = value; }
        }

        /// <summary>
        /// 功能名称
        /// </summary>
        public string ResName
        {
            get { return _ResName; }
            set { _ResName = value; }
        }

        /// <summary>
        /// 模块id
        /// </summary>
        public string ModuleId
        {
            get { return _ModuleId; }
            set { _ModuleId = value; }
        }

        [DapperIgnore]
        public SysModule TheSysModule
        {
            get { return Dbers.GetInstance().SelfDber.Get<SysModule>(this.ModuleId); }
        }
    }
}
