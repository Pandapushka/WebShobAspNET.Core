using Core.Entity;
using Core.Entity.Enums;
using OnlineShopDB.Repository.BaseRepository;

namespace Core.Repository
{
    public interface IOrderRepository : IRepository<Order>
    {
        List<Order> GetAll();
        Order TryGetById(Guid orderId);
        void UpdateStatus(Guid orderId, OrderStatus orderStatus);
    }
}