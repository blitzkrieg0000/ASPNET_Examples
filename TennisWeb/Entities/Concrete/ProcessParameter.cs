using System;
using System.Collections.Generic;
using Entities.Concrete;

#nullable disable

namespace UI.Entities.Concrete {
    public class ProcessParameter : BaseEntity{
        public ProcessParameter() {
            Processes = new HashSet<Process>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long? StreamId { get; set; }
        public long? AosTypeId { get; set; }
        public long? PlayerId { get; set; }
        public long? CourtId { get; set; }
        public long? Limit { get; set; }
        public bool? Force { get; set; }
        public DateTime SaveDate { get; set; }
        public bool IsDeleted { get; set; }

        public AosType AosType { get; set; }
        public Court Court { get; set; }
        public Player Player { get; set; }
        public Stream Stream { get; set; }
        public ICollection<Process> Processes { get; set; }
    }
}
