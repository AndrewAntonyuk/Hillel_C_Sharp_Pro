using System.ComponentModel.DataAnnotations;

namespace InternetShop.Contract.Requests.Update
{
    public class ProductUpdateRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
