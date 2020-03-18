using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys;

namespace CMCS.Common.Entities.Inf
{
    /// <summary>
    /// 自动存样柜-样品主表
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("InfTBCYGCONTROLCMD")]
    public class InfCYGControlCMD : EntityBase
    {
        public virtual DateTime PlanDate { get; set; }
        public virtual String Bill { get; set; }
        public virtual String OperPerson { get; set; }
        public virtual String OperType { get; set; }
        public virtual Decimal CodeNumber { get; set; }
        public virtual DateTime UpdateTime { get; set; }
        public virtual Decimal DataFlag { get; set; }
        public virtual String ReMark { get; set; }
        public virtual String StartPlace { get; set; }
        public virtual String Place { get; set; }
        public virtual String Status { get; set; }
        public virtual String CanWorking { get; set; }
    }
}
