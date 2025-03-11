using OnlineShopDB.Models;

namespace OnlineShopDB.Repository
{
    public interface ICartRepository
    {
        Cart TryGetByUserId(string userId);
        void AddCart(Cart cart);
        void UpdateCart(Cart cart);
        void RemoveCart(Cart cart);
        void RemoveCartItem(CartItem cartItem);
    }
}
