using System.Collections.Generic;
using Entities.Concrete;
using UI.Entities.Concrete;

#nullable disable

namespace UI.Entities.Concrete {
    public class Gender : BaseEntity {
        public Gender() {
            Players = new HashSet<Player>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
