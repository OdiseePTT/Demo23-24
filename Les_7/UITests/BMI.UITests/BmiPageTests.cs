using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BMI.UITests
{
    public class BmiPageTests : IDisposable
    {
        IWebDriver _webDriver;
        public BmiPageTests()
        {
            _webDriver = new ChromeDriver();

        }

        public void Dispose()
        {
            _webDriver.Quit();
        }

        [Fact]
        public void OnInitialLoadCalculateButtonIsDisabled()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:7020");

            Thread.Sleep(5);

            IWebElement calculateButton = _webDriver.FindElement(By.TagName("button"));

            calculateButton.Enabled.Should().BeFalse();
        }

        [Fact]
        public void WhenFieldsFilledCalculateButtonISEnabled()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:7020");

            Thread.Sleep(5);
            IWebElement heightField = _webDriver.FindElement(By.Name("height"));
            IWebElement weightField = _webDriver.FindElement(By.Name("weight"));
            IWebElement calculateButton = _webDriver.FindElement(By.TagName("button"));

            // Optie 1
            heightField.SendKeys("180");
            weightField.SendKeys("80");
            heightField.Click();

            // Optie 2
            heightField.SendKeys("180" + Keys.Enter);
            weightField.SendKeys("80" + Keys.Enter);

            calculateButton.Enabled.Should().BeTrue();
            weightField.GetAttribute("class").Should().Be("");
        }

        [Fact]
        public void WithCorrectFieldsAndCalculateClickedH4IsDisplayed()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:7020");

            Thread.Sleep(5);
            IWebElement heightField = _webDriver.FindElement(By.Name("height"));
            IWebElement weightField = _webDriver.FindElement(By.Name("weight"));
            IWebElement calculateButton = _webDriver.FindElement(By.TagName("button"));

            // Optie 1
            heightField.SendKeys("180" + Keys.Enter);
            weightField.SendKeys("80" + Keys.Enter);

            calculateButton.Click();

            IWebElement h4element = _webDriver.FindElement(By.TagName("h4"));

            h4element.Displayed.Should().BeTrue();
        }
    }
}