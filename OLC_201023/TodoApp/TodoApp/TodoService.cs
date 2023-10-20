namespace TodoApp
{
    public class TodoService
    {
        private List<TodoItem> todoItems;
        private ICsvFileHelper csvFileHelper; // DEPENDENCY !!
        private string filePath;

        public TodoService(string filePath): this(filePath, new CsvFileHelper()) // Default ctor voor CsvFileHelper
        {
           
        }

        public TodoService(string filePath, ICsvFileHelper helper)
        {
            this.filePath = filePath;
            csvFileHelper = helper;
            todoItems = csvFileHelper.ReadFromCsv(filePath);
        }

        public List<TodoItem> GetTodoItems()
        {
            return todoItems;
        }

        public void AddTodoItem(TodoItem item)
        {
            todoItems.Add(item);
            csvFileHelper.WriteToCsv(filePath, todoItems);
        }

        public void CompleteTodoItem(string title)
        {
            var item = todoItems.FirstOrDefault(i => i.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                item.IsCompleted = true;
                csvFileHelper.WriteToCsv(filePath, todoItems);
            }
        }

        public void DeleteTodoItem(string title)
        {
            var item = todoItems.FirstOrDefault(i => i.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                todoItems.Remove(item);
                csvFileHelper.WriteToCsv(filePath, todoItems);
            }
        }

        public void PostponeDueDate(string title, DateTime newDueDate)
        {
            var item = todoItems.FirstOrDefault(i => i.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                item.DueDate = newDueDate;
                csvFileHelper.WriteToCsv(filePath, todoItems);
            }
        }
    }

}