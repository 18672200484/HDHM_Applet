using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities;
using CMCS.DapperDber.Attrs;

namespace CMCS.DumblyConcealer.Tasks.AssayDevice.Entities
{
    /// <summary>
    /// .水分仪 型号：5E-MW6510
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("HYTBSFY_5EMW6510")]
    public class SFY_5EMW6510
    {
        [DapperPrimaryKey]
        public string PKID { get; set; }
        /// <summary>
        /// 自动编号
        /// </summary>
        public string AutoNo { get; set; }
        /// <summary>
        /// 手动编号
        /// </summary>
        public string SampleNo { get; set; }
        /// <summary>
        /// Mad样重(g)
        /// </summary>
        public Decimal MMass { get; set; }
        /// <summary>
        /// Mad坩埚重(g)
        /// </summary>
        public int MTare { get; set; }
        /// <summary>
        /// Mad烘后重(g)
        /// </summary>
        public decimal MHeated { get; set; }
        /// <summary>
        /// Mad(%)
        /// </summary>
        public decimal Mad { get; set; }
        /// <summary>
        /// Mt样重(g)
        /// </summary>
        public decimal MtMass { get; set; }
        /// <summary>
        /// Mt坩埚重(g)
        /// </summary>
        public decimal MtTare { get; set; }
        /// <summary>
        /// Mt(%
        /// </summary>
        public decimal Mt { get; set; }
        /// <summary>
        /// Mt烘后重(g)
        /// </summary>
        public decimal MtHeated { get; set; }
        /// <summary>
        /// 全水类型
        /// </summary>
        public String MType { get; set; }
        /// <summary>
        /// 灰分样重(g)
        /// </summary>
        public decimal AMass { get; set; }
        /// <summary>
        /// 灰分皮重(g)
        /// </summary>
        public decimal ATare { get; set; }
        /// <summary>
        /// 灰分灼后重(g)
        /// </summary>
        public decimal ABurned { get; set; }
        /// <summary>
        /// Aad(%)
        /// </summary>
        public decimal Aad { get; set; }
        /// <summary>
        /// Ad(%)
        /// </summary>
        public decimal Ad { get; set; }
        /// <summary>
        /// 挥发分样重(g)
        /// </summary>
        public decimal VMass { get; set; }
        /// <summary>
        /// 挥发分皮重(g)
        /// </summary>
        public decimal VTare { get; set; }
        /// <summary>
        /// 挥发分灼后重(g)
        /// </summary>
        public decimal VBurned { get; set; }
        /// <summary>
        /// Vt,ad(%)
        /// </summary>
        public decimal Vt_ad { get; set; }
        /// <summary>
        /// Vad(%)
        /// </summary>
        public decimal Vad { get; set; }
        /// <summary>
        /// Vd(%)
        /// </summary>
        public decimal Vd { get; set; }
        /// <summary>
        /// Vdaf(%)
        /// </summary>
        public decimal Vdaf { get; set; }
        /// <summary>
        /// FCad(%)
        /// </summary>
        public decimal FCad { get; set; }
        /// <summary>
        /// FCd
        /// </summary>
        public decimal FCd { get; set; }
        /// <summary>
        /// Had(%)
        /// </summary>
        public decimal Had { get; set; }
        /// <summary>
        /// Hd(%)
        /// </summary>
        public decimal Hd { get; set; }
        /// <summary>
        /// Qad,MJ/Kg
        /// </summary>
        public decimal Qad { get; set; }
        /// <summary>
        /// Qd,MJ/Kg
        /// </summary>
        public decimal Qd { get; set; }
        /// <summary>
        /// 分析水方法
        /// </summary>
        public String MMethod { get; set; }
        /// <summary>
        /// 灰分方法
        /// </summary>
        public String AMethod { get; set; }
        /// <summary>
        /// 挥发分方法
        /// </summary>
        public String VMethod { get; set; }
        /// <summary>
        /// 测试日期
        /// </summary>
        public DateTime TestDate { get; set; }
        /// <summary>
        /// 测试时间
        /// </summary>
        public String TestTime { get; set; }
        /// <summary>
        /// 分析水测试时间
        /// </summary>
        public String MTime { get; set; }
        /// <summary>
        /// 灰分时间
        /// </summary>
        public String ATime { get; set; }
        /// <summary>
        /// 挥发分时间
        /// </summary>
        public String VTime { get; set; }
        /// <summary>
        /// 化验员
        /// </summary>
        public String TestMan { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public String Meno { get; set; }
        /// <summary>
        /// Mcwm(%)
        /// </summary>
        public Decimal Mcwm { get; set; }
        /// <summary>
        /// Acwm(%)
        /// </summary>
        public Decimal Acwm { get; set; }
        /// <summary>
        /// Vcwm(%)
        /// </summary>
        public Decimal Vcwm { get; set; }
        /// <summary>
        /// FCcwm(%)
        /// </summary>
        public Decimal FCcwm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Decimal iFirstMad { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Decimal iFirstAad { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Decimal iFirstVad { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Decimal iZeroMad { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Decimal iZeroAad { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Decimal iZeroVad { get; set; }
        /// <summary>
        /// 设备型号
        /// </summary>
        public String DeviceModel { get; set; }
        /// <summary>
        /// 设备编号
        /// </summary>
        public String DeviceNo { get; set; }
        /// <summary>
        /// 环境温度(℃)
        /// </summary>
        public String Temp { get; set; }
        /// <summary>
        /// 湿度(%)
        /// </summary>
        public String Humidity { get; set; }
        /// <summary>
        /// 焦渣特征
        /// </summary>
        public Decimal CRC { get; set; }
        /// <summary>
        /// 预留文本1
        /// </summary>
        public String SpareTxt1 { get; set; }
        /// <summary>
        /// 预留文本2
        /// </summary>
        public String SpareTxt2 { get; set; }
        /// <summary>
        /// 控号
        /// </summary>
        public String SpareTxt3 { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public String SpareTxt4 { get; set; }
    }
}
