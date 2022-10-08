using System;
using Dtos.Interface;

namespace Dtos.StreamDtos {
    public class StreamCreateDto : IDto{
        public string Name { get; set; }
        public string Source { get; set; }
        public string CourtLineArray { get; set; }
        public DateTime SaveDate { get; set; }
        public bool? IsActivated { get; set; }
        public bool? IsDeleted { get; set; }
        public bool IsVideo { get; set; }

    }
}