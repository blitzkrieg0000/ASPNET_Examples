using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Concrete {
    public class ProcessParameter {
        public long Id { get; set; }
        public long? StreamId { get; set; }
        public long? Limit { get; set; }

        public Process IdNavigation { get; set; }
        public Stream Stream { get; set; }
    }
}