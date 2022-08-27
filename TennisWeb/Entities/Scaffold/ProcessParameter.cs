using System;
using System.Collections.Generic;

#nullable disable

namespace UI
{
    public partial class ProcessParameter
    {
        public long Id { get; set; }
        public long? StreamId { get; set; }
        public long? Limit { get; set; }

        public virtual Process IdNavigation { get; set; }
        public virtual Stream Stream { get; set; }
    }
}
