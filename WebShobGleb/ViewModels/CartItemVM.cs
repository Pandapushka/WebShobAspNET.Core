using Core.Entity;

namespace WebShobGleb.Models
{
    public class CartItemVM
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
        public CartItemVM()
        {
            Id = Guid.NewGuid();
        }

    }
}
