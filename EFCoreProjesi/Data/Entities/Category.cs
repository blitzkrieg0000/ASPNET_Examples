using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreProjesi.Data.Entities {

    [Table(name: "Category", Schema = "c")]
    public class Category {

        [Column("category_id")]
        public int Id { get; set; }

        [Required]
        //[MaxLength(100)]
        [Column("category_name", TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        public List<ProductCategory> ProductCategories { get; set; } //Navigation Property
    }
}