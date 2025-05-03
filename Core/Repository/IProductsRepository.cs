using Core.Entity;
using Core.Repository.BaseRepository;
using System.Collections.Generic;

namespace Core.Repository
{
    public interface IProductsRepository : IRepository<Product>
    {
        void Edit(Product productEdit, Guid id);
    }
}