using TodoApp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace TodoApp
{

    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "todo.csv";
            var todoService = new TodoService(filePath);

            // Add a new to-do item
            var newItem = new TodoItem
            {
                Title = "Buy groceries",
                Description = "Milk eggs and bread",
                DueDate = DateTime.Today.AddDays(7),
                IsCompleted = false
            };
            todoService.AddTodoItem(newItem);

            // Mark a to-do item as completed
            todoService.CompleteTodoItem("Buy groceries");

            // Postpone the due date of a to-do item
            todoService.PostponeDueDate("Buy groceries", DateTime.Today.AddDays(14));
        }
    }

}