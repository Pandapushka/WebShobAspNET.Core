using Core.Entity.Enums;
using Core.Repository;
using WebShobGleb.Mappers;
using WebShobGleb.Models;
using WebShobGleb.Repository;

namespace WebShobGleb.Servises
{
    public class OrderService : IOrderService
    {
        private readonly ICartRepository _cartsRepository;
        private readonly IOrderRepository _ordersRepository;

        public OrderService(ICartRepository cartsRepository, IOrderRepository ordersRepository)
        {
            _cartsRepository = cartsRepository;
            _ordersRepository = ordersRepository;
        }
        public OrderVM TryGetById(Guid orderId)
        { 
            var order = _ordersRepository.TryGetById(orderId);
            return OrderMapper.MapOrderToOrderVM(order);
        }

        public List<OrderVM> GetAll()
        {
            return OrderMapper.MapOrdersToOrderVMs(_ordersRepository.GetAll());
        }

        public OrderVM GetOrderVMForUser(string userId)
        {
            return OrderMapper.MapCartToOrderVM(_cartsRepository.TryGetByUserId(userId));
        }

        public OrderVM RebuildOrderVM(OrderVM orderVM, string userId)
        {
            var cart = _cartsRepository.TryGetByUserId(userId);
            orderVM.Items = cart.Items.Select(item => new OrderItemVM
            {
                Id = item.Id,
                Product = item.Product,
                Amount = item.Amount
            }).ToList();
            return orderVM;
        }

        public void CreateOrder(OrderVM orderVM, string userId)
        {
            orderVM = RebuildOrderVM(orderVM, userId);
            var order = OrderMapper.OrderForDb(orderVM, _cartsRepository.TryGetByUserId(userId));
            _ordersRepository.Add(order);
            var cart = _cartsRepository.TryGetByUserId(userId);
            _cartsRepository.Remove(cart);
        }
        public void UpdateStatus(Guid orderId, OrderStatus orderStatus)
        {
            _ordersRepository.UpdateStatus(orderId, orderStatus);
        }
    }
}
