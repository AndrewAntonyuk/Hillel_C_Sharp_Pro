using Microsoft.AspNetCore.Mvc;
using Task_12_Cinema.Repositories.Interfaces;

namespace Task_12_Cinema.Controllers
{
    public class FilmController : Controller
    {
        private readonly IFilmRepository _repository;

        public FilmController(IFilmRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }
    }
}
