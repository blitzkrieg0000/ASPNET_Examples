using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreProjesi.Data.Entities {
    public class Product {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public List<SaleHistory> SaleHistories { get; set; } //Navigation Property
        public List<ProductCategory> ProductCategories { get; set; } //Navigation Property
        public ProductDetail ProductDetail { get; set; } //Navigation Property
        
        
        public DateTime CreatedTime { get; set; }

    }
}