using System;
using CMCS.Common.Entities.Sys; 

namespace CMCS.Common.Entities.TrainInFactory
{

    [Serializable]
    [CMCS.DapperDber.Attrs.DapperBind("CmcsTbTrainWatch")]
    public class CmcsTrainWatch : EntityBase
    {
        public Decimal OrderNumber { get; set; }
        public String CatchDest { get; set; }
        public String CatchType { get; set; }
        public DateTime CatchTime { get; set; }
        public String TrainWeightRecordId { get; set; }
        [DapperDber.Attrs.DapperIgnore]
        public CmcsTrainWeightRecord TheTrainWeightRecord
        {
            get
            {
                return Dbers.GetInstance().SelfDber.Get<CmcsTrainWeightRecord>(this.TrainWeightRecordId);
            }
        }
    }
}
