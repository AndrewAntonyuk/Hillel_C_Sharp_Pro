using Microsoft.EntityFrameworkCore;
using Task_12_Cinema.Data;
using Task_12_Cinema.Models;
using Task_12_Cinema.Repositories.Interfaces;

namespace Task_12_Cinema.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly AppDbContext _context;

        public FilmRepository(AppDbContext context)
        {
            _context = context;
        }

        public Film Create(Film entity)
        {
            _context.Films.Add(entity);
            _context.SaveChanges();

            return GetById(entity.Id);
        }

        public void Delete(int id)
        {
            var existEntity = GetById(id);

            if (existEntity != null)
            {
                _context.Films.Remove(existEntity);
                _context.SaveChanges();
            }
        }

        public Film Edit(Film entity)
        {
            var existEntity = GetById(entity.Id);

            _context.Films.Entry(existEntity).CurrentValues.SetValues(entity);
            _context.SaveChanges();

            return GetById(entity.Id);
        }

        public IEnumerable<Film> GetAll()
        {
            return _context.Films.AsNoTracking().Include(x => x.Genre)
                                                .Include(x => x.Director)
                                                .Include(x => x.Sessions)
                                                .ToList();
        }

        public Film GetById(int id)
        {
            return _context.Films.AsNoTracking().Include(x => x.Genre)
                                                .Include(x => x.Director)
                                                .Include(x => x.Sessions)
                                                .FirstOrDefault(x => x.Id == id);
        }
    }
}
