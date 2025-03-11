using Microsoft.EntityFrameworkCore;
using OnlineShopDB.Models;

namespace OnlineShopDB.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly IProductsRepository _productsRepository;
        private readonly DataBaseContext _databaseContext;

        public CartRepository(DataBaseContext databaseContext, IProductsRepository productsRepository)
        {
            _databaseContext = databaseContext;
            _productsRepository = productsRepository;
        }

        public Cart TryGetByUserId(string userId)
        {
            var cart = _databaseContext.Carts.Include(x => x.Items).ThenInclude(el => el.Product).FirstOrDefault(cart => cart.UserId == userId);
            return cart;
        }

        public void Add(int productId, string userId)
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
                _databaseContext.Carts.Add(newCart);
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
            _databaseContext.SaveChanges();

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
                _databaseContext.Carts.Remove(existingCart);
            _databaseContext.SaveChanges();
        }
        public void Clear(string userId)
        {
            var сart = TryGetByUserId(userId);
            if (сart != null)
            {
                _databaseContext.CartItems.RemoveRange(_databaseContext.CartItems.Where(i => i.Cart.Id == сart.Id));
                _databaseContext.Carts.Remove(сart);
                _databaseContext.SaveChanges();
            }
        }
    }
}
