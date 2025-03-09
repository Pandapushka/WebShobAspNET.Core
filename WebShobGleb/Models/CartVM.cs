using WebShobGleb.Const;

namespace WebShobGleb.Models
{
    public class CartVM
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<CartItemVM> Items { get; set; }

        public int Amount
        {
            get
            {
                return Items.Sum(x => x.Amount);
            }
        }

        public decimal Cost
        {
            get
            {
                return Items.Sum(x => x.Cost);
            }
        }
        public CartVM()
        {
            Id = Guid.NewGuid();
            UserId = Constants.UserId;
        }
    }
}
