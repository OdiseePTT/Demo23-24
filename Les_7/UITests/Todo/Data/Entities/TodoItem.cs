using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Todo.Data.Entities
{
    public class TodoItem : IEntity
    {
        #region Properties

        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public IdentityUser User { get; set; }

        [Required]
        public string UserId { get; set; }

        public DateTime? DueDate { get; set; }

        #endregion Properties
    }
}