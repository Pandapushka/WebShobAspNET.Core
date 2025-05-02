using WebShobGleb.Models;

namespace WebShobGleb.Servises
{
    public interface IProductService
    {
        List<ProductVM> GetAllProducts();
        ProductVM GetProductById(Guid id);
        void AddProduct(ProductVM productVM);
        void UpdateProduct(ProductVM productVM, Guid id);
        void DeleteProduct(Guid id);
    }
}
