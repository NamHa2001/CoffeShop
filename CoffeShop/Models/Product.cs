using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Detail { get; set; }
        public string? ImageUrl { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public bool IsTrendingProduct { get; set; }
    }
}
