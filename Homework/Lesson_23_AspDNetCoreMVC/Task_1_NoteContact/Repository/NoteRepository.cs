using Task_1_NoteContact.Data;
using Task_1_NoteContact.Interfaces;
using Task_1_NoteContact.Models;

namespace Task_1_NoteContact.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly AppDbContext _context;

        public NoteRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void Create(Note entity)
        {
            var existEntity = GetById(entity.Id);

            if (existEntity != null)
            {
                throw new ArgumentException("Object with id " + entity.Id + " already exist!");
            }

            _context.Notes.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var existEntity = GetById(id);

            if (existEntity == null)
            {
                throw new ArgumentException("Can't find object with id " + id);
            }

            _context.Notes.Remove(existEntity);
            _context.SaveChanges();
        }

        public ICollection<Note> GetAll()
        {
            return _context.Notes.ToList();
        }

        public Note? GetById(int? id)
        {
            return _context.Notes.FirstOrDefault(o => o.Id == id);
        }

        public void Update(Note entity)
        {
            var existEntity = GetById(entity.Id);

            if (existEntity == null)
            {
                throw new ArgumentException("Can't find object with id " + entity.Id);
            }

            _context.Entry(existEntity).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }
    }
}
