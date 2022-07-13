using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;

namespace OnspringAutomatedUITests.PageObjects
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
