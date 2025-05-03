using Core.Entity;

namespace Core.Repository
{
    public class CategoryRepository : BaseRepository<Сategory> , ICategoryRepository
    {
        public CategoryRepository(DataBaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
}
