using Application.DTOs;

namespace Application.Servises
{
    public interface ICartService
    {
        CartDTO GetCart(string userId, string tempUser);
        void AddProductToCart(Guid productId, string userId, string tempUser);
        void RemoveProductFromCart(Guid productId, string userId, string tempUser);
        void ClearCart(string userId, string tempUser);
        void MergeCarts(string tempUserId, string userId);
    }
}
