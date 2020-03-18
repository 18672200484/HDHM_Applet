using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCS.WeighCheck.MakeCheck.Enums
{
    /// <summary>
    /// 流程标识
    /// </summary>
    public enum eFlowFlag
    {
        等待扫码,
        等待校验,
        校验成功,
        打印化验码
    }
}
