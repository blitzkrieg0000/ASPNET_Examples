using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dtos.ProcessDtos {
    public class ProcessCreateDto {
        public string Name { get; set; }
        public long SessionId { get; set; }
        public long ProcessParameterId { get; set; }
        public long ProcessResponseId { get; set; }
        public DateTime? SaveDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }
    }
}