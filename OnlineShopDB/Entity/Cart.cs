using Core.Entity.BaseEntitys;

namespace Core.Entity
{
    public class Cart : BaseEntity
    {
        public string UserId { get; set; }
        public List<CartItem> Items { get; set; }

        public Cart()
        {
            Items = new List<CartItem>();
        }
    }
}
