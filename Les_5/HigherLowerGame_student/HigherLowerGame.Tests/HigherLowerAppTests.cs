using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigherLowerGame.Tests
{
    public class HigherLowerAppTests
    {
        [Fact]
        public void GuessGuessNumber_WithGuessToHigh_ReturnsLower()
        {
            // Arrange
            IRandomProvider randomProvider = Substitute.For<IRandomProvider>();
            randomProvider.Next(default).ReturnsForAnyArgs(10);
            HigherLowerApp sut = new HigherLowerApp(0, randomProvider);

            // Act
            Result result = sut.GuessNumber(20);

            // Assert
            result.Should().Be(Result.Lower);
        }

        [Fact]
        public void GuessGuessNumber_WithGuessToLow_ReturnsHigher()
        {
            // Arrange
            IRandomProvider randomProvider = Substitute.For<IRandomProvider>();
            randomProvider.Next(default).ReturnsForAnyArgs(22);
            HigherLowerApp sut = new HigherLowerApp(0, randomProvider);

            // Act
            Result result = sut.GuessNumber(20);

            // Assert
            result.Should().Be(Result.Higher);
        }
    }
}
