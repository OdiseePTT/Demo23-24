using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace PhoneBook
{
    public class PhoneBookOperations
    {
        IPhoneBook _phoneBook;

        public PhoneBookOperations():this(new PhoneBook("phonebook.json"))
        {
            
        }

        public PhoneBookOperations(IPhoneBook phoneBook)
        {
            _phoneBook = phoneBook;
        }

        #region Properties

        public ImmutableList<Contact> Contacts => _phoneBook.Contacts;

        public IEnumerable<Contact> Favorites => _phoneBook.Contacts.Where(contact => contact.Favorite);

        public ImmutableArray<Contact?> QuickDials
        {
            get
            {
                Contact?[] quickdials = new Contact?[10];

                quickdials = quickdials.Select((_, i) => Contacts.FirstOrDefault(contact => contact.QuickDial == i))
                    .ToArray();

                return quickdials.ToImmutableArray();
            }
        }

        #endregion

        #region public methods

        public void AddContact(string firstName, string lastName, string phoneNumber)
        {
            ValidateInput(firstName, lastName, phoneNumber);
            _phoneBook.AddContact(new Contact(GenerateId(), firstName, lastName, phoneNumber));
        }

        public void UpdateContact(Contact contact, string firstName, string lastName, string phoneNumber)
        {
            ValidateInput(firstName, lastName, phoneNumber);

            contact.FirstName = firstName;
            contact.LastName = lastName;
            contact.PhoneNumber = phoneNumber;

            _phoneBook.UpdateContact(contact);
        }

        public void Favorite(Contact contact)
        {
            contact.Favorite = true;
            _phoneBook.UpdateContact(contact);
        }

        public void UnFavorite(Contact contact)
        {
            contact.Favorite = false;
            _phoneBook.UpdateContact(contact);
        }

        public void AddQuickDial(Contact contact, int quickDialNumber)
        {
            if (QuickDials[quickDialNumber] != null)
            {
                throw new ArgumentException("Quickdial already taken", nameof(quickDialNumber));
            }

            contact.QuickDial = quickDialNumber;

            _phoneBook.UpdateContact(contact);
        }

        public void RemoveQuickDial(Contact contact)
        {
            contact.QuickDial = null;
            _phoneBook.UpdateContact(contact);
        }

        public void RemoveContact(Contact contact)
        {
            _phoneBook.RemoveContact(contact);
        }

        #endregion

        #region private methods

        private void ValidateInput(string firstName, string lastName, string phoneNumber)
        {
            if (!IsValidPhoneNumber(phoneNumber))
            {
                throw new ArgumentException("Invalid phoneNumber", nameof(phoneNumber));
            }

            if (Contacts.Exists(contact => contact.PhoneNumber == phoneNumber))
            {
                throw new ArgumentException("Phonenumber already exists", nameof(phoneNumber));
            }

            if (!IsValidName(firstName))
            {
                throw new ArgumentException("Invalid firstName", nameof(firstName));
            }

            if (!IsValidName(lastName))
            {
                throw new ArgumentException("Invalid lastName", nameof(lastName));
            }
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern =
                @"^\s*(?:\+?(\d{1,3}))?([-. (]*(\d{3})[-. )]*)?((\d{3})[-. ]*(\d{2,4})(?:[-.x ]*(\d+))?)\s*$";
            return Regex.IsMatch(phoneNumber, pattern);
        }

        private bool IsValidName(string name)
        {
            return name.Length > 2;
        }

        private int GenerateId()
        {
            if (_phoneBook.Contacts.IsEmpty)
            {
                return 0;
            }

            return _phoneBook.Contacts.Max(contact => contact.Id) + 1;
        }

        #endregion
    }
}