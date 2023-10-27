using System.ComponentModel.DataAnnotations;

namespace Task_12_Cinema.ViewModels
{
    public class DirectorViewModel
    {
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; } = "Unnamed";

        [MaxLength(30)]
        public string? MiddleName { get; set; }

        [MaxLength(30)]
        public string? LastName { get; set; }

        [MaxLength(1500)]
        public string? ShortBio { get; set; }
    }
}
