using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCS.WeighCheck.SampleCheck.Enums
{
    /// <summary>
    /// 流程标识
    /// </summary>
    public enum eFlowFlag
    {
        等待扫码,
        重量校验,
        等待校验,
        发送制样命令,
        等待制样结果
    }
}
