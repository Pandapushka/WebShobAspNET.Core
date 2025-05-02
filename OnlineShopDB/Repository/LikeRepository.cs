using Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopDB.Repository
{
    public class LikeRepository : BaseRepository<UserLikeProducts>, ILikeRepository
    {
        private readonly DataBaseContext _databaseContext;

        public LikeRepository(DataBaseContext databaseContext) : base(databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public UserLikeProducts? TryGetByUserId(string userId)
        {
            return _databaseContext.UserLikeProducts
                .Include(x => x.Products)
                .FirstOrDefault(likeProduct => likeProduct.UserId == userId);
        }

        public void SaveChanges()
        {
            _databaseContext.SaveChanges();
        }
    }
}