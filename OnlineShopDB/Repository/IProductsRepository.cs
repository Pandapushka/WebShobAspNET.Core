using OnlineShopDB.Models;

namespace OnlineShopDB.Repository
{
    public interface IProductsRepository
    {
        List<Product> GetAll();
        Product GetProduct(int id);
        void Delete(int id);
        void Edit(Product productEdit, int id);
        void Add(Product newProduct);
    }
}
