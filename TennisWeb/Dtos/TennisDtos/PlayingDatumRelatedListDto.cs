using System;
using Dtos.Interface;

namespace Dtos.TennisDtos {
    public class PlayingDatumRelatedListDto : IDto {
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

    }
}