using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using sampleApp.Models;

namespace sampleApp.Common
{
    public static class EmailSender
    {
        public static async Task SendEmailAsync(List<string> recipients, string cc, string subject, string body, List<string> attachments)
        {
            if (ApplicationState.IsDebug)
            {
                Console.WriteLine("Email not sent. Application in debug mode.");
                return;
            }

            using (MailMessage mailMessage = new MailMessage())
            {

                AddRecipients(mailMessage, recipients);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.From = new MailAddress("notify@ustcorp.net");

                if (cc != null)
                    mailMessage.CC.Add(cc);

                AddAttachments(mailMessage, attachments);

                await SendMessageAsync(mailMessage);

                foreach (Attachment a in mailMessage.Attachments) //dispose of attachments
                    a.Dispose();
            }
        }

        private static void AddRecipients(MailMessage message, List<string> recipients)
        {
            foreach (string recipient in recipients)
                message.To.Add(recipient);
        }

        private static void AddAttachments(MailMessage message, List<string> attachments)
        {
            if (attachments != null)
            {
                foreach (string attachStr in attachments)
                {
                    Attachment attachment = new Attachment(attachStr);
                    message.Attachments.Add(attachment);
                }
            }
        }

        private static async Task SendMessageAsync(MailMessage message)
        {
            SmtpClient smtpClient = new SmtpClient
            {
                Credentials = config.SMTP.EmailCredential,
                Host = config.SMTP.Host,
                Port = config.SMTP.Port,
                EnableSsl = config.SMTP.EnableSSL
            };

            await Task.Run(() => smtpClient.Send(message));
        }
    }
}
