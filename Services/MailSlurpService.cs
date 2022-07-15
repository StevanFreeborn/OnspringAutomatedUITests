using mailslurp.Api;
using mailslurp.Client;
using mailslurp.Model;
using Microsoft.Extensions.Configuration;
using OnspringAutomatedUITests.Config;

namespace OnspringAutomatedUITests.Services
{
    public class MailSlurpService
    {
        private readonly Configuration _mailSlurpConfig;
        private readonly Guid _inboxId;

        public MailSlurpService()
        {
            var config = ConfigurationFactory.GetConfig();

            var apiKey = config.GetSection("MailSlurp")["ApiKey"];
            _mailSlurpConfig = new Configuration();
            _mailSlurpConfig.ApiKey.Add("x-api-key", apiKey);

            _inboxId = new Guid(config.GetSection("MailSlurp")["InboxId"]);
        }

        public Email? GetPasswordResetEmail()
        {
            var mailSlurpApi = new WaitForControllerApi(_mailSlurpConfig);

            var timeout = 60000;
            var unreadOnly = true;
            var since = DateTime.UtcNow;
            var options = new List<MatchOption> { new MatchOption(MatchOption.FieldEnum.SUBJECT, MatchOption.ShouldEnum.CONTAIN, "Reset Password") };
            var matchOptions = new MatchOptions(options);

            try
            {
                return mailSlurpApi.WaitForMatchingFirstEmail(_inboxId, matchOptions, timeout, unreadOnly, since);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
