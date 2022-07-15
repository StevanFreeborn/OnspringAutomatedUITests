using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;

namespace OnspringAutomatedUITests.PageObjects.Onspring
{
    public class SharedLayoutPage
    {
        private readonly IWebDriver _driver;

        public SharedLayoutPage(IConfiguration config, IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement Username => _driver.FindElement(By.Id("user-name"));

        public string GetUsersName()
        {
            return Username.GetAttribute("innerText");
        }
    }
}
