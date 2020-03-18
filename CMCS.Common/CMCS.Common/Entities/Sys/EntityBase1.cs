using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using CMCS.DapperDber.Attrs;

namespace CMCS.Common.Entities.Sys
{
    [Serializable]
    public class EntityBase1 : EntityBase
    {
        public EntityBase1()
        {
            this.IsDeleted = 0;
            this.DeleterUserId = this.DeleterUserId;
            this.DeletionTime = this.DeletionTime;
        }

        public int IsDeleted { get; set; }
        public int DeleterUserId { get; set; }
        public DateTime DeletionTime { get; set; }
    }
}
