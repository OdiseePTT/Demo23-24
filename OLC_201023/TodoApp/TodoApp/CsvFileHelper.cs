using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    public interface ICsvFileHelper
    {
        List<TodoItem> ReadFromCsv(string filePath);
        void WriteToCsv(string filePath, List<TodoItem> items);
    }

    public class CsvFileHelper: ICsvFileHelper
    {
        public List<TodoItem> ReadFromCsv(string filePath)
        {
            List<TodoItem> items = new List<TodoItem>();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    TodoItem item = TodoItem.FromCsvString(line);
                    items.Add(item);
                }
            }

            return items;
        }

        public void WriteToCsv(string filePath, List<TodoItem> items)
        {
            List<string> lines = new List<string>();

            foreach (TodoItem item in items)
            {
                string csvLine = item.ToCsvString();
                lines.Add(csvLine);
            }

            File.WriteAllLines(filePath, lines, Encoding.UTF8);
        }
    }
}
