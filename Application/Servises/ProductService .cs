using Application.DTOs;
using Application.Mappers;
using Core.Repository;

namespace Application.Servises
{
    public class ProductService : IProductService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public List<ProductDTO> GetAllProducts()
        {
            var products = _productsRepository.GetAll();
            return ProductMapperDTO.MapToProductVMList(products);
        }

        public ProductDTO GetProductById(Guid id)
        {
            var product = _productsRepository.GetById(id);
            return ProductMapperDTO.MapToProductDTO(product);
        }

        public void AddProduct(ProductDTO productVM)
        {
            var product = ProductMapperDTO.MapToProduct(productVM);
            _productsRepository.Add(product);
        }

        public void UpdateProduct(ProductDTO productVM, Guid id)
        {
            var product = ProductMapperDTO.MapToProduct(productVM);
            _productsRepository.Edit(product, id);
        }

        public void DeleteProduct(Guid id)
        {
            _productsRepository.Delete(id);
        }
    }
}
