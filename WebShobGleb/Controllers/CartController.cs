using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Core.Entity;
using Application.Servises;
using WebShobGleb.Mappers;

namespace WebShobGleb.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartController(ICartService cartService, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _cartService = cartService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User); 
            return View(CartMapper.MapToCartVM(_cartService.GetCart(userId, GetTempUserId())));
        }

        public async Task<IActionResult> Add(Guid id)
        {
            var userId = _userManager.GetUserId(User);
            _cartService.AddProductToCart(id, userId, GetTempUserId());
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var userId = _userManager.GetUserId(User);
            _cartService.RemoveProductFromCart(id, userId, GetTempUserId());
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Clear()
        {
            var userId = _userManager.GetUserId(User);
            _cartService.ClearCart(userId, GetTempUserId());
            return RedirectToAction("Index");
        }

        private string GetTempUserId()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null)
            {
                throw new InvalidOperationException("HTTP-контекст недоступен.");
            }

            var tempUserId = httpContext.Session.GetString("TempUserId");
            if (string.IsNullOrEmpty(tempUserId))
            {
                tempUserId = Guid.NewGuid().ToString();
                httpContext.Session.SetString("TempUserId", tempUserId);
            }

            return tempUserId;
        }
    }
}