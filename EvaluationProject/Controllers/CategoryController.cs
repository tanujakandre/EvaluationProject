using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.DataAccess.Repositories;
using Web.DataAccess.Repositories.IRepository;
using Web.Models;

namespace EvaluationProject.Controllers
{
    
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unit;
        public CategoryController(UnitOfWork unit)
        {
            _unit = unit;
        }
        public IActionResult Index()
        {
            var categories = _unit.Category.GetAll();
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _unit.Category.Add(obj);
                _unit.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update(int id)
        {
            var category = _unit.Category.GetById(id);
            if(id == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Update(Category obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _unit.Category.Update(obj);
                _unit.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var category = _unit.Category.GetById(id);
            if (id == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _unit.Category.Remove(obj);
                _unit.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}

        

