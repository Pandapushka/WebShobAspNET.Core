using Application.DTOs;
using Core.Entity.Enums;

namespace Application.Servises
{
    public interface IOrderService
    {
        OrderDTO GetOrderVMForUser(string userId);
        OrderDTO RebuildOrderVM(OrderDTO orderVM, string userId);
        void CreateOrder(OrderDTO orderVM, string userId);
        List<OrderDTO> GetAll();
        OrderDTO TryGetById(Guid orderId);
        void UpdateStatus(Guid orderId, OrderStatus orderStatus);
    }
}
