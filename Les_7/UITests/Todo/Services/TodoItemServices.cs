using System.Security.Claims;
using Todo.Data;
using Todo.Data.Entities;
using Todo.Models;

namespace Todo.Services
{
    public class TodoItemServices : ITodoItemServices
    {
        #region Fields

        private readonly ITodoItemRepository _todoItemRepo;
        private readonly string _userId;

        #endregion Fields

        public TodoItemServices(ITodoItemRepository todoItemRepo, IHttpContextAccessor contextAccessor)
        {
            _todoItemRepo = todoItemRepo;
            string? userId = (contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value) ?? throw new Exception("User should be logged in");
            _userId = userId;
        }

        public List<TodoItemViewModel> GetItems()
        {
            return _todoItemRepo
                .GetTodoItemsForUserId(_userId)
                .Select(item => TodoItemViewModel.FromEntity(item)).ToList();
        }

        public void Create(TodoItemViewModel viewModel)
        {
            TodoItem todoItem = viewModel.ToEntity();

            todoItem.UserId = _userId;

            _todoItemRepo.Create(todoItem);
        }

        public TodoItemViewModel? GetItem(int id)
        {
            TodoItem? todoItem = _todoItemRepo.GetById(id);

            if (todoItem?.UserId == _userId)
            {
                return TodoItemViewModel.FromEntity(todoItem);
            }

            return null;
        }

        public void UpdateTodo(int id, TodoItemViewModel viewModel)
        {
            TodoItem? todoItem = _todoItemRepo.GetById(id);

            if (todoItem != null && todoItem?.UserId == _userId)
            {
                todoItem.Title = viewModel.Title;
                todoItem.DueDate = viewModel.DueDate;
                todoItem.Description = viewModel.Description;
                _todoItemRepo.Update(id, todoItem);
            }
        }

        public void Delete(int id)
        {
            TodoItem? todoItem = _todoItemRepo.GetById(id);
            if (todoItem?.UserId == _userId)
            {
                _todoItemRepo.Delete(id);
            }
        }
    }
}