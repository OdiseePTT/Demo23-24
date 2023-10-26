using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigherLowerGame
{
    public class PersonRepository
    {
        PersonDbContext _context = new PersonDbContext();

        public List<Person> GetAllPersons()
        {
            return _context.Persons.ToList();
        }

        public void AddPerson(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
        }
    }
}
