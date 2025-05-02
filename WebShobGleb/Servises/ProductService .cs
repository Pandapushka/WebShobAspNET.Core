using OnlineShopDB.Repository;
using WebShobGleb.Mappers;
using WebShobGleb.Models;

namespace WebShobGleb.Servises
{
    public class ProductService : IProductService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public List<ProductVM> GetAllProducts()
        {
            var products = _productsRepository.GetAll();
            return ProductMapper.MapToProductVMList(products);
        }

        public ProductVM GetProductById(Guid id)
        {
            var product = _productsRepository.GetById(id);
            return ProductMapper.MapToProductVM(product);
        }

        public void AddProduct(ProductVM productVM)
        {
            var product = ProductMapper.MapToProduct(productVM);
            _productsRepository.Add(product);
        }

        public void UpdateProduct(ProductVM productVM, Guid id)
        {
            var product = ProductMapper.MapToProduct(productVM);
            _productsRepository.Edit(product, id);
        }

        public void DeleteProduct(Guid id)
        {
            _productsRepository.Delete(id);
        }
    }
}
