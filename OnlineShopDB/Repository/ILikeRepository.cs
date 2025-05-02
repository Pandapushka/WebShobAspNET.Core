using Core.Entity;
using OnlineShopDB.Repository.BaseRepository;

namespace Core.Repository
{
    public interface ILikeRepository : IRepository<UserLikeProducts>
    {
        UserLikeProducts TryGetByUserId(string userId);
        void SaveChanges();
    }
}
