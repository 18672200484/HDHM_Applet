using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using CMCS.Common.Entities.Sys;
using CMCS.Common.Enums;

namespace CMCS.DumblyConcealer.Tasks.AutoMaker.Entities
{
    /// <summary>
    /// 控制命令表
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("EquTbQZDZYJCmd")]
    public class EquQZDZYJCmd : EntityBase2
    {
        /// <summary>
        /// 命令代码
        /// </summary>		
        private string _CmdCode;
        public string CmdCode
        {
            get { return _CmdCode; }
            set { _CmdCode = value; }
        }

        /// <summary>
        /// 制样码
        /// </summary>		
        private string _MakeCode;
        public string MakeCode
        {
            get { return _MakeCode; }
            set { _MakeCode = value; }
        }

        /// <summary>
        /// 执行结果
        /// </summary>		
        private string _ResultCode = eEquInfCmdResultCode.默认.ToString();
        public string ResultCode
        {
            get { return _ResultCode; }
            set { _ResultCode = value; }
        }

        /// <summary>
        /// 标识符
        /// </summary>		
        private int _DataFlag;
        public int DataFlag
        {
            get { return _DataFlag; }
            set { _DataFlag = value; }
        }


    }
}