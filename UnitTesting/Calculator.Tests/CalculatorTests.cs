using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Calculator.Tests
{
    public class CalculatorTests : IDisposable
    {
        private readonly ITestOutputHelper _output;

        public CalculatorTests(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Setup");
        }
        [Fact]
        public void Sum_With2PositiveNumbers_ReturnsCorrectPositiveResult()
        {
            _output.WriteLine("Sum_With2PositiveNumbers_ReturnsCorrectPositiveResult");

            // arrange => precondities + testdata
            Calculator sut = new Calculator();

            int number1 = 3021;
            int number2 = 2000;


            // act => test stappen
            int result = sut.Sum(number1, number2);

            // assert => Expected/actual result
            Assert.Equal(5021, result);


            result.Should().Be(5021);


        }


        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(1102, 1, 1103)]
        [InlineData(9876, 4, 9880)]
        [InlineData(-10, -300, -310)]
        public void Sum_With2Integers_ReturnsCorrectSum(int number1, int number2, int expectedResult)
        {
            // arrange => precondities + testdata
            Calculator sut = new Calculator();


            // act => test stappen
            int actualResult = sut.Sum(number1, number2);

            // assert => Expected/actual result
            Assert.Equal(expectedResult, actualResult);


            actualResult.Should().Be(expectedResult);
        }



        [Fact]
        public void Divide_ByZero_ThrowsError()
        {
            //Arrange
            int number1 = 6;
            int number2 = 0;
            Calculator sut = new Calculator();


            //
            try
            {
                int result = sut.Divide(number1, number2);
                Assert.True(false);

            }catch(DivideByZeroException ex)
            {
                Assert.True(true);
                ex.Message.Should().Be("Attempted to divide by zero.");
            }

            //Assert
            // Assert.Equal(result, new DivideByZeroException());
        }

        /*  [Fact]
          public void NuttelozeTest()
          {
              _output.WriteLine("NuttelozeTest");
              Assert.True(false);
          }*/

        public void Dispose()
        {
            _output.WriteLine("Teardown");
        }
    }
}
