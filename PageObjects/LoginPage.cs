using Microsoft.Extensions.Configuration;
using OnspringAutomatedUITests.Helpers;
using OpenQA.Selenium;

namespace OnspringAutomatedUITests.PageObjects
{
    public class LoginPage
    {
        private readonly string _path = "/Public/Login";
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
        private IWebElement ForgotPasswordLink => _driver.FindElement(By.LinkText("Forgot Password?"));

        public string GetUrl()
        {
            return UrlFactory.BuildUrl(_path);
        }

        public void NavigateTo()
        {
            var url = GetUrl();
            _driver.Navigate().GoToUrl(url);
        }

        public void EnterValidUsername()
        {
            UsernameField.Clear();
            var username = _config.GetSection("UserCredentials")["ActiveUserUsername"];
            UsernameField.SendKeys(username);
        }

        public void EnterInvalidUsername()
        {
            UsernameField.Clear();
            var username = new Guid().ToString();
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

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public string GetValidationSummaryErrors()
        {
            return ValidationSummaryErrors.GetAttribute("innerText");
        }

        public void ClickForgotPasswordLink()
        {
            ForgotPasswordLink.Click();
        }
    }
}
