using OnlineShopDB.Repository;
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

        public OrderVM GetOrderVMForUser(string userId)
        {
            var cart = _cartsRepository.TryGetByUserId(userId);
            return OrderMapper.MapCartToOrderVM(cart);
        }

        // так как если валидация не проходит модель возвращается пустой, метод нужен для обновления списка товаров в модели
        public OrderVM RebuildOrderVM(OrderVM orderVM, string userId)
        {
            var cart = _cartsRepository.TryGetByUserId(userId);
            orderVM.Items = cart.Items.Select(item => new CartItemVM
            {
                Id = item.Id,
                Product = item.Product,
                Amount = item.Amount
            }).ToList();
            return orderVM;
        }

        public void CreateOrder(OrderVM orderVM, string userId)
        {
            var order = OrderMapper.OrderForDb(orderVM, _cartsRepository.TryGetByUserId(userId));
            _ordersRepository.Add(order);
            _cartsRepository.Clear(userId);
        }
    }
}
