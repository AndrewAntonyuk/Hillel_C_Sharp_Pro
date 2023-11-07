using System.ComponentModel.DataAnnotations;

namespace InternetShop.Contract.Requests.Create
{
    public class OrderCreateRequest
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Required]
        public int CustomerId { get; set; }
    }
}
