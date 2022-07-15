using System;
using Microsoft.Extensions.Configuration;
using OnspringAutomatedUITests.Constants;
using OnspringAutomatedUITests.PageObjects.Onspring;
using OnspringAutomatedUITests.Services;
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
        private readonly MailSlurpService _mailSlurpService;
        public ResetPasswordStepDefinitions(IConfiguration config, IWebDriver driver, MailSlurpService mailSlurpService)
        {
            _config = config;
            _driver = driver;
            _loginPage = new LoginPage(config, driver);
            _forgotPasswordPage = new ForgotPasswordPage(config, driver);
            _mailSlurpService = mailSlurpService;
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

        [When(@"the user clicks the reset via email button")]
        public void WhenClicksTheResetViaEmailButton()
        {
            _forgotPasswordPage.ClickResetViaEmailButtion();
        }

        [When(@"the user clicks on the forgot password link")]
        public void WhenTheUserClicksOnTheForgotPasswordLink()
        {
            _loginPage.ClickForgotPasswordLink();
        }

        [Then(@"the user will be taken to the forgot password page")]
        public void ThenTheUserWillBeTakenToTheForgotPasswordPage_()
        {
            _driver.Url.Should().Be(_forgotPasswordPage.GetUrl());
        }

        [Then(@"the reset password message should be displayed")]
        public void ThenTheResetPasswordMessageShouldBeDisplayed_()
        {
            var confirmation = _forgotPasswordPage.GetConfirmationMessage();
            confirmation.Should().Contain(ForgotPasswordPageConstants.ResetPasswordConfirmationHeader);
            confirmation.Should().Contain(ForgotPasswordPageConstants.ResetPasswordConfirmationMessageActiveUsername);
            confirmation.Should().Contain(ForgotPasswordPageConstants.ResetPasswordConfirmationMessageInactiveUsername);
        }

        [Then(@"the user should receive a password reset email")]
        public void ThenTheUserShouldReceiveAPasswordResetEmail()
        {
            var email = _mailSlurpService.GetPasswordResetEmail();
            email.Should().NotBeNull();

            if (email != null)
            {
                email.From.Should().Be("noreply@onspring.com");
                email.Subject.Should().Be("Reset Password");
            }
        }
    }
}
