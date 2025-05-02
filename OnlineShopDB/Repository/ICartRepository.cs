using Core.Entity;
using OnlineShopDB.Repository.BaseRepository;

namespace OnlineShopDB.Repository
{
    public interface ICartRepository : IRepository<Cart>
    {
        Cart TryGetByUserId(string userId);
        void RemoveCartItem(CartItem cartItem);
        void Remove(Cart cart);
    }
}
