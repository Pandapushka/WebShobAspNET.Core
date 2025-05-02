
namespace Core.Entity
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreateDateTime { get; set; }
        public decimal Cost { get; set; }

        public Order()
        {
            Status = OrderStatus.Created;
            CreateDateTime = DateTime.Now;
        }

    }
}
