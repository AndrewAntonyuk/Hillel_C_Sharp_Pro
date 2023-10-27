using Microsoft.EntityFrameworkCore;
using Task_12_Cinema.Data;
using Task_12_Cinema.Models;
using Task_12_Cinema.Repositories.Interfaces;

namespace Task_12_Cinema.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly AppDbContext _context;

        public DirectorRepository(AppDbContext context)
        {
            _context = context;
        }

        public Director Create(Director entity)
        {
            _context.Directors.Add(entity);
            _context.SaveChanges();

            return GetById(entity.Id);
        }

        public void Delete(int id)
        {
            var existEntity = GetById(id);

            if (existEntity != null)
            {
                _context.Directors.Remove(existEntity);
                _context.SaveChanges();
            }
        }

        public Director Edit(Director entity)
        {
            var existEntity = GetById(entity.Id);

            _context.Directors.Entry(existEntity).CurrentValues.SetValues(entity);
            _context.SaveChanges();

            return GetById(entity.Id);
        }

        public IEnumerable<Director> GetAll()
        {
            return _context.Directors.AsNoTracking()
                                     //.Include(x => x.Films)
                                     .ToList();
        }

        public Director GetById(int id)
        {
            return _context.Directors.AsNoTracking()
                                     .Include(x => x.Films)
                                     .FirstOrDefault(x => x.Id == id);
        }
    }
}
