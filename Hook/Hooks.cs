using Microsoft.Extensions.Configuration;
using OnspringAutomatedUITests.Configuration;
using OnspringAutomatedUITests.Drivers;
using OpenQA.Selenium;

namespace OnspringAutomatedUITests.Hook
{
    [Binding]
    public static class Hooks
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public static IConfiguration config;
        public static IWebDriver driver;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


        [BeforeScenario]
        public static void BeforeTestRun()
        {
            config = ConfigurationFactory.GetConfig();
            driver = DriverFactory.GetDriver();
        }

        [AfterScenario]
        public static void AfterTestRun()
        {
            driver!.Quit();
        }
    }
}