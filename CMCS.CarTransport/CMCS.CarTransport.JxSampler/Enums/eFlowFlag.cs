using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCS.CarTransport.JxSampler.Enums
{
    /// <summary>
    /// 流程标识
    /// </summary>
    public enum eFlowFlag
    {
        等待车辆,
        验证车辆,
        发送计划,
        等待采样,
        采样完毕,
        等待离开
    }
}
