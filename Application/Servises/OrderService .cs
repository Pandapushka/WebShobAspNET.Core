using Application.DTOs;
using Core.Entity.Enums;
using Core.Repository;
using WebShobGleb.Mappers;

namespace Application.Servises
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
        public OrderDTO TryGetById(Guid orderId)
        { 
            var order = _ordersRepository.TryGetById(orderId);
            return OrderMapperDTO.MapOrderToOrderVM(order);
        }

        public List<OrderDTO> GetAll()
        {
            return OrderMapperDTO.MapOrdersToOrderVMs(_ordersRepository.GetAll());
        }

        public OrderDTO GetOrderVMForUser(string userId)
        {
            return OrderMapperDTO.MapCartToOrderVM(_cartsRepository.TryGetByUserId(userId));
        }

        public OrderDTO RebuildOrderVM(OrderDTO orderVM, string userId)
        {
            var cart = _cartsRepository.TryGetByUserId(userId);
            orderVM.Items = cart.Items.Select(item => new OrderItemDTO
            {
                Id = item.Id,
                Product = item.Product,
                Amount = item.Amount
            }).ToList();
            return orderVM;
        }

        public void CreateOrder(OrderDTO orderVM, string userId)
        {
            orderVM = RebuildOrderVM(orderVM, userId);
            var order = OrderMapperDTO.OrderForDb(orderVM, _cartsRepository.TryGetByUserId(userId));
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
