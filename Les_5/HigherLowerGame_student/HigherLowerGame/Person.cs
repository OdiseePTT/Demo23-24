using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigherLowerGame
{
    public class Person { 

        IDate _dateTimeProvider = new DateTimeProvider();
        
        public Person(string firstName, string lastName, DateTime birthDate, IDate dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public Person(string firstName, string lastName, DateTime birthDate): this(firstName, lastName, birthDate, new DateTimeProvider()) { 
        }

        public Person()
        {
            
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age
        {
            get
            {
                int age = _dateTimeProvider.Now.Year - BirthDate.Year;
                if (BirthDate.Date > _dateTimeProvider.Today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }
    }
}
