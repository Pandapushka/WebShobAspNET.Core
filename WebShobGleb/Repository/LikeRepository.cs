using OnlineShopDB.Models;
using OnlineShopDB.Repository;
using WebShobGleb.Models;

namespace WebShobGleb.Repository
{
    public class LikeRepository : ILikeRepository
    {
        private readonly IProductsRepository _productsRepository;
        public List<UserLikeProducts> likeProducts = new List<UserLikeProducts>();
        public LikeRepository(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public UserLikeProducts TryGetByUserId(string userId)
        {
            var likeProduct = likeProducts.FirstOrDefault(likeProduct => likeProduct.UserId == userId);
            return likeProduct;
        }

        public void Add(int productId, string userId)
        {
            var product = _productsRepository.GetProduct(productId);
            var likeProduct = TryGetByUserId(userId);
            if (likeProduct == null)
            {
                var newLikeItem = new UserLikeProducts()
                {
                    UserId = userId,
                    Products = new List<Product>
                    {
                        product
                    }
                };
                likeProducts.Add(newLikeItem);
            }
            else
            {
                var prod = likeProduct.Products.FirstOrDefault(x =>x.Id == productId);
                if (prod == null)
                {
                    likeProduct.Products.Add(product);
                }
            }
        }

    }
}
