using Core.Entity;
using OnlineShopDB.Repository;
using WebShobGleb.Mappers;
using WebShobGleb.Models;

namespace WebShobGleb.Servises
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IProductsRepository _productsRepository;

        public LikeService(ILikeRepository likeRepository, IProductsRepository productsRepository)
        {
            _likeRepository = likeRepository;
            _productsRepository = productsRepository;
        }

        public UserLikeProductsVM GetUserLikeProducts(string userId)
        {
            var likeProducts = _likeRepository.TryGetByUserId(userId);
            return UserLikeProductsMapper.MapToUserLikeProductsVM(likeProducts);
        }

        public void AddLike(Guid productId, string userId)
        {
            var product = _productsRepository.GetById(productId);

            var likeProduct = _likeRepository.TryGetByUserId(userId);

            if (likeProduct == null)
            {
                var newLikeItem = new UserLikeProducts
                {
                    UserId = userId,
                    Products = new List<Product> { product }
                };
                _likeRepository.Add(newLikeItem);
            }
            else
            {
                var existingProduct = likeProduct.Products.FirstOrDefault(p => p.Id == productId);
                if (existingProduct == null)
                {
                    likeProduct.Products.Add(product);
                }
            }

            _likeRepository.SaveChanges();
        }

        public void DeleteLike(Guid productId, string userId)
        {
            var likeProduct = _likeRepository.TryGetByUserId(userId);
            if (likeProduct != null)
            {
                var productToRemove = likeProduct.Products.FirstOrDefault(p => p.Id == productId);
                if (productToRemove != null)
                {
                    likeProduct.Products.Remove(productToRemove);
                    _likeRepository.SaveChanges();
                }
            }
        }
    }
}
