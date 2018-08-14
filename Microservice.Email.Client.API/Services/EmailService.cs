namespace Microservice.Email.Client.API.Controllers
{
    using Microservice.Email.Client.API.Contracts;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Net;
    using System.Net.Mail;

    public class GmailService : IEmailService
    {
        private string _username;
        private string _password;
        private SmtpClient _client;
        private IConfiguration _configuration;

        public GmailService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public GmailService(string username, string password)
        {
            this._username = username;
            this._password = password;

            this.Initialize();
        }

        private void Initialize()
        {
            var host = this._configuration["Email:Host"];
            var port = Int32.Parse(this._configuration["Email:Port"]);

            this._client = new SmtpClient
            {
                Host = host,
                Port = port,
                EnableSsl = true,
                Credentials = new NetworkCredential(this._username, this._password)
            };
        }

        public void SendHtmlAsync(EmailInfo emailInfo)
        {
            var message = BuildEmailMessage(emailInfo);

            message.IsBodyHtml = true;

            this._client.SendMailAsync(message);
        }

        public void SendTextAsync(EmailInfo emailInfo)
        {
            this._client.SendMailAsync(BuildEmailMessage(emailInfo));
        }

        private MailMessage BuildEmailMessage(EmailInfo emailInfo)
        {
            return new MailMessage(this._username, emailInfo.To) {
                Subject = emailInfo.Title,
                Body = emailInfo.Message
            };
        }
    }
}
