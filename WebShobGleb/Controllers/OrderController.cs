using Microsoft.AspNetCore.Mvc;
using OnlineShopDB.Repository;
using WebShobGleb.Const;
using WebShobGleb.Halpers;
using WebShobGleb.Mappers;
using WebShobGleb.Models;
using WebShobGleb.Repository;

namespace WebShobGleb.Controllers
{
    public class OrderController : Controller
    {

        private readonly ICartRepository _cartsRepository;
        private readonly IOrderRepository _ordersRepository;


        public OrderController(ICartRepository cartsRepository, IOrderRepository orderRepository)
        {
            _cartsRepository = cartsRepository;
            _ordersRepository = orderRepository;
        }
        public IActionResult Index()
        {
            var cart = _cartsRepository.TryGetByUserId(Constants.UserId);
            var order = new OrderVM();
            var orderVM = OrderMapper.ToOrderVM(cart, order);
            return View(orderVM);
        }
        [HttpPost]
        public IActionResult Make(OrderVM orderVM)
        {


            if (!orderVM.Name.All(c => char.IsLetter(c) || c == ' '))
            {
                ModelState.AddModelError("", "ФИО должны содержать только буквы");
            }
            if (!orderVM.Phone.All(c => char.IsDigit(c) || "+()- ".Contains(c)))
            {
                ModelState.AddModelError("", "Номер телефона может содержать только цифры и символы '+()-'");
            }
            if (!ModelState.IsValid)
            {
                return View("Index", orderVM);
            }
            orderVM = OrderMapper.ToOrderVM(_cartsRepository.TryGetByUserId(Constants.UserId), orderVM);
            var order = OrderMapper.OrderForDb(orderVM, _cartsRepository.TryGetByUserId(Constants.UserId));
            _ordersRepository.Add(order);
            _cartsRepository.Clear(Constants.UserId);
            return View("Success", orderVM);
        }
    }
}
