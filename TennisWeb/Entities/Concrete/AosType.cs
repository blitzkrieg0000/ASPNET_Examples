using System;
using System.Collections.Generic;
using Entities.Concrete;

#nullable disable

namespace UI.Entities.Concrete {
    public class AosType : BaseEntity {
        public AosType() {
            PlayingData = new HashSet<PlayingDatum>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long CourtPointAreaId { get; set; }
        public DateTime SaveDate { get; set; }
        public bool IsDeleted { get; set; }

        public CourtPointArea CourtPointArea { get; set; }
        public ICollection<PlayingDatum> PlayingData { get; set; }
    }
}
