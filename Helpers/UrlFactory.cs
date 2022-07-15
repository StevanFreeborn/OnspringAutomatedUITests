using Microsoft.Extensions.Configuration;
using OnspringAutomatedUITests.Configuration;

namespace OnspringAutomatedUITests.Helpers
{
    public static class UrlFactory
    {
        private static readonly IConfiguration _config = ConfigurationFactory.GetConfig();

        public static string BuildUrl(string path)
{
            var baseUrl = _config.GetSection("Instance")["BaseUrl"];
            return $"{baseUrl}{path}";
        }
    }
}
