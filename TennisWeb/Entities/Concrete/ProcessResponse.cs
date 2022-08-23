using System;
using System.Collections.Generic;
using UI.Entities.Concrete;

namespace Entities.Concrete {
    public class ProcessResponse {
        public ProcessResponse()
        {
            Processes = new HashSet<Process>();
        }

        public long Id { get; set; }
        public string Description { get; set; }
        public string Canvas { get; set; }
        public string BallPositionArray { get; set; }
        public string BallFallArray { get; set; }
        public string PlayerPositionArray { get; set; }
        public DateTime? SaveDate { get; set; }
        public bool? IsDeleted { get; set; }

        public ICollection<Process> Processes { get; set; }
    }
}