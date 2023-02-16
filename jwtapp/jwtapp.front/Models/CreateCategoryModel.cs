using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace jwtapp.front.Models
{
    public class CreateCategoryModel
    {
        [Required(ErrorMessage ="Kategori Adı Gereklidir.")]
        public string? Definition { get; set; }
    }
}