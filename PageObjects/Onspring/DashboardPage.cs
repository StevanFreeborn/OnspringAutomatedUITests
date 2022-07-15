using Microsoft.Extensions.Configuration;
using OnspringAutomatedUITests.Helpers;
using OpenQA.Selenium;

namespace OnspringAutomatedUITests.PageObjects.Onspring
{
    public class DashboardPage
    {
        private readonly string _path = "/Dashboard";
        private readonly IConfiguration _config;
        private readonly IWebDriver _driver;

        public DashboardPage(IConfiguration config, IWebDriver driver)
        {
            _config = config;
            _driver = driver;
        }

        public string GetUrl()
        {
            return UrlFactory.BuildUrl(_path);
        }

        public void NavigateTo()
        {
            var url = GetUrl();
            _driver.Navigate().GoToUrl(url);
        }
    }
}
