using System;
using Dtos.Interface;

namespace Dtos.TennisDtos {
    public class PlayingDatumListDto : IDto {
        public long Id { get; set; }
        public string PlayerName { get; set; }
        public string CourtName { get; set; }
        public string AosTypeName { get; set; }
        public long StreamName { get; set; }
        public double? Score { get; set; }
        public byte[] BallPositionArea { get; set; }
        public byte[] PlayerPositionArea { get; set; }
        public byte[] BallFallArray { get; set; }
        public DateTime? SaveDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}