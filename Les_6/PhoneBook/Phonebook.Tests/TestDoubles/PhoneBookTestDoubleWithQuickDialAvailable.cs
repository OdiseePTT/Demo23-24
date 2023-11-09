using PhoneBook;
using System.Collections.Immutable;

namespace Phonebook.Tests.TestDoubles
{
    internal class PhoneBookTestDoubleWithQuickDialAvailable : IPhoneBook
    {
        public ImmutableList<Contact> Contacts => new List<Contact>()
        {
            new Contact(1,"John", "Doe", "123456789"){Favorite = true},
            new Contact(2,"Jane", "Doe", "987654321"){QuickDial = 5},

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
