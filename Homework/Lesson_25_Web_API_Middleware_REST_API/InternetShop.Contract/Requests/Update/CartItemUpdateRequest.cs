using System.ComponentModel.DataAnnotations;

namespace InternetShop.Contract.Requests.Update
{
    public class CartItemUpdateRequest
    {
        [Required]
        public int Id { get; set; }        

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}
