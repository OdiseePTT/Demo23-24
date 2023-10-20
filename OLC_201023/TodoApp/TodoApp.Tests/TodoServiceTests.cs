using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Tests
{
    public class TodoServiceTests
    {
        [Fact]
        public void GetTodoItems_WithNoItemsInTodo_ReturnsEmptyList()
        {
            // Arrange
            ICsvFileHelper helper = new CsvFileHelperTestDouble();   
            TodoService sut = new TodoService("test1.csv", helper);

            // Act
            List<TodoItem> items = sut.GetTodoItems();

            // Assert
            items.Should().BeEmpty();
        }

        [Fact]
        public void GetTodoItems_WithExistingList_ReturnsNotEmptyList()
        {
            // Arrange
            ICsvFileHelper helper = new CsvFileHelperTestDouble2();
            TodoService sut = new TodoService("test.csv", helper);

            // Act
            List<TodoItem> items = sut.GetTodoItems();

            // Assert
            items.Should().NotBeEmpty();
        }

        [Fact]
        public void AddTodoItem_ToEmptyList_UpdatesTodoListAndCallsWriteToCSV()
        {
            // Arrange
            ICsvFileHelper helper = new CsvFileHelperTestDouble();
            TodoService sut = new TodoService("test.csv", helper);
            TodoItem item = new TodoItem();

            // Act
            Action act = () => sut.AddTodoItem(item);


            // Assert
            act.Should().Throw<WriteToCsvMethodCalled>();
            sut.GetTodoItems().Should().Contain(item);
        }

        [Fact]
        public void AddTodoItem_ToExistingList_UpdatesTodoListAndCallsWriteToCSV()
        {
            // Arrange
            CsvFileHelperTestDouble2 helper = new CsvFileHelperTestDouble2();
            TodoService sut = new TodoService("test.csv", helper);
            TodoItem item = new TodoItem(); // 1

            // Act
            sut.AddTodoItem(item);


            // Assert
            helper.FilePath.Should().Be("test.csv");
            helper.Items.Should().BeEquivalentTo(new List<TodoItem> {
            new TodoItem()/*4*/, new TodoItem()/*5*/, new TodoItem()/*6*/ });
            sut.GetTodoItems().Should().Contain(item);
        }
    }
}
