using WebShobGleb.Models;

namespace WebShobGleb.Repository
{
    public interface ICartRepository
    {
        Cart TryGetByUserId(string userId);
        void Add(int productId, string userId);
        void Del(int productId, string userId);
        void Clear(string userId);
    }
}
