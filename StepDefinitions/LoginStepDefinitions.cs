using Microsoft.Extensions.Configuration;
using OnspringAutomatedUITests.Hook;
using OnspringAutomatedUITests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OnspringAutomatedUITests.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        public readonly IConfiguration _config;
        public readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;
        private readonly SharedLayoutPage _sharedLayoutPage;
        private readonly DashboardPage _dashboardPage;

        public LoginStepDefinitions()
        {
            _config = Hooks.config;
            _driver = Hooks.driver;
            _loginPage = new LoginPage(_config, _driver);
            _sharedLayoutPage = new SharedLayoutPage(_config, _driver);
            _dashboardPage = new DashboardPage(_config, _driver);
        }

        [Given(@"a user has navigated to the login page")]
        public void GivenAUserHasNavigatedToTheLoginPage()
        {
            _loginPage.NavigateTo();
        }

        [When(@"the user enters their username")]
        public void WhenTheUserEntersTheirUsername()
        {
            _loginPage.EnterUsername();
        }

        [When(@"the user enters their password")]
        public void WhenTheUserEntersTheirPassword()
        {
            _loginPage.EnterValidPassword();
        }

        [When(@"the user clicks on the login button")]
        public void WhenTheUserClicksOnTheLoginButton()
        {
            _loginPage.Login();
        }

        [When(@"the user enters an invalid password")]
        public void WhenTheUserEntersAnInvalidPassword()
        {
            _loginPage.EnterInvalidPassword();
        }

        [Then(@"the user should be logged in to the instance")]
        public void ThenTheUserShouldBeLoggedInToTheInstance()
        {
            _driver.Url.Should().Be(_dashboardPage.GetUrl());
            _sharedLayoutPage.GetUsersName().Should().Be("Stevan Freeborn");
        }

        [Then(@"the user should not be logged in to the instance")]
        public void ThenTheUserShouldNotBeLoggedInToTheInstance()
        {
            _driver.Url.Should().Be(_loginPage.GetUrl());
        }

        [Then(@"the invalid username/password error message should be displayed to the user")]
        public void ThenTheInvalidUsernamePasswordErrorMessageShouldBeDisplayedToTheUser()
        {
            _loginPage.GetValidationSummaryErrors().Should().Contain("Username/Password combination is not valid");
        }
    }
}
