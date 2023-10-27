using System.ComponentModel.DataAnnotations;

namespace Task_12_Cinema.ViewModels
{
    public class GenreViewModel
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
