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
    }
}