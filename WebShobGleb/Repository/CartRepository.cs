using OnlineShopDB.Repository;
using WebShobGleb.Models;

namespace WebShobGleb.Repository
{
    public  class CartRepository : ICartRepository
    {
        private readonly IProductsRepository _productsRepository;
        public  List<Cart> carts = new List<Cart>();

        public CartRepository(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public  Cart TryGetByUserId(string userId)
        {
            var cart = carts.FirstOrDefault(cart => cart.UserId == userId);
            return cart;
        }

        public  void Add(int productId, string userId)
        {
            var product = _productsRepository.GetProduct(productId);
            var existingCart = TryGetByUserId(userId);
            var newCartItem = new CartItem
            {
                Amount = 1,
                Product = product
            };
            if (existingCart == null)
            {
                var newCart = new Cart()
                {
                    UserId = userId,
                    Items = new List<CartItem>
                    {
                        newCartItem
                    }
                };
                carts.Add(newCart);
            }
            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(cart => cart.Product.Id == product.Id);
                if (existingCartItem != null)
                {
                    existingCartItem.Amount++;
                }
                else
                {
                    existingCart.Items.Add(newCartItem);
                }
            }
        }
        public void Del(int productId, string userId)
        {
            var product = _productsRepository.GetProduct(productId);
            var existingCart = TryGetByUserId(userId);
            var existingCartItem = existingCart.Items.FirstOrDefault(cart => cart.Product.Id == product.Id);
            existingCartItem.Amount--;
            if (existingCartItem.Amount == 0)
                existingCart.Items.Remove(existingCartItem);
            if (existingCart.Items.Count == 0)
                carts.Remove(existingCart);
        }
        public void Clear(string userId)
        {
            var existingCart = TryGetByUserId(userId);
            carts.Remove(existingCart);
        }
    }
}
