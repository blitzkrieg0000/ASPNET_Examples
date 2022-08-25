using System;
using System.Collections.Generic;


namespace Entities.Concrete {
    public class Player : BaseEntity {
        public Player() {
            PlayingData = new HashSet<PlayingDatum>();
            SessionParameters = new HashSet<SessionParameter>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public long? GenderId { get; set; }
        public DateTime SaveDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual ICollection<PlayingDatum> PlayingData { get; set; }
        public virtual ICollection<SessionParameter> SessionParameters { get; set; }
    }
}
