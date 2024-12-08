﻿using MimeKit;
using StudentManagementSystem.Entities.E_mail;

namespace StudentManagementSystem.Repository
{
    public class EmailServiceProvider
    {
        private readonly EmailConfig _config;
        public EmailServiceProvider(EmailConfig config)
        {
            _config = config;
        }
        public async Task SendMail(MailModel mailModel)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_config.FromName, _config.FromAddress));
            message.To.Add(new MailboxAddress("", mailModel.To));
            message.Subject = mailModel.Subject;
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = mailModel.Body,
            };

            using var client = new MailKit.Net.Smtp.SmtpClient();
            client.Connect(_config.SmtpServer, _config.Port, true);
            client.Authenticate(_config.UserName, _config.Password);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}