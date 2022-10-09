namespace TennisWeb6.Core.Domains {
    public class Category {
        public Category() {
            Products = new List<Product>();
        }
        public int Id { get; set; }
        public string? Definition { get; set; }
        public List<Product> Products { get; set; }
    }
}