namespace Core.Repository.BaseRepository
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
