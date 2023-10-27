using System.ComponentModel.DataAnnotations;
using Task_12_Cinema.Models;

namespace Task_12_Cinema.ViewModels
{
    public class FilmViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = "Unnamed";

        [Required]
        public int GenreId { get; set; }

        [Required]
        public int DirectorId { get; set; }

        [MaxLength(1500)]
        public string? Description { get; set; }
    }
}
