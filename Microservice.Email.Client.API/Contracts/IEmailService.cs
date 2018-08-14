namespace Microservice.Email.Client.API.Contracts
{
    public interface IEmailService
    {
        void SendTextAsync(EmailInfo emailInfo, EmailCredentials credentials);

        void SendHtmlAsync(EmailInfo emailInfo, EmailCredentials credentials);
    }

    public class EmailInfo
    {
        public string Title { get; set; }

        public string Message { get; set; }

        public string Sender { get; set; }

        public string Receiver { get; set; }
    }

    public class EmailCredentials
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

}