using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys;

namespace CMCS.DumblyConcealer.Tasks.AutoMaker.Entities
{
    /// <summary>
    /// 全自动制样机接口表 - 制样计划表
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("EquTbQZDZYJPlan")]
    public class EquQZDZYJPlan : EntityBase2
    {
        private string _InFactoryBatchId;
        /// <summary>
        /// 批次Id
        /// </summary>
        public string InFactoryBatchId
        {
            get { return _InFactoryBatchId; }
            set { _InFactoryBatchId = value; }
        }

        private string _MakeCode;
        /// <summary>
        /// 制样码
        /// </summary>
        public string MakeCode
        {
            get { return _MakeCode; }
            set { _MakeCode = value; }
        }

        private string _FuelKindName;
        /// <summary>
        /// 煤种
        /// </summary>
        public string FuelKindName
        {
            get { return _FuelKindName; }
            set { _FuelKindName = value; }
        }

        private double _Mt;
        /// <summary>
        /// 水分
        /// </summary>
        public double Mt
        {
            get { return _Mt; }
            set { _Mt = value; }
        }

        private double _CoalSize;
        /// <summary>
        /// 煤炭粒度
        /// </summary>
        public double CoalSize
        {
            get { return _CoalSize; }
            set { _CoalSize = value; }
        } 

        private int _DataFlag;
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
