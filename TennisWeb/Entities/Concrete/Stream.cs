using System;
using System.Collections.Generic;

namespace Entities.Concrete {
    public class Stream : BaseEntity {
        public Stream() {
            PlayingData = new HashSet<PlayingDatum>();
            ProcessParameters = new HashSet<ProcessParameter>();
            SessionParameters = new HashSet<SessionParameter>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }
        public byte[] CourtLineArray { get; set; }
        public string KafkaTopicName { get; set; }
        public DateTime SaveDate { get; set; }
        public bool? IsActivated { get; set; }
        public bool? IsDeleted { get; set; }

        public ICollection<PlayingDatum> PlayingData { get; set; }
        public ICollection<ProcessParameter> ProcessParameters { get; set; }
        public ICollection<SessionParameter> SessionParameters { get; set; }
    }
}
