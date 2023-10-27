using Microsoft.EntityFrameworkCore;
using Task_12_Cinema.Data;
using Task_12_Cinema.Models;
using Task_12_Cinema.Repositories.Interfaces;

namespace Task_12_Cinema.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly AppDbContext _context;

        public SessionRepository(AppDbContext context)
        {
            _context = context;
        }

        public Session Create(Session entity)
        {
            _context.Sessions.Add(entity);
            _context.SaveChanges();

            return GetById(entity.Id);
        }

        public void Delete(int id)
        {
            var existEntity = GetById(id);

            if (existEntity != null)
            {
                _context.Sessions.Remove(existEntity);
                _context.SaveChanges();
            }
        }

        public Session Edit(Session entity)
        {
            var existEntity = GetById(entity.Id);

            _context.Sessions.Entry(existEntity).CurrentValues.SetValues(entity);
            _context.SaveChanges();

            return GetById(entity.Id);
        }

        public IEnumerable<Session> GetAll()
        {
            return _context.Sessions.AsNoTracking()
                                    .Include(x => x.Film)
                                    .Include(x => x.Film.Genre)
                                    .Include(x => x.Film.Director)
                                    .OrderBy(x => x.EventDateTime)
                                    .ToList();
        }

        public Session GetById(int id)
        {
            return _context.Sessions.AsNoTracking().Include(x => x.Film)
                                                   .Include(x => x.Film.Genre)
                                                   .Include(x => x.Film.Director)
                                                   .FirstOrDefault(x => x.Id == id);
        }
    }
}
