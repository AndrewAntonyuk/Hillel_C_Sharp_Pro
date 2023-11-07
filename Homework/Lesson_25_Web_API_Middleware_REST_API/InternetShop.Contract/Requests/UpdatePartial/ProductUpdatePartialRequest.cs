using System.ComponentModel.DataAnnotations;

namespace InternetShop.Contract.Requests.UpdatePartial
{
    public class ProductUpdatePartialRequest
    {
        [Required]
        public int Id { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }

        public int CategoryId { get; set; }
    }
}
