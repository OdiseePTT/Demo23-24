namespace HigherLowerGame.Tests
{
    public class PersonTests
    {

        [Theory]
        [InlineData(2000, 1, 1, 30)]
        [InlineData(2000, 12, 31, 29)]
        [InlineData(2000, 2, 2, 29)]
        [InlineData(1900, 1, 1, 130)]
        public void Age_WithDateOn1January2030_ReturnsExpectedAge(int year, int month, int day, int exptectedAge)
        {

            // Arrange
            Person sut = new Person("demo", "demo", new DateTime(year, month, day));


            // Act
            int actualAge =  sut.Age;

            // Assert
            actualAge.Should().Be(exptectedAge);

        }
    }
}
