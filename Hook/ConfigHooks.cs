using BoDi;
using Microsoft.Extensions.Configuration;
using OnspringAutomatedUITests.Config;

namespace OnspringAutomatedUITests.Hook
{
    [Binding]
    public class ConfigHooks
    {
        private readonly IObjectContainer _container;

        public ConfigHooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void CreateConfig()
        {
            var config = ConfigurationFactory.GetConfig();
            _container.RegisterInstanceAs<IConfiguration>(config);
        }
    }
}