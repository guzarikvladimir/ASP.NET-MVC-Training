using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace MVCPL.Infrastructure
{
    public static class MailSender
    {
        public static void SendEmail(string emailFrom, string emailTo, string subject, string body,
            string userName, string password)
        {
            MailMessage message = new MailMessage(
                new MailAddress(emailFrom),
                new MailAddress(emailTo))
            {
                Subject = subject,
                BodyEncoding = Encoding.UTF8,
                Body = body,
                IsBodyHtml = true,
                SubjectEncoding = Encoding.UTF8
            };
            SmtpClient client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Credentials = new NetworkCredential(userName, password),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            client.Send(message);
        }
    }
}