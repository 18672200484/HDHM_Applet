using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.CarTransport.Weighter.Enums;

namespace CMCS.CarTransport.Weighter.Core
{
    public class ImperfectCar
    {
        public ImperfectCar(eDirection passWay, string voucher)
        {
            this.passWay = passWay;
            this.voucher = voucher;
        }

        private eDirection passWay = eDirection.UnKnow;
        /// <summary>
        /// 路径
        /// </summary>
        public eDirection PassWay
        {
            get { return passWay; }
            set { passWay = value; }
        }

        private string voucher;
        /// <summary>
        /// 凭证：标签号或车牌号
        /// </summary>
        public string Voucher
        {
            get { return voucher; }
            set { voucher = value; }
        }
    }
}
