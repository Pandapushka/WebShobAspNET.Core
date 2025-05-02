using WebShobGleb.Models;

namespace WebShobGleb.Servises
{
    public interface ICartService
    {
        CartVM GetCart(string userId);
        void AddProductToCart(Guid productId, string userId);
        void RemoveProductFromCart(Guid productId, string userId);
        void ClearCart(string userId);
        void MergeCarts(string tempUserId, string userId);
    }
}
