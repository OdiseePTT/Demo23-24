using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Todo.UITests.Helpers;

namespace Todo.UITests
{
    public class RegisterPageTests: IClassFixture<SharedWebDriver>
    {
        WebDriver _webDriver;
        string _url = "https://localhost:1234";
        public RegisterPageTests(SharedWebDriver driver)
        {
            _webDriver = driver;

            WebTestingHostFactory<TodoProgram> factory = new WebTestingHostFactory<TodoProgram>();
            factory.WithWebHostBuilder(builder =>
            {
                builder.UseUrls(_url);
            }).CreateDefaultClient();
        }

        [Fact]
        public void NoDataAndRegisterClickedShows2Errors()
        {
            _webDriver.Navigate().GoToUrl(_url +"/Identity/Account/Register");

            IWebElement registerButton = _webDriver.FindElement(By.Id("registerSubmit"));

            registerButton.Click();

            IWebElement inputEmailErrorField = _webDriver.FindElement(By.Id("Input_Email-error"));
            IWebElement inputPasswordErrorField = _webDriver.FindElement(By.Id("Input_Password-error"));

            inputEmailErrorField.Displayed.Should().BeTrue();
            inputPasswordErrorField.Displayed.Should().BeTrue();

            inputEmailErrorField.Text.Should().NotBeEmpty();
            inputPasswordErrorField.Text.Should().NotBeEmpty();
        }

        [Fact]
        public void InvalidDataForAllFieldShows3Errors()
        {
            _webDriver.Navigate().GoToUrl(_url+"/Identity/Account/Register");

            IWebElement emailField =_webDriver.FindElement(By.Name("Input.Email")) ;
            IWebElement passwordField = _webDriver.FindElement(By.Name("Input.Password"));
            IWebElement confirmPasswordField = _webDriver.FindElement(By.Name("Input.ConfirmPassword"));

            emailField.SendKeys("demo");
            passwordField.SendKeys("demo");
            confirmPasswordField.SendKeys("omed"+Keys.Enter);

            // emailField.Click(); // Gebruiken wanneer we geen Keys.Enter gebruiken.

            IWebElement inputEmailErrorField = _webDriver.FindElement(By.Id("Input_Email-error"));
            IWebElement inputPasswordErrorField = _webDriver.FindElement(By.Id("Input_Password-error"));
            IWebElement inputConfirmPasswordErrorField = _webDriver.FindElement(By.Id("Input_ConfirmPassword-error"));


            inputConfirmPasswordErrorField.Displayed.Should().BeTrue();
            inputPasswordErrorField.Displayed.Should().BeTrue();
            inputEmailErrorField.Displayed.Should().BeTrue();
        }
    }
}