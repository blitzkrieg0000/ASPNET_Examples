using System;
using System.Collections.Generic;

#nullable disable

namespace Entities.Concrete {
    public class Court : BaseEntity {
        public Court() {
            PlayingData = new HashSet<PlayingDatum>();
            SessionParameters = new HashSet<SessionParameter>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long CourtTypeId { get; set; }
        public DateTime SaveDate { get; set; }
        public bool IsDeleted { get; set; }

        public CourtType CourtType { get; set; }
        public ICollection<PlayingDatum> PlayingData { get; set; }
        public ICollection<SessionParameter> SessionParameters { get; set; }
    }
}
