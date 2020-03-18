using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys;

namespace CMCS.Common.Entities.Inf
{
    /// <summary>
    /// 自动存样柜-样品从表
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("InfTBCYGCONTROLCMDDETAIL")]
    public class InfCYGControlCMDDetail : EntityBase
    {
        public virtual String MachineCode { get; set; }
        /// <summary>
        /// 样品编码
        /// </summary>
        public virtual String Code { get; set; }
        /// <summary>
        /// 样品类型
        /// </summary>
        public virtual String SamType { get; set; }
        public virtual DateTime UpdateTime { get; set; }
        /// <summary>
        /// 是否完成
        /// </summary>
        public virtual Decimal ResultCode { get; set; }
        public virtual String CYGControlCMDId { get; set; }
        public virtual String Status { get; set; }
        public virtual String Errors { get; set; }
        [DapperDber.Attrs.DapperIgnore]
        public InfCYGControlCMD TheCmcsCYGControlCMD
        {
            get
            {
                return Dbers.GetInstance().SelfDber.Get<InfCYGControlCMD>(this.CYGControlCMDId);
            }
        }
    }
}
