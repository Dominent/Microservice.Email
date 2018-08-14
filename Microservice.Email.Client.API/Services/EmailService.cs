namespace Microservice.Email.Client.API.Controllers
{
    using Microservice.Email.Client.API.Contracts;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Net;
    using System.Net.Mail;

    public class GmailService : IEmailService
    {
        private IConfiguration _configuration;

        public GmailService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public void SendHtmlAsync(EmailInfo emailInfo, EmailCredentials credentials)
        {
            var message = BuildEmailMessage(emailInfo);

            message.IsBodyHtml = true;

            this.BuildEmailClient(credentials)
                    .SendMailAsync(message);
        }

        public void SendTextAsync(EmailInfo emailInfo, EmailCredentials credentials)
        {
            this.BuildEmailClient(credentials)
                  .SendMailAsync(BuildEmailMessage(emailInfo));
        }

        private MailMessage BuildEmailMessage(EmailInfo emailInfo)
        {
            return new MailMessage(emailInfo.Sender, emailInfo.Receiver)
            {
                Subject = emailInfo.Title,
                Body = emailInfo.Message
            };
        }

        private SmtpClient BuildEmailClient(EmailCredentials credentials)
        {
            var host = this._configuration["Email:Host"];
            var port = Int32.Parse(this._configuration["Email:Port"]);

            return new SmtpClient
            {
                Host = host,
                Port = port,
                EnableSsl = true,
                Credentials = new NetworkCredential(credentials.Username, credentials.Password)
            };
        }
    }
}
