using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCS.DumblyConcealer.Tasks.PneumaticTransfer.Entities
{

    /// <summary>
    /// 气动传输 
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("QD_STATUS_TB")]
    public class EquQDStatus
    {
        public int SamReady { get; set; }
    }
}
