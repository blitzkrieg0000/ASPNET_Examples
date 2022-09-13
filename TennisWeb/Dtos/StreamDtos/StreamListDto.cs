using System;
using Dtos.Interface;

namespace Dtos.StreamDtos {
    public class StreamListDto : IDto {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }
        public string CourtLineArray { get; set; }
        public DateTime SaveDate { get; set; }
        public bool? IsActivated { get; set; }
        public bool? IsDeleted { get; set; }
        public bool IsVideo { get; set; }
    }
}