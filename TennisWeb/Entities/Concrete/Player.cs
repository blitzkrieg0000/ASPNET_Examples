using System;
using System.Collections.Generic;
using Entities.Concrete;

#nullable disable

namespace UI.Entities.Concrete {
    public class Player : BaseEntity {
        public Player() {
            PlayingData = new HashSet<PlayingDatum>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public char Gender { get; set; }
        public DateTime SaveDate { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<PlayingDatum> PlayingData { get; set; }
    }
}
