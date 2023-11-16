using Todo.Data.Entities;

namespace Todo.Data
{
    public class TodoItemRepository : GenericRepository<TodoItem>, ITodoItemRepository
    {
        #region Fields

        private readonly ApplicationDbContext _dbContext;

        #endregion Fields

        public TodoItemRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<TodoItem> GetTodoItemsForUserId(string userId)
        {
            return _dbContext.TodoItems.Where(item => item.User.Id == userId);
        }
    }
}