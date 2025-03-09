using Microsoft.AspNetCore.Mvc;
using OnlineShopDB.Repository;
using WebShobGleb.Const;
using WebShobGleb.Mappers;
using WebShobGleb.Repository;

namespace WebShobGleb.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public IActionResult Index()
        {
            var cart = _cartRepository.TryGetByUserId(Constants.UserId);
            return View(CartMapper.MappingToCartVM(cart));
        }
        public IActionResult Add(int Id)
        {
            _cartRepository.Add(Id, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            _cartRepository.Del(Id, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            _cartRepository.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
