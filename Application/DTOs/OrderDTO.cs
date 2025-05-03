using Core.Entity.Enums;
using System.ComponentModel.DataAnnotations;


namespace Application.DTOs
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public Guid CartVMId { get; set; }
        public string UserId { get; set; }

        public List<OrderItemDTO> Items { get; set; } = new List<OrderItemDTO>();

        public OrderStatus Status { get; set; }
        public DateTime CreateDataTime { get; set; }

        public decimal Cost
        {
            get
            {
                return Items?.Sum(x => x.Cost) ?? 0;
            }
        }

        public OrderDTO()
        {
            Items = new List<OrderItemDTO>(); // Инициализация пустым списком
        }
    }
}