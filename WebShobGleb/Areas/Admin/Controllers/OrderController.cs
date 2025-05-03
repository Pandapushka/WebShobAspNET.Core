using Core.Entity.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core.Constans;
using WebShobGleb.Models;
using WebShobGleb.Repository;
using WebShobGleb.Servises;
using Application.Servises;
using WebShobGleb.Mappers;

namespace WebShobGleb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Constant.AdminRoleName)]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public IActionResult Orders()
        {           
            var ordersVM = OrderMapper.MapToOrderVMList(_orderService.GetAll());
            return View(ordersVM);
        }
        public IActionResult OrderDetails(Guid orderId)
        {
            var order = OrderMapper.MapToOrderVM(_orderService.TryGetById(orderId));
            return View(order);
        }
        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatus orderStatus)
        {
            _orderService.UpdateStatus(orderId, orderStatus);
            return RedirectToAction("Orders");
        }
    }
}
