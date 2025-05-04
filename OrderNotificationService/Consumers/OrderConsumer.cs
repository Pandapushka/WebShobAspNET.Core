using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OrderNotificationService.DTOs;
using OrderNotificationService.Services;

namespace OrderNotificationService.Consumers
{
    public class OrderConsumer : BackgroundService, IAsyncDisposable
    {
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private IConnection? _connection;
        private IChannel? _channel;

        public OrderConsumer(IEmailService emailService, IConfiguration configuration)
        {
            _emailService = emailService;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var mqSettings = _configuration.GetSection("RabbitMQ").Get<RabbitMQSettings>();

            var factory = new ConnectionFactory()
            {
                HostName = mqSettings.HostName,
                UserName = mqSettings.Username,
                Password = mqSettings.Password
            };

            // Создаем подключение
            _connection = await factory.CreateConnectionAsync(stoppingToken);

            // Создаем канал
            _channel = await _connection.CreateChannelAsync(new CreateChannelOptions(false, true, null, null), stoppingToken);

            // Объявляем очередь
            await _channel.QueueDeclareAsync(
                queue: "order_queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null,
                cancellationToken: stoppingToken);

            // Создаем потребителя
            var consumer = new AsyncEventingBasicConsumer(_channel);

            // Подписываемся на событие получения сообщения
            consumer.ReceivedAsync += async (sender, ea) =>
            {
                try
                {
                    // Парсим сообщение
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var @event = JsonSerializer.Deserialize<OrderCreatedEvent>(message);

                    if (@event != null)
                        await _emailService.SendOrderConfirmationEmailAsync(@event);

                    // Подтверждаем обработку
                    await _channel.BasicAckAsync(ea.DeliveryTag, multiple: false, cancellationToken: stoppingToken);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при обработке сообщения: {ex.Message}");

                    // Отклоняем сообщение без повторной постановки в очередь
                    await _channel.BasicNackAsync(ea.DeliveryTag, multiple: false, requeue: false, cancellationToken: stoppingToken);
                }
            };

            // Подписываемся на получение сообщений
            await _channel.BasicConsumeAsync("order_queue", autoAck: false, consumer, stoppingToken);
        }

        // Реализуем IAsyncDisposable вместо DisposeAsync() из BackgroundService
        public async ValueTask DisposeAsync()
        {
            if (_channel is not null)
                await _channel.DisposeAsync();

            if (_connection is not null)
                await _connection.DisposeAsync();
        }
    }
}