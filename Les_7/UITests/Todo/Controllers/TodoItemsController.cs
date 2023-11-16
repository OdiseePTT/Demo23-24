using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Models;
using Todo.Services;

namespace Todo.Controllers
{
    [Authorize]
    public class TodoItemsController : Controller
    {
        #region Fields

        private readonly ITodoItemServices _service;

        #endregion Fields

        public TodoItemsController(ITodoItemServices service)
        {
            _service = service;
        }

        // GET: TodoItems
        public IActionResult Index()
        {
            return View(_service.GetItems());
        }

        // GET: TodoItems/Details/5

        public IActionResult Details(int id)
        {
            var todoItem = _service.GetItem(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return View(todoItem);
        }

        // GET: TodoItems/Create
        public IActionResult Create()
        {
            return View(new TodoItemViewModel());
        }

        // POST: TodoItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TodoItemViewModel todoItem)
        {
            if (ModelState.IsValid)
            {
                _service.Create(todoItem);
                return RedirectToAction(nameof(Index));
            }
            return View(todoItem);
        }

        // GET: TodoItems/Edit/5
        public IActionResult Edit(int id)
        {
            var todoItem = _service.GetItem(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return View(todoItem);
        }

        // POST: TodoItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TodoItemViewModel todoItem)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateTodo(id, todoItem);
                return RedirectToAction(nameof(Index));
            }
            return View(todoItem);
        }

        // GET: TodoItems/Delete/5
        public IActionResult Delete(int id)
        {
            var todoItem = _service.GetItem(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return View(todoItem);
        }

        // POST: TodoItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}