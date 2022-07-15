using Microsoft.Extensions.Configuration;
using OnspringAutomatedUITests.Constants;
using OnspringAutomatedUITests.PageObjects.Onspring;
using OpenQA.Selenium;

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

        public LoginStepDefinitions(IWebDriver driver, IConfiguration config)
        {
            _config = config;
            _driver = driver;
            _loginPage = new LoginPage(_config, _driver);
            _sharedLayoutPage = new SharedLayoutPage(_config, _driver);
            _dashboardPage = new DashboardPage(_config, _driver);
        }

        [Given(@"a user has navigated to the login page")]
        [Given(@"the user has navigated to the login page")]
        public void GivenAUserHasNavigatedToTheLoginPage()
        {
            _loginPage.NavigateTo();
        }

        [Given(@"the user has attempted to login (.*) times unsuccessfully")]
        public void GivenTheUserHasAttemptedToLoginTimesUnsuccessfully(int attempts)
        {
            for (var i = 0; i < attempts; i++)
            {
                _loginPage.EnterValidUsername();
                _loginPage.EnterInvalidPassword();
                _loginPage.ClickLoginButton();
            }
        }
        
        [Given(@"the user waited (.*) minutes")]
        public void GivenTheUserWaitedMinute(int timeToWait)
        {
            var milliseconds = timeToWait * 70000;
            Thread.Sleep(milliseconds);
        }

        [When(@"the user enters their username")]
        public void WhenTheUserEntersTheirUsername()
        {
            _loginPage.EnterValidUsername();
        }

        [When(@"the user enters their password")]
        public void WhenTheUserEntersTheirPassword()
        {
            _loginPage.EnterValidPassword();
        }

        [When(@"the user clicks on the login button")]
        public void WhenTheUserClicksOnTheLoginButton()
        {
            _loginPage.ClickLoginButton();
        }

        [When(@"the user enters an invalid password")]
        public void WhenTheUserEntersAnInvalidPassword()
        {
            _loginPage.EnterInvalidPassword();
        }

        [When(@"the user enters an invalid username")]
        public void WhenTheUserEntersAnInvalidUsername()
        {
            _loginPage.EnterInvalidUsername();
        }

        [Then(@"the user should be logged in to the instance")]
        public void ThenTheUserShouldBeLoggedInToTheInstance()
        {
            _driver.Url.Should().Be(_dashboardPage.GetUrl());
            var usersName = _config.GetSection("UserCredentials")["ActiveUserName"];
            _sharedLayoutPage.GetUsersName().Should().Be(usersName);
        }

        [Then(@"the user should not be logged in to the instance")]
        public void ThenTheUserShouldNotBeLoggedInToTheInstance()
        {
            _driver.Url.Should().Be(_loginPage.GetUrl());
        }

        [Then(@"the invalid username/password error message should be displayed to the user")]
        public void ThenTheInvalidUsernamePasswordErrorMessageShouldBeDisplayedToTheUser()
        {
            _loginPage.GetValidationSummaryErrors().Should().Contain(LoginPageConstants.UsernamePasswordValidationError);
        }
    }
}
