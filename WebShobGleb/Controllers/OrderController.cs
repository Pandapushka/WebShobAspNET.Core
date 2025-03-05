using Microsoft.AspNetCore.Mvc;
using WebShobGleb.Const;
using WebShobGleb.Halpers;
using WebShobGleb.Models;
using WebShobGleb.Models.DTO;
using WebShobGleb.Repository;

namespace WebShobGleb.Controllers
{
    public class OrderController : Controller
    {
       
        private readonly ICartRepository cartsRepository;
        private readonly IOrderRepository orderRepository;

        public OrderController(ICartRepository cartsRepository, IOrderRepository orderRepository)
        {
            this.cartsRepository = cartsRepository;
            this.orderRepository = orderRepository;
        }
        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            var cartAndOrderData = HalperFromOrder.MapCartToCartAndOrderData(cart);
            return View(cartAndOrderData);
        }

        [HttpPost]
        public IActionResult Make(CartAndOrderData userOrder)
        {
            //To DU сделать все по человечески 
            userOrder.UserId = Constants.UserId;
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            userOrder.Items = cart.Items;
            userOrder.Amount = cart.Amount;
            userOrder.Cost = cart.Cost;
            if (userOrder.Name != null && userOrder.Phone != null)
            {
                if (!userOrder.Name.All(c => char.IsLetter(c) || c == ' '))
                {
                    ModelState.AddModelError("", "ФИО должны содержать только буквы");
                }
                if (!userOrder.Phone.All(c => char.IsDigit(c) || "+()- ".Contains(c)))
                {
                    ModelState.AddModelError("", "Номер телефона может содержать только цифры и символы '+()-'");
                }
            }
            if (!ModelState.IsValid)
            {
                return View("Index", userOrder);
            }
            var order = HalperFromOrder.FormOrder(userOrder);
            order.Cart = cartsRepository.TryGetByUserId(Constants.UserId);
            orderRepository.Add(order);
            cartsRepository.Clear(Constants.UserId);
            return View("Success", order);
        }
    }
}
