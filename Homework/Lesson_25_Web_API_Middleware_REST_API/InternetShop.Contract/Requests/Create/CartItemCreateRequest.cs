using System.ComponentModel.DataAnnotations;

namespace InternetShop.Contract.Requests.Create
{
    public class CartItemUpdateRequest
    {
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}
