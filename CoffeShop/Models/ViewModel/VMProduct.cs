using System.ComponentModel.DataAnnotations;

namespace CoffeShop.Models.ViewModel
{
    public class VMProduct
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        public string? Detail { get; set; }

        [Required]
        public string? ImageUrl { get; set; }

        [Required]
        [Range(0.01, 100000000)]
        public decimal Price { get; set; }

        [Required]
        public string? IsTrendingProduct { get; set; } // "true" hoặc "false"
    }
}
