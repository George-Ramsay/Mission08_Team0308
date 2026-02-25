using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Assignment.Models;
using Mission08_Assignment.Repositories;
using Mission08_Team0308.Models;

namespace Mission08_Team0308.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQuadrantsRepository _repository;

        public HomeController(IQuadrantsRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: /Home/Quadrants – list only incomplete tasks
        [HttpGet]
        public IActionResult Quadrants()
        {
            var incompleteTasks = _repository.TaskItems
                .Where(t => !t.Completed)
                .ToList();

            return View(incompleteTasks);
        }

        // GET: /Home/Create – show blank form
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new TaskViewModel
            {
                Categories = _repository.Categories.ToList()
            };

            return View(viewModel);
        }

        // POST: /Home/Create – validate and save new task
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaskViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _repository.AddTask(viewModel.TaskItem);
                _repository.SaveChanges();

                return RedirectToAction("Quadrants");
            }

            // Repopulate dropdown on validation failure
            viewModel.Categories = _repository.Categories.ToList();
            return View(viewModel);
        }

        // GET: /Home/Edit/5 – load task by id
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _repository.TaskItems
                .FirstOrDefault(t => t.TaskItemId == id);

            if (task == null)
            {
                return NotFound();
            }

            var viewModel = new TaskViewModel
            {
                TaskItem = task,
                Categories = _repository.Categories.ToList()
            };

            return View(viewModel);
        }

        // POST: /Home/Edit – validate and save changes
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TaskViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateTask(viewModel.TaskItem);
                _repository.SaveChanges();

                return RedirectToAction("Quadrants");
            }

            // Repopulate dropdown on validation failure
            viewModel.Categories = _repository.Categories.ToList();
            return View(viewModel);
        }

        // POST: /Home/Delete/5 – remove task
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var task = _repository.TaskItems
                .FirstOrDefault(t => t.TaskItemId == id);

            if (task == null)
            {
                return NotFound();
            }

            _repository.DeleteTask(task);
            _repository.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        // POST: /Home/Complete/5 – mark task as completed
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Complete(int id)
        {
            var task = _repository.TaskItems
                .FirstOrDefault(t => t.TaskItemId == id);

            if (task == null)
            {
                return NotFound();
            }

            task.Completed = true;
            _repository.UpdateTask(task);
            _repository.SaveChanges();

            return RedirectToAction("Quadrants");
        }
    }
}
