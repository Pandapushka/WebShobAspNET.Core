using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopDB.Models;
using OnlineShopDB.Repository;
using WebShobGleb.Const;
using WebShobGleb.Mappers;
using WebShobGleb.Repository;
using WebShobGleb.Servises;

namespace WebShobGleb.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartService _cartService;
        private readonly UserManager<User> _userManager;
        ICartRepository cartsRepository;

        public CartViewComponent(ICartRepository cartsRepository, ICartService cartService, UserManager<User> userManager)
        {
            this.cartsRepository = cartsRepository;
            _cartService = cartService;
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var userId = _userManager.GetUserId((System.Security.Claims.ClaimsPrincipal)User);
            var cart = _cartService.GetCart(userId);
            var productCounts = cart?.Amount;
            return View("Cart", productCounts);
        }
    }
}
