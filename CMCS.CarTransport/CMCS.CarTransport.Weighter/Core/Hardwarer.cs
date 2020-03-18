
namespace CMCS.CarTransport.Weighter.Core
{
    /// <summary>
    /// 硬件设备类
    /// </summary>
    public class Hardwarer
    {
        static IOC.JMDM20DIOV2.JMDM20DIOV2Iocer iocer = new IOC.JMDM20DIOV2.JMDM20DIOV2Iocer();
        /// <summary>
        /// IO控制器
        /// </summary>
        public static IOC.JMDM20DIOV2.JMDM20DIOV2Iocer Iocer
        {
            get { return iocer; }
        }

        static WB.TOLEDO.IND245.TOLEDO_IND245Wber wber = new WB.TOLEDO.IND245.TOLEDO_IND245Wber(4);
        /// <summary>
        /// 地磅仪表
        /// </summary>
        public static WB.TOLEDO.IND245.TOLEDO_IND245Wber Wber
        {
            get { return wber; }
        }

        static RW.LZR12.Lzr12Rwer rwer1 = new RW.LZR12.Lzr12Rwer();
        /// <summary>
        /// 读卡器1
        /// </summary>
        public static RW.LZR12.Lzr12Rwer Rwer1
        {
            get { return rwer1; }
        }

        static RW.LZR12.Lzr12Rwer rwer2 = new RW.LZR12.Lzr12Rwer();
        /// <summary>
        /// 读卡器2
        /// </summary>
        public static RW.LZR12.Lzr12Rwer Rwer2
        {
            get { return rwer2; }
        }
    }
}
