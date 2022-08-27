using System;
using System.Collections.Generic;

#nullable disable

namespace UI
{
    public partial class CourtPointArea
    {
        public CourtPointArea()
        {
            Aostypes = new HashSet<Aostype>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public byte[] AreaArray { get; set; }
        public DateTime SaveDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Aostype> Aostypes { get; set; }
    }
}
