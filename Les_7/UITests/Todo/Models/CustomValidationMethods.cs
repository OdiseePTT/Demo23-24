using System.ComponentModel.DataAnnotations;

namespace Todo.Models
{
    public static class CustomValidationMethods
    {
        public static ValidationResult? DateInFuture(DateTime? date)
        {
            if (date != null)
            {
                DateTime d = (DateTime)date;
                return DateTime.Compare(d, DateTime.Today) > 0 ? ValidationResult.Success : new ValidationResult("Date cannot be in the past");
            }

            return ValidationResult.Success;
        }
    }
}