using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Tests
{
    internal class WriteToCsvMethodCalled : Exception
    {

    }

    internal class CsvFileHelperTestDouble : ICsvFileHelper
    {
        public List<TodoItem> ReadFromCsv(string filePath)
        {
            return new List<TodoItem>();
        }

        public void WriteToCsv(string filePath, List<TodoItem> items)
        {
            throw new WriteToCsvMethodCalled();
        }
    }
}
