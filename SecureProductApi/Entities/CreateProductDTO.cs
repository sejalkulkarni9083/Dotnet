using System.ComponentModel.DataAnnotations;

namespace SecureProductApi.DTOs
{
    public class CreateProductDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Range(1, 100000)]
        public decimal Price { get; set; }
    }
}
