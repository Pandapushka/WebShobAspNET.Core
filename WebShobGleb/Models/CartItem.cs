using OnlineShopDB.Models;

namespace WebShobGleb.Models
{
    public class CartItem
    {
        public Guid Id { get; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public decimal Cost
        {
            get
            {
                return Amount * Product.Cost;
            }
        }
        public CartItem()
        {
            Id = Guid.NewGuid();
        }

    }
}
