using Microsoft.AspNetCore.Mvc;
using WebShobGleb.Models;
using WebShobGleb.Repository;

namespace WebShobGleb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _ordersRepository;
        public OrderController(IOrderRepository ordersRepository)
        {
             _ordersRepository = ordersRepository;
        }
        public IActionResult Orders()
        {
            var orders = _ordersRepository.GetAll();
            return View(orders);
        }
        public IActionResult OrderDetails(Guid orderId)
        {
            var order = _ordersRepository.TryGetById(orderId);
            return View(order);
        }
        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatus orderStatus)
        {
            _ordersRepository.UpdateStatus(orderId, orderStatus);
            return RedirectToAction("Orders");
        }
    }
}
