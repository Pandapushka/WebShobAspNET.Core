using Core.Entity;

namespace Application.DTOs
{
    public class OrderItemDTO
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
        public OrderItemDTO()
        {
            Id = Guid.NewGuid();
        }
    }
}
