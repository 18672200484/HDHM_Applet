using System;
using CMCS.Common.Entities.Sys; 

namespace CMCS.Common.Entities.TrainInFactory
{

    [Serializable]
    [CMCS.DapperDber.Attrs.DapperBind("CmcsTbTrainLine")]
    public class CmcsTrainLine : EntityBase1
    {
        public Decimal OrderNumber { get; set; }
        public String Height { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
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
