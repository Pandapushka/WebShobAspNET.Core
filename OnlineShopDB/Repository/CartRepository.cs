using Microsoft.EntityFrameworkCore;
using OnlineShopDB.Models;

namespace OnlineShopDB.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly DataBaseContext _databaseContext;

        public CartRepository(DataBaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Cart TryGetByUserId(string userId)
        {
            return _databaseContext.Carts
                .Include(x => x.Items)
                .ThenInclude(el => el.Product)
                .FirstOrDefault(cart => cart.UserId == userId);
        }

        public void AddCart(Cart cart)
        {
            _databaseContext.Carts.Add(cart);
            _databaseContext.SaveChanges();
        }

        public void UpdateCart(Cart cart)
        {
            _databaseContext.Carts.Update(cart);
            _databaseContext.SaveChanges();
        }

        public void RemoveCart(Cart cart)
        {
            _databaseContext.Carts.Remove(cart);
            _databaseContext.SaveChanges();
        }

        public void RemoveCartItem(CartItem cartItem)
        {
            _databaseContext.CartItems.Remove(cartItem);
            _databaseContext.SaveChanges();
        }
    }
}
