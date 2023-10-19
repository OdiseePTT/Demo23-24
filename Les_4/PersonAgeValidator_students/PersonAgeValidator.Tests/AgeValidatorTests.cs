using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonAgeValidator.Tests
{
    public class AgeValidatorTests
    {
        [Fact]
        public void IsValidAge_IsBetween21And70_ReturnsTrue()
        {
            // Arrange
            AgeValidator sut = new AgeValidator();
            int inputAge = 21;

            // Act
            bool result = sut.IsValidAge(inputAge);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(17)]
        [InlineData(71)]
        [InlineData(1000)]
        public void IsValidAge_IsNotBetween18And70_ReturnsFalse(int inputAge)
        {
            // Arrange
            AgeValidator sut = new AgeValidator();

            // Act
            bool result = sut.IsValidAge(inputAge);

            // Assert
            Assert.False(result);
        }
    }
}
