using System.ComponentModel.DataAnnotations;

namespace InternetShop.Contract.Requests.UpdatePartial
{
    public class CustomerUpdatePartialRequest
    {
        [Required]
        public int Id { get; set; }

        [StringLength(50)]
        public string? FirstName { get; set; } 

        [StringLength(50)]
        public string? LastName { get; set; }

        [EmailAddress]
        public string? Email { get; set; } 

        [Phone]
        public string? Phone { get; set; } 
    }
}
