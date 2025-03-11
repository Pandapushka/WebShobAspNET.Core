using WebShobGleb.Models;

namespace WebShobGleb.Servises
{
    public interface IProductService
    {
        List<ProductVM> GetAllProducts();
        ProductVM GetProductById(int id);
        void AddProduct(ProductVM productVM);
        void UpdateProduct(ProductVM productVM, int id);
        void DeleteProduct(int id);
    }
}
