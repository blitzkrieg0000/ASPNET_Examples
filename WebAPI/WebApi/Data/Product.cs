using System;

namespace WebApi.Data {
    public class Product {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ImagePath { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}