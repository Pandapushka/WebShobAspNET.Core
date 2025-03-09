using WebShobGleb.Models;

namespace WebShobGleb.Servises
{
    public interface IOrderService
    {
        OrderVM GetOrderVMForUser(string userId);
        OrderVM RebuildOrderVM(OrderVM orderVM, string userId);
        void CreateOrder(OrderVM orderVM, string userId);
    }
}
