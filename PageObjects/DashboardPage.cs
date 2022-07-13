using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;

namespace OnspringAutomatedUITests.PageObjects
{
    public class DashboardPage
    {
        private readonly IConfiguration _config;
        private readonly IWebDriver _driver;

        public DashboardPage(IConfiguration config, IWebDriver driver)
        {
            _config = config;
            _driver = driver;
        }

        public string GetUrl()
        {
            var baseUrl = _config.GetSection("Instance")["BaseUrl"];
            return $"{baseUrl}/Dashboard";
        }

        public void NavigateTo()
        {
            var url = GetUrl();
            _driver.Navigate().GoToUrl(url);
        }
    }
}
