using System.ComponentModel.DataAnnotations;

namespace InternetShop.Contract.Responses
{
    public class CartItemResponse
    {
        public int Id { get; set; }        

        public int Quantity { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public virtual ProductResponse? Product { get; set; }
    }
}
