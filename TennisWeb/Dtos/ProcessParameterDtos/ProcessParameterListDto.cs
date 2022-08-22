using System;

namespace Dtos.ProcessParameterDtos {
    public class ProcessParameterListDto {
        public long Id { get; set; }
        public string Name { get; set; }
        public long StreamId { get; set; }
        public long AosTypeId { get; set; }
        public long PlayerId { get; set; }
        public long CourtId { get; set; }
        public long Limit { get; set; }
        public bool Force { get; set; }
        public DateTime SaveDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}