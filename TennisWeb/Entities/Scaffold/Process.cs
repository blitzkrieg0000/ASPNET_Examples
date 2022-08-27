using System;
using System.Collections.Generic;

#nullable disable

namespace UI
{
    public partial class Process
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? SessionId { get; set; }
        public DateTime? SaveDate { get; set; }
        public bool? IsCompleted { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Session Session { get; set; }
        public virtual ProcessParameter ProcessParameter { get; set; }
        public virtual ProcessResponse ProcessResponse { get; set; }
    }
}
