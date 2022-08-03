using System;
using System.Collections.Generic;
using Entities.Concrete;

#nullable disable

namespace UI.Entities.Concrete {
    public class CourtType : BaseEntity{
        public CourtType() {
            Courts = new HashSet<Court>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime SaveDate { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Court> Courts { get; set; }
    }
}
