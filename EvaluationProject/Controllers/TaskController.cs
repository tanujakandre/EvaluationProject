using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.DataAccess.Repositories;
using Web.DataAccess.Repositories.IRepository;
using Web.Models;
using Web.Models.ViewModels;

namespace EvaluationProject.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly IUnitOfWork _unit;
        public TaskController(IUnitOfWork unit)
        {
            _unit = unit;

        }
        public IActionResult Index()
        {
            var tasks = _unit.Task.GetAll(includeProperties: "Category");
            return View(tasks);
        }

        public IActionResult Create()
        {
            TaskVM vm = new TaskVM()
            {
                tasks = new TaskManager(),
                CategoryList = _unit.Category.GetAll()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(TaskVM obj)
        {
            if (ModelState.IsValid)
            {
                _unit.Task.Add(obj.tasks);
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
            TaskVM vm = new TaskVM()
            {
                tasks = task,
                CategoryList = _unit.Category.GetAll()
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Update(TaskVM obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _unit.Task.Update(obj.tasks);
                _unit.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int id)
        {
            var task = _unit.Task.Get(u=> u.Id==id,"Category");
            if (id == null)
            {
                return NotFound();
            }
            TaskVM vm = new TaskVM()
            {
                tasks = task,
                CategoryList = _unit.Category.GetAll()
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Delete(TaskVM obj)
        {
            if (obj == null)
            {
                return NotFound();
            }

            _unit.Task.Remove(obj.tasks);
            _unit.Save();
            return RedirectToAction("Index");

        }

    }
}




