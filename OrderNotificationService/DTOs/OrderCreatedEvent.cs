using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderNotificationService.DTOs
{
    public class OrderCreatedEvent
    {
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
