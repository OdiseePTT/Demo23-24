using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Sum_With2PositiveNumbers_ReturnsCorrectPositiveResult()
        {
        
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
    }
}
