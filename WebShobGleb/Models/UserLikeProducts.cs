using OnlineShopDB.Models;

namespace WebShobGleb.Models
{
    public class UserLikeProducts
    {
        public Guid Id { get; }
        public string UserId { get; set; }
        public List<Product> Products { get; set; }
    }
}
