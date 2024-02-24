using System.Net;
using System.Net.Mail;
using SendEmail.Models;

namespace SendEmail.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(Sender sender, Receiver receiver)
        {

            var client = new SmtpClient(sender.Host, sender.Port)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(sender.Email, sender.Password)
            };

            return client.SendMailAsync(
                new MailMessage(from: receiver.Email,
                                to: sender.Email,
                                subject: $"{receiver.Name} - {receiver.Email}",
                                body: receiver.Message
                                ));
        }
    }
}