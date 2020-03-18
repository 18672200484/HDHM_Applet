using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys;
using CMCS.DapperDber.Attrs;

namespace CMCS.Common.Entities.Sys
{
    /// <summary>
    /// 用户功能权限表
    /// </summary>
    [DapperBind("CmcsTbSysResourceUser")]
    public class SysResourceUser : EntityBase1
    {
        private string _ResourceId;
        private string _UserId;

        public string ResourceId
        {
            get { return _ResourceId; }
            set { _ResourceId = value; }
        }

        public string UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }

    }
}
