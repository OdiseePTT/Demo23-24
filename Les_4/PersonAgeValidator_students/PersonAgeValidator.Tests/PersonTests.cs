using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonAgeValidator.Tests
{
    public class PersonTests
    {
        [Fact]
        public void Ctor_WithValidAge_ReturnsPersonObjectWithExpectedProperties()
        {
            // Arrange 
            string firstName = "Claudio";
            string lastName = "L'Abbatte";
            int age = 20;

            // Act
            Person sut = new Person(firstName, lastName, age);

            // Assert
            sut.FirstName.Should().Be("Claudio");
            sut.LastName.Should().Be("L'Abbatte");
            sut.Age.Should().Be(20);
            sut.Should().BeOfType<Person>();
        }

        [Fact]
        public void Ctor_WithInValidAge_ThrowsException()
        {
            // Arrange 
            string firstName = "Claudio";
            string lastName = "L'Abbatte";
            int age = 10;

            // Act
            Action act = () => { Person sut = new Person(firstName, lastName, age); };

            // Assert
            act.Should().Throw<Exception>().WithMessage("age invalid");

        }

    }
}
