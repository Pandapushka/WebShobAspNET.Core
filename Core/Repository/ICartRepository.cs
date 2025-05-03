using Core.Entity;
using Core.Repository.BaseRepository;

namespace Core.Repository
{
    public interface ICartRepository : IRepository<Cart>
    {
        Cart TryGetByUserId(string userId);
        void RemoveCartItem(CartItem cartItem);
        void Remove(Cart cart);
    }
}
