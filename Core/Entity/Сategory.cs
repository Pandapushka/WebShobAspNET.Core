using Core.Entity.BaseEntitys;

namespace Core.Entity
{
    public class Сategory : BaseEntity
    {
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
