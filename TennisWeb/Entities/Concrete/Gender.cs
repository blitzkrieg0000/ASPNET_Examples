using System.Collections.Generic;

namespace Entities.Concrete {
    public class Gender : BaseEntity {
        public Gender() {
            Players = new HashSet<Player>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
