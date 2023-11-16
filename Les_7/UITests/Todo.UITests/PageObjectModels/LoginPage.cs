using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.UITests.PageObjectModels
{
    public class LoginPage
    {
        IWebDriver _webDriver;

        public LoginPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        private IWebElement EmailField => _webDriver.FindElement(By.Name("Input.Email"));
        private IWebElement PasswordField => _webDriver.FindElement(By.Name("Input.Password"));
        private IWebElement LoginButton => _webDriver.FindElement(By.Id("login-submit"));


        public void SetEmail(string text)
        {
            EmailField.SendKeys(text);
        }
        public void SetPassword(string text)
        {
            PasswordField.SendKeys(text);
        }

        public void SubmitLogin()
        {
            LoginButton.Submit();
        }
    }
}
