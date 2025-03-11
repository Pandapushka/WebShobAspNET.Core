using Microsoft.EntityFrameworkCore;
using OnlineShopDB.Models;

namespace OnlineShopDB.Repository
{
    public class LikeRepository : ILikeRepository
    {
        private readonly IProductsRepository _productsRepository;
        private readonly DataBaseContext _databaseContext;
        public LikeRepository(IProductsRepository productsRepository, DataBaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _productsRepository = productsRepository;
        }

        public UserLikeProducts TryGetByUserId(string userId)
        {
            var likeProduct = _databaseContext.UserLikeProducts.Include(x => x.Products).FirstOrDefault(likeProduct => likeProduct.UserId == userId);
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
                _databaseContext.UserLikeProducts.Add(newLikeItem);
            }
            else
            {
                var prod = likeProduct.Products.FirstOrDefault(x => x.Id == productId);
                if (prod == null)
                {
                    likeProduct.Products.Add(product);
                }
            }
            _databaseContext.SaveChanges();
        }
        public void Delete(int productId ,string userId)
        {
            var likeProduct = TryGetByUserId(userId);
            likeProduct.Products.Remove(_productsRepository.GetProduct(productId));
            _databaseContext.SaveChanges();
        }

    }
}
