using System;
using Dtos.Interface;

namespace Dtos.SessionDtos {
    public class SessionListDto : IDto {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? SaveDate { get; set; }
        public bool? IsActivated { get; set; }
        public bool IsDeleted { get; set; }
    }
}