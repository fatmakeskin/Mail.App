using Business.Extension;
using Data.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.SendMailServices
{
    public class SendMailService : ISendMailService
    {
        private readonly MailSettings mailSettings;
        public SendMailService(IOptions<MailSettings> settings)
        {
            mailSettings = settings.Value;
        }

        public async Task SendMailAsync(SendMailModel sendMailModel)
        {
            try
            {
                using (var smtp = new SmtpClient())
                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress(mailSettings.Mail);
                    mail.To.Add(sendMailModel.MailTo);
                    mail.Subject = sendMailModel.MailSubject;
                    mail.Body = sendMailModel.MailBody;

                    smtp.Port = mailSettings.Port;
                    smtp.Credentials = new NetworkCredential(mailSettings.Mail, mailSettings.Password);
                    smtp.EnableSsl = true;

                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //return Task.FromResult(0);
        }
    }
}
