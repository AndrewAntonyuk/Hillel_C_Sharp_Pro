using System.ComponentModel.DataAnnotations;

namespace InternetShop.Contract.Responses
{
    public class ProductResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; } 

        public int CategoryId { get; set; }

        public virtual CategoryResponse? Category { get; set; }
    }
}
