using System;
using System.Collections.Generic;

namespace Entities.Concrete {
    public class AosType : BaseEntity {
        public AosType() {
            PlayingData = new HashSet<PlayingDatum>();
            SessionParameters = new HashSet<SessionParameter>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long CourtPointAreaId { get; set; }
        public DateTime SaveDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual CourtPointArea CourtPointArea { get; set; }
        public virtual ICollection<PlayingDatum> PlayingData { get; set; }
        public virtual ICollection<SessionParameter> SessionParameters { get; set; }
    }
}
