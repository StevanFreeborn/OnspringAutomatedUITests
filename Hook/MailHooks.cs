using BoDi;
using OnspringAutomatedUITests.Drivers;
using OnspringAutomatedUITests.Services;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace OnspringAutomatedUITests.Hook
{
    [Binding]
    public sealed class MailHooks
    {
        private readonly IObjectContainer _container;

        public MailHooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario("mailslurp")]
        public void CreateMailSlurpService()
        {
            var mailSurpService = new MailSlurpService();

            _container.RegisterInstanceAs<MailSlurpService>(mailSurpService);
        }
    }
}