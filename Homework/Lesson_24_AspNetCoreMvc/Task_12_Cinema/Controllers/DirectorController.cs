using Microsoft.AspNetCore.Mvc;
using Task_12_Cinema.Models;
using Task_12_Cinema.Repositories.Interfaces;
using Task_12_Cinema.ViewModels;

namespace Task_12_Cinema.Controllers
{
    public class DirectorController : Controller 
    {
        private readonly IDirectorRepository _repository;

        public DirectorController(IDirectorRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DirectorViewModel director)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(new Director()
                { 
                    FirstName = director.FirstName,
                    MiddleName = director.MiddleName,
                    LastName = director.LastName,
                    ShortBio = director.ShortBio
                });

                return View(director);
            }

            return View(ModelState);
        }
    }
}
