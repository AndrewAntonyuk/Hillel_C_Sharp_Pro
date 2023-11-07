using System.ComponentModel.DataAnnotations;

namespace InternetShop.Data.Entities
{
    public class Product
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = "Unnamed product";

        [StringLength(200)]
        public string? Description { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Required]
        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }
    }
}
