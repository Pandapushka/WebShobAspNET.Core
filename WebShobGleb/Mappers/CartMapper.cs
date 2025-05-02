using Core.Entity;
using WebShobGleb.Models;

namespace WebShobGleb.Mappers
{
    public class CartMapper
    {
        public static Cart ToCart(CartVM cartVM)
        {
            if (cartVM == null)
                return null;
            var cart = new Cart()
            {
                Id = cartVM.Id,
                UserId = cartVM.UserId,
                Items = ToCartItem(cartVM.Items)
            };
            return cart;
        }
        public static List<CartItem> ToCartItem(List<CartItemVM> cartDbItems)
        {
            var cartItems = new List<CartItem>();
            foreach (var cartDbItem in cartDbItems)
            {
                var cartItem = new CartItem()
                {
                    Id = cartDbItem.Id,
                    Amount = cartDbItem.Amount,
                    Product = cartDbItem.Product,
                };
                cartItems.Add(cartItem);
            }
            return cartItems;

        }
        public static CartVM MappingToCartVM(Cart cart)
        {
            if (cart == null)
                return null;
            var cartVM = new CartVM()
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = ToCartItemViewModel(cart.Items)
            };
            return cartVM;
        }
        public static List<CartItemVM> ToCartItemViewModel(List<CartItem> cartDbItems)
        {
            var cartItems = new List<CartItemVM>();
            foreach (var cartDbItem in cartDbItems)
            {
                var cartItem = new CartItemVM()
                {
                    Id = cartDbItem.Id,
                    Amount = cartDbItem.Amount,
                    Product = cartDbItem.Product,
                };
                cartItems.Add(cartItem);
            }
            return cartItems;
        }
    }
}
