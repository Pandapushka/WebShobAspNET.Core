namespace OnlineShopDB.Models
{
    public class UserLikeProducts
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<Product> Products { get; set; }
    }
}
