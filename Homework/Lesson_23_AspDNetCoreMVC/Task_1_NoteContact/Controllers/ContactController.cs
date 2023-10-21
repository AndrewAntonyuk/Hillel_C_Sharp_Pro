using Microsoft.AspNetCore.Mvc;
using Task_1_NoteContact.Interfaces;
using Task_1_NoteContact.Models;

namespace Task_1_NoteContact.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _repository;

        public ContactController(IContactRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            ICollection<Contact> contacts = _repository.GetAll();

            return View(contacts);
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contact entity) 
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
        public IActionResult Edit(Contact entity)
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
        public IActionResult DeleteContact(int? id)
        {
            var existEntity = CheckExistEntity(id);

            if (existEntity == null)
            {
                return NotFound();
            }

            _repository.Delete(id);

            return RedirectToAction("Index");
        }

        private Contact? CheckExistEntity(int? id)
        {
            if (id == null || id <= 0)
            {
                return null;
            }

            return _repository.GetById(id);
        }
    }
}
