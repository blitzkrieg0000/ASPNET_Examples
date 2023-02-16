using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace jwtapp.front.Models
{
    public class UpdateProductModel
    {
        public int Id { get; set; }
         [Required(ErrorMessage ="Ürün Adi Giriniz")]
        public string? Name { get; set; }
        [Required(ErrorMessage ="Ürün Stok Adeti Giriniz")]
        public int Stock { get; set; }
        [Required(ErrorMessage ="Ürün Fiyati Giriniz")]
        public decimal Price { get; set; }
        [Required(ErrorMessage ="Kategori Seçiniz")]
        public int CategoryId { get; set; }
        public SelectList? Categories { get; set; }
    }
}