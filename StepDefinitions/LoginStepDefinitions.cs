using Microsoft.Extensions.Configuration;
using OnspringAutomatedUITests.Hook;
using OnspringAutomatedUITests.PageObjects;
using OpenQA.Selenium;

namespace OnspringAutomatedUITests.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        public readonly IConfiguration _config;
        public readonly IWebDriver _driver;
        private readonly LoginPage  _loginPage;
        private readonly DashboardPage _dashboardPage;

        public LoginStepDefinitions()
        {
            _config = Hooks.config;
            _driver = Hooks.driver;
            _loginPage = new LoginPage(_config, _driver);
            _dashboardPage = new DashboardPage(_config, _driver);
        }

        [Given(@"a user has navigated to the login page")]
        public void GivenAUserHasNavigatedToTheLoginPage()
        {
            _loginPage.NavigateTo();
        }

        [When(@"the user clicks on the username field")]
        [When(@"the user enters their username")]
        public void WhenTheUserEntersTheirUsername()
        {
            _loginPage.EnterUsername();
        }

        [When(@"the user clicks on the password field")]
        [When(@"the user enters their password")]
        public void WhenTheUserEntersTheirPassword()
        {
            _loginPage.EnterPassword();
        }

        [When(@"the user clicks on the login button")]
        public void WhenTheUserClicksOnTheLoginButton()
        {
            _loginPage.Login();
        }

        [Then(@"the user should be logged in to the instance")]
        public void ThenTheUserShouldBeLoggedInToTheInstance()
        {
            _dashboardPage.GetUsersName().Should().Be("Stevan Freeborn");
            _driver.Quit();
        }
    }
}
