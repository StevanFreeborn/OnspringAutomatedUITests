using Microsoft.Extensions.Configuration;

namespace OnspringAutomatedUITests.Config
{
    public static class ConfigurationFactory
    {
        public static IConfiguration GetConfig()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Config/appsettings.json")
                .Build();
        }
    }
}
