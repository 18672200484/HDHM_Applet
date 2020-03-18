using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys;

namespace CMCS.Common.Entities.Fuel
{
    /// <summary>
    /// 入厂煤采样与入厂煤批次明细关联表
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("cmcstbrcsampling_b_t")]
    public class CmcsRCSampling_B_T : EntityBase1
    {
        private string _SampleBarrelId;
        /// <summary>
        /// 采样桶Id
        /// </summary>
        public string SampleBarrelId
        {
            get { return _SampleBarrelId; }
            set { _SampleBarrelId = value; }
        }

        private string _TransportId;
        /// <summary>
        /// 车次明细Id
        /// </summary>
        public string TransportId
        {
            get { return _TransportId; }
            set { _TransportId = value; }
        }
    }
}
