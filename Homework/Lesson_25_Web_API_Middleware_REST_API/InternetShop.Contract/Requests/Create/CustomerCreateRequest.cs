using System.ComponentModel.DataAnnotations;

namespace InternetShop.Contract.Requests.Create
{
    public class CustomerCreateRequest
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = "Unnamed";

        [StringLength(50)]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "mail@mail.com";

        [Phone]
        public string Phone { get; set; } = "0987654321";
    }
}
