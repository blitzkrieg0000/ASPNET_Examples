using System;

namespace Dtos.PlayerDtos {
    public class PlayerCreateDto {
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public long? GenderId { get; set; }
        public DateTime SaveDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}