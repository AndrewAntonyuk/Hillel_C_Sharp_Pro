using System.ComponentModel.DataAnnotations;

namespace InternetShop.Data.Entities
{
    public class CartItem
    {
        [Required]
        [Key]
        public int Id { get; set; }        

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int ProductId { get; set; }

        public virtual Product? Product { get; set; }
    }
}
