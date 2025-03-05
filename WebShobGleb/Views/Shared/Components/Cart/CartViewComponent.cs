using Microsoft.AspNetCore.Mvc;
using WebShobGleb.Const;
using WebShobGleb.Repository;

namespace WebShobGleb.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        ICartRepository cartsRepository;

        public CartViewComponent(ICartRepository cartsRepository)
        {
            this.cartsRepository = cartsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            var productCounts = cart?.Amount;
            return View("Cart", productCounts);
        }
    }
}
