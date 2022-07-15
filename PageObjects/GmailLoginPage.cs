using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;

namespace OnspringAutomatedUITests.PageObjects
{
    public class GmailLoginPage
    {
        private readonly IConfiguration _config;
        private readonly IWebDriver _driver;

        public GmailLoginPage(IConfiguration config, IWebDriver driver)
        {
            _config = config;
            _driver = driver;
        }

        private IWebElement UsernameField => _driver.FindElement(By.Id("identifierId"));
        private IWebElement UsernameNextButton => _driver.FindElement(By.Id("identifierNext"));
        private IWebElement PasswordField => _driver.FindElement(By.Name("password"));
        private IWebElement PasswordNextButton => _driver.FindElement(By.Name("passwordNext"));

        public string GetUrl()
        {
            return "https://mail.google.com";
        }

        public void NavigateTo()
        {
            var url = GetUrl();
            _driver.Navigate().GoToUrl(url);
        }

        public void EnterValidUsername()
        {
            UsernameField.Clear();
            var username = _config.GetSection("GmailCredentials")["GmailUsername"];
            UsernameField.SendKeys(username);
        }

        public void EnterValidPassword()
        {
            PasswordField.Clear();
            var password = _config.GetSection("GmailCredentials")["GmailPassword"];
            PasswordField.SendKeys(password);
        }

        public void ClickUsernameNextButton()
        {
            UsernameNextButton.Click();
        }

        public void ClickPasswordNextButton()
        { 
            PasswordNextButton.Click();
        }

    }
}
