using Core.Entity;
using OnlineShopDB.Repository.BaseRepository;
using System.Collections.Generic;

namespace OnlineShopDB.Repository
{
    public interface IProductsRepository : IRepository<Product>
    {
        void Edit(Product productEdit, Guid id);
    }
}