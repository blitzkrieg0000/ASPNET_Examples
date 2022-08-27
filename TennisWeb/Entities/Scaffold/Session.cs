using System;
using System.Collections.Generic;

#nullable disable

namespace UI
{
    public partial class Session
    {
        public Session()
        {
            Processes = new HashSet<Process>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? SaveDate { get; set; }
        public bool? IsActivated { get; set; }
        public bool IsDeleted { get; set; }

        public virtual SessionParameter SessionParameter { get; set; }
        public virtual ICollection<Process> Processes { get; set; }
    }
}
