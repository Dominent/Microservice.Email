namespace Microservice.Email.Client.API.Contracts
{
    using System.Threading.Tasks;

    public interface IEmailService
    {
        Task SendAsync(EmailInfo emailInfo);
    }

    public class EmailInfo
    {
        public string Title { get; set; }

        public string Message { get; set; }

        public string To { get; set; }
    }
}