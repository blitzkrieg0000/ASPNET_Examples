using System;

namespace Dtos.ProcessDtos {
    public class ProcessCreateDto {
        public string Name { get; set; }
        public long SessionId { get; set; }
        public string ProcessParameterId { get; set; }
        public string ProcessResponseId { get; set; }
        public DateTime? SaveDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }
    }
}