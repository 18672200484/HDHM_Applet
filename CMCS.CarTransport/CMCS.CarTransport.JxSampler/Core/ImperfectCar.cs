using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCS.CarTransport.JxSampler.Core
{
    public class ImperfectCar
    {
        public ImperfectCar(string voucher)
        { 
            this.voucher = voucher;
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
