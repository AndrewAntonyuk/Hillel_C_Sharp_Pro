using Microsoft.EntityFrameworkCore;
using Task_12_Cinema.Data;
using Task_12_Cinema.Models;
using Task_12_Cinema.Repositories.Interfaces;

namespace Task_12_Cinema.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly AppDbContext _context;

        public GenreRepository(AppDbContext context) 
        { 
            _context = context;
        }

        public Genre Create(Genre entity)
        {
            _context.Genres.Add(entity);
            _context.SaveChanges();

            return GetById(entity.Id);
        }

        public void Delete(int id)
        {
            var existEntity = GetById(id);

            if (existEntity != null)
            {
                _context.Genres.Remove(existEntity);
                _context.SaveChanges();
            }
        }

        public Genre Edit(Genre entity)
        {
            var existEntity = GetById(entity.Id);

            _context.Genres.Entry(existEntity).CurrentValues.SetValues(entity);
            _context.SaveChanges();

            return GetById(entity.Id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return _context.Genres.AsNoTracking().ToList();
        }

        public Genre GetById(int id)
        {
            return _context.Genres.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
    }
}
