using Application.DTOs;
using Core.Entity;

namespace Application.Mappers
{
    public class CartDTOMapper
    {
        public static Cart ToCart(CartDTO cartVM)
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
        public static List<CartItem> ToCartItem(List<CartItemDTO> cartDbItems)
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
        public static CartDTO MappingToCartDTO(Cart cart)
        {
            if (cart == null)
                return null;
            var cartVM = new CartDTO()
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = ToCartItemDTO(cart.Items)
            };
            return cartVM;
        }
        public static List<CartItemDTO> ToCartItemDTO(List<CartItem> cartDbItems)
        {
            var cartItems = new List<CartItemDTO>();
            foreach (var cartDbItem in cartDbItems)
            {
                var cartItem = new CartItemDTO()
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
