using OnlineShopDB.Models;
using OnlineShopDB.Repository;
using WebShobGleb.Mappers;
using WebShobGleb.Models;

namespace WebShobGleb.Servises
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductsRepository _productsRepository;

        public CartService(ICartRepository cartRepository, IProductsRepository productsRepository)
        {
            _cartRepository = cartRepository;
            _productsRepository = productsRepository;
        }

        public CartVM GetCart(string userId)
        {
            var cart = _cartRepository.TryGetByUserId(userId);
            return CartMapper.MappingToCartVM(cart);
        }

        public void AddProductToCart(int productId, string userId)
        {
            var product = _productsRepository.GetProduct(productId);
            if (product == null)
            {
                throw new InvalidOperationException("Товар не найден.");
            }

            var existingCart = _cartRepository.TryGetByUserId(userId);
            var newCartItem = new CartItem
            {
                Amount = 1,
                Product = product
            };

            if (existingCart == null)
            {
                var newCart = new Cart
                {
                    UserId = userId,
                    Items = new List<CartItem> { newCartItem }
                };
                _cartRepository.AddCart(newCart);
            }
            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(item => item.Product.Id == productId);
                if (existingCartItem != null)
                {
                    existingCartItem.Amount++;
                }
                else
                {
                    existingCart.Items.Add(newCartItem);
                }
                _cartRepository.UpdateCart(existingCart);
            }
        }

        public void RemoveProductFromCart(int productId, string userId)
        {
            var existingCart = _cartRepository.TryGetByUserId(userId);
            if (existingCart == null)
            {
                throw new InvalidOperationException("Корзина не найдена.");
            }

            var existingCartItem = existingCart.Items.FirstOrDefault(item => item.Product.Id == productId);
            if (existingCartItem == null)
            {
                throw new InvalidOperationException("Товар не найден в корзине.");
            }

            existingCartItem.Amount--;
            if (existingCartItem.Amount == 0)
            {
                existingCart.Items.Remove(existingCartItem);
                _cartRepository.RemoveCartItem(existingCartItem);
            }

            if (existingCart.Items.Count == 0)
            {
                _cartRepository.RemoveCart(existingCart);
            }
            else
            {
                _cartRepository.UpdateCart(existingCart);
            }
        }

        public void ClearCart(string userId)
        {
            var cart = _cartRepository.TryGetByUserId(userId);
            if (cart != null)
            {
                _cartRepository.RemoveCart(cart);
            }
        }
    }
}
