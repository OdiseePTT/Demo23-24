using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonAgeValidator
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        private IAgeValidator _ageValidator;

        public Person(IAgeValidator validator, string firstName, string lastName, int age)
        {
            _ageValidator = validator;

            if (!_ageValidator.IsValidAge(age))
            {
                throw new Exception("age invalid");
            }

            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public Person(string firstName, string lastName, int age) : this(new AgeValidator(), firstName, lastName, age)
        {

        }
    }
}
