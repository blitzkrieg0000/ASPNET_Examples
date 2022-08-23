using System;

namespace Entities.Concrete {
    public class Process : BaseEntity {
        public long Id { get; set; }
        public string Name { get; set; }
        public long SessionId { get; set; }
        public long ProcessParameterId { get; set; }
        public long? ProcessResponseId { get; set; }
        public DateTime? SaveDate { get; set; }
        public bool? IsCompleted { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ProcessParameter ProcessParameter { get; set; }
        public virtual ProcessResponse ProcessResponse { get; set; }
        public virtual Session Session { get; set; }
    }
}
