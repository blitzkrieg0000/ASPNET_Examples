using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProjesi.Models {
    public class UserAdminCreateModel {

        [Required(ErrorMessage="Kullanıcı Adı Gereklidir.")]
        public string Username { get; set; }
        
        [Required(ErrorMessage="Email Adresi Gereklidir.")]
        public string Email { get; set; }

        [Required(ErrorMessage="Cinsiyet Gereklidir.")]
        public string Gender { get; set; }
    }
}