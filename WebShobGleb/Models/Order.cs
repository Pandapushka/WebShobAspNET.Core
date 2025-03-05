namespace WebShobGleb.Models
{
    public class Order
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Cart Cart { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreateDataTime { get; set; }
        public decimal Cost
        {
            get
            {
                return Cart.Items.Sum(x => x.Cost);
            }
        }
        public Order()
        {
            Id = Guid.NewGuid();
            Status = OrderStatus.Created;
            CreateDataTime = DateTime.Now;
        }

    }
}
