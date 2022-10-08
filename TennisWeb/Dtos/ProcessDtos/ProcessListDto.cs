using System;
using Dtos.Interface;

namespace Dtos.ProcessDtos {
    public class ProcessListDto : IDto {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? SessionId { get; set; }
        public DateTime? SaveDate { get; set; }
        public bool? IsCompleted { get; set; }
        public bool? IsDeleted { get; set; }
    }
}