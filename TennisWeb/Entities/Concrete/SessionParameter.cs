using System;

#nullable disable

namespace Entities.Concrete {
    public class SessionParameter : BaseEntity {
        public long Id { get; set; }
        public long? StreamId { get; set; }
        public long? AosTypeId { get; set; }
        public long? PlayerId { get; set; }
        public long? CourtId { get; set; }
        public long? Limit { get; set; }
        public bool? Force { get; set; }
        public DateTime SaveDate { get; set; }
        public bool IsDeleted { get; set; }

        public AosType AosType { get; set; }
        public Court Court { get; set; }
        public Player Player { get; set; }
        public Stream Stream { get; set; }
        public Session Session { get; set; }
    }
}
