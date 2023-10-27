namespace Task_12_Cinema.Models
{
    public class Director
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = "Unnamed";

        public string? MiddleName { get; set;  }

        public string? LastName { get; set; }

        public string? ShortBio {  get; set; }

        public virtual ICollection<Film> Films { get; set; } = new List<Film>();
    }
}
