using FluentAssertions;
using Todo.UITests.Helpers;
using Todo.UITests.PageObjectModels;

namespace Todo.UITests
{
    public class LoginPageTests : BaseTest, IClassFixture<SharedWebDriver>
    {

        public LoginPageTests(SharedWebDriver driver) : base(driver)
        {

        }

        [Fact]
        public void LoginTest()
        {

            AddUser("matthias.druwe@odisee.be", "o0D1s33@");
            _webDriver.Navigate().GoToUrl(_url);

            LoginPage page = new LoginPage(_webDriver);

            page.SetEmail("matthias.druwe@odisee.be");
            page.SetPassword("o0D1s33@");

            page.SubmitLogin();


            TodoOverviewPage todoOverviewPage = new TodoOverviewPage(_webDriver);
            todoOverviewPage.ProfileButtonText.Should().Be("Hello matthias.druwe@odisee.be!");


        }
    }
}
