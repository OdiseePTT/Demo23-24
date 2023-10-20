using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Tests
{
    internal class CsvFileHelperTestDouble2 : ICsvFileHelper
    {

        public String FilePath { get; private set; }
        public  List<TodoItem> Items { get; set; }

        public List<TodoItem> ReadFromCsv(string filePath)
        {
            return new List<TodoItem> { new TodoItem()/*2*/, new TodoItem() /*3*/ };
        }

        public void WriteToCsv(string filePath, List<TodoItem> items)
        {
            FilePath = filePath;
            Items = items;
        }
    }
}
