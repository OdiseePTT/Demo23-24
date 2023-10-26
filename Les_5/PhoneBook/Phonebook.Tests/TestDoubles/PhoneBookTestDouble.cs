using PhoneBook;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Tests.TestDoubles
{
    internal class PhoneBookTestDouble : IPhoneBook
    {
        public ImmutableList<Contact> Contacts => new List<Contact>() { new Contact(1, "Matthias", "Druwé", "0123456789") }.ToImmutableList();

        public bool AddContactCalled { get; private set; }
        public Contact ContactLastAdded { get; private set; }
        public void AddContact(Contact contact)
        {
            AddContactCalled = true;
            ContactLastAdded = contact;
        }

        public void RemoveContact(Contact contact)
        {
            throw new RemoveContactCalled();
        }

        public void UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }

    public class RemoveContactCalled: Exception { }
}
