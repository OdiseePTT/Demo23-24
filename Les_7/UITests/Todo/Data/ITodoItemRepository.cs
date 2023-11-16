using Todo.Data.Entities;

namespace Todo.Data
{
    public interface ITodoItemRepository : IGenericRepository<TodoItem>
    {
        IEnumerable<TodoItem> GetTodoItemsForUserId(string userId);
    }
}