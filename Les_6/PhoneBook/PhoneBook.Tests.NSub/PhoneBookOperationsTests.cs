using PhoneBook;
using System.Collections.Immutable;

namespace Phonebook.Tests
{
    public class PhoneBookOperationsTests
    {
        [Fact]
        public void Contacts_MetContactenInPhoneBook_GeeftAlleContactenTerug()
        {
            // Arrange
            IPhoneBook phoneBookTestDouble = Substitute.For<IPhoneBook>();
            phoneBookTestDouble.Contacts.Returns(new List<Contact>()
            {
                new Contact(1, "Matthias", "Druwé", "0123456789")
            }.ToImmutableList());

            PhoneBookOperations sut = new PhoneBookOperations(phoneBookTestDouble);

            List<Contact> expectedContacts = new List<Contact>() { new Contact(1, "Matthias", "Druwé", "0123456789") };

            // Act
            ImmutableList<Contact> contacts = sut.Contacts;

            // Assert
            contacts.Should().BeEquivalentTo(expectedContacts);
        }

        [Fact]
        public void Favorites_ZonderFavorietenInContacten_GeeftLegeLijstTerug()
        {
            // Arrange
            IPhoneBook phoneBookTestDouble = Substitute.For<IPhoneBook>();
            phoneBookTestDouble.Contacts.Returns(new List<Contact>()
            {
                new Contact(1, "Matthias", "Druwé", "0123456789")
            }.ToImmutableList());

            PhoneBookOperations sut = new PhoneBookOperations(phoneBookTestDouble);

            // Act
            IEnumerable<Contact> contacts = sut.Favorites;

            // Assert
            contacts.Should().BeEmpty();
        }

        [Fact]
        public void Favorites_MetFavorietenInContacten_GeeftLegeLijstTerug()
        {
            // Arrange
            IPhoneBook phoneBookTestDouble = Substitute.For<IPhoneBook>();
            phoneBookTestDouble.Contacts.Returns(new List<Contact>()
            {
                new Contact(1, "John", "Doe", "123456789"){Favorite = true},
                new Contact(2, "Janneke", "Doe", "234567891"),

            }.ToImmutableList()); 

            PhoneBookOperations sut = new PhoneBookOperations(phoneBookTestDouble);

            List<Contact> expectedResult = new List<Contact>()
            {
                new Contact(1,"John", "Doe", "123456789"){Favorite = true},
            };

            // Act
            IEnumerable<Contact> contacts = sut.Favorites;

            // Assert
            contacts.Should().BeEquivalentTo(expectedResult);
        }
        
        [Fact]
        //
        // Firstname en Lastname langer dan 2 karakters
        // Telefoonnummer geldig & niet in bestaande contacten
        //
        public void AddContact_MetCorrecteData_ContactWordtToegevoegdEnCorrectContactObjectWordtGemaakt()
        {
            // Arrange
            IPhoneBook phoneBookTestDouble = Substitute.For<IPhoneBook>();
            phoneBookTestDouble.Contacts.Returns(new List<Contact>().ToImmutableList());
            PhoneBookOperations sut = new PhoneBookOperations(phoneBookTestDouble);

            // Act
            sut.AddContact("Matthias", "Druwé", "987654321");

            //
            // 
            phoneBookTestDouble.Received().AddContact(new Contact(0, "Matthias", "Druwé", "987654321"));
        }

        [Fact]
        public void AddQuickDial_MetOnbeschikbareSneltoets_GooitError()
        {
            // Arrange
            IPhoneBook phoneBookTestDouble = Substitute.For<IPhoneBook>();
            phoneBookTestDouble.Contacts.Returns(new List<Contact>()
        {
            new Contact(1,"John", "Doe", "123456789"){Favorite = true},
            new Contact(2,"Jane", "Doe", "987654321"){QuickDial = 5},

        }.ToImmutableList());

            PhoneBookOperations sut = new PhoneBookOperations(phoneBookTestDouble);
            Contact contact = null; // dummy


            // Act
            Action act = () => sut.AddQuickDial(contact, 5);

            // Assert
            act.Should().Throw<ArgumentException>().WithParameterName("quickDialNumber");
        }


        [Fact]
        public void RemoveContact_WithContact_RemoveContactIsCalledOnPhonebook()
        {
            // Arrange
            IPhoneBook phonebookTestDouble = Substitute.For<IPhoneBook>();
            PhoneBookOperations sut = new PhoneBookOperations(phonebookTestDouble);

            // Act
            sut.RemoveContact(null);

            // Assert
            phonebookTestDouble.Received().RemoveContact(null);
            
        }
    }
}