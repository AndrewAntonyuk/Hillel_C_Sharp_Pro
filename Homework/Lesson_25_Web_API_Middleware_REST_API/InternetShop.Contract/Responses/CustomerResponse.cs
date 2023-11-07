using System.ComponentModel.DataAnnotations;

namespace InternetShop.Contract.Responses
{
    public class CustomerResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; } 

        public string LastName { get; set; }

        public string Email { get; set; } 

        public string Phone { get; set; }

        public virtual IEnumerable<OrderResponse> Orders { get; set; } = new List<OrderResponse>();

        public virtual IEnumerable<CartItemResponse> CartItems { get; set; } = new List<CartItemResponse>();
    }
}
