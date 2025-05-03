using Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository
{

    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        private readonly DataBaseContext _databaseContext;
        public CartRepository(DataBaseContext databaseContext)
            : base(databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Remove(Cart cart)
        {
            _databaseContext.Carts.Remove(cart);
            _databaseContext.SaveChanges();
        }

        public Cart TryGetByUserId(string userId)
        {
            return _context.Carts
                .Include(x => x.Items)
                .ThenInclude(el => el.Product)
                .FirstOrDefault(cart => cart.UserId == userId);
        }

        public void RemoveCartItem(CartItem cartItem)
        {
            _context.CartItems.Remove(cartItem);
            _context.SaveChanges();
        }
    }

}
