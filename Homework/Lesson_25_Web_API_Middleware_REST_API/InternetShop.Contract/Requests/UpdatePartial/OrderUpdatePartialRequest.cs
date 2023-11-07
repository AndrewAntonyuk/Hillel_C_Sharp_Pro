using System.ComponentModel.DataAnnotations;

namespace InternetShop.Contract.Requests.UpdatePartial
{
    public class OrderUpdatePartialRequest
    {
        [Required]
        public int Id { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }
    }
}
