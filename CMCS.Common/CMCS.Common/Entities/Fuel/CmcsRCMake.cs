using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities.Sys;

namespace CMCS.Common.Entities.Fuel
{
    /// <summary>
    /// 入厂煤制样表
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("CmcsTbMake")]
    public class CmcsRCMake : EntityBase1
    {
        private string _SamplingId;

        /// <summary>
        /// 入厂煤采样Id
        /// </summary>
        public string SamplingId
        {
            get { return _SamplingId; }
            set { _SamplingId = value; }
        }
        private string _GetPle;

        /// <summary>
        /// 接样人
        /// </summary>
        public string GetPle
        {
            get { return _GetPle; }
            set { _GetPle = value; }
        }
        private DateTime _GetDate;

        /// <summary>
        /// 接样时间
        /// </summary>
        public DateTime GetDate
        {
            get { return _GetDate; }
            set { _GetDate = value; }
        }

        private DateTime _MakeDate;
        /// <summary>
        /// 制样时间
        /// </summary>
        public DateTime MakeDate
        {
            get { return _MakeDate; }
            set { _MakeDate = value; }
        }

        private string _MakePle;

        /// <summary>
        /// 制样人
        /// </summary>
        public string MakePle
        {
            get { return _MakePle; }
            set { _MakePle = value; }
        }
        private string _MakeType;

        /// <summary>
        /// 制样方式
        /// </summary>
        public string MakeType
        {
            get { return _MakeType; }
            set { _MakeType = value; }
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

        private string _Discriminator;
        /// <summary>
        /// 入厂入炉标识
        /// </summary>
        public string Discriminator
        {
            get { return _Discriminator; }
            set { _Discriminator = value; }
        }

        private string _Remark;

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        /// <summary>
        /// 是否删除 0已删除 1 未删除
        /// </summary>
        public Int32 IsDeleted { get; set; }
    }
}
