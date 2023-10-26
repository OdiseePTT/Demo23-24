
using System.Collections.Immutable;
using System.Text.Json;

namespace PhoneBook
{
    public class PhoneBook : IPhoneBook
    {
        string _url;
        private List<Contact> _contacts = new List<Contact>();
        public PhoneBook(string url)
        {
            _url = url;
            LoadContacts();
        }


        public ImmutableList<Contact> Contacts => _contacts.ToImmutableList();



        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
            SaveContacts(); // Save the updated phonebook to the CSV file.
        }

        public void RemoveContact(Contact contact)
        {
            _contacts.Remove(contact);
            SaveContacts();
        }

        public void UpdateContact(Contact contact)
        {
            Contact localContact = Contacts.FirstOrDefault(c => c.Id == contact.Id);

            localContact.FirstName = contact.FirstName;
            localContact.LastName = contact.LastName;
            localContact.PhoneNumber = contact.PhoneNumber;
            localContact.Favorite = contact.Favorite;
            localContact.QuickDial = contact.QuickDial;

            SaveContacts();
        }

        private void LoadContacts()
        {
            if (File.Exists(_url))
            {
                string json = File.ReadAllText(_url);
                _contacts = JsonSerializer.Deserialize<List<Contact>>(json);
            }
        }
        private void SaveContacts()
        {
            string json = JsonSerializer.Serialize(_contacts);
            File.WriteAllText(_url, json);
        }
    }


}
