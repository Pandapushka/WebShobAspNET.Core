using OnlineShopDB.Models;

namespace OnlineShopDB.Repository
{
    public class ProductRepository : IProductsRepository
    {
        private readonly DataBaseContext _databaseContext;
        public ProductRepository(DataBaseContext databaseContext)
        {
           _databaseContext = databaseContext;
        }

        public List<Product> GetAll()
        {
            return _databaseContext.Products.ToList();
        }

        public Product GetProduct(int id)
        {
            return _databaseContext.Products.FirstOrDefault(product => product.Id == id);
        }

        public void Delete(int id)
        {
            var product = GetProduct(id);
            _databaseContext.Products.Remove(product);
            _databaseContext.SaveChanges();
        }
        public void Edit(Product productEdit, int id)
        {
            var product = GetProduct(id);
            if (product != null)
            {
                product.Name = productEdit.Name;
                product.Cost = productEdit.Cost;
                product.Description = productEdit.Description;
            }
            _databaseContext.SaveChanges();
        }
        public void Add(Product newProduct)
        {
            _databaseContext.Products.Add(newProduct);
            _databaseContext.SaveChanges();            
        }
    }
}

