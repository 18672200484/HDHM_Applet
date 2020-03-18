using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCS.Common.Enums
{
    /// <summary>
    /// 汽车智能化入厂步骤
    /// </summary>
    public enum eTruckInFactoryStep
    {
        入厂,
        重车,
        采样,
        装载,
        卸载,
        轻车,
        出厂,
        第一次称重,
        第二次称重
    }
}
