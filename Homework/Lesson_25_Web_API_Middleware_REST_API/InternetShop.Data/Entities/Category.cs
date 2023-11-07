using System.ComponentModel.DataAnnotations;

namespace InternetShop.Data.Entities
{
    public class Category
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = "Unnamed category";

        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
