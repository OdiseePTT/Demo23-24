using PhoneBook;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Tests.TestDoubles
{
    internal class PhoneBookTestDoubleWithFavorites : IPhoneBook
    {
        public ImmutableList<Contact> Contacts => new List<Contact>()
        {
            new Contact(1,"John", "Doe", "123456789"){Favorite = true},
            new Contact(2,"Jane", "Doe", "987654321"),

        }.ToImmutableList();

        public void AddContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void RemoveContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
