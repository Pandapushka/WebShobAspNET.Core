using Core.Entity;
using OnlineShopDB.Repository.BaseRepository;

namespace OnlineShopDB.Repository
{
    public interface ILikeRepository : IRepository<UserLikeProducts>
    {
        UserLikeProducts TryGetByUserId(string userId);
        void SaveChanges();
    }
}
