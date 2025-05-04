using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.OrderNotificationService
{
    public class OrderCreatedEvent
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
