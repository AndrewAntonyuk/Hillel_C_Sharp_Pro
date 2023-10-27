namespace Task_12_Cinema.Models
{
    public class Session
    {
        public int Id { get; set; }

        public DateTime EventDateTime { get; set; }

        public int FilmId { get; set; }

        public virtual Film? Film { get; set; }
    }
}
