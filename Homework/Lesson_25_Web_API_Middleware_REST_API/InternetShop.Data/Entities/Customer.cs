using System.ComponentModel.DataAnnotations;

namespace InternetShop.Data.Entities
{
    public class Customer
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = "Unnamed";

        [StringLength(50)]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "mail@mail.com";

        [Phone]
        public string Phone { get; set; } = "0987654321";

        public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();

        public virtual IEnumerable<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
