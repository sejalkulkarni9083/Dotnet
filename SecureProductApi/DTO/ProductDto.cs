using System.ComponentModel.DataAnnotations;

namespace SecureProductApi.DTO
{
    public class ProductDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Range(1, 100000)]
        public decimal Price { get; set; }
    }
}
