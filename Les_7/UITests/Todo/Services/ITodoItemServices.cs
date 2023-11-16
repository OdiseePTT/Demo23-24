using Todo.Models;

namespace Todo.Services
{
    public interface ITodoItemServices
    {
        List<TodoItemViewModel> GetItems();

        void Create(TodoItemViewModel viewModel);

        TodoItemViewModel? GetItem(int id);

        void UpdateTodo(int id, TodoItemViewModel todoItem);

        void Delete(int id);
    }
}