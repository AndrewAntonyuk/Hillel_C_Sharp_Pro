namespace Task_12_Cinema.Models
{
    public class Film
    {
        public int Id { get; set; }

        public string Name { get; set; } = "Unnamed";

        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        public int DirectorId { get; set; }

        public virtual Director Director { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
