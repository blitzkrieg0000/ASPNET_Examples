using System;
using Dtos.Interface;

namespace Dtos.PlayerDtos {
    public class PlayerListRelatedDto : IDto{
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public string GenderName { get; set; }
        public DateTime SaveDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}