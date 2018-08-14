namespace Microservice.Email.Client.API.Contracts
{
    public interface IEmailService
    {
        void SendTextAsync(EmailInfo emailInfo);

        void SendHtmlAsync(EmailInfo emailInfo);
    }

    public class EmailInfo
    {
        public string Title { get; set; }

        public string Message { get; set; }

        public string To { get; set; }
    }
}