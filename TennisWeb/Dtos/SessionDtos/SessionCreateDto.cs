using System;
using Dtos.Interface;

namespace Dtos.SessionDtos {
    public class SessionCreateDto : IDto {

        public string Name { get; set; }
        public long SessionId { get; set; }
        public bool? IsActivated { get; set; }

        public int StreamId { get; set; }
        public int AOSTypeId { get; set; }
        public int PlayerId { get; set; }
        public int CourtId { get; set; }
        public int Limit { get; set; }
        public bool? Force { get; set; }
        public DateTime? SaveDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
