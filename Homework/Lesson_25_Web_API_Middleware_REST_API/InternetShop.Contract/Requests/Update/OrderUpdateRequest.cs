using System.ComponentModel.DataAnnotations;

namespace InternetShop.Contract.Requests.Update
{
    public class OrderUpdateRequest
    {
        [Required]
        public int Id { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public int CustomerId { get; set; }
    }
}
