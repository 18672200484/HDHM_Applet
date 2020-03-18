using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys; 

namespace CMCS.Common.Entities.Fuel
{
    /// <summary>
    /// 化验数据-工业分析仪
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("CMCSTBPROXIMATEASSAY")]
    public class CmcsProximateAssay : EntityBase
    {
        /// <summary>
        /// 化验编码
        /// </summary>
        public string SampleNumber { get; set; }

        /// <summary>
        /// 设备编号
        /// </summary>
        public string FacilityNumber { get; set; }

        /// <summary>
        /// 内水器皿/坩埚编号
        /// </summary>
        public String MadContainerNumber { get; set; }

        /// <summary>
        /// 内水坩埚重量
        /// </summary>
        public decimal MadContainerWeight { get; set; }

        /// <summary>
        /// 内水样品重量
        /// </summary>
        public decimal MadSampleWeight { get; set; }

        /// <summary>
        /// 内水烘干后总质量
        /// </summary>
        public decimal MadDryWeight { get; set; }

        /// <summary>
        /// 内水
        /// </summary>
        public decimal Mad { get; set; }

        /// <summary>
        /// 挥发分器皿/坩埚编号
        /// </summary>
        public String VadContainerNumber { get; set; }

        /// <summary>
        /// 挥发分坩埚重量
        /// </summary>
        public decimal VadContainerWeight { get; set; }

        /// <summary>
        /// 挥发分样品重量
        /// </summary>
        public decimal VadSampleWeight { get; set; }

        /// <summary>
        /// 挥发分灼烧后总质量
        /// </summary>
        public decimal VadDryWeight { get; set; }

        /// <summary>
        /// 挥发份
        /// </summary>
        public decimal Vad { get; set; }

        /// <summary>
        /// 灰分器皿/坩埚编号
        /// </summary>
        public String AadContainerNumber { get; set; }

        /// <summary>
        /// 灰分坩埚重量
        /// </summary>
        public decimal AadContainerWeight { get; set; }

        /// <summary>
        /// 灰分样品重量
        /// </summary>
        public decimal AadSampleWeight { get; set; }

        /// <summary>
        /// 灰分灼烧后总质量
        /// </summary>
        public decimal AadDryWeight { get; set; }

        /// <summary>
        /// 灰分
        /// </summary>
        public decimal Aad { get; set; }

        /// <summary>
        /// 化验用户
        /// </summary>
        public string AssayUser { get; set; }

        /// <summary>
        /// 化验日期
        /// </summary>
        public DateTime AssayTime { get; set; }

        /// <summary>
        /// 顺序号
        /// </summary>
        public int OrderNumber { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public int IsEffective { get; set; }

        /// <summary>
        /// 第三方主键ID
        /// </summary>
        public string PKID { get; set; }

        /// <summary>
        /// 数据来源
        /// </summary>
        public String DataFrom { get; set; }
    }
}
