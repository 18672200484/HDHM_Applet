
namespace CMCS.CarTransport.JxSampler.Core
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

        static RW.LZR12.Lzr12Rwer rwer1 = new RW.LZR12.Lzr12Rwer();
        /// <summary>
        /// 读卡器1
        /// </summary>
        public static RW.LZR12.Lzr12Rwer Rwer1
        {
            get { return rwer1; }
        } 
    }
}
