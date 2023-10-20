using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    public class TodoItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }

        public string ToCsvString()
        {
            string dueDateStr = DueDate.HasValue ? DueDate.Value.ToString("yyyy-MM-dd") : "";
            return $"{Title},{Description},{dueDateStr},{IsCompleted}";
        }

        public static TodoItem FromCsvString(string csvLine)
        {
            string[] values = csvLine.Split(',');
            TodoItem item = new TodoItem
            {
                Title = values[0],
                Description = values[1],
                DueDate = string.IsNullOrEmpty(values[2]) ? (DateTime?)null : DateTime.ParseExact(values[2], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                IsCompleted = bool.Parse(values[3])
            };
            return item;
        }
    }
}
