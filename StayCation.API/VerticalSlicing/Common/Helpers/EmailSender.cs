using Azure.Core;
using System.Net.Mail;
using System.Net;
using StayCation.API.VerticalSlicing.Common.DTOs;

namespace StayCation.API.VerticalSlicing.Common.Helpers
{
    public static class EmailSender
    {
        public async static void SendEmail(EmailSenderDTO emailSenderDTO)
        {
            var senderEmail = "hassan.adel1298@gmail.com";
            var senderPassword = "uwtu lqeh wedz vmjy";


            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(senderEmail, senderPassword),
                EnableSsl = true

            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress(senderEmail),
                Subject = emailSenderDTO.Subject,
                Body = emailSenderDTO.Body,
                IsBodyHtml = true
            };
            mailMessage.To.Add(emailSenderDTO.ToEmail);

            await client.SendMailAsync(mailMessage);

        }
    }
}
