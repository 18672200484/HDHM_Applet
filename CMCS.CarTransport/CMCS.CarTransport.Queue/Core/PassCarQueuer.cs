using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.CarTransport.Queue.Enums;

namespace CMCS.CarTransport.Queue.Core
{
    /// <summary>
    /// 识别车辆队列
    /// </summary>
    public class PassCarQueuer
    {
        /// <summary>
        /// 识别车号队列
        /// </summary>
        Queue<ImperfectCar> Queuer = new Queue<ImperfectCar>();

        public int Count
        {
            get { return Queuer.Count; }
        }

        /// <summary>
        /// 将对象添加到结尾处。
        /// </summary>
        /// <param name="passWay">路径</param>
        /// <param name="voucher">凭证：标签号或车牌号</param>
        /// <param name="isFromDevice">来自设备</param>
        public void Enqueue(ePassWay passWay, string voucher, bool isFromDevice)
        {
            if (Queuer.Any(a => a.Voucher == voucher)) return;

            Queuer.Enqueue(new ImperfectCar(passWay, voucher, isFromDevice));
        }

        /// <summary>
        /// 移除并返回位于开始处的对象。
        /// </summary>
        /// <returns></returns>
        public ImperfectCar Dequeue()
        {
            return Queuer.Dequeue();
        }
    }
}
