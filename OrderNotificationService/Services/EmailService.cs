﻿using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using OrderNotificationService.DTOs;

namespace OrderNotificationService.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> options)
        {
            _settings = options.Value;
        }

        public async Task SendOrderConfirmationEmailAsync(OrderCreatedEvent @event)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_settings.FromEmail));
            email.To.Add(MailboxAddress.Parse(@event.Email));
            email.Subject = "Ваш заказ оформлен";

            var builder = new BodyBuilder();
            builder.TextBody = $"Здравствуйте, {@event.Name}, ваш заказ на сумму {@event.TotalAmount:C} успешно оформлен.\n\nС уважением,\nКоманда интернет-магазина";

            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_settings.SmtpServer, _settings.Port, SecureSocketOptions.StartTls, CancellationToken.None);
            await smtp.AuthenticateAsync(_settings.Username, _settings.Password, CancellationToken.None);
            await smtp.SendAsync(email, CancellationToken.None);
            await smtp.DisconnectAsync(true, CancellationToken.None);
        }
    }
}
