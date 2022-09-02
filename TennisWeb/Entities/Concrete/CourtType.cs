using System;
using System.Collections.Generic;

#nullable disable

namespace Entities.Concrete {
    public class CourtType : BaseEntity {
        public CourtType() {
            Courts = new HashSet<Court>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime SaveDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Court> Courts { get; set; }
    }
}
