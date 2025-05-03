using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Core.Entity;
using Application.Servises;
using WebShobGleb.Mappers;

namespace WebShobGleb.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<User> _userManager;

        public OrderController(IOrderService orderService, UserManager<User> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            // Получаем модель заказа для текущего пользователя
            var userId = _userManager.GetUserId(User);
            var orderVM = OrderMapper.MapToOrderVM(_orderService.GetOrderVMForUser(userId));
            return View(orderVM);
        }

        [HttpPost]
        public IActionResult Make(OrderVM orderVM)
        {
            var userId = _userManager.GetUserId(User);
            if (!ModelState.IsValid)
            {
                // Если модель недействительна, обновляем список товаров в модели
                orderVM = OrderMapper.MapToOrderVM(_orderService.RebuildOrderVM(OrderMapper.MapToOrderDTO(orderVM), userId));
                return View("Index", orderVM);
            }

            // Если модель действительна, создаем заказ
            _orderService.CreateOrder(OrderMapper.MapToOrderDTO(orderVM), userId);
            return View("Success", orderVM);
        }
    }
}
