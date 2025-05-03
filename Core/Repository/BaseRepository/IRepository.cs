using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopDB.Repository.BaseRepository
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(object id);
    }
}
