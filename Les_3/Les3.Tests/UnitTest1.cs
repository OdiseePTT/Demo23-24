using FluentAssertions;

namespace Les3.Tests
{
    public class Demo
    {
        [Fact]
        public void DemoTest()
        {
            List<int> items = new List<int>() { 1, 2, 3 };
            List<int> reversedItems = new List<int>() { 3, 2, 1 };

            items.Reverse();

            items.Should().BeEquivalentTo(reversedItems, (options) => options.WithStrictOrdering());
        }

        [Fact]
        public void DemoContains()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };


            Assert.Contains(numbers, (number) =>
            {
                return number == 1;
            });

        }

        [Fact]
        public void DemoAll()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.All(numbers, (number) =>
            {
                Assert.NotEqual(10, number);
            });

            foreach (var number in numbers)
            {
                Assert.NotEqual(10, number);
            }
        }

        [Fact]
        public void DemoContain()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            numbers.Should().Contain((number) => number%2 == 0);
        }

        [Fact]
        public void DemoOnlyContain()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            numbers.Should().OnlyContain((number) => number >= 0);
        }


        [Fact]
        public void DemoException1()
        {
            int number1 = 2;
            int number2 = 0;
            Calculator sut = new Calculator();

            // Act + Assert
            Assert.Throws<DivideByZeroException>(()=> { double result = sut.Divide(number1, number2); });
        }


        [Fact]
        public void DemoException2()
        {

            int number1 = 2;
            int number2 = 0;
            Calculator sut = new Calculator();

            // Act + assert
            sut.Invoking(sut => sut.Divide(number1,number2)).Should().Throw<DivideByZeroException>();
        }

        [Fact]
        public void DemoException3()
        {
            // Arrange 
            int number1 = 2;
            int number2 = 0;
            Calculator sut = new Calculator();

            // Act
            Action act = () => sut.Divide(number1, number2);

            // Assert
            act.Should().Throw<DivideByZeroException>();
        }

    }
}