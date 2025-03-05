using WebShobGleb.Const;

namespace WebShobGleb.Models
{
    public class Cart
    {
        public Guid Id { get; }
        public string UserId { get; set; }
        public List<CartItem> Items { get; set; }

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
        public Cart()
        {
            Id = Guid.NewGuid();
            UserId = Constants.UserId;
        }
    }
}
