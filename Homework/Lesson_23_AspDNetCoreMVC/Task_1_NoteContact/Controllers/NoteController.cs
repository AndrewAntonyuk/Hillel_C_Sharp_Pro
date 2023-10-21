using Microsoft.AspNetCore.Mvc;
using Task_1_NoteContact.Interfaces;
using Task_1_NoteContact.Models;

namespace Task_1_NoteContact.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteRepository _repository;

        public NoteController(INoteRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            ICollection<Note> notes = _repository.GetAll();

            return View(notes);
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Note entity) 
        { 
            if(ModelState.IsValid)
            {
                _repository.Create(entity);
                return RedirectToAction("Index");
            }

            return View(entity);
        }

        public IActionResult Edit(int? id)
        {
            var existEntity = CheckExistEntity(id);

            if (existEntity == null)
            {
                return NotFound();
            }

            return View(existEntity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Note entity)
        {
            if(ModelState.IsValid)
            {
                _repository.Update(entity);
                return RedirectToAction("Index");
            }

            return View(entity);
        }

        public IActionResult Delete(int? id)
        {
            var existEntity = CheckExistEntity(id);

            if (existEntity == null)
            {
                return NotFound();
            }

            return View(existEntity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteNote(int? id)
        {
            var existEntity = CheckExistEntity(id);

            if (existEntity == null)
            {
                return NotFound();
            }

            _repository.Delete(id);

            return RedirectToAction("Index");
        }

        private Note? CheckExistEntity(int? id)
        {
            if (id == null || id <= 0)
            {
                return null;
            }

            return _repository.GetById(id);
        }
    }
}
