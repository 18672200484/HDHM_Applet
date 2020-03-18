using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.CarTransport.Weighter.Enums;

namespace CMCS.CarTransport.Weighter.Core
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
        /// <param name="passWay">上磅的方向</param>
        /// <param name="voucher">凭证：标签号或车牌号</param>
        public void Enqueue(eDirection direction, string voucher)
        {
            if (Queuer.Any(a => a.Voucher == voucher)) return;

            Queuer.Enqueue(new ImperfectCar(direction, voucher));
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
