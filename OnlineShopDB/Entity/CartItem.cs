

using Core.Entity.BaseEntitys;

namespace Core.Entity
{
    public class CartItem : BaseEntity
    {
        public Product Product { get; set; }
        public Cart Cart { get; set; }
        public int Amount { get; set; }
        public CartItem()
        {

        }

    }
}
