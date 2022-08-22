using System;
using System.Collections.Generic;
using Entities.Concrete;

#nullable disable

namespace UI.Entities.Concrete {
    public class Session : BaseEntity {
        public Session() {
            Processes = new HashSet<Process>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? SaveDate { get; set; }
        public bool? IsActivated { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Process> Processes { get; set; }
    }
}
