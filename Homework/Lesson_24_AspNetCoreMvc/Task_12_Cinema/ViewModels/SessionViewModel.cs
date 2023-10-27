using System.ComponentModel.DataAnnotations;

namespace Task_12_Cinema.ViewModels
{
    public class SessionViewModel
    {
        [Required]
        public DateTime EventDateTime { get; set; }

        [Required]
        public int FilmId { get; set; }
    }
}
