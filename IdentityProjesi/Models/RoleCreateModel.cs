using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProjesi.Models {
    public class RoleCreateModel {
        [Required(ErrorMessage = "Ad alanı gereklidir.")]
        public string Name { get; set; }
    }
}