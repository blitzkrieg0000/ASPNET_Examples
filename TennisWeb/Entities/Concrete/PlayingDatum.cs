using System;
using Entities.Concrete;

#nullable disable

namespace UI.Entities.Concrete {
    public class PlayingDatum : BaseEntity {
        public long Id { get; set; }
        public long PlayerId { get; set; }
        public long CourtId { get; set; }
        public long AosTypeId { get; set; }
        public long StreamId { get; set; }
        public double? Score { get; set; }
        public byte[] BallPositionArea { get; set; }
        public byte[] PlayerPositionArea { get; set; }
        public byte[] BallFallArray { get; set; }
        public DateTime? SaveDate { get; set; }
        public bool IsDeleted { get; set; }

        public AosType AosType { get; set; }
        public Court Court { get; set; }
        public Player Player { get; set; }
        public Stream Stream { get; set; }
    }
}