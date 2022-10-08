using System;
using Dtos.Interface;

namespace Dtos.PlayingDatumDtos {
    public class PlayingDatumListDto : IDto {
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
    }
}