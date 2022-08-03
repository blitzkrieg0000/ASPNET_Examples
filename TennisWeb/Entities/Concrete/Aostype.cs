using System;
using System.Collections.Generic;
using Entities.Concrete;

#nullable disable

namespace UI.Entities.Concrete {
    public class Aostype : BaseEntity {
        public Aostype() {
            PlayingData = new HashSet<PlayingDatum>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long CourtPointAreaId { get; set; }
        public DateTime SaveDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual CourtPointArea CourtPointArea { get; set; }
        public virtual ICollection<PlayingDatum> PlayingData { get; set; }
    }
}
