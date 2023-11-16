using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMI.UITests.Helpers
{
    public class SharedWebDriver : ChromeDriver
    {
        public SharedWebDriver() : base(GetOptions())
        {
        }

        private static ChromeOptions GetOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless");
            return options;
        }
    }
}