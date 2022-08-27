using System;
using System.Collections.Generic;

#nullable disable

namespace UI
{
    public partial class Gender
    {
        public Gender()
        {
            Players = new HashSet<Player>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
