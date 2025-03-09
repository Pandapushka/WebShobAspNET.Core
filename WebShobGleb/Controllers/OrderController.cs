using Microsoft.AspNetCore.Mvc;
using WebShobGleb.Const;
using WebShobGleb.Models;
using WebShobGleb.Servises;

namespace WebShobGleb.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            // Получаем модель заказа для текущего пользователя
            var orderVM = _orderService.GetOrderVMForUser(Constants.UserId);
            return View(orderVM);
        }

        [HttpPost]
        public IActionResult Make(OrderVM orderVM)
        {
            if (!ModelState.IsValid)
            {
                // Если модель недействительна, обновляем список товаров в модели
                orderVM = _orderService.RebuildOrderVM(orderVM, Constants.UserId);
                return View("Index", orderVM);
            }

            // Если модель действительна, создаем заказ
            _orderService.CreateOrder(orderVM, Constants.UserId);
            return View("Success", orderVM);
        }
    }
}
