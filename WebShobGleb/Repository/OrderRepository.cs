using WebShobGleb.Models;

namespace WebShobGleb.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private List<Order> orders = new List<Order>();
        public void Add(Order order)
        {
            orders.Add(order);
        }
        public List<Order> GetAll()
        {
            return orders;
        }
        public Order TryGetById(Guid orderId)
        {
            return orders.FirstOrDefault(x => x.Id == orderId);
        }

        public void UpdateStatus(Guid orderId, OrderStatus orderStatus)
        {
            var order = TryGetById(orderId);
            if (orders != null)
                order.Status = orderStatus;
        }
    }
}
