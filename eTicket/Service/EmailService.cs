using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using eTicket.Models;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using Microsoft.EntityFrameworkCore;
using System.Text;
using eTicket.Data;

namespace eTicket.Service
{
    public class EmailService : IEmailService
    {
        private const string templatePath = @"EmailTemplate/{0}.html";
        private readonly SMTPConfigModel _smtpConfig;

        private readonly AppDbContext _db;

        public EmailService(AppDbContext db, IOptions<SMTPConfigModel> smtpConfig)
        {
            _db = db;
            _smtpConfig = smtpConfig.Value;
        }

        public async Task <EmailTemplate> GetId(int id)
        {
            return await _db.EmailTemplates.FirstOrDefaultAsync(x => x.id == id);
            
        }
       
        
        public async Task SendEmailTemplate(UserEmailOptions userEmailOptions)
        {

            //Get Email Data  
           

            EmailTemplate emailData = await GetId(2);



            userEmailOptions.Subject = UpdatePlaceHolders(emailData.subject, userEmailOptions.PlaceHolders);
            

            userEmailOptions.ToEmail = new List<string> { UpdatePlaceHolders(emailData.key_name, userEmailOptions.PlaceHolders) };

            userEmailOptions.EmailBody = UpdatePlaceHolders(emailData.body, userEmailOptions.PlaceHolders);


            await SendEmail(userEmailOptions);

        }




        private async Task SendEmail(UserEmailOptions userEmailOptions)
        {
            MailMessage mail = new MailMessage()
            {
                Subject = userEmailOptions.Subject,
                Body = userEmailOptions.EmailBody,
                From = new MailAddress(_smtpConfig.SenderAddress, _smtpConfig.SenderDisplayName),
                IsBodyHtml = _smtpConfig.IsBodyHTML
            };

            foreach (var toEmail in userEmailOptions.ToEmail)
            {
                mail.To.Add(toEmail);
            }
            NetworkCredential networkCredential = new NetworkCredential(_smtpConfig.UserName, _smtpConfig.Password);
            // smtpClient.Credentials = new System.Net.NetworkCredential(address, password);

            SmtpClient smtpClient = new SmtpClient
            {
                Host = _smtpConfig.Host,
                Port = _smtpConfig.Port,
                EnableSsl = _smtpConfig.EnableSSL,
                UseDefaultCredentials = _smtpConfig.UseDefaultCredentials,
                Credentials = networkCredential
            };
            mail.BodyEncoding = Encoding.Default;


            // smtpClient.Send(mail);

            await smtpClient.SendMailAsync(mail);

        }
        private string GetEmailBody(string templateName)
        {
            var body = File.ReadAllText(string.Format(templatePath, templateName));
            return body;
        }

        private string UpdatePlaceHolders(string text, List<KeyValuePair<string, string>> keyValuePairs)
        {
            if (!string.IsNullOrEmpty(text) && keyValuePairs != null)
            {
                foreach (var placeholder in keyValuePairs)
                {
                    if (text.Contains(placeholder.Key))
                    {
                        text = text.Replace(placeholder.Key, placeholder.Value);
                    }
                }
            }

            return text;
        }

        
        
    }

}
