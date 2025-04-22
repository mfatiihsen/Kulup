

using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace kulup.Service
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpClient _smtpClient;


        public EmailSender(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }

        public Task SendEmailAsync(string email, string subject, string body)
        {
            var mailMessage = new MailMessage("no-reply@example.com", email, subject, body);
            return _smtpClient.SendMailAsync(mailMessage);
        }
    }
}