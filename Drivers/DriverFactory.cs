using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OnspringAutomatedUITests.Drivers
{
    public static class DriverFactory
    {
        public static IWebDriver GetDriver()
        {
            return new ChromeDriver();
        }
    }
}
