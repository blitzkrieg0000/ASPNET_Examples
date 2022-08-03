using System;
using System.Collections.Generic;

#nullable disable

namespace UI.Entities.Concrete
{
    public partial class Court
    {
        public Court()
        {
            PlayingData = new HashSet<PlayingDatum>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long CourtTypeId { get; set; }
        public DateTime SaveDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual CourtType CourtType { get; set; }
        public virtual ICollection<PlayingDatum> PlayingData { get; set; }
    }
}
