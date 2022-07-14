using BoDi;
using OnspringAutomatedUITests.Drivers;
using OpenQA.Selenium;

namespace OnspringAutomatedUITests.Hook
{
    [Binding]
    public class WebDriverHooks
    {
        private readonly IObjectContainer _container;

        public WebDriverHooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void CreateWebDriver()
        {
            var driver = DriverFactory.GetDriver();

            _container.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void DestroyWebDriver()
        {
            var driver = _container.Resolve<IWebDriver>();

            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}