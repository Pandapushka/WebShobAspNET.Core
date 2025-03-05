using WebShobGleb.Models;

namespace WebShobGleb.Repository
{
    public interface ILikeRepository
    {
        UserLikeProducts TryGetByUserId(string userId);
        void Add(int productId, string userId);
    }
}
