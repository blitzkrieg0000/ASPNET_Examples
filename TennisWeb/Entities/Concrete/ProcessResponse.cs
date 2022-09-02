using System;

namespace Entities.Concrete {
    public class ProcessResponse : BaseEntity {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Canvas { get; set; }
        public string BallPositionArray { get; set; }
        public string BallFallArray { get; set; }
        public string PlayerPositionArray { get; set; }
        public DateTime? SaveDate { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Process IdNavigation { get; set; }
    }
}