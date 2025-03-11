
using WebShobGleb.Models;

namespace WebShobGleb.Servises
{
    public interface ILikeService
    {
        UserLikeProductsVM GetUserLikeProducts(string userId);
        void AddLike(int productId, string userId);
        void DeleteLike(int productId, string userId);
    }
}
