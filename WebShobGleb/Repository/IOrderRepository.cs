using WebShobGleb.Models;

namespace WebShobGleb.Repository
{
    public interface IOrderRepository
    {
        void Add(Order order);
        List<Order> GetAll();
        Order TryGetById(Guid orderId);
        void UpdateStatus(Guid orderId, OrderStatus orderStatus);
    }
}