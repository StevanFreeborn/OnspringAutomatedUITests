using System;
using Microsoft.Extensions.Configuration;
using OnspringAutomatedUITests.Constants;
using OnspringAutomatedUITests.PageObjects;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace OnspringAutomatedUITests.StepDefinitions
{
    [Binding]
    public class ResetPasswordStepDefinitions
    {
        private readonly IConfiguration _config;
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;
        private readonly ForgotPasswordPage _forgotPasswordPage;

        public ResetPasswordStepDefinitions(IConfiguration config, IWebDriver driver)
        {
            _config = config;
            _driver = driver;
            _loginPage = new LoginPage(config, driver);
            _forgotPasswordPage = new ForgotPasswordPage(config, driver);
        }

        [Given(@"a user has navigated to the forgot password page")]
        public void GivenAUserHasNavigatedToTheForgotPasswordPage()
        {
            _forgotPasswordPage.NavigateTo();
        }

        [When(@"the user enters their username on the forgot password page")]
        public void WhenTheUserEntersTheirUsernameOnTheForgotPasswordPage()
        {
            _forgotPasswordPage.EnterValidUsername();
        }

        [When(@"clicks the reset via email button")]
        public void WhenClicksTheResetViaEmailButton()
        {
            _forgotPasswordPage.ClickResetViaEmailButtion();
        }

        [When(@"the user clicks on the forgot password link")]
        public void WhenTheUserClicksOnTheForgotPasswordLink()
        {
            _loginPage.ClickForgotPasswordLink();
        }

        [Then(@"the user will be taken to the forgot password page\.")]
        public void ThenTheUserWillBeTakenToTheForgotPasswordPage_()
        {
            _driver.Url.Should().Be(_forgotPasswordPage.GetUrl());
        }

        [Then(@"the reset password message should be displayed\.")]
        public void ThenTheResetPasswordMessageShouldBeDisplayed_()
        {
            var confirmation = _forgotPasswordPage.GetConfirmationMessage();
            confirmation.Should().Contain(ForgotPasswordPageConstants.ResetPasswordConfirmationHeader);
            confirmation.Should().Contain(ForgotPasswordPageConstants.ResetPasswordConfirmationMessageActiveUsername);
            confirmation.Should().Contain(ForgotPasswordPageConstants.ResetPasswordConfirmationMessageInactiveUsername);
        }
    }
}
