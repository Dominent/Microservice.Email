namespace Microservice.Email.Client.API.Controllers
{
    using Microservice.Email.Client.API.Contracts;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;

    public class GmailService : IEmailService
    {
        private const string GMAIL_SMTP_SERVER_HOST = "smtp.gmail.com";
        private const int GMAIL_SMTP_SERVER_PORT = 587;

        private string _username;
        private string _password;

        public GmailService(string username, string password)
        {
            this._username = username;
            this._password = password;
        }

        public async Task SendAsync(EmailInfo emailInfo)
        {
            var smtpClient = new SmtpClient
            {
                Host = GMAIL_SMTP_SERVER_HOST,
                Port = GMAIL_SMTP_SERVER_PORT,
                EnableSsl = true,
                Credentials = new NetworkCredential(this._username, this._password)
            };

            using (var message = new MailMessage(this._username, emailInfo.To)
                { Subject = emailInfo.Title, Body = emailInfo.Message })
            {
                await smtpClient.SendMailAsync(message);
            }
        }
    }
}
