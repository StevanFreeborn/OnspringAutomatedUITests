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
        private IWebElement ValidationSummaryErrors => _driver.FindElement(By.ClassName("validation-summary-errors"));

        public string GetUrl()
        {
            var baseUrl = _config.GetSection("Instance")["BaseUrl"];
            return $"{baseUrl}/Public/Login";
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

        public void EnterValidPassword()
        {
            PasswordField.Clear();
            var password = _config.GetSection("UserCredentials")["ActiveUserPassword"];
            PasswordField.SendKeys(password);
        }

        public void EnterInvalidPassword()
        {
            PasswordField.Clear();
            var password = new Guid().ToString();
            PasswordField.SendKeys(password);
        }

        public void Login()
        {
            LoginButton.Click();
        }

        public string GetValidationSummaryErrors()
        {
            return ValidationSummaryErrors.GetAttribute("innerText");
        }

        internal void EnterInvalidUsername()
        {
            UsernameField.Clear();
            var username = new Guid().ToString();
            UsernameField.SendKeys(username);
        }
    }
}
