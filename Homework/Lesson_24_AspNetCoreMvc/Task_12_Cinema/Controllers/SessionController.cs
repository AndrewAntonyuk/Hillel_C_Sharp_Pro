using Microsoft.AspNetCore.Mvc;
using Task_12_Cinema.Repositories.Interfaces;

namespace Task_12_Cinema.Controllers
{
    public class SessionController : Controller
    {
        private readonly ISessionRepository _repositorySession;
        private readonly IFilmRepository _repositoryFilm;

        public SessionController(ISessionRepository repositorySession, IFilmRepository repositoryFilm)
        {
            _repositorySession = repositorySession;
            _repositoryFilm = repositoryFilm;
        }

        public IActionResult Index()
        {
            return View(_repositorySession.GetAll());
        }

        public IActionResult Detail(int id)
        {
            var entitySession = _repositorySession.GetById(id);
            
            if (entitySession == null)
            {
                return View("Doesn'tExist");
            }

            var entityFilm = _repositoryFilm.GetById(entitySession.FilmId);

            return View(entityFilm);
        }
    }
}
