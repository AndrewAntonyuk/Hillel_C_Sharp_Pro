using System.ComponentModel.DataAnnotations;

namespace InternetShop.Contract.Requests.UpdatePartial
{
    public class CartItemUpdatePartialRequest
    {
        [Required]
        public int Id { get; set; }

        public int Quantity { get; set; }
    }
}
