using System.ComponentModel.DataAnnotations;

namespace InternetShop.Data.Entities
{
    public class Order
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Required]
        public int CustomerId { get; set; }

        public virtual IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
