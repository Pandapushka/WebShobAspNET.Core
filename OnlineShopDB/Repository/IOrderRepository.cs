using Core.Entity;
using OnlineShopDB.Repository.BaseRepository;

namespace WebShobGleb.Repository
{
    public interface IOrderRepository : IRepository<Order>
    {
        List<Order> GetAll();
        Order TryGetById(Guid orderId);
        void UpdateStatus(Guid orderId, OrderStatus orderStatus);
    }
}