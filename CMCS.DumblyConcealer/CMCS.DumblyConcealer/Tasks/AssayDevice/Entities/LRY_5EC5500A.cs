using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities;
using CMCS.DapperDber.Attrs;

namespace CMCS.DumblyConcealer.Tasks.AssayDevice.Entities
{
    /// <summary>
    /// .量热仪 型号：5E-C5500A双控
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("HYTBLRY_5EC5500A")]
    public class LRY_5EC5500A
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
        /// 测试时间
        /// </summary>
        public DateTime TestTime { get; set; }
        /// <summary>
        /// 试样编号
        /// </summary>
        public String SYBH { get; set; }
        /// <summary>
        /// 试样重量
        /// </summary>
        public String SYZL { get; set; }
        //测试苯甲酸
        public String CSBJS { get; set; }
        //主期温升
        public Decimal ZJWS { get; set; }
        //冷却校正
        public Decimal LQJZ { get; set; }
        //弹筒发热量
        public Decimal DTFRL { get; set; }
        //空干基高位热值
        public Decimal KGJGWRZ { get; set; }
        //收到基低位热值
        public Decimal SDJDWRZ { get; set; }
        //点火温度
        public Decimal DHWD { get; set; }
        //终点温度
        public Decimal ZDWD { get; set; }
        //空干基水分
        public Decimal KGJSF { get; set; }
        //收到基水分
        public Decimal SDJSF { get; set; }
        //空干基灰分
        public Decimal KGJHF { get; set; }
        //空干基挥发分
        public Decimal KGJHFF { get; set; }
        //空干基氢含量
        public Decimal KGJQHL { get; set; }
        //空干基硫含量
        public Decimal KGJLHL { get; set; }
        /// <summary>
        /// 化验员
        /// </summary>
        public String HYY { get; set; }
    }
}
