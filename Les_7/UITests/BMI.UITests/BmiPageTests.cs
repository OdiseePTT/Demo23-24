using BMI.UITests.Helpers;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BMI.UITests
{
    public class BmiPageTests : IDisposable, IClassFixture<SharedWebDriver>
    {
        private IWebDriver _webDriver;
        private string _url = "https://localhost:8000";
        private WebTestingHostFactory<BMIProgram> _factory;

        public BmiPageTests(SharedWebDriver driver)
        {
            _webDriver = driver;
            _factory = new WebTestingHostFactory<BMIProgram>();
            _factory.WithWebHostBuilder(builder => builder.UseUrls(_url)).CreateDefaultClient();
        }

        public void Dispose()
        {
            _factory.Dispose();
        }

        [Fact]
        public void OnInitialLoadCalculateButtonIsDisabled()
        {
            _webDriver.Navigate().GoToUrl(_url);

            Thread.Sleep(5);

            IWebElement calculateButton = _webDriver.FindElement(By.TagName("button"));

            calculateButton.Enabled.Should().BeFalse();
        }

        [Fact]
        public void WhenFieldsFilledCalculateButtonISEnabled()
        {
            _webDriver.Navigate().GoToUrl(_url);

            Thread.Sleep(50);
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
        }

        [Fact]
        public void WithCorrectFieldsAndCalculateClickedH4IsDisplayed()
        {
            _webDriver.Navigate().GoToUrl(_url);

            Thread.Sleep(50);
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