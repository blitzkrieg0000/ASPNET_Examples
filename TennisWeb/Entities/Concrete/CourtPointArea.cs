using System;
using System.Collections.Generic;
using Entities.Concrete;

#nullable disable

namespace UI.Entities.Concrete {
    public class CourtPointArea : BaseEntity{
        public CourtPointArea() {
            Aostypes = new HashSet<Aostype>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public byte[] AreaArray { get; set; }
        public DateTime SaveDate { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Aostype> Aostypes { get; set; }
    }
}
