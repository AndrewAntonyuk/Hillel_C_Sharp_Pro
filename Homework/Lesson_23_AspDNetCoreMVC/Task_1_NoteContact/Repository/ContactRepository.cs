using Task_1_NoteContact.Data;
using Task_1_NoteContact.Interfaces;
using Task_1_NoteContact.Models;

namespace Task_1_NoteContact.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void Create(Contact entity)
        {
            var existEntity = GetById(entity.Id);

            if (existEntity != null)
            {
                throw new ArgumentException("Object with id " + entity.Id + " already exist!");
            }

            _context.Contacts.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var existEntity = GetById(id);

            if (existEntity == null)
            {
                throw new ArgumentException("Can't find object with id " + id);
            }

            _context.Contacts.Remove(existEntity);
            _context.SaveChanges();
        }

        public ICollection<Contact> GetAll()
        {
            return _context.Contacts.ToList();
        }

        public Contact? GetById(int? id)
        {
            return _context.Contacts.FirstOrDefault(o => o.Id == id);
        }

        public void Update(Contact entity)
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
