using OnlineShopDB.Repository;
using WebShobGleb.Mappers;
using WebShobGleb.Models;

namespace WebShobGleb.Servises
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;

        public LikeService(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public UserLikeProductsVM GetUserLikeProducts(string userId)
        {
            var likeProducts = _likeRepository.TryGetByUserId(userId);
            return UserLikeProductsMapper.MapToUserLikeProductsVM(likeProducts);
        }

        public void AddLike(int productId, string userId)
        {
            _likeRepository.Add(productId, userId);
        }

        public void DeleteLike(int productId, string userId)
        {
            _likeRepository.Delete(productId, userId);
        }
    }
}
