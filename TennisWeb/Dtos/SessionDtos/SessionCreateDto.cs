using System;
using Dtos.Interface;

namespace Dtos.SessionDtos {
    public class SessionCreateDto : IDto {
        public string Name { get; set; }
        public DateTime? SaveDate { get; set; }
        public bool? IsActivated { get; set; }
        public bool IsDeleted { get; set; }
    }
}