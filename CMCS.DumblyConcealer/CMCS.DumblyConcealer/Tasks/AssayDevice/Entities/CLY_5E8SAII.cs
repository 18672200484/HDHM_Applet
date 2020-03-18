using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities;
using CMCS.DapperDber.Attrs;

namespace CMCS.DumblyConcealer.Tasks.AssayDevice.Entities
{
    /// <summary>
    /// .测硫仪 型号：5E-8SAII
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("HYTBCLY_5E8SAII")]
    public class CLY_5E8SAII
    {
        [DapperPrimaryKey]
        public string PKID { get; set; }
        /// <summary>
        /// 设备编码
        /// </summary>
        public String MachineCode { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        public Int32 NID { get; set; }
        /// <summary>
        /// 试样编号
        /// </summary>
        public String SYBH { get; set; }
        /// <summary>
        /// 试样重量
        /// </summary>
        public Decimal SYZL { get; set; }
        /// <summary>
        /// 空干基水分
        /// </summary>
        public Decimal KGJSF { get; set; }
        /// <summary>
        /// 空干基硫含量
        /// </summary>
        public Decimal KGJLHL { get; set; }
        /// <summary>
        /// 干基硫含量
        /// </summary>
        public Decimal GJLHL { get; set; }
        /// <summary>
        /// 测试日期
        /// </summary>
        public DateTime TESTTIME { get; set; }
    }
}
