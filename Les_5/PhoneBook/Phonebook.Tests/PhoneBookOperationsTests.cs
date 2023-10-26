using FluentAssertions;
using Phonebook.Tests.TestDoubles;
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
            IPhoneBook phoneBookTestDouble = new PhoneBookTestDouble();
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
            IPhoneBook phoneBookTestDouble = new PhoneBookTestDouble();
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
            IPhoneBook phoneBookTestDouble = new PhoneBookTestDoubleWithFavorites();
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
            PhoneBookTestDouble phoneBookTestDouble = new PhoneBookTestDouble();
            PhoneBookOperations sut = new PhoneBookOperations(phoneBookTestDouble);

            // Act
            sut.AddContact("Matthias", "Druwé", "987654321");

            // Assert
            phoneBookTestDouble.AddContactCalled.Should().BeTrue();
            phoneBookTestDouble.ContactLastAdded.Should().BeEquivalentTo(new Contact(2, "Matthias", "Druwé", "987654321"));
            phoneBookTestDouble.ContactLastAdded.Id.Should().Be(2);
            phoneBookTestDouble.ContactLastAdded.FirstName.Should().Be("Matthias");
            phoneBookTestDouble.ContactLastAdded.LastName.Should().Be("Druwé");
            phoneBookTestDouble.ContactLastAdded.PhoneNumber.Should().Be("987654321");
        }

        [Fact]
        public void AddQuickDial_MetOnbeschikbareSneltoets_GooitError()
        {
            // Arrange
            IPhoneBook phoneBookTestDouble = new PhoneBookTestDoubleWithQuickDialAvailable();
            PhoneBookOperations sut = new PhoneBookOperations(phoneBookTestDouble);
            Contact contact = null;


            // Act
            Action act = () => sut.AddQuickDial(contact, 5);

            // Assert
            act.Should().Throw<ArgumentException>().WithParameterName("quickDialNumber");
        }

        [Fact]
        public void RemoveContact_WithContact_RemoveContactIsCalledOnPhonebook()
        {
            // Arrange
            IPhoneBook phonebookTestDouble = new PhoneBookTestDouble();
            PhoneBookOperations sut = new PhoneBookOperations(phonebookTestDouble);

            // Act + Assert
            Action act  = () => sut.RemoveContact(null);

            act.Should().Throw<RemoveContactCalled>();
        }
    }
}