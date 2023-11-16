using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.UITests.PageObjectModels
{
    public class TodoOverviewPage
    {

        IWebDriver _webDriver;

        public TodoOverviewPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        public string ProfileButtonText => ProfileButton.Text;
        private IWebElement ProfileButton => 
            _webDriver.FindElement(By.CssSelector("a[title='Manage']"));


    }
}
