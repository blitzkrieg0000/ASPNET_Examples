using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IdentityProjesi.Data.Entities {
    public class AppUser : IdentityUser<int> {

        public string ImagePath { get; set; }
        public string Gender { get; set; }

    }
}