using Microsoft.AspNetCore.Mvc;
using SendEmail.Models;
using SendEmail.Services;

namespace SendEmail.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendEmailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;

        public SendEmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost]
        //public IActionResult Send(string from, string subject, string body)
        public async Task<IActionResult> Send(string emailSender, string passwordSender, string hostSender, int portSender, string emailReceiver, string nameReceiver, string messageReceiver)
        {
            Sender sender = new Sender(emailSender, passwordSender, hostSender, portSender);
            Receiver receiver = new Receiver(emailReceiver, nameReceiver, messageReceiver);
            try
            {
                await _emailSender.SendEmailAsync(sender, receiver);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Send");
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("running");
        }
    }
}