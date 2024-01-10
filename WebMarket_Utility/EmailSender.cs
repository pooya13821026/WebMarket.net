using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace WebMarket_Utility
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var fromAddress = new MailAddress("pooya.kar.test@gmail.com", "WebMarket");
            var toAddress = new MailAddress(email);
            string fromPassword = "pooya_kar_test*";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                From = fromAddress,
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            })
            {
                smtp.Send(message);
            }
        }
    }
}
