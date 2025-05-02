using Core.Entity.BaseEntitys;

namespace Core.Entity
{
    public class UserLikeProducts : BaseEntity
    {
        public string UserId { get; set; }
        public List<Product> Products { get; set; }
    }
}
