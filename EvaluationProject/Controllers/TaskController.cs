using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;

        public TaskController(IUnitOfWork unit, UserManager<IdentityUser> userManager)
        {
            _unit = unit;
            _userManager = userManager;

        }
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var tasks = _unit.Task.GetAll(u=> u.UserId== userId, includeProperties: "Category");
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
            var user = _userManager.GetUserId(User);
            obj.tasks.UserId = user;
            if (ModelState.IsValid)
            {
                _unit.Task.Add(obj.tasks);
                _unit.Save();
                return RedirectToAction("Index");
            }
            obj.CategoryList = _unit.Category.GetAll();
            return View(obj);
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
            obj.CategoryList = _unit.Category.GetAll();
            return View(obj);
        }

        public IActionResult Delete(int id)
        {
            var task = _unit.Task.Get(u => u.Id == id, "Category");
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




