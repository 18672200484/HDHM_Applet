using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCS.DumblyConcealer.Tasks.PneumaticTransfer.Enums
{
    /// <summary>
    /// 气动传输-传输地点
    /// </summary>
    public enum eOp
    {
        人工制样间 = 1,
        自动存查样管理系统 = 2,
        化验室 = 3,
        制样机1 = 4,
        制样机2 = 5,
        弃样 = 999
    }
}
