using Microsoft.EntityFrameworkCore;
using OnlineShopDB;
using WebShobGleb.Models;

namespace WebShobGleb.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataBaseContext _dataBaseContext;
        public OrderRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;               
        }
        //public void Add(Order order)
        //{
        //    _dataBaseContext.Orders.Add(order);
        //    _dataBaseContext.SaveChanges();
        //}
        public void Add(Order order)
        {
            try
            {
                _dataBaseContext.Orders.Add(order);
                _dataBaseContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Ошибка при сохранении заказа: {ex.InnerException?.Message}");
                throw;
            }
        }
        public List<Order> GetAll()
        {
            return _dataBaseContext.Orders.ToList();
        }
        public Order TryGetById(Guid orderId)
        {
            return _dataBaseContext.Orders.FirstOrDefault(x => x.Id == orderId);
        }

        public void UpdateStatus(Guid orderId, OrderStatus orderStatus)
        {
            var order = TryGetById(orderId);
            if (_dataBaseContext.Orders != null)
            {
                order.Status = orderStatus;
                _dataBaseContext.SaveChanges();
            }
        }
    }
}
