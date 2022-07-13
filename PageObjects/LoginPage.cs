using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;

namespace OnspringAutomatedUITests.PageObjects
{
    public class LoginPage
    {
        private readonly IConfiguration _config;
        private readonly IWebDriver _driver;

        public LoginPage(IConfiguration config, IWebDriver driver)
        {
            _config = config;
            _driver = driver;
        }

        private IWebElement UsernameField => _driver.FindElement(By.Id("UserName"));
        private IWebElement PasswordField => _driver.FindElement(By.Id("Password"));
        private IWebElement LoginButton => _driver.FindElement(By.ClassName("signin"));

        public string GetUrl()
        {
            return _config.GetSection("Instance")["BaseUrl"];
        }

        public void NavigateTo()
        {
            var url = GetUrl();
            _driver.Navigate().GoToUrl(url);
        }

        public void EnterUsername()
        {
            UsernameField.Clear();
            var username = _config.GetSection("UserCredentials")["ActiveUserUsername"];
            UsernameField.SendKeys(username);
        }

        public void EnterPassword()
        {
            PasswordField.Clear();
            var password = _config.GetSection("UserCredentials")["ActiveUserPassword"];
            PasswordField.SendKeys(password);
        }

        public void Login()
        {
            LoginButton.Click();
        }
    }
}
