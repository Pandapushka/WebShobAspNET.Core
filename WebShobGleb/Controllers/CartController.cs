using Microsoft.AspNetCore.Mvc;
using OnlineShopDB.Repository;
using WebShobGleb.Const;
using WebShobGleb.Mappers;
using WebShobGleb.Servises;

namespace WebShobGleb.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        public IActionResult Index()
        {
            return View(_cartService.GetCart(Constants.UserId));
        }
        public IActionResult Add(int Id)
        {
            _cartService.AddProductToCart(Id, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            _cartService.RemoveProductFromCart(Id, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            _cartService.ClearCart(Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
