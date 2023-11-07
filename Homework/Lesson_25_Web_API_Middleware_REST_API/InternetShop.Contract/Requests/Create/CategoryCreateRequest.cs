using System.ComponentModel.DataAnnotations;

namespace InternetShop.Contract.Requests.Create
{
    public class CategoryCreateRequest
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = "Unnamed category";

        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
