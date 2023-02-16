using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace jwtapp.front.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage ="Kullanıcı adı gereklidir.")]
        public string? Username { get; set; }
        [Required(ErrorMessage ="Şifre gereklidir.")]
        public string? Password { get; set; }
    }
}