using SendEmail.Models;

namespace SendEmail.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(Sender sender, Receiver receiver);
    }
}