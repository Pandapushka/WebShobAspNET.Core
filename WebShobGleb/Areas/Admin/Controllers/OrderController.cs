using Microsoft.AspNetCore.Mvc;
using WebShobGleb.Models;
using WebShobGleb.Repository;
using WebShobGleb.Servises;

namespace WebShobGleb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public IActionResult Orders()
        {           
            var ordersVM = _orderService.GetAll();
            return View(ordersVM);
        }
        public IActionResult OrderDetails(Guid orderId)
        {
            var order = _orderService.TryGetById(orderId);
            return View(order);
        }
        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatus orderStatus)
        {
            _orderService.UpdateStatus(orderId, orderStatus);
            return RedirectToAction("Orders");
        }
    }
}
