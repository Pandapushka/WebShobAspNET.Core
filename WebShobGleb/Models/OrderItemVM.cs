using OnlineShopDB.Models;

namespace WebShobGleb.Models
{
    public class OrderItemVM
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public decimal Cost
        {
            get
            {
                return Amount * Product.Cost;
            }
        }
        public OrderItemVM()
        {
            Id = Guid.NewGuid();
        }
    }
}
