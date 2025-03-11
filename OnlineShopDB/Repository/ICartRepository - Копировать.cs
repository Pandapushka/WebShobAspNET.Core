using OnlineShopDB.Models;

namespace OnlineShopDB.Repository
{
    public interface ICartRepository
    {
        Cart TryGetByUserId(string userId);
        void Add(int productId, string userId);
        void Del(int productId, string userId);
        void Clear(string userId);
    }
}
