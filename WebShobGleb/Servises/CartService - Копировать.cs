using OnlineShopDB.Repository;
using WebShobGleb.Mappers;
using WebShobGleb.Models;

namespace WebShobGleb.Servises
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public CartVM GetCart(string userId)
        {
            var cart = _cartRepository.TryGetByUserId(userId);
            return CartMapper.MappingToCartVM(cart);
        }

        public void AddProductToCart(int productId, string userId)
        {
            _cartRepository.Add(productId, userId);
        }

        public void RemoveProductFromCart(int productId, string userId)
        {
            _cartRepository.Del(productId, userId);
        }

        public void ClearCart(string userId)
        {
            _cartRepository.Clear(userId);
        }
    }
}
