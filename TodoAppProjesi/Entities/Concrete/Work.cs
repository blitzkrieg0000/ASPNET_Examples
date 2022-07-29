using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Concrete {
    public class Work {

        public int Id { get; set; }
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }

    }
}