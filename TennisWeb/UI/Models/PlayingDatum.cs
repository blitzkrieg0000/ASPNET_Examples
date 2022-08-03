using System;
using System.Collections.Generic;

#nullable disable

namespace UI.Models {
    public partial class PlayingDatum {
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

        public virtual Aostype AosType { get; set; }
        public virtual Court Court { get; set; }
        public virtual Player Player { get; set; }
        public virtual Stream Stream { get; set; }
    }
}
