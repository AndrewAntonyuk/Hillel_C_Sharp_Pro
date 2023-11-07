using System.ComponentModel.DataAnnotations;

namespace InternetShop.Contract.Responses
{
    public class OrderResponse
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; } 

        public int CustomerId { get; set; }

        public virtual IEnumerable<ProductResponse> Products { get; set; } = new List<ProductResponse>();
    }
}
