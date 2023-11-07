namespace HigherLowerGame.Tests
{
    public class PersonTests
    {

        [Theory]
        [InlineData(2000, 1, 1, 30)]
        [InlineData(2000, 12, 31, 29)]
        [InlineData(2000, 2, 2, 29)]
        [InlineData(1900, 1, 1, 130)]
        [InlineData(2004, 2, 29, 25)]
        public void Age_WithMultipleDatesCheckedOn1January2030_ReturnsExpectedAge(int year, int month, int day, int expectedAge)
        {

            // Arrange
            IDate dateTimeProvider = Substitute.For<IDate>();
            dateTimeProvider.Today.Returns(new DateTime(2030, 1, 1));
            dateTimeProvider.Now.Returns(new DateTime(2030, 1, 1, 12, 30, 30, 0));
            Person sut = new Person("demo", "demo", new DateTime(year, month, day), dateTimeProvider);


            // Act
            int actualAge = sut.Age;

            // Assert
            actualAge.Should().Be(expectedAge);

        }
    }
}
