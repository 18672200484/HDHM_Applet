using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCS.WeighCheck.SampleWeigh.Enums
{
    /// <summary>
    /// 流程标识
    /// </summary>
    public enum eFlowFlag
    {
        选择采样单,
        等待扫码,
        样桶称重,
        等待登记,
        完成登记
    }
}
