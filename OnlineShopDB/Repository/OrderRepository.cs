using Microsoft.EntityFrameworkCore;
using Core.Entity;
using Core.Entity.Enums;

namespace Core.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(DataBaseContext dataBaseContext)
            : base(dataBaseContext)
        {
        }

        public List<Order> GetAll()
        {
            return _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .OrderByDescending(o => o.CreateDateTime)
                .ToList();
        }

        public Order TryGetById(Guid orderId)
        {
            return _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefault(x => x.Id == orderId);
        }

        public void UpdateStatus(Guid orderId, OrderStatus orderStatus)
        {
            var order = GetById(orderId);
            if (order != null)
            {
                order.Status = orderStatus;
                Update(order);
            }
        }
    }
}
