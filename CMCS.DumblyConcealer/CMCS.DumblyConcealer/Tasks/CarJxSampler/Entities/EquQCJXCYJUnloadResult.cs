using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities;
using CMCS.Common.Entities.Sys;

namespace CMCS.DumblyConcealer.Tasks.CarJXSampler.Entities
{
    /// <summary>
    /// 汽车机械采样机接口 - 卸样结果表
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("EquTbQCJXCYJUnloadResult")]
    public class EquQCJXCYJUnloadResult : EntityBase2
    {
        private string _SampleCode;
        private string _BarrelCode;
        private DateTime _UnloadTime;
        private int _DataFlag;


        private string samplingId;
        /// <summary>
        /// 采样单Id
        /// </summary>
        public string SamplingId
        {
            get { return samplingId; }
            set { samplingId = value; }
        }

        /// <summary>
        /// 采样码
        /// </summary>
        public string SampleCode
        {
            get { return _SampleCode; }
            set { _SampleCode = value; }
        }

        private string barrelNumber;
        /// <summary>
        /// 样罐编号
        /// </summary>
        public string BarrelNumber
        {
            get { return barrelNumber; }
            set { barrelNumber = value; }
        }

        /// <summary>
        /// 样罐编码
        /// </summary>
        public string BarrelCode
        {
            get { return _BarrelCode; }
            set { _BarrelCode = value; }
        }

        /// <summary>
        /// 卸样时间
        /// </summary>
        public DateTime UnloadTime
        {
            get { return _UnloadTime; }
            set { _UnloadTime = value; }
        }

        /// <summary>
        /// 标识符
        /// </summary>
        public int DataFlag
        {
            get { return _DataFlag; }
            set { _DataFlag = value; }
        }
    }
}
