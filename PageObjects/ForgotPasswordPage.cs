using Microsoft.Extensions.Configuration;
using OnspringAutomatedUITests.Helpers;
using OpenQA.Selenium;

namespace OnspringAutomatedUITests.PageObjects
{
    public class ForgotPasswordPage
    {
        private readonly string _path = "/Public/ForgotPassword";
        private readonly IConfiguration _config;
        private readonly IWebDriver _driver;

        public ForgotPasswordPage(IConfiguration config, IWebDriver driver)
        {
            _config = config;
            _driver = driver;
        }

        private IWebElement UsernameField => _driver.FindElement(By.Id("UserName"));
        private IWebElement ResetViaEmailButton => _driver.FindElement(By.ClassName("signin"));
        private IWebElement ForgotPasswordConfirmation => _driver.FindElement(By.ClassName("forgot-password-sent"));

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

        public void ClickResetViaEmailButtion()
        {
            ResetViaEmailButton.Click();
        }

        public string GetConfirmationMessage()
        {
            return ForgotPasswordConfirmation.GetAttribute("innerText");
        }
    }
}
