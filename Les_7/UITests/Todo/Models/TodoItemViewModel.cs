using System.ComponentModel.DataAnnotations;
using Todo.Data.Entities;

namespace Todo.Models
{
    public class TodoItemViewModel
    {
        public TodoItemViewModel()
        {
        }

        public TodoItemViewModel(string? title, string? description, DateTime? dueDate, int id)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Id = id;
        }

        #region Properties

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Description { get; set; }

        [CustomValidation(typeof(CustomValidationMethods), nameof(CustomValidationMethods.DateInFuture))]
        public DateTime? DueDate { get; set; }

        public int Id { get; set; }

        #endregion Properties

        public static TodoItemViewModel FromEntity(TodoItem todoItem)
        {
            return new TodoItemViewModel(todoItem.Title, todoItem.Description, todoItem.DueDate, todoItem.Id);
        }

        public TodoItem ToEntity()
        {
            return new TodoItem()
            {
                Title = Title,
                Description = Description,
                DueDate = DueDate,
            };
        }
    }
}