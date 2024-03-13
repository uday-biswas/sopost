// using Api.DTOs.Account;
// using Mailjet.Client;
// using Mailjet.Client.TransactionalEmails;
// using Microsoft.Extensions.Configuration;
// using System.Threading.Tasks;

// namespace Api.Services
// {
//     public class EmailService
//     {
//         private readonly IConfiguration _config;

//         public EmailService(IConfiguration config)
//         {
//             _config = config;
//         }

//         public async Task<bool> SendEmailAsync(EmailSendDto emailSend)
//         {
//             MailjetClient client = new MailjetClient(_config["MailJet:ApiKey"], _config["MailJet:SecretKey"]);

//             var email = new TransactionalEmailBuilder()
//                  .WithFrom(new SendContact(_config["Email:From"], _config["Email:ApplicationName"]))
//                  .WithSubject(emailSend.Subject)
//                  .WithHtmlPart(emailSend.Body)
//                  .WithTo(new SendContact(emailSend.To))
//                  .Build();

//             var response = await client.SendTransactionalEmailAsync(email);
//             if (response.Messages != null)
//             {
//                 if (response.Messages[0].Status == "success")
//                 {
//                     return true;
//                 }
//             }

//             return false;
//         }
//     }
// }

using Api.DTOs.Account;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;

namespace Api.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<bool> SendEmailAsync(EmailSendDto emailSend)
        {
            // MailjetClient client = new MailjetClient(_config["MailJet:ApiKey"], _config["MailJet:SecretKey"]);
            MimeMessage message = new MimeMessage();
            var Port = Int32.Parse(_config["Email:Port"]);

            message.From.Add(new MailboxAddress(_config["Email:SenderName"], _config["Email:SenderEmail"]));
            message.To.Add(new MailboxAddress("deva", emailSend.To));
            message.Subject = emailSend.Subject;
            message.Body = new TextPart(TextFormat.Html) { Text = emailSend.Body };

            using (var smtp = new SmtpClient())
            {
                smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;

                await smtp.ConnectAsync(_config["Email:Server"], Port, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_config["Email:Username"], _config["Email:Password"]);
                await smtp.SendAsync(message);
                await smtp.DisconnectAsync(true);
            }
            return true;
        }
    }
}
