using Core.Entity;

namespace Core.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductsRepository
    {
        public ProductRepository(DataBaseContext databaseContext)
            : base(databaseContext)
        {
        }

        public void Edit(Product productEdit, Guid id)
        {
            var product = GetById(id);
            if (product != null)
            {
                product.Name = productEdit.Name;
                product.Cost = productEdit.Cost;
                product.Description = productEdit.Description;
                Update(product);
            }
        }
    }
}

