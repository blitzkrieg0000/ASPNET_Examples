using System;
using Dtos.Interface;

namespace Dtos.TennisDtos {
    public class PlayerListDto : IDto{

        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public char Gender { get; set; }
        public DateTime SaveDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}