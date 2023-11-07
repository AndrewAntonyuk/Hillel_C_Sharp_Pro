using System.ComponentModel.DataAnnotations;

namespace InternetShop.Contract.Requests.UpdatePartial
{
    public class CategoryUpdatePartialRequest
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
