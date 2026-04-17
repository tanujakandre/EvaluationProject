using Microsoft.AspNetCore.Mvc;
using Web.DataAccess.Repositories;
using Web.DataAccess.Repositories.IRepository;
using Web.Models;

namespace EvaluationProject.Controllers
{
    public class TaskController : Controller
    {
        private readonly IUnitOfWork _unit;
        public TaskController(UnitOfWork unit)
        {
            _unit = unit;

        }
        public IActionResult Index()
        {
            var tasks = _unit.Task.GetAll();
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskManager obj)
        {
            if (ModelState.IsValid)
            {
                _unit.Task.Add(obj);
                _unit.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update(int id)
        {
            var task = _unit.Task.GetById(id);
            if (id == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        public IActionResult Update(TaskManager obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _unit.Task.Update(obj);
                _unit.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var task = _unit.Task.GetById(id);
            if (id == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(TaskManager obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _unit.Task.Remove(obj);
                _unit.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}




