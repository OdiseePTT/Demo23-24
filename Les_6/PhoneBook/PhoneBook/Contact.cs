using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class Contact
    {
        public Contact(int id, string firstName, string lastName, string phoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }

        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int? QuickDial { get; set; }
        public bool Favorite { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Contact contact &&
                   Id == contact.Id &&
                   FirstName == contact.FirstName &&
                   LastName == contact.LastName &&
                   PhoneNumber == contact.PhoneNumber &&
                   QuickDial == contact.QuickDial &&
                   Favorite == contact.Favorite;
        }
    }
}
