using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Data.Common;
using Todo.Data;
using Todo.UITests.Helpers;

namespace Todo.UITests
{
    public class RegisterPageTests: BaseTest, IClassFixture<SharedWebDriver>
    {

        public RegisterPageTests(SharedWebDriver driver):base(driver)
        {
            
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

        [Fact]
        public void CreateNewUser()
        {
            _webDriver.Navigate().GoToUrl(_url + "/Identity/Account/Register");

            IWebElement emailField = _webDriver.FindElement(By.Name("Input.Email"));
            IWebElement passwordField = _webDriver.FindElement(By.Name("Input.Password"));
            IWebElement confirmPasswordField = _webDriver.FindElement(By.Name("Input.ConfirmPassword"));
            IWebElement registerButton = _webDriver.FindElement(By.Id("registerSubmit"));

            emailField.SendKeys("matthias.druwe@odisee2.be");
            passwordField.SendKeys("Qwer3@tsd");
            confirmPasswordField.SendKeys("Qwer3@tsd");


            registerButton.Submit();

            _webDriver.Url.Should().StartWith("https://localhost:1234/Identity/Account/RegisterConfirmation");
        }



    }
}