using System.Collections.Immutable;

namespace PhoneBook
{
    public interface IPhoneBook
    {
        ImmutableList<Contact> Contacts { get; }
        void AddContact(Contact contact);
        void RemoveContact(Contact contact);
        void UpdateContact(Contact contact);
    }
}
