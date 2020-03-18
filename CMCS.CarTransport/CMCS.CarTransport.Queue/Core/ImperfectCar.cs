using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.CarTransport.Queue.Enums;

namespace CMCS.CarTransport.Queue.Core
{
    public class ImperfectCar
    {
        public ImperfectCar(ePassWay passWay, string voucher, bool isFromDevice)
        {
            this.passWay = passWay;
            this.voucher = voucher;
            this.isFromDevice = isFromDevice;
        }

        private ePassWay passWay = ePassWay.UnKnow;
        /// <summary>
        /// 路径
        /// </summary>
        public ePassWay PassWay
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

        private bool isFromDevice;
        /// <summary>
        /// 来自设备
        /// </summary>
        public bool IsFromDevice
        {
            get { return isFromDevice; }
            set { isFromDevice = value; }
        }
    }
}
