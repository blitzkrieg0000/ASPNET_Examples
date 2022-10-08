using System;

namespace Entities.Concrete {
    public class PlayingDatum : BaseEntity {
        public long Id { get; set; }
        public long PlayerId { get; set; }
        public long CourtId { get; set; }
        public long AosTypeId { get; set; }
        public long StreamId { get; set; }
        public double? Score { get; set; }
        public string BallPositionArea { get; set; }
        public string PlayerPositionArea { get; set; }
        public string BallFallArray { get; set; }
        public DateTime? SaveDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual AosType AosType { get; set; }
        public virtual Court Court { get; set; }
        public virtual Player Player { get; set; }
        public virtual Stream Stream { get; set; }
    }
}