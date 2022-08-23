using System;
using Dtos.Interface;

namespace Dtos.PlayingDatumDtos {
    public class PlayingDatumRelatedListDto : IDto {
        public long Id { get; set; }
        public string PlayerName { get; set; }
        public string CourtName { get; set; }
        public string AosTypeName { get; set; }
        public long StreamName { get; set; }
        public double? Score { get; set; }
        public string BallPositionArea { get; set; }
        public string PlayerPositionArea { get; set; }
        public string BallFallArray { get; set; }
        public DateTime? SaveDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}