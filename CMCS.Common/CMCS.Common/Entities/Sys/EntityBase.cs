using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.DapperDber.Attrs;

namespace CMCS.Common.Entities.Sys
{
    [Serializable]
    public class EntityBase
    {
        public EntityBase()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreationTime = DateTime.Now;
            this.CreatorUserId = "1";
            this.LastModificAtionTime = this.CreationTime;
            this.LastModifierUserId = this.CreatorUserId;
        }

        [DapperPrimaryKey]
        public string Id { get; set; }
        public DateTime CreationTime { get; set; }
        public string CreatorUserId { get; set; }
        public DateTime LastModificAtionTime { get; set; }
        public string LastModifierUserId { get; set; }
    }
}
