using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCS.Common.Enums
{
    /// <summary>
    /// 第三方设备接口 - 全自动制样机系统状态
    /// </summary>
    public enum eEquInfAutoMakerSystemStatus
    {
        正在运行 = 1,
        发生故障 = 2,
        就绪待机 = 3
    }
}
