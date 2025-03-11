using WebShobGleb.Models;

namespace WebShobGleb.Servises
{
    public interface ICartService
    {
        CartVM GetCart(string userId);
        void AddProductToCart(int productId, string userId);
        void RemoveProductFromCart(int productId, string userId);
        void ClearCart(string userId);
    }
}
