
using WebShobGleb.Models;

namespace WebShobGleb.Servises
{
    public interface ILikeService
    {
        UserLikeProductsVM GetUserLikeProducts(string userId);
        void AddLike(Guid productId, string userId);
        void DeleteLike(Guid productId, string userId);
    }
}
