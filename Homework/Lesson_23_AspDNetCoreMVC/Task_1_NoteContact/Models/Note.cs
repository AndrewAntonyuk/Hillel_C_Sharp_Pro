using System.ComponentModel.DataAnnotations;

namespace Task_1_NoteContact.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string? NoteText { get; set; }

        [Required]
        public DateTime CreateStamp { get; set; }

        public string? Tags { get; set; }
    }
}
