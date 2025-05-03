using Application.DTOs;

namespace Application.Servises
{
    public interface IProductService
    {
        List<ProductDTO> GetAllProducts();
        ProductDTO GetProductById(Guid id);
        void AddProduct(ProductDTO productVM);
        void UpdateProduct(ProductDTO productVM, Guid id);
        void DeleteProduct(Guid id);
    }
}
