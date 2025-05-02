using Core.Entity.Enums;

namespace WebShobGleb.Servises
{
    public interface IOrderService
    {
        OrderVM GetOrderVMForUser(string userId);
        OrderVM RebuildOrderVM(OrderVM orderVM, string userId);
        void CreateOrder(OrderVM orderVM, string userId);
        List<OrderVM> GetAll();
        OrderVM TryGetById(Guid orderId);
        void UpdateStatus(Guid orderId, OrderStatus orderStatus);
    }
}
