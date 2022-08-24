using System;

namespace Entities.Concrete {
    public class Process : BaseEntity {
        public long Id { get; set; }
        public string Name { get; set; }
        public long SessionId { get; set; }
        public string ProcessParameterId { get; set; }
        public string ProcessResponseId { get; set; }
        public DateTime? SaveDate { get; set; }
        public bool? IsCompleted { get; set; }
        public bool? IsDeleted { get; set; }

        public ProcessParameter ProcessParameter { get; set; }
        public ProcessResponse ProcessResponse { get; set; }
        public Session Session { get; set; }
    }
}
