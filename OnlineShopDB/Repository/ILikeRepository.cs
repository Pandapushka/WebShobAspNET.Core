using OnlineShopDB.Models;

namespace OnlineShopDB.Repository
{
    public interface ILikeRepository
    {
        UserLikeProducts TryGetByUserId(string userId);
        void Add(int productId, string userId);
        void Delete(int productId, string userId);
    }
}
