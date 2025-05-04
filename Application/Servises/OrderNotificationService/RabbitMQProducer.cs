using Application.DTOs.OrderNotificationService;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Servises.OrderNotificationService
{
    public class RabbitMQProducer : IRabbitMQProducer
    {
        private readonly RabbitMQSettings _settings;

        public RabbitMQProducer(IOptions<RabbitMQSettings> options)
        {
            _settings = options.Value;
        }

        public async Task SendOrderCreatedMessageAsync(OrderCreatedEvent message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _settings.HostName,
                UserName = _settings.Username,
                Password = _settings.Password
            };

            // Асинхронное создание подключения
            await using var connection = await factory.CreateConnectionAsync();

            // Асинхронное создание канала
            await using var channel = await connection.CreateChannelAsync();

            // Объявляем очередь (если ещё не существует)
            await channel.QueueDeclareAsync(queue: "order_queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

            // Сериализуем сообщение
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

            // Отправляем сообщение в очередь
            await channel.BasicPublishAsync(exchange: "", routingKey: "order_queue", body: body);
        }
    }
}
