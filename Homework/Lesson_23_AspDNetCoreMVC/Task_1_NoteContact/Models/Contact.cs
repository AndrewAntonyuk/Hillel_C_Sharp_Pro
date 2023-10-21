using System.ComponentModel.DataAnnotations;

namespace Task_1_NoteContact.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Phone]
        public string? PhoneMain { get; set; }

        [Phone]
        public string? PhoneSeccond { get; set;}

        [EmailAddress]
        public string? EmailAddress { get; set;}

        public string? Description { get; set;}
    }
}
