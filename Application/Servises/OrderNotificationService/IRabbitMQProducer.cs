using Application.DTOs.OrderNotificationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Servises.OrderNotificationService
{
    public interface IRabbitMQProducer
    {
        Task SendOrderCreatedMessageAsync(OrderCreatedEvent message);
    }
}
