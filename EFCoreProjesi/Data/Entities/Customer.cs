using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreProjesi.Data.Entities {
    public class Customer {
        
        //[Key]
        public int Number { get; set; }

        public string Name { get; set; }
        
        public string Surname { get; set; }

    }
}