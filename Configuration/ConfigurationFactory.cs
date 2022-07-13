using Microsoft.Extensions.Configuration;

namespace OnspringAutomatedUITests.Configuration
{
    public static class ConfigurationFactory
    {
        public static IConfiguration GetConfig()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Configuration/appsettings.json")
                .Build();
        }
    }
}
